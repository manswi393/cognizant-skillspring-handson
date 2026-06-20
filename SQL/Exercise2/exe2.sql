CREATE DATABASE Practicedb;
USE Practicedb;
CREATE TABLE Customer1 (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Region VARCHAR(50)
);
CREATE TABLE Product1 (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50)
);
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
INSERT INTO Customers VALUES
(9, 'Manswi', 'North'),
(88, 'Savani', 'South'),
(73, 'Yaman', 'North'),
(48, 'Riya', 'West');
INSERT INTO Products VALUES
(101, 'Laptop', 'Electronics'),
(102, 'Phone', 'Electronics'),
(103, 'Shirt', 'Clothing'),
(104, 'Jeans', 'Clothing');
INSERT INTO Orders VALUES
(1001, 1),
(1002, 2),
(1003, 3),
(1004, 4);
INSERT INTO OrderDetails VALUES
(1, 1001, 101, 5),
(2, 1001, 103, 10),
(3, 1002, 102, 8),
(4, 1002, 104, 6),
(5, 1003, 101, 7),
(6, 1003, 103, 4),
(7, 1004, 102, 9),
(8, 1004, 104, 3);
SELECT c.Region, NULL AS Category, SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY c.Region

UNION ALL

SELECT NULL AS Region, p.Category, SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.Category

UNION ALL

SELECT c.Region, p.Category, SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY c.Region, p.Category;
SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY c.Region, p.Category WITH ROLLUP;
SELECT VERSION();