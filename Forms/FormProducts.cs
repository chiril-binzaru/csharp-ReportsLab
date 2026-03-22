using Microsoft.Data.SqlClient;
using ReportsLab.Data;

namespace ReportsLab.Forms
{
    public partial class FormProducts : Form
    {
        private int _selectedProductId = -1;

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
                if (dgvProducts.Columns["ProductId"] != null)
                    dgvProducts.Columns["ProductId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            var row            = dgvProducts.CurrentRow;
            _selectedProductId = Convert.ToInt32(row.Cells["ProductId"].Value);
            txtProductName.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
            txtCategory.Text    = row.Cells["Category"].Value?.ToString() ?? "";
            numPrice.Value      = Convert.ToDecimal(row.Cells["Price"].Value);
            numStock.Value      = Convert.ToInt32(row.Cells["Stock"].Value);
            lblStatus.Text      = $"Editing: {txtProductName.Text}";
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadProducts();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;
            try
            {
                DatabaseClient.ExecuteNonQuery(DatabaseClient.InsertProduct,
                    new SqlParameter("@ProductName", txtProductName.Text.Trim()),
                    new SqlParameter("@Category",    txtCategory.Text.Trim()),
                    new SqlParameter("@Price",       numPrice.Value),
                    new SqlParameter("@Stock",       (int)numStock.Value));

                MessageBox.Show("Product added.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == -1)
            {
                MessageBox.Show("Select a product to update.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateFields()) return;
            try
            {
                DatabaseClient.ExecuteNonQuery(DatabaseClient.UpdateProduct,
                    new SqlParameter("@ProductName", txtProductName.Text.Trim()),
                    new SqlParameter("@Category",    txtCategory.Text.Trim()),
                    new SqlParameter("@Price",       numPrice.Value),
                    new SqlParameter("@Stock",       (int)numStock.Value),
                    new SqlParameter("@ProductId",   _selectedProductId));

                MessageBox.Show("Product updated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Product Name and Category are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == -1)
            {
                MessageBox.Show("Select a product to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Delete '{txtProductName.Text}'?\nThis will fail if the product has sales.",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                DatabaseClient.ExecuteNonQuery(DatabaseClient.DeleteProduct,
                    new SqlParameter("@ProductId", _selectedProductId));

                ClearForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot delete product:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            _selectedProductId = -1;
            dgvProducts.ClearSelection();
            txtProductName.Clear();
            txtCategory.Clear();
            numPrice.Value = 0;
            numStock.Value = 0;
            lblStatus.Text = "New product";
        }
    }
}
