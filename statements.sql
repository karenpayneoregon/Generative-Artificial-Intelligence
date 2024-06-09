-- create a sql-server table for catagories and products

-- Create Categories table
CREATE TABLE dbo.Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL
);

-- Create Products table
CREATE TABLE dbo.Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50) NOT NULL,
    CategoryID INT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);



WITH CTE
AS (SELECT t2.id,
           t2.TransDate AS [Date],
           t2.Credit,
           t2.Debit,
           SUM(COALESCE(t1.credit, 0) - COALESCE(t1.debit, 0)) AS Balance
    FROM dbo.Transactions t1
        INNER JOIN dbo.Transactions t2
            ON t1.TransDate <= t2.TransDate
    GROUP BY t2.TransDate,
             t2.Credit,
             t2.Debit,
             t2.id)
SELECT id, [Date], Credit, Debit
FROM CTE
ORDER BY CTE.[Date];
