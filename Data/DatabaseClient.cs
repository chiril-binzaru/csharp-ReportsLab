using Microsoft.Data.SqlClient;
using System.Data;

namespace ReportsLab.Data
{
    internal static class DatabaseClient
    {
        private const string ConnectionString =
            "Server=localhost\\SQLEXPRESS;Database=StoreDB;User Id=ReportsLabUser;Password=ReportsLab123!;TrustServerCertificate=True;";

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

        // ── SQL Queries ──────────────────────────────────────────────────────────

        public const string GetAllProducts =
            "SELECT ProductName, Category, Price, Stock " +
            "FROM Products ORDER BY ProductName";

        public const string GetProductsForCombo =
            "SELECT ProductId, ProductName, Price FROM Products ORDER BY ProductName";

        public const string GetProductsForReport =
            "SELECT ProductName, Category, Price, Stock FROM Products ORDER BY ProductName";

        public const string GetAllSales =
            "SELECT p.ProductName, s.SaleDate, s.Quantity, s.SalePrice, " +
            "       CAST(s.Quantity * s.SalePrice AS DECIMAL(10,2)) AS TotalAmount " +
            "FROM Sales s JOIN Products p ON s.ProductId = p.ProductId " +
            "ORDER BY s.SaleDate DESC";

        public const string GetSalesByPeriod =
            "SELECT s.SaleDate, p.ProductName, s.Quantity, s.SalePrice, " +
            "       CAST(s.Quantity * s.SalePrice AS DECIMAL(10,2)) AS TotalAmount " +
            "FROM Sales s JOIN Products p ON s.ProductId = p.ProductId " +
            "WHERE s.SaleDate BETWEEN @StartDate AND @EndDate " +
            "ORDER BY s.SaleDate";

        public const string GetTopProducts =
            "SELECT p.ProductName, p.Category, SUM(s.Quantity) AS TotalQuantity " +
            "FROM Sales s JOIN Products p ON s.ProductId = p.ProductId " +
            "GROUP BY p.ProductId, p.ProductName, p.Category " +
            "ORDER BY TotalQuantity DESC";

        public const string InsertProduct =
            "INSERT INTO Products (ProductName, Category, Price, Stock) " +
            "VALUES (@ProductName, @Category, @Price, @Stock)";

        public const string InsertSale =
            "INSERT INTO Sales (ProductId, SaleDate, Quantity, SalePrice) " +
            "VALUES (@ProductId, @SaleDate, @Quantity, @SalePrice)";

        public const string UpdateStock =
            "UPDATE Products SET Stock = Stock - @Quantity WHERE ProductId = @ProductId";
    }
}
