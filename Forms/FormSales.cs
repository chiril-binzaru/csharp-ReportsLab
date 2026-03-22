using Microsoft.Data.SqlClient;
using ReportsLab.Data;
using System.Data;

namespace ReportsLab.Forms
{
    public partial class FormSales : Form
    {
        public FormSales()
        {
            InitializeComponent();
        }

        private void FormSales_Load(object sender, EventArgs e)
        {
            LoadSales();
            LoadProductsCombo();
        }

        private void LoadSales()
        {
            try
            {
                dgvSales.DataSource = DatabaseClient.ExecuteQuery(DatabaseClient.GetAllSales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales:\n{ex.Message}", "Error",
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

        private void btnRefreshSales_Click(object sender, EventArgs e) => LoadSales();

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auto-fill sale price with the product's default price
            if (cmbProduct.SelectedItem is DataRowView row)
                numSalePrice.Value = Convert.ToDecimal(row["Price"]);
        }

        private void btnRecordSale_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int productId = Convert.ToInt32(cmbProduct.SelectedValue);

                DatabaseClient.ExecuteNonQuery(DatabaseClient.InsertSale,
                    new SqlParameter("@ProductId", productId),
                    new SqlParameter("@SaleDate",  dtpSaleDate.Value.Date),
                    new SqlParameter("@Quantity",  (int)numQuantity.Value),
                    new SqlParameter("@SalePrice", numSalePrice.Value));

                // Reduce stock accordingly
                DatabaseClient.ExecuteNonQuery(DatabaseClient.UpdateStock,
                    new SqlParameter("@Quantity",  (int)numQuantity.Value),
                    new SqlParameter("@ProductId", productId));

                MessageBox.Show("Sale recorded successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                numQuantity.Value = 1;
                LoadSales();
                tabControl.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording sale:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
