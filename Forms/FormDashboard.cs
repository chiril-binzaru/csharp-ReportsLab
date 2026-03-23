using MaterialSkin;
using MaterialSkin.Controls;
using ReportsLab.Data;
using System.Data;

namespace ReportsLab.Forms
{
    public partial class FormDashboard : MaterialForm
    {
        // Chart color palette
        private static readonly ScottPlot.Color[] Palette =
        {
            ScottPlot.Color.FromHex("#3498DB"),
            ScottPlot.Color.FromHex("#2ECC71"),
            ScottPlot.Color.FromHex("#F39C12"),
            ScottPlot.Color.FromHex("#9B59B6"),
            ScottPlot.Color.FromHex("#1ABC9C"),
            ScottPlot.Color.FromHex("#E67E22"),
            ScottPlot.Color.FromHex("#34495E"),
        };

        public FormDashboard()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.AddFormToManage(this);
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                var summary     = DatabaseClient.ExecuteQuery(DatabaseClient.GetDashboardSummary);
                var topProducts = DatabaseClient.ExecuteQuery(DatabaseClient.GetDashboardTopProducts);
                var categories  = DatabaseClient.ExecuteQuery(DatabaseClient.GetDashboardByCategory);
                var lowStock    = DatabaseClient.ExecuteQuery(DatabaseClient.GetDashboardLowStock);

                PopulateKpis(summary);
                PlotTopProducts(topProducts);
                PlotByCategory(categories);
                PlotLowStock(lowStock);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateKpis(DataTable summary)
        {
            var row = summary.Rows[0];
            lblOrdersValue.Text  = row["TotalOrders"].ToString();
            lblRevenueValue.Text = $"${Convert.ToDecimal(row["TotalRevenue"]):N2}";
            lblItemsValue.Text   = row["TotalItemsSold"].ToString();
        }

        private void PlotTopProducts(DataTable data)
        {
            var plot = chartTopProducts.Plot;
            plot.Clear();
            plot.Title("Top 5 Products by Revenue");
            plot.YLabel("Revenue ($)");

            if (data.Rows.Count == 0) { chartTopProducts.Refresh(); return; }

            var rows = data.Rows.Cast<DataRow>().ToList();

            var bars = rows.Select((r, i) => new ScottPlot.Bar
            {
                Position  = i,
                Value     = Convert.ToDouble(r["TotalRevenue"]),
                FillColor = Palette[i % Palette.Length],
                Label     = $"${Convert.ToDecimal(r["TotalRevenue"]):N0}"
            }).ToArray();

            plot.Add.Bars(bars);

            double[] positions  = Enumerable.Range(0, rows.Count).Select(i => (double)i).ToArray();
            string[] tickLabels = rows.Select(r => r["ProductName"].ToString()!).ToArray();
            plot.Axes.Bottom.SetTicks(positions, tickLabels);
            plot.Axes.Margins(bottom: 0);

            chartTopProducts.Refresh();
        }

        private void PlotByCategory(DataTable data)
        {
            var plot = chartByCategory.Plot;
            plot.Clear();
            plot.Title("Revenue by Category");

            if (data.Rows.Count == 0) { chartByCategory.Refresh(); return; }

            var rows = data.Rows.Cast<DataRow>().ToList();

            var slices = rows.Select((r, i) => new ScottPlot.PieSlice
            {
                Value     = Convert.ToDouble(r["TotalRevenue"]),
                Label     = r["Category"].ToString()!,
                FillColor = Palette[i % Palette.Length]
            }).ToList();

            plot.Add.Pie(slices);
            plot.ShowLegend();
            plot.HideGrid();
            plot.Axes.Frameless();

            chartByCategory.Refresh();
        }

        private void PlotLowStock(DataTable data)
        {
            var plot = chartLowStock.Plot;
            plot.Clear();
            plot.Title("Low Stock Alert  (≤ 5 units)");
            plot.YLabel("Units in Stock");

            if (data.Rows.Count == 0)
            {
                chartLowStock.Refresh();
                return;
            }

            var rows = data.Rows.Cast<DataRow>().ToList();

            var bars = rows.Select((r, i) => new ScottPlot.Bar
            {
                Position  = i,
                Value     = Convert.ToDouble(r["Stock"]),
                FillColor = ScottPlot.Color.FromHex("#E74C3C"),
                Label     = r["Stock"].ToString()!
            }).ToArray();

            plot.Add.Bars(bars);

            double[] positions  = Enumerable.Range(0, rows.Count).Select(i => (double)i).ToArray();
            string[] tickLabels = rows.Select(r => r["ProductName"].ToString()!).ToArray();
            plot.Axes.Bottom.SetTicks(positions, tickLabels);
            plot.Axes.Margins(bottom: 0);

            chartLowStock.Refresh();
        }
    }
}
