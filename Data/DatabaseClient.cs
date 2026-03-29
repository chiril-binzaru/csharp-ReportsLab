using Microsoft.Data.SqlClient;
using System.Data;

namespace ReportsLab.Data
{
    internal static class DatabaseClient
    {
        private const string ConnectionString =
            "Server=localhost\\SQLEXPRESS;Database=StoreDB;User Id=ReportsLabUser;Password=ReportsLab123!;TrustServerCertificate=True;";

        //private const string ConnectionString =
        //    "Server=localhost\\SQLEXPRESS;Database=StoreDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection() => new(ConnectionString);

        /// <summary>Executes a SELECT query and returns results as a DataTable.</summary>
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
            conn.Open();
            var dt = new DataTable();
            new SqlDataAdapter(cmd).Fill(dt);
            return dt;
        }

        /// <summary>Executes an INSERT / UPDATE / DELETE statement.</summary>
        public static void ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // ── Products ─────────────────────────────────────────────────────────────

        public const string GetAllProducts =
            "SELECT ProductId, ProductName, Category, Price, Stock " +
            "FROM Products ORDER BY ProductName";

        public const string GetProductsForCombo =
            "SELECT ProductId, ProductName, Price FROM Products ORDER BY ProductName";

        public const string GetProductsForReport =
            "SELECT ProductName, Category, Price, Stock FROM Products ORDER BY ProductName";

        public const string GetCategories =
            "SELECT DISTINCT Category FROM Products ORDER BY Category";

        public const string GetProductsByCategory =
            "SELECT ProductName, Category, Price, Stock FROM Products " +
            "WHERE Category = @Category ORDER BY ProductName";

        public const string GetProductsInStock =
            "SELECT ProductName, Category, Price, Stock FROM Products " +
            "WHERE Stock > 0 ORDER BY ProductName";

        public const string GetProductsOutOfStock =
            "SELECT ProductName, Category, Price, Stock FROM Products " +
            "WHERE Stock = 0 ORDER BY ProductName";

        public const string InsertProduct =
            "INSERT INTO Products (ProductName, Category, Price, Stock) " +
            "VALUES (@ProductName, @Category, @Price, @Stock)";

        public const string UpdateProduct =
            "UPDATE Products SET ProductName=@ProductName, Category=@Category, " +
            "Price=@Price, Stock=@Stock WHERE ProductId=@ProductId";

        public const string DeleteProduct =
            "DELETE FROM Products WHERE ProductId=@ProductId";

        // ── Sales ────────────────────────────────────────────────────────────────

        public const string GetAllSales =
            "SELECT s.SaleId, p.ProductName, s.SaleDate, s.Quantity, s.SalePrice, " +
            "       CAST(s.Quantity * s.SalePrice AS DECIMAL(10,2)) AS TotalAmount " +
            "FROM Sales s JOIN Products p ON s.ProductId = p.ProductId " +
            "ORDER BY s.SaleDate DESC";

        public const string GetSalesByPeriod =
            "SELECT s.SaleDate, p.ProductName, s.Quantity, s.SalePrice, " +
            "       CAST(s.Quantity * s.SalePrice AS DECIMAL(10,2)) AS TotalAmount " +
            "FROM Sales s JOIN Products p ON s.ProductId = p.ProductId " +
            "WHERE s.SaleDate BETWEEN @StartDate AND @EndDate " +
            "ORDER BY s.SaleDate";

        public const string GetSalesByProduct =
            "SELECT s.SaleDate, s.Quantity, s.SalePrice, " +
            "       CAST(s.Quantity * s.SalePrice AS DECIMAL(10,2)) AS TotalAmount " +
            "FROM Sales s WHERE s.ProductId = @ProductId ORDER BY s.SaleDate";

        public const string GetSalesByCategoryAndPeriod =
            "SELECT s.SaleDate, p.ProductName, s.Quantity, s.SalePrice, " +
            "       CAST(s.Quantity * s.SalePrice AS DECIMAL(10,2)) AS TotalAmount " +
            "FROM Sales s JOIN Products p ON s.ProductId = p.ProductId " +
            "WHERE p.Category = @Category AND s.SaleDate BETWEEN @StartDate AND @EndDate " +
            "ORDER BY s.SaleDate";

        public const string GetDashboardSummary =
            "SELECT COUNT(DISTINCT s.SaleId) AS TotalOrders, " +
            "       ISNULL(SUM(s.Quantity), 0) AS TotalItemsSold, " +
            "       ISNULL(CAST(SUM(s.Quantity * s.SalePrice) AS DECIMAL(10,2)), 0) AS TotalRevenue " +
            "FROM Sales s";

        public const string GetDashboardTopProducts =
            "SELECT TOP 5 p.ProductName, " +
            "       SUM(s.Quantity) AS TotalQty, " +
            "       CAST(SUM(s.Quantity * s.SalePrice) AS DECIMAL(10,2)) AS TotalRevenue " +
            "FROM Sales s JOIN Products p ON s.ProductId = p.ProductId " +
            "GROUP BY p.ProductId, p.ProductName " +
            "ORDER BY TotalRevenue DESC";

        public const string GetDashboardByCategory =
            "SELECT p.Category, " +
            "       COUNT(DISTINCT s.SaleId) AS TotalOrders, " +
            "       CAST(SUM(s.Quantity * s.SalePrice) AS DECIMAL(10,2)) AS TotalRevenue " +
            "FROM Sales s JOIN Products p ON s.ProductId = p.ProductId " +
            "GROUP BY p.Category " +
            "ORDER BY TotalRevenue DESC";

        public const string GetDashboardLowStock =
            "SELECT ProductName, Category, Stock " +
            "FROM Products WHERE Stock <= 5 " +
            "ORDER BY Stock, ProductName";

        public const string GetTopProducts =
            "SELECT p.ProductName, p.Category, SUM(s.Quantity) AS TotalQuantity " +
            "FROM Sales s JOIN Products p ON s.ProductId = p.ProductId " +
            "GROUP BY p.ProductId, p.ProductName, p.Category " +
            "ORDER BY TotalQuantity DESC";

        /// <summary>Returns ProductId and Quantity for a single sale (needed for stock rollback).</summary>
        public const string GetSaleById =
            "SELECT ProductId, Quantity FROM Sales WHERE SaleId=@SaleId";

        public const string InsertSale =
            "INSERT INTO Sales (ProductId, SaleDate, Quantity, SalePrice) " +
            "VALUES (@ProductId, @SaleDate, @Quantity, @SalePrice)";

        public const string UpdateSale =
            "UPDATE Sales SET SaleDate=@SaleDate, Quantity=@Quantity, SalePrice=@SalePrice " +
            "WHERE SaleId=@SaleId";

        /// <summary>Adjusts stock when a sale's quantity changes: restores old qty, deducts new qty.</summary>
        public const string AdjustStockForEdit =
            "UPDATE Products SET Stock = Stock + @OldQuantity - @NewQuantity WHERE ProductId=@ProductId";

        public const string UpdateStock =
            "UPDATE Products SET Stock = Stock - @Quantity WHERE ProductId=@ProductId";

        /// <summary>Restores stock when a sale is deleted.</summary>
        public const string RestoreStock =
            "UPDATE Products SET Stock = Stock + @Quantity WHERE ProductId=@ProductId";

        public const string DeleteSale =
            "DELETE FROM Sales WHERE SaleId=@SaleId";
    }
}
