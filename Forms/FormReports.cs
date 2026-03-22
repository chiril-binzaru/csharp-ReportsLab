using Microsoft.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using ReportsLab.Data;

namespace ReportsLab.Forms
{
    public partial class FormReports : Form
    {
        public FormReports()
        {
            InitializeComponent();
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            cmbReport.Items.AddRange(new object[]
            {
                "Product List",
                "Sales by Period",
                "Top-Selling Products"
            });
            cmbReport.SelectedIndex = 0;
        }

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isPeriod = cmbReport.SelectedIndex == 1;
            lblFrom.Visible = isPeriod;
            dtpFrom.Visible = isPeriod;
            lblTo.Visible   = isPeriod;
            dtpTo.Visible   = isPeriod;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();

                switch (cmbReport.SelectedIndex)
                {
                    case 0: // Product List
                        var products = DatabaseClient.ExecuteQuery(DatabaseClient.GetProductsForReport);
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "ReportsLab.Reports.ReportProducts.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("ProductsData", products));
                        break;

                    case 1: // Sales by Period
                        var sales = DatabaseClient.ExecuteQuery(DatabaseClient.GetSalesByPeriod,
                            new SqlParameter("@StartDate", dtpFrom.Value.Date),
                            new SqlParameter("@EndDate",   dtpTo.Value.Date));
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "ReportsLab.Reports.ReportSalesByPeriod.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("SalesData", sales));
                        break;

                    case 2: // Top-Selling Products
                        var top = DatabaseClient.ExecuteQuery(DatabaseClient.GetTopProducts);
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "ReportsLab.Reports.ReportTopProducts.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("TopProductsData", top));
                        break;
                }

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
