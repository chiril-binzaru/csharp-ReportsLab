-- ============================================================
-- Script 2: Create Database, Tables, User, and Seed Data
-- Run this AFTER 01_create_login.sql
-- Run as: sa or any sysadmin account in SSMS
-- ============================================================

USE master;
GO

-- ── 1. Database ──────────────────────────────────────────────
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'StoreDB')
BEGIN
    CREATE DATABASE StoreDB;
    PRINT 'Database StoreDB created.';
END
ELSE
    PRINT 'Database StoreDB already exists – skipped.';
GO

USE StoreDB;
GO

-- ── 2. Database User ─────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'ReportsLabUser')
BEGIN
    CREATE USER ReportsLabUser FOR LOGIN ReportsLabUser;
    ALTER ROLE db_owner ADD MEMBER ReportsLabUser;
    PRINT 'User ReportsLabUser created and added to db_owner.';
END
ELSE
    PRINT 'User ReportsLabUser already exists – skipped.';
GO

-- ── 3. Products Table ────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Products')
BEGIN
    CREATE TABLE Products
    (
        ProductId   INT           IDENTITY(1,1) PRIMARY KEY,
        ProductName NVARCHAR(100) NOT NULL,
        Category    NVARCHAR(50)  NOT NULL,
        Price       DECIMAL(10,2) NOT NULL,
        Stock       INT           NOT NULL DEFAULT 0
    );
    PRINT 'Table Products created.';
END
ELSE
    PRINT 'Table Products already exists – skipped.';
GO

-- ── 4. Sales Table ───────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Sales')
BEGIN
    CREATE TABLE Sales
    (
        SaleId    INT           IDENTITY(1,1) PRIMARY KEY,
        ProductId INT           NOT NULL REFERENCES Products(ProductId),
        SaleDate  DATE          NOT NULL DEFAULT GETDATE(),
        Quantity  INT           NOT NULL,
        SalePrice DECIMAL(10,2) NOT NULL
    );
    PRINT 'Table Sales created.';
END
ELSE
    PRINT 'Table Sales already exists – skipped.';
GO

-- ── 5. Seed: Products ────────────────────────────────────────
IF NOT EXISTS (SELECT TOP 1 1 FROM Products)
BEGIN
    INSERT INTO Products (ProductName, Category, Price, Stock) VALUES
        ('Laptop Pro 15',       'Electronics', 1299.99, 15),
        ('Wireless Mouse',      'Electronics',   29.99, 80),
        ('Mechanical Keyboard', 'Electronics',   89.99, 45),
        ('USB-C Hub',           'Electronics',   49.99, 60),
        ('Notebook A5',         'Stationery',     4.99, 200),
        ('Ballpoint Pen Pack',  'Stationery',     3.49, 300),
        ('Desk Lamp',           'Furniture',     39.99, 25),
        ('Office Chair',        'Furniture',    199.99, 10),
        ('Monitor 24"',         'Electronics',  249.99, 20),
        ('Webcam HD',           'Electronics',   79.99, 35);
    PRINT 'Products seeded.';
END
ELSE
    PRINT 'Products already contain data – seed skipped.';
GO

-- ── 6. Seed: Sales ───────────────────────────────────────────
IF NOT EXISTS (SELECT TOP 1 1 FROM Sales)
BEGIN
    INSERT INTO Sales (ProductId, SaleDate, Quantity, SalePrice) VALUES
        (1,  '2025-01-05',  2, 1299.99),
        (2,  '2025-01-10',  5,   29.99),
        (3,  '2025-01-15',  3,   89.99),
        (9,  '2025-01-20',  1,  249.99),
        (1,  '2025-02-03',  1, 1299.99),
        (4,  '2025-02-14',  4,   49.99),
        (5,  '2025-02-18', 10,    4.99),
        (6,  '2025-02-22', 15,    3.49),
        (2,  '2025-03-01',  8,   29.99),
        (7,  '2025-03-05',  2,   39.99),
        (8,  '2025-03-12',  1,  199.99),
        (10, '2025-03-20',  3,   79.99),
        (3,  '2025-04-02',  5,   89.99),
        (1,  '2025-04-10',  3, 1299.99),
        (9,  '2025-04-18',  2,  249.99),
        (2,  '2025-05-05', 10,   29.99),
        (5,  '2025-05-12', 20,    4.99),
        (4,  '2025-05-20',  3,   49.99),
        (6,  '2025-06-01', 25,    3.49),
        (10, '2025-06-15',  4,   79.99);
    PRINT 'Sales seeded.';
END
ELSE
    PRINT 'Sales already contain data – seed skipped.';
GO

PRINT 'Setup complete. Connection string:';
PRINT 'Server=localhost;Database=StoreDB;User Id=ReportsLabUser;Password=ReportsLab123!;TrustServerCertificate=True;';
GO
