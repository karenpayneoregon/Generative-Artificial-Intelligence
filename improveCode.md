# Ask Copilot to refactor your code

To start off, general refactoring can be changing a method with a statement body to an expression body member using Visual Studio ReSharper extension.

## Using statement body

```csharp
public string[] Items()
{
    return new[] { ApplicationName, ApplicationVersion, ApplicationKey };
}
```

## Refactor to expression body

```csharp
public string[] Items() => new[] { ApplicationName, ApplicationVersion, ApplicationKey };
```

## Improve/refactor code with Copilot

Given the following method used for decades to return a list of primary keys from a database table a developer learns about [Dapper](https://github.com/DapperLib/Dapper) and wants to rewrite this code using Dapper.

```csharp
public List<int> CategoryIdentifiers()
{
    var idList = new List<int>();
    var selectStatement = "SELECT DISTINCT CategoryID FROM dbo.Categories ";

    using (var cn = new SqlConnection() { ConnectionString = ConnectionString })
    {
        using (var cmd = new SqlCommand() { Connection = cn })
        {
            cmd.CommandText = selectStatement;
            cn.Open();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                idList.Add(reader.GetInt32(0));
            }

        }
    }

    return idList;
}
```

1. Select the above method
1. Press <kbd>ALT</kbd>  + <kbd>/</kbd>
1. Enter `Refactor this method to use Dapper.`
1. <kbd>ENTER</kbd>

The following is produced.

```csharp
public List<int> CategoryIdentifiers()
{
	var idList = new List<int>();
	var selectStatement = "SELECT DISTINCT CategoryID FROM dbo.Categories";

	using (var cn = new SqlConnection() { ConnectionString = ConnectionString })
	{
		cn.Open();
		idList = cn.Query<int>(selectStatement).AsList();
	}

	return idList;
}
```

Copilot did a great job on refactoring and works for inexperienced developers but an experienced developer can farther modify the code.

Here the experienced developer understands that Dapper will open the connection for us and the SQL statement does not really need to be formatted but imagine a large complex SQL statement with many joins, this would make a difference.

```csharp
public List<int> CategoryIdentifiers()
{
    using SqlConnection cn = new() { ConnectionString = ConnectionString };
    return cn.Query<int>("""
                         SELECT DISTINCT 
                            CategoryID 
                         FROM 
                            dbo.Categories
                         """).AsList();
}
```

Let's now ask Copilot to make the above code asynchronous.

Copilot produces the following yet appears to change the SQL from a raw string literal to a verbatim string.


```csharp
public async Task<List<int>> CategoryIdentifiersAsync()
{
    await using SqlConnection cn = new() { ConnectionString = ConnectionString };
    return (await cn.QueryAsync<int>(@"
                         SELECT DISTINCT 
                            CategoryID 
                         FROM 
                            dbo.Categories
                         ")).AsList();
}
```

ReSharper will provide a refactor recommendation and the developer accepts the recommendation.

```csharp
public async Task<List<int>> CategoryIdentifiersAsync()
{
    await using SqlConnection cn = new() { ConnectionString = ConnectionString };
    return (await cn.QueryAsync<int>("""
                                    
                                     SELECT DISTINCT 
                                        CategoryID 
                                     FROM 
                                        dbo.Categories
                                     
                                     """)).AsList();
}
```

## Ask Copilot to write a unit test

1. Select the above method
1. Press <kbd>ALT</kbd>  + <kbd>/</kbd>
1. Enter `write a unit test`
1. <kbd>ENTER</kbd>

> **Note**
> We get a standard MS-Test but could specify which test framework to use.

```csharp
[TestClass]
public class DapperOperationsTests
{
    [TestMethod]
    public async Task CategoryIdentifiersAsync_ShouldReturnDistinctCategoryIDs()
    {
        // Arrange
        var dapperOperations = new DapperOperations();

        // Act
        var result = await dapperOperations.CategoryIdentifiersAsync();

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AllItemsAreUnique(result);
    }
}
```

## Ask Copilot to add error handling

add error handling with SeriLog logging to this method

1. Select the above method
1. Press <kbd>ALT</kbd>  + <kbd>/</kbd>
1. Enter `add error handling with SeriLog logging to this method`
1. <kbd>ENTER</kbd>

The results were not what the developer wanted.

```csharp
public async Task<List<int>> CategoryIdentifiersAsync()
{
    try
    {
        await using SqlConnection cn = new() { ConnectionString = ConnectionString };
        return (await cn.QueryAsync<int>(@"
                SELECT DISTINCT 
                    CategoryID 
                FROM 
                    dbo.Categories
            ")).AsList();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred while executing CategoryIdentifiersAsync");
        throw;
    }
}
```

- We are back to a verbatim string, use ReSharper to use a raw string literal.

```csharp
public async Task<List<int>> CategoryIdentifiersAsync()
{
    try
    {
        await using SqlConnection cn = new() { ConnectionString = ConnectionString };
        return (await cn.QueryAsync<int>("""
                                         
                                          SELECT DISTINCT 
                                              CategoryID 
                                          FROM 
                                              dbo.Categories
                                         """)).AsList();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred while executing CategoryIdentifiersAsync");
        throw;
    }
}
```

Let now go on without Copilot and get rid of `throw` and change the return type to a tuple which can be [deconstructed](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct) by the caller.

```csharp
public async Task<(bool, List<int>)> CategoryIdentifiersAsync()
{
    try
    {
        await using SqlConnection cn = new() { ConnectionString = ConnectionString };
        return (true,(await cn.QueryAsync<int>("""
                                         
                                          SELECT DISTINCT 
                                              CategoryID 
                                          FROM 
                                              dbo.Categories
                                         """)).AsList());
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred while executing CategoryIdentifiersAsync");

        return (false, null);
    }
}
```

### Unit test revision

Now that there has been a change to the return type `ask Copilot to write a new unit test`.

```csharp
[TestClass]
public class DapperOperationsTests
{
    [TestMethod]
    public async Task CategoryIdentifiersAsync_ShouldReturnCategoryIDs()
    {
        // Arrange
        DapperOperations dapperOperations = new DapperOperations();

        // Act
        (bool success, List<int> categoryIds) = await dapperOperations.CategoryIdentifiersAsync();

        // Assert
        Assert.IsTrue(success);
        Assert.IsNotNull(categoryIds);
        Assert.IsTrue(categoryIds.Count > 0);
    }
}
```

## Unit test

In each example for unit test only one test was written, a developer should do a mirror image of a good test and have a one or more test for when things break.

