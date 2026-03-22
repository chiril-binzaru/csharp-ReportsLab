using MaterialSkin.Controls;

namespace ReportsLab.Forms
{
    partial class FormSales
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop       = new System.Windows.Forms.Panel();
            btnRefresh   = new MaterialButton();
            dgvSales     = new System.Windows.Forms.DataGridView();
            fieldsCard   = new MaterialCard();
            lblStatus    = new MaterialLabel();
            cmbProduct   = new MaterialComboBox();
            lblDate      = new MaterialLabel();
            dtpSaleDate  = new System.Windows.Forms.DateTimePicker();
            lblQuantity  = new MaterialLabel();
            numQuantity  = new System.Windows.Forms.NumericUpDown();
            lblSalePrice = new MaterialLabel();
            numSalePrice = new System.Windows.Forms.NumericUpDown();
            btnAdd       = new MaterialButton();
            btnSave      = new MaterialButton();
            btnDelete    = new MaterialButton();
            btnClear     = new MaterialButton();
            SuspendLayout();

            // ── pnlTop ───────────────────────────────────────────────────────────
            pnlTop.Dock   = System.Windows.Forms.DockStyle.Top;
            pnlTop.Height = 46;
            pnlTop.Controls.Add(btnRefresh);

            btnRefresh.Text         = "REFRESH";
            btnRefresh.Location     = new Point(8, 8);
            btnRefresh.Size         = new Size(110, 30);
            btnRefresh.Type         = MaterialButton.MaterialButtonType.Outlined;
            btnRefresh.HighEmphasis = false;
            btnRefresh.Click       += btnRefresh_Click;

            // ── dgvSales ─────────────────────────────────────────────────────────
            dgvSales.Dock                = System.Windows.Forms.DockStyle.Fill;
            dgvSales.ReadOnly            = true;
            dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.AllowUserToAddRows  = false;
            dgvSales.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSales.MultiSelect         = false;
            dgvSales.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            dgvSales.SelectionChanged   += dgvSales_SelectionChanged;

            // ── fieldsCard ───────────────────────────────────────────────────────
            fieldsCard.Dock   = System.Windows.Forms.DockStyle.Bottom;
            fieldsCard.Height = 172;
            fieldsCard.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblStatus,
                cmbProduct, lblDate, dtpSaleDate,
                lblQuantity, numQuantity, lblSalePrice, numSalePrice,
                btnAdd, btnSave, btnDelete, btnClear
            });

            // lblStatus
            lblStatus.Text     = "New sale";
            lblStatus.Location = new Point(14, 6);
            lblStatus.Size     = new Size(600, 18);
            lblStatus.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;

            // Row 1 ── Product (wide) | Date
            cmbProduct.Hint                  = "Product";
            cmbProduct.Location              = new Point(12, 24);
            cmbProduct.Size                  = new Size(370, 48);
            cmbProduct.DropDownStyle         = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;

            lblDate.Text      = "Sale Date:";
            lblDate.Location  = new Point(398, 36);
            lblDate.Size      = new Size(68, 23);
            lblDate.FontType  = MaterialSkin.MaterialSkinManager.fontType.Body2;

            dtpSaleDate.Location = new Point(469, 35);
            dtpSaleDate.Size     = new Size(145, 23);
            dtpSaleDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpSaleDate.Value    = DateTime.Today;

            // Row 2 ── Quantity | Sale Price
            lblQuantity.Text     = "Qty:";
            lblQuantity.Location = new Point(14, 88);
            lblQuantity.Size     = new Size(38, 23);
            lblQuantity.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;

            numQuantity.Location = new Point(55, 85);
            numQuantity.Size     = new Size(100, 23);
            numQuantity.Minimum  = 1;
            numQuantity.Maximum  = 9999;
            numQuantity.Value    = 1;

            lblSalePrice.Text     = "Sale Price:";
            lblSalePrice.Location = new Point(172, 88);
            lblSalePrice.Size     = new Size(75, 23);
            lblSalePrice.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;

            numSalePrice.Location      = new Point(250, 85);
            numSalePrice.Size          = new Size(120, 23);
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Maximum       = 99999.99M;
            numSalePrice.Minimum       = 0;

            // Buttons
            btnAdd.Text         = "ADD";
            btnAdd.Location     = new Point(12, 122);
            btnAdd.Size         = new Size(90, 36);
            btnAdd.Type         = MaterialButton.MaterialButtonType.Contained;
            btnAdd.HighEmphasis = true;
            btnAdd.Click       += btnAdd_Click;

            btnSave.Text         = "SAVE";
            btnSave.Location     = new Point(112, 122);
            btnSave.Size         = new Size(90, 36);
            btnSave.Type         = MaterialButton.MaterialButtonType.Contained;
            btnSave.HighEmphasis = true;
            btnSave.Click       += btnSave_Click;

            btnDelete.Text     = "DELETE";
            btnDelete.Location = new Point(212, 122);
            btnDelete.Size     = new Size(90, 36);
            btnDelete.Type     = MaterialButton.MaterialButtonType.Outlined;
            btnDelete.Click   += btnDelete_Click;

            btnClear.Text     = "CLEAR";
            btnClear.Location = new Point(312, 122);
            btnClear.Size     = new Size(90, 36);
            btnClear.Type     = MaterialButton.MaterialButtonType.Text;
            btnClear.Click   += btnClear_Click;

            // ── FormSales ────────────────────────────────────────────────────────
            ClientSize    = new Size(820, 600);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text          = "Sales";
            Controls.Add(dgvSales);
            Controls.Add(pnlTop);
            Controls.Add(fieldsCard);
            Load += FormSales_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlTop;
        private MaterialButton                      btnRefresh;
        private System.Windows.Forms.DataGridView   dgvSales;
        private MaterialCard                        fieldsCard;
        private MaterialLabel                       lblStatus;
        private MaterialComboBox                    cmbProduct;
        private MaterialLabel                       lblDate;
        private System.Windows.Forms.DateTimePicker dtpSaleDate;
        private MaterialLabel                       lblQuantity;
        private System.Windows.Forms.NumericUpDown  numQuantity;
        private MaterialLabel                       lblSalePrice;
        private System.Windows.Forms.NumericUpDown  numSalePrice;
        private MaterialButton                      btnAdd;
        private MaterialButton                      btnSave;
        private MaterialButton                      btnDelete;
        private MaterialButton                      btnClear;
    }
}
