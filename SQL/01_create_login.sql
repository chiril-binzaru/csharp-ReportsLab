-- ============================================================
-- Script 1: Create SQL Server Login and Database User
-- Run this as: sa or any sysadmin account in SSMS
-- ============================================================

USE master;
GO

-- Create the login (server-level principal)
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'ReportsLabUser')
BEGIN
    CREATE LOGIN ReportsLabUser
        WITH PASSWORD    = 'ReportsLab123!',
             CHECK_POLICY = OFF;   -- turn off complexity policy for lab simplicity
    PRINT 'Login ReportsLabUser created.';
END
ELSE
    PRINT 'Login ReportsLabUser already exists – skipped.';
GO
