using System.Windows.Forms;

namespace ReportsLab.Forms
{
    partial class FormDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain          = new TableLayoutPanel();
            pnlKpis          = new TableLayoutPanel();
            pnlKpiOrders     = new Panel();
            pnlKpiRevenue    = new Panel();
            pnlKpiItems      = new Panel();
            lblOrdersName    = new Label();
            lblOrdersValue   = new Label();
            lblRevenueName   = new Label();
            lblRevenueValue  = new Label();
            lblItemsName     = new Label();
            lblItemsValue    = new Label();
            tblCharts        = new TableLayoutPanel();
            chartTopProducts = new ScottPlot.WinForms.FormsPlot();
            chartByCategory  = new ScottPlot.WinForms.FormsPlot();
            chartLowStock    = new ScottPlot.WinForms.FormsPlot();
            SuspendLayout();

            // ── pnlMain (3 rows: KPIs | side-by-side charts | low stock) ─────────
            pnlMain.Dock        = DockStyle.Fill;
            pnlMain.RowCount    = 3;
            pnlMain.ColumnCount = 1;
            pnlMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 120));
            pnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 58));
            pnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 42));
            pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            pnlMain.Controls.Add(pnlKpis,      0, 0);
            pnlMain.Controls.Add(tblCharts,    0, 1);
            pnlMain.Controls.Add(chartLowStock, 0, 2);

            // ── pnlKpis (3 equal KPI cards) ───────────────────────────────────────
            pnlKpis.Dock        = DockStyle.Fill;
            pnlKpis.ColumnCount = 3;
            pnlKpis.RowCount    = 1;
            pnlKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            pnlKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            pnlKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34f));
            pnlKpis.Padding     = new Padding(8);
            pnlKpis.Controls.Add(pnlKpiOrders,  0, 0);
            pnlKpis.Controls.Add(pnlKpiRevenue, 1, 0);
            pnlKpis.Controls.Add(pnlKpiItems,   2, 0);

            // ── KPI card: Total Orders ─────────────────────────────────────────────
            pnlKpiOrders.Dock      = DockStyle.Fill;
            pnlKpiOrders.Margin    = new Padding(4);
            pnlKpiOrders.BackColor = Color.FromArgb(227, 242, 253);
            pnlKpiOrders.Controls.Add(lblOrdersValue);
            pnlKpiOrders.Controls.Add(lblOrdersName);

            lblOrdersName.Text      = "TOTAL ORDERS";
            lblOrdersName.Font      = new Font("Roboto", 9f, FontStyle.Bold);
            lblOrdersName.ForeColor = Color.FromArgb(100, 100, 100);
            lblOrdersName.Dock      = DockStyle.Bottom;
            lblOrdersName.Height    = 22;
            lblOrdersName.TextAlign = ContentAlignment.BottomCenter;

            lblOrdersValue.Text      = "—";
            lblOrdersValue.Font      = new Font("Roboto", 26f, FontStyle.Bold);
            lblOrdersValue.ForeColor = Color.FromArgb(25, 118, 210);
            lblOrdersValue.Dock      = DockStyle.Fill;
            lblOrdersValue.TextAlign = ContentAlignment.MiddleCenter;

            // ── KPI card: Total Revenue ────────────────────────────────────────────
            pnlKpiRevenue.Dock      = DockStyle.Fill;
            pnlKpiRevenue.Margin    = new Padding(4);
            pnlKpiRevenue.BackColor = Color.FromArgb(232, 245, 233);
            pnlKpiRevenue.Controls.Add(lblRevenueValue);
            pnlKpiRevenue.Controls.Add(lblRevenueName);

            lblRevenueName.Text      = "TOTAL REVENUE";
            lblRevenueName.Font      = new Font("Roboto", 9f, FontStyle.Bold);
            lblRevenueName.ForeColor = Color.FromArgb(100, 100, 100);
            lblRevenueName.Dock      = DockStyle.Bottom;
            lblRevenueName.Height    = 22;
            lblRevenueName.TextAlign = ContentAlignment.BottomCenter;

            lblRevenueValue.Text      = "—";
            lblRevenueValue.Font      = new Font("Roboto", 26f, FontStyle.Bold);
            lblRevenueValue.ForeColor = Color.FromArgb(46, 125, 50);
            lblRevenueValue.Dock      = DockStyle.Fill;
            lblRevenueValue.TextAlign = ContentAlignment.MiddleCenter;

            // ── KPI card: Total Items Sold ─────────────────────────────────────────
            pnlKpiItems.Dock      = DockStyle.Fill;
            pnlKpiItems.Margin    = new Padding(4);
            pnlKpiItems.BackColor = Color.FromArgb(255, 243, 224);
            pnlKpiItems.Controls.Add(lblItemsValue);
            pnlKpiItems.Controls.Add(lblItemsName);

            lblItemsName.Text      = "TOTAL ITEMS SOLD";
            lblItemsName.Font      = new Font("Roboto", 9f, FontStyle.Bold);
            lblItemsName.ForeColor = Color.FromArgb(100, 100, 100);
            lblItemsName.Dock      = DockStyle.Bottom;
            lblItemsName.Height    = 22;
            lblItemsName.TextAlign = ContentAlignment.BottomCenter;

            lblItemsValue.Text      = "—";
            lblItemsValue.Font      = new Font("Roboto", 26f, FontStyle.Bold);
            lblItemsValue.ForeColor = Color.FromArgb(230, 81, 0);
            lblItemsValue.Dock      = DockStyle.Fill;
            lblItemsValue.TextAlign = ContentAlignment.MiddleCenter;

            // ── tblCharts (bar left | pie right) ──────────────────────────────────
            tblCharts.Dock        = DockStyle.Fill;
            tblCharts.ColumnCount = 2;
            tblCharts.RowCount    = 1;
            tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tblCharts.Controls.Add(chartTopProducts, 0, 0);
            tblCharts.Controls.Add(chartByCategory,  1, 0);

            // ── FormsPlot controls ─────────────────────────────────────────────────
            chartTopProducts.Dock = DockStyle.Fill;
            chartByCategory.Dock  = DockStyle.Fill;
            chartLowStock.Dock    = DockStyle.Fill;

            // ── FormDashboard ──────────────────────────────────────────────────────
            ClientSize    = new Size(1200, 750);
            StartPosition = FormStartPosition.CenterParent;
            Text          = "Sales Dashboard";
            Controls.Add(pnlMain);
            Load += FormDashboard_Load;
            ResumeLayout(false);
        }

        private TableLayoutPanel                   pnlMain;
        private TableLayoutPanel                   pnlKpis;
        private Panel                              pnlKpiOrders;
        private Panel                              pnlKpiRevenue;
        private Panel                              pnlKpiItems;
        private Label                              lblOrdersName;
        private Label                              lblOrdersValue;
        private Label                              lblRevenueName;
        private Label                              lblRevenueValue;
        private Label                              lblItemsName;
        private Label                              lblItemsValue;
        private TableLayoutPanel                   tblCharts;
        private ScottPlot.WinForms.FormsPlot       chartTopProducts;
        private ScottPlot.WinForms.FormsPlot       chartByCategory;
        private ScottPlot.WinForms.FormsPlot       chartLowStock;
    }
}
