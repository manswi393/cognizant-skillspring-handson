SELECT 'Hello World' AS Test;
WITH CalendarCTE AS
(
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate

    UNION ALL

    SELECT DATEADD(DAY, 1, CalendarDate)
    FROM CalendarCTE
    WHERE CalendarDate < '2025-01-31'
)
SELECT * FROM CalendarCTE
OPTION (MAXRECURSION 31);
CREATE TABLE Productsiniy
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50),
    Price DECIMAL(10,2)
);
INSERT INTO Products
VALUES
(1, 'Laptop', 50000),
(2, 'Mouse', 500),
(3, 'Keyboard', 1000);
SELECT * FROM Products;
CREATE TABLE StagingProducts
(
    ProductID INT,
    ProductName VARCHAR(50),
    Price DECIMAL(10,2)
);
INSERT INTO StagingProducts
VALUES
(1, 'Laptop', 52000),
(2, 'Mouse', 600),
(4, 'Monitor', 12000);
SELECT * FROM StagingProducts;
MERGE Products AS Target
USING StagingProducts AS Source
ON Target.ProductID = Source.ProductID

WHEN MATCHED THEN
    UPDATE SET
        Target.ProductName = Source.ProductName,
        Target.Price = Source.Price

WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductID, ProductName, Price)
    VALUES (Source.ProductID, Source.ProductName, Source.Price);
	SELECT * FROM Products;
	SELECT * FROM StagingProducts;