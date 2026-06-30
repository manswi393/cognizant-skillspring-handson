CREATE DATABASE Exercise1;
USE Exercise1;
CREATE TABLE Products(
ProductID INT NOT NULL,
ProductName VARCHAR(100) NOT NULL,
Price FLOAT);
INSERT INTO Products
VALUES
('01','Television','50000'),
('02','FRIDGE','60000'),
('08', 'HEATER', '25000'),
('11', 'SMART PHONE',30000),
('22', 'laptop','80000');
SELECT * FROM Products;
-- using ROW_NUMBER()
SELECT
ProductID,
productName,
Price,
ROW_NUMBER()OVER(
PARTITION BY Price
ORDER BY Price DESC
)AS Row_Num
FROM Products;
-- using RANK
SELECT
ProductID,
ProductName,
Price,
RANK() OVER(
     PARTITION BY Price
     ORDER BY Price DESC
     ) AS Rank_No
FROM Products;
-- Using DENSE_RANK()
SELECT
    ProductID,
	productName,
    Price,
    DENSE_RANK() OVER (
        PARTITION BY Price
        ORDER BY Price DESC
    ) AS Dense_Rank_No
FROM Products;





