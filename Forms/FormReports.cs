using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using ReportsLab.Data;
using System.Data;

namespace ReportsLab.Forms
{
    public partial class FormReports : MaterialForm
    {
        public FormReports()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.AddFormToManage(this);
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            cmbReport.Items.AddRange(new object[]
            {
                "Product List",
                "Sales by Period",
                "Top-Selling Products",
                "Products by Category",
                "Sales by Product",
                "Sales by Category & Period"
            });

            LoadCategoriesCombo();
            LoadProductsCombo();

            cmbReport.SelectedIndex = 0;
        }

        private void LoadCategoriesCombo()
        {
            try
            {
                var dt = DatabaseClient.ExecuteQuery(DatabaseClient.GetCategories);
                foreach (DataRow r in dt.Rows)
                    cmbCategory.Items.Add(r["Category"].ToString()!);
                if (cmbCategory.Items.Count > 0)
                    cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductsCombo()
        {
            try
            {
                var dt = DatabaseClient.ExecuteQuery(DatabaseClient.GetProductsForCombo);
                cmbProduct.DataSource    = dt;
                cmbProduct.DisplayMember = "ProductName";
                cmbProduct.ValueMember   = "ProductId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cmbReport.SelectedIndex;

            bool showDates    = idx == 1 || idx == 5;
            bool showCategory = idx == 3 || idx == 5;
            bool showProduct  = idx == 4;

            lblFrom.Visible     = showDates;
            dtpFrom.Visible     = showDates;
            lblTo.Visible       = showDates;
            dtpTo.Visible       = showDates;
            lblCategory.Visible = showCategory;
            cmbCategory.Visible = showCategory;
            lblProduct.Visible  = showProduct;
            cmbProduct.Visible  = showProduct;

            // For the combined report (idx 5), category goes to the right of the date pickers;
            // for category-only (idx 3) it starts right after the report selector.
            if (idx == 5)
            {
                lblCategory.Location = new Point(640, 30);
                cmbCategory.Location = new Point(706, 14);
            }
            else
            {
                lblCategory.Location = new Point(256, 30);
                cmbCategory.Location = new Point(328, 14);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();

                switch (cmbReport.SelectedIndex)
                {
                    case 0:
                    {
                        var data = DatabaseClient.ExecuteQuery(DatabaseClient.GetProductsForReport);
                        if (data.Rows.Count == 0) { ShowNoData(); return; }
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "ReportsLab.Reports.ReportProducts.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("ProductsData", data));
                        break;
                    }

                    case 1:
                    {
                        var data = DatabaseClient.ExecuteQuery(DatabaseClient.GetSalesByPeriod,
                            new SqlParameter("@StartDate", dtpFrom.Value.Date),
                            new SqlParameter("@EndDate",   dtpTo.Value.Date));
                        if (data.Rows.Count == 0) { ShowNoData(); return; }
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "ReportsLab.Reports.ReportSalesByPeriod.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("SalesData", data));
                        break;
                    }

                    case 2:
                    {
                        var data = DatabaseClient.ExecuteQuery(DatabaseClient.GetTopProducts);
                        if (data.Rows.Count == 0) { ShowNoData(); return; }
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "ReportsLab.Reports.ReportTopProducts.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("TopProductsData", data));
                        break;
                    }

                    case 3: // Products by Category
                    {
                        if (cmbCategory.SelectedItem == null)
                        {
                            MessageBox.Show("Please select a category.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string category = cmbCategory.SelectedItem.ToString()!;
                        var data = DatabaseClient.ExecuteQuery(DatabaseClient.GetProductsByCategory,
                            new SqlParameter("@Category", category));
                        if (data.Rows.Count == 0) { ShowNoData(); return; }
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "ReportsLab.Reports.ReportProductsByCategory.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("ProductsData", data));
                        reportViewer1.LocalReport.SetParameters(new[]
                        {
                            new ReportParameter("ParamCategory",    category),
                            new ReportParameter("ParamGeneratedOn", DateTime.Now.ToString("g"))
                        });
                        break;
                    }

                    case 4: // Sales by Product
                    {
                        if (cmbProduct.SelectedValue == null)
                        {
                            MessageBox.Show("Please select a product.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        int    productId   = Convert.ToInt32(cmbProduct.SelectedValue);
                        string productName = cmbProduct.Text;
                        var data = DatabaseClient.ExecuteQuery(DatabaseClient.GetSalesByProduct,
                            new SqlParameter("@ProductId", productId));
                        if (data.Rows.Count == 0) { ShowNoData(); return; }
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "ReportsLab.Reports.ReportSalesByProduct.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("SalesData", data));
                        reportViewer1.LocalReport.SetParameters(new[]
                        {
                            new ReportParameter("ParamProduct",     productName),
                            new ReportParameter("ParamGeneratedOn", DateTime.Now.ToString("g"))
                        });
                        break;
                    }

                    case 5: // Sales by Category & Period
                    {
                        if (cmbCategory.SelectedItem == null)
                        {
                            MessageBox.Show("Please select a category.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string category = cmbCategory.SelectedItem.ToString()!;
                        var data = DatabaseClient.ExecuteQuery(DatabaseClient.GetSalesByCategoryAndPeriod,
                            new SqlParameter("@Category",  category),
                            new SqlParameter("@StartDate", dtpFrom.Value.Date),
                            new SqlParameter("@EndDate",   dtpTo.Value.Date));
                        if (data.Rows.Count == 0) { ShowNoData(); return; }
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "ReportsLab.Reports.ReportSalesByCategoryAndPeriod.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("SalesData", data));
                        reportViewer1.LocalReport.SetParameters(new[]
                        {
                            new ReportParameter("ParamCategory",    category),
                            new ReportParameter("ParamFrom",        dtpFrom.Value.ToString("d")),
                            new ReportParameter("ParamTo",          dtpTo.Value.ToString("d")),
                            new ReportParameter("ParamGeneratedOn", DateTime.Now.ToString("g"))
                        });
                        break;
                    }
                }

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ShowNoData()
        {
            MessageBox.Show("No data found for the selected parameters.", "No Data",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
