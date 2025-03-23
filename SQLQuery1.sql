CREATE DATABASE DemoDB;
USE DemoDB;
CREATE TABLE SalesData.Customer (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    CompanyName NVARCHAR(100) NULL
);
CREATE TABLE SalesData.Employee (
    BusinessEntityID INT IDENTITY(1,1) PRIMARY KEY,
    LoginID NVARCHAR(50) NOT NULL,
    JobTitle NVARCHAR(100) NOT NULL,
    BirthDate DATE NOT NULL
);

CREATE TABLE SalesData.Person (
    BusinessEntityID INT PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50) NULL,
    LastName NVARCHAR(50) NOT NULL
);
CREATE TABLE SalesData.Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Color NVARCHAR(15) NULL,
    StandardCost MONEY NOT NULL,
    ListPrice MONEY NOT NULL,
    Size NVARCHAR(5) NULL,
    Weight DECIMAL(8,2) NULL
);
CREATE TABLE SalesData.ProductCostHistory (
    ProductID INT,
    Cost MONEY NOT NULL,
    ModifiedDate DATE NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES SalesData.Product(ProductID)
);
CREATE TABLE SalesData.SalesOrderHeader (
    SalesOrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE NOT NULL,
    ShipDate DATE NULL,
    SubTotal MONEY NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES SalesData.Customer(CustomerID)
);
CREATE TABLE SalesData.SalesOrderDetail (
    SalesOrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    SalesOrderID INT,
    ProductID INT,
    OrderQty INT NOT NULL,
    LineTotal MONEY NOT NULL,
    FOREIGN KEY (SalesOrderID) REFERENCES SalesData.SalesOrderHeader(SalesOrderID),
    FOREIGN KEY (ProductID) REFERENCES SalesData.Product(ProductID)
);
INSERT INTO SalesData.Customer (FirstName, LastName, CompanyName)
VALUES 
('John', 'Doe', 'TechCorp'),
('Alice', 'Smith', 'HealthPlus'),
('Bob', 'Johnson', 'EduWorld'),
('Emily', 'Clark', 'Foodie Inc.'),
('Michael', 'Brown', 'AutoParts');
INSERT INTO SalesData.Employee (LoginID, JobTitle, BirthDate)
VALUES 
('john.doe@company.com', 'Research and Development Engineer', '1985-05-12'),
('alice.smith@company.com', 'Software Engineer', '1990-07-23'),
('bob.johnson@company.com', 'Research and Development Engineer', '1982-02-14');
INSERT INTO SalesData.Person (BusinessEntityID, FirstName, MiddleName, LastName)
VALUES 
(1, 'John', 'A', 'Doe'),
(2, 'Alice', NULL, 'Smith'),
(3, 'Bob', 'B', 'Johnson');
INSERT INTO SalesData.Product (Name, Color, StandardCost, ListPrice, Size, Weight)
VALUES 
('Laptop', 'Silver', 500.00, 800.00, '15', 2.5),
('Monitor', 'Black', 120.00, 200.00, '24', 3.0),
('Keyboard', NULL, 20.00, 50.00, NULL, 0.5),
('Mouse', 'Red', 10.00, 25.00, NULL, 0.2),
('Chair', 'Blue', 75.00, 150.00, NULL, NULL);
INSERT INTO SalesData.ProductCostHistory (ProductID, Cost, ModifiedDate)
VALUES 
(1, 480.00, '2003-06-17'),
(2, 100.00, '2022-01-15'),
(3, 18.00, '2021-12-05');
INSERT INTO SalesData.SalesOrderHeader (CustomerID, OrderDate, ShipDate, SubTotal)
VALUES 
(1, '2024-03-15', '2024-03-20', 1000.00),
(2, '2024-03-16', '2024-03-21', 200.00),
(3, '2024-03-17', NULL, 500.00);
INSERT INTO SalesData.SalesOrderDetail (SalesOrderID, ProductID, OrderQty, LineTotal)
VALUES 
(1, 1, 2, 1600.00),
(1, 2, 1, 200.00),
(2, 3, 5, 250.00),
(3, 4, 10, 250.00);

SELECT * FROM SalesData.Customer;
SELECT * FROM SalesData.Employee;
SELECT * FROM SalesData.Person;
SELECT * FROM SalesData.Product;
SELECT * FROM SalesData.ProductCostHistory;
SELECT * FROM SalesData.SalesOrderHeader;
SELECT * FROM SalesData.SalesOrderDetail;
SELECT name FROM sys.databases WHERE database_id >= 5;
SELECT name FROM sys.databases;
-- List Customers with ID, Last Name, First Name, and Company
SELECT CustomerID, FirstName, LastName, CompanyName FROM SalesData.Customer;
-- Employees with Job Title "Research and Development Engineer"
SELECT BusinessEntityID, LoginID, JobTitle 
FROM SalesData.Employee 
WHERE JobTitle = 'Research and Development Engineer';
--Get ProductCostHistory Modified on June 17, 2003
SELECT * FROM SalesData.ProductCostHistory WHERE ModifiedDate = '2003-06-17';
--Employees Who Are NOT "Research and Development Engineer"
SELECT BusinessEntityID, LoginID, JobTitle FROM SalesData.Employee WHERE JobTitle <> 'Research and Development Engineer';
--Join Employee Table with Person Table
SELECT e.JobTitle, e.BirthDate, p.FirstName, p.LastName FROM SalesData.Employee e JOIN SalesData.Person p ON e.BusinessEntityID = p.BusinessEntityID;
-- Join Customer Table with Person Table
SELECT c.CustomerID, c.CompanyName, p.FirstName, p.LastName
FROM SalesData.Customer c
JOIN SalesData.Person p 
ON c.CustomerID = p.BusinessEntityID;
--Extend Customer Query with Sales Orders
SELECT c.CustomerID, c.FirstName, c.LastName, c.CompanyName, s.SalesOrderID
FROM SalesData.Customer c
JOIN SalesData.SalesOrderHeader s 
ON c.CustomerID = s.CustomerID;
--Display Products with Sales Orders (Even If Not Ordered)
SELECT p.ProductID, p.Name, s.SalesOrderID
FROM SalesData.Product p
LEFT JOIN SalesData.SalesOrderDetail s 
ON p.ProductID = s.ProductID;
--Get Middle Name Containing 'E' or 'B'
SELECT BusinessEntityID, FirstName, MiddleName, LastName
FROM SalesData.Person
WHERE MiddleName LIKE 'E%' OR MiddleName LIKE 'B%';
--Update NULL AddressLine2 to "N/A"
UPDATE SalesData.Customer 
SET CompanyName = 'N/A' 
WHERE CompanyName IS NULL;
--Update UnitPrice from ListPrice
DELETE FROM SalesData.Customer 
WHERE LastName LIKE 'S%';


--Update UnitPrice from ListPrice
UPDATE s
SET s.LineTotal = p.ListPrice * s.OrderQty
FROM SalesData.SalesOrderDetail s
JOIN SalesData.Product p 
ON s.ProductID = p.ProductID;

SELECT * INTO SalesData.Customer_Backup FROM SalesData.Customer;


--Join Employee & Person Table
SELECT e.JobTitle, e.BirthDate, p.FirstName, p.LastName
FROM SalesData.Employee e
JOIN SalesData.Person p 
ON e.BusinessEntityID = p.BusinessEntityID;

--Join Customer & Person 
SELECT c.CustomerID, c.CompanyName, p.FirstName, p.LastName
FROM SalesData.Customer c
JOIN SalesData.Person p 
ON c.CustomerID = p.BusinessEntityID;

--Extend Query 2 to Include Sales Order
SELECT c.CustomerID, c.FirstName, c.LastName, c.CompanyName, s.SalesOrderID
FROM SalesData.Customer c
LEFT JOIN SalesData.SalesOrderHeader s 
ON c.CustomerID = s.CustomerID;

--Products with or without Orders
SELECT p.ProductID, p.Name, s.SalesOrderID
FROM SalesData.Product p
LEFT JOIN SalesData.SalesOrderDetail s 
ON p.ProductID = s.ProductID;

--Create demoProduct Table
CREATE TABLE SalesData.demoProduct (
    ProductID INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Color NVARCHAR(15) NULL,
    StandardCost MONEY NOT NULL,
    ListPrice MONEY NOT NULL,
    Size NVARCHAR(5) NULL,
    Weight DECIMAL(8,2) NULL
);


--Insert into demoProduct
INSERT INTO SalesData.demoProduct (ProductID, Name, Color, StandardCost, ListPrice, Size, Weight)
VALUES 
(1, 'Tablet', 'Black', 200.00, 350.00, '10', 1.5),
(2, 'Headphone', 'Red', 50.00, 100.00, NULL, 0.3),
(3, 'Smartwatch', 'Blue', 80.00, 150.00, NULL, 0.5),
(4, 'Speakers', 'White', 120.00, 220.00, NULL, 2.0),
(5, 'Router', 'Gray', 75.00, 130.00, NULL, 1.0);

--Replace NULL Color with "No Color"
SELECT ProductID, Name, ISNULL(Color, 'No Color') AS Color
FROM SalesData.Product;


--Days Between Order & Ship Date
SELECT SalesOrderID, OrderDate, ShipDate, 
       DATEDIFF(DAY, OrderDate, ShipDate) AS DaysToShip
FROM SalesData.SalesOrderHeader;

--Extract Year & Month from Order Date
SELECT SalesOrderID, OrderDate, 
       YEAR(OrderDate) AS OrderYear, 
       MONTH(OrderDate) AS OrderMonth
FROM SalesData.SalesOrderHeader;

--Round SubTotal to 2 Decimal Places
SELECT SalesOrderID, ROUND(SubTotal, 2) AS RoundedTotal
FROM SalesData.SalesOrderHeader;

--Generate Random Number (1-10)
SELECT FLOOR(RAND() * 10) + 1 AS RandomNumber;
--Total Items Ordered Per Product
SELECT ProductID, SUM(OrderQty) AS TotalItemsOrdered
FROM SalesData.SalesOrderDetail
GROUP BY ProductID;

--Count of Products in Each Product Line
SELECT Color, COUNT(ProductID) AS ProductCount
FROM SalesData.Product
GROUP BY Color;


--Sum LineTotal Grouped by Order
SELECT SalesOrderID, SUM(LineTotal) AS TotalLineCost
FROM SalesData.SalesOrderDetail
GROUP BY SalesOrderID
HAVING SUM(LineTotal) > 1000;

--Customers with at Least 5 Orders
SELECT CustomerID, SalesOrderID, OrderDate
FROM SalesData.SalesOrderHeader
WHERE CustomerID IN (
    SELECT CustomerID FROM SalesData.SalesOrderHeader 
    GROUP BY CustomerID 
    HAVING COUNT(SalesOrderID) >= 5
);

-- Products that Have Been Ordered
SELECT ProductID, Name
FROM SalesData.Product
WHERE ProductID IN (
    SELECT DISTINCT ProductID FROM SalesData.SalesOrderDetail
);

--Products Not Ordered
SELECT ProductID, Name
FROM SalesData.Product
WHERE ProductID NOT IN (
    SELECT DISTINCT ProductID FROM SalesData.SalesOrderDetail
);










