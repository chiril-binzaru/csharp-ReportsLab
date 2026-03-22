using Microsoft.Data.SqlClient;
using ReportsLab.Data;

namespace ReportsLab.Forms
{
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
        }

        private void FormProducts_Load(object sender, EventArgs e) => LoadProducts();

        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = DatabaseClient.ExecuteQuery(DatabaseClient.GetAllProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshProducts_Click(object sender, EventArgs e) => LoadProducts();

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Product Name and Category are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DatabaseClient.ExecuteNonQuery(DatabaseClient.InsertProduct,
                    new SqlParameter("@ProductName", txtProductName.Text.Trim()),
                    new SqlParameter("@Category",    txtCategory.Text.Trim()),
                    new SqlParameter("@Price",       numPrice.Value),
                    new SqlParameter("@Stock",       (int)numStock.Value));

                MessageBox.Show("Product added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtProductName.Clear();
                txtCategory.Clear();
                numPrice.Value = 0;
                numStock.Value = 0;
                LoadProducts();
                tabControl.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
