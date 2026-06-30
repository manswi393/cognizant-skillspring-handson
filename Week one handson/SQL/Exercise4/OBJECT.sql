IF OBJECT_ID('Sales', 'U') IS NOT NULL
    DROP TABLE Sales;
	CREATE TABLE Sales (
    ProductName VARCHAR(50),
    SaleMonth VARCHAR(10),
    Quantity INT
);
INSERT INTO Sales VALUES
('Laptop', 'Jan', 10),
('Laptop', 'Feb', 15),
('Laptop', 'Mar', 20),
('Mouse', 'Jan', 5),
('Mouse', 'Feb', 8),
('Mouse', 'Mar', 12);
SELECT * FROM Sales;
SELECT 
    ProductName,
    ISNULL([Jan],0) AS Jan,
    ISNULL([Feb],0) AS Feb,
    ISNULL([Mar],0) AS Mar
FROM
(
    SELECT ProductName, SaleMonth, Quantity
    FROM Sales
) AS src
PIVOT
(
    SUM(Quantity)
    FOR SaleMonth IN ([Jan], [Feb], [Mar])
) AS pvt;
SELECT SaleMonth, COUNT(*) 
FROM Sales
GROUP BY SaleMonth;