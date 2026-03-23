-- ============================================================
-- Script 2: Create Database, Tables, User, and Seed Data
-- Run this AFTER 01_create_login.sql
-- Run as: sa or any sysadmin account in SSMS
--
-- Re-running this script is safe:
--   * Tables and user are created only if they don't exist.
--   * Seed sections always wipe and re-insert, then reseed
--     the IDENTITY counters so IDs start cleanly from 1.
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
-- Sales must be deleted first because of the FK constraint.
DELETE FROM Sales;
DELETE FROM Products;

-- Reseed both identity columns so IDs restart from 1.
-- RESEED, 0  →  next inserted row gets ID = 1.
DBCC CHECKIDENT ('Sales',    RESEED, 0);
DBCC CHECKIDENT ('Products', RESEED, 0);

INSERT INTO Products (ProductName, Category, Price, Stock) VALUES
    -- Electronics (4)
    ('Laptop Pro 15',        'Electronics',  1299.99,  15),
    ('Wireless Mouse',       'Electronics',    29.99,  80),
    ('Mechanical Keyboard',  'Electronics',    89.99,  45),
    ('Monitor 27"',          'Electronics',   319.99,  20),
    -- Stationery (4)
    ('Notebook A5',          'Stationery',      4.99, 200),
    ('Ballpoint Pen Pack',   'Stationery',      3.49, 300),
    ('Desk Organizer',       'Stationery',     14.99,  60),
    ('Sticky Notes Set',     'Stationery',      6.99, 150),
    -- Furniture (4)
    ('Desk Lamp',            'Furniture',      39.99,  25),
    ('Office Chair',         'Furniture',     199.99,  10),
    ('Bookshelf',            'Furniture',     149.99,   5),  -- low stock
    ('Standing Desk',        'Furniture',     349.99,   3),  -- low stock
    -- Clothing (4)
    ('Cotton T-Shirt',       'Clothing',       19.99,   4),  -- low stock
    ('Denim Jeans',          'Clothing',       49.99,  75),
    ('Winter Jacket',        'Clothing',       89.99,  30),
    ('Sports Sneakers',      'Clothing',       69.99,  55),
    -- Sports (4)
    ('Yoga Mat',             'Sports',         29.99,  40),
    ('Resistance Bands Set', 'Sports',         19.99,  70),
    ('Water Bottle',         'Sports',         12.99, 120),
    ('Fitness Tracker',      'Sports',         79.99,  35);

PRINT 'Products seeded (20 rows, 5 categories × 4).';
GO

-- ── 6. Seed: Sales ───────────────────────────────────────────
-- Products were already wiped above; Sales was wiped too.
INSERT INTO Sales (ProductId, SaleDate, Quantity, SalePrice) VALUES
    -- January 2025
    ( 1, '2025-01-05',  2, 1299.99),   -- Laptop        Electronics
    ( 5, '2025-01-08', 15,    4.99),   -- Notebook       Stationery
    (13, '2025-01-12',  5,   19.99),   -- T-Shirt        Clothing
    (17, '2025-01-18',  3,   29.99),   -- Yoga Mat       Sports
    ( 4, '2025-01-25',  1,  319.99),   -- Monitor        Electronics
    -- February 2025
    ( 6, '2025-02-03', 20,    3.49),   -- Pens           Stationery
    (10, '2025-02-07',  2,  199.99),   -- Office Chair   Furniture
    (14, '2025-02-14',  3,   49.99),   -- Denim Jeans    Clothing
    ( 2, '2025-02-20',  8,   29.99),   -- Mouse          Electronics
    (18, '2025-02-25',  5,   19.99),   -- Resist. Bands  Sports
    -- March 2025
    ( 3, '2025-03-01',  4,   89.99),   -- Keyboard       Electronics
    ( 9, '2025-03-05',  3,   39.99),   -- Desk Lamp      Furniture
    (15, '2025-03-10',  2,   89.99),   -- Winter Jacket  Clothing
    (19, '2025-03-15', 10,   12.99),   -- Water Bottle   Sports
    ( 7, '2025-03-20',  6,   14.99),   -- Desk Organizer Stationery
    -- April 2025
    ( 1, '2025-04-02',  1, 1299.99),   -- Laptop         Electronics
    (11, '2025-04-08',  2,  149.99),   -- Bookshelf      Furniture
    (16, '2025-04-15',  4,   69.99),   -- Sneakers       Clothing
    (20, '2025-04-20',  3,   79.99),   -- Fitness Tracker Sports
    ( 8, '2025-04-25', 12,    6.99),   -- Sticky Notes   Stationery
    -- May 2025
    ( 4, '2025-05-03',  2,  319.99),   -- Monitor        Electronics
    (12, '2025-05-10',  1,  349.99),   -- Standing Desk  Furniture
    (13, '2025-05-17',  8,   19.99),   -- T-Shirt        Clothing
    (18, '2025-05-22',  6,   19.99),   -- Resist. Bands  Sports
    ( 5, '2025-05-28', 25,    4.99),   -- Notebook       Stationery
    -- June 2025
    ( 2, '2025-06-05', 10,   29.99),   -- Mouse          Electronics
    ( 9, '2025-06-12',  2,   39.99),   -- Desk Lamp      Furniture
    (15, '2025-06-18',  3,   89.99),   -- Winter Jacket  Clothing
    (19, '2025-06-25', 15,   12.99),   -- Water Bottle   Sports
    ( 6, '2025-06-30', 30,    3.49);   -- Pens           Stationery

PRINT 'Sales seeded (30 rows across all 5 categories).';
GO

-- ============================================================
-- How to manually reseed an identity at any time:
--
--   DBCC CHECKIDENT ('TableName', RESEED, 0);
--     → resets the seed so the NEXT insert gets ID = 1
--
--   DBCC CHECKIDENT ('TableName', RESEED, 100);
--     → next insert gets ID = 101
--
--   DBCC CHECKIDENT ('TableName');
--     → reports the current identity value without changing it
--
-- If you ever TRUNCATE a table (only possible when no FK
-- references it), the identity resets to the seed
-- automatically — no DBCC call needed.
-- ============================================================

PRINT 'Setup complete. Connection string:';
PRINT 'Server=localhost\SQLEXPRESS;Database=StoreDB;User Id=ReportsLabUser;Password=ReportsLab123!;TrustServerCertificate=True;';
GO
