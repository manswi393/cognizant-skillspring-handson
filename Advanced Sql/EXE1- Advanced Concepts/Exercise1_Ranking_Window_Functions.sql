CREATE TABLE ProductDetail (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50),
    Category VARCHAR(30),
    Price DECIMAL(10,2)
);

INSERT INTO ProductDetail (ProductID, ProductName, Category, Price) VALUES
(101, 'Laptop Pro', 'Electronics', 90000),
(102, 'Gaming Laptop', 'Electronics', 85000),
(103, 'Tablet', 'Electronics', 85000),
(104, 'Smartphone', 'Electronics', 60000),
(105, 'Smart Watch', 'Electronics', 30000),
(201, 'Office Chair', 'Furniture', 20000),
(202, 'Sofa', 'Furniture', 45000),
(203, 'Dining Table', 'Furniture', 45000),
(204, 'Bed', 'Furniture', 40000),
(205, 'Bookshelf', 'Furniture', 15000);


SELECT * FROM ProductDetail; 

-- 1. ROW_NUMBER()

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RowNumber
    FROM ProductDetail
) AS RankedProducts
WHERE RowNumber <= 3;

-- 2. RANK()

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        RANK() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RankNumber
    FROM ProductDetail
) AS RankedProducts
WHERE RankNumber <= 3;

-- 3. DENSE_RANK()

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        DENSE_RANK() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS DenseRankNumber
    FROM ProductDetail
) AS RankedProducts
WHERE DenseRankNumber <= 3;