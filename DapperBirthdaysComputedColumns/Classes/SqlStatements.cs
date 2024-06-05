namespace DapperBirthdaysComputedColumns.Classes;
internal class SqlStatements
{
    /// <summary>
    /// Get all records, and yes this can be a stored procedure 😍
    /// </summary>
    public static string GetBirthdays =>
        """
        SELECT Id
            ,FirstName
            ,LastName
            ,BirthDate
            ,YearsOld
        FROM dbo.BirthDays
        """;
}
