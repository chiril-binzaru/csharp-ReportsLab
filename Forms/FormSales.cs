using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using ReportsLab.Data;
using System.Data;

namespace ReportsLab.Forms
{
    public partial class FormSales : MaterialForm
    {
        private int _selectedSaleId    = -1;
        private int _selectedProductId = -1;

        public FormSales()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.AddFormToManage(this);
        }

        private void FormSales_Load(object sender, EventArgs e)
        {
            LoadProductsCombo();
            LoadSales();
        }

        private void LoadSales()
        {
            try
            {
                dgvSales.DataSource = DatabaseClient.ExecuteQuery(DatabaseClient.GetAllSales);
                if (dgvSales.Columns["SaleId"] != null)
                    dgvSales.Columns["SaleId"].Visible = false;
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

        private void dgvSales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null) return;

            var row            = dgvSales.CurrentRow;
            _selectedSaleId    = Convert.ToInt32(row.Cells["SaleId"].Value);

            var info           = DatabaseClient.ExecuteQuery(DatabaseClient.GetSaleById,
                                     new SqlParameter("@SaleId", _selectedSaleId));
            _selectedProductId = Convert.ToInt32(info.Rows[0]["ProductId"]);

            cmbProduct.SelectedValue = _selectedProductId;
            dtpSaleDate.Value        = Convert.ToDateTime(row.Cells["SaleDate"].Value);
            numQuantity.Value        = Convert.ToInt32(row.Cells["Quantity"].Value);
            numSalePrice.Value       = Convert.ToDecimal(row.Cells["SalePrice"].Value);
            lblStatus.Text           = $"Editing sale for: {row.Cells["ProductName"].Value}";
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedSaleId == -1 && cmbProduct.SelectedItem is DataRowView row)
                numSalePrice.Value = Convert.ToDecimal(row["Price"]);
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadSales();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;
            try
            {
                int productId = Convert.ToInt32(cmbProduct.SelectedValue);

                DatabaseClient.ExecuteNonQuery(DatabaseClient.InsertSale,
                    new SqlParameter("@ProductId", productId),
                    new SqlParameter("@SaleDate",  dtpSaleDate.Value.Date),
                    new SqlParameter("@Quantity",  (int)numQuantity.Value),
                    new SqlParameter("@SalePrice", numSalePrice.Value));

                DatabaseClient.ExecuteNonQuery(DatabaseClient.UpdateStock,
                    new SqlParameter("@Quantity",  (int)numQuantity.Value),
                    new SqlParameter("@ProductId", productId));

                MessageBox.Show("Sale recorded.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording sale:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedSaleId == -1)
            {
                MessageBox.Show("Select a sale to update.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateFields()) return;
            try
            {
                var original    = DatabaseClient.ExecuteQuery(DatabaseClient.GetSaleById,
                                      new SqlParameter("@SaleId", _selectedSaleId));
                int oldQuantity = Convert.ToInt32(original.Rows[0]["Quantity"]);
                int newQuantity = (int)numQuantity.Value;

                DatabaseClient.ExecuteNonQuery(DatabaseClient.UpdateSale,
                    new SqlParameter("@SaleDate",  dtpSaleDate.Value.Date),
                    new SqlParameter("@Quantity",  newQuantity),
                    new SqlParameter("@SalePrice", numSalePrice.Value),
                    new SqlParameter("@SaleId",    _selectedSaleId));

                DatabaseClient.ExecuteNonQuery(DatabaseClient.AdjustStockForEdit,
                    new SqlParameter("@OldQuantity", oldQuantity),
                    new SqlParameter("@NewQuantity", newQuantity),
                    new SqlParameter("@ProductId",   _selectedProductId));

                MessageBox.Show("Sale updated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating sale:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSaleId == -1)
            {
                MessageBox.Show("Select a sale to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Delete this sale? Stock will be restored.",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                var info  = DatabaseClient.ExecuteQuery(DatabaseClient.GetSaleById,
                                new SqlParameter("@SaleId", _selectedSaleId));
                int qty   = Convert.ToInt32(info.Rows[0]["Quantity"]);

                DatabaseClient.ExecuteNonQuery(DatabaseClient.RestoreStock,
                    new SqlParameter("@Quantity",  qty),
                    new SqlParameter("@ProductId", _selectedProductId));

                DatabaseClient.ExecuteNonQuery(DatabaseClient.DeleteSale,
                    new SqlParameter("@SaleId", _selectedSaleId));

                ClearForm();
                LoadSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting sale:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private bool ValidateFields()
        {
            if (cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            _selectedSaleId    = -1;
            _selectedProductId = -1;
            dgvSales.ClearSelection();
            dtpSaleDate.Value  = DateTime.Today;
            numQuantity.Value  = 1;
            numSalePrice.Value = 0;
            lblStatus.Text     = "New sale";
        }
    }
}
