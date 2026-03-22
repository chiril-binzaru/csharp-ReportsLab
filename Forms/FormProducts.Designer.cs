using MaterialSkin.Controls;

namespace ReportsLab.Forms
{
    partial class FormProducts
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop         = new System.Windows.Forms.Panel();
            btnRefresh     = new MaterialButton();
            dgvProducts    = new System.Windows.Forms.DataGridView();
            fieldsCard     = new MaterialCard();
            lblStatus      = new MaterialLabel();
            txtProductName = new MaterialTextBox();
            txtCategory    = new MaterialTextBox();
            lblPrice       = new MaterialLabel();
            numPrice       = new System.Windows.Forms.NumericUpDown();
            lblStock       = new MaterialLabel();
            numStock       = new System.Windows.Forms.NumericUpDown();
            btnAdd         = new MaterialButton();
            btnSave        = new MaterialButton();
            btnDelete      = new MaterialButton();
            btnClear       = new MaterialButton();
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

            // ── dgvProducts ──────────────────────────────────────────────────────
            dgvProducts.Dock                = System.Windows.Forms.DockStyle.Fill;
            dgvProducts.ReadOnly            = true;
            dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.AllowUserToAddRows  = false;
            dgvProducts.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect         = false;
            dgvProducts.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            dgvProducts.SelectionChanged   += dgvProducts_SelectionChanged;

            // ── fieldsCard (MaterialCard, docked Bottom) ─────────────────────────
            fieldsCard.Dock    = System.Windows.Forms.DockStyle.Bottom;
            fieldsCard.Height  = 172;
            fieldsCard.Padding = new Padding(12, 6, 12, 6);
            fieldsCard.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblStatus,
                txtProductName, txtCategory,
                lblPrice, numPrice, lblStock, numStock,
                btnAdd, btnSave, btnDelete, btnClear
            });

            // lblStatus
            lblStatus.Text      = "New product";
            lblStatus.Location  = new Point(14, 6);
            lblStatus.Size      = new Size(600, 18);
            lblStatus.FontType  = MaterialSkin.MaterialSkinManager.fontType.Caption;

            // txtProductName
            txtProductName.Hint     = "Product Name";
            txtProductName.Location = new Point(12, 24);
            txtProductName.Size     = new Size(270, 48);

            // txtCategory
            txtCategory.Hint     = "Category";
            txtCategory.Location = new Point(292, 24);
            txtCategory.Size     = new Size(210, 48);

            // Price row
            lblPrice.Text      = "Price:";
            lblPrice.Location  = new Point(14, 87);
            lblPrice.Size      = new Size(46, 23);
            lblPrice.FontType  = MaterialSkin.MaterialSkinManager.fontType.Body2;

            numPrice.Location      = new Point(63, 84);
            numPrice.Size          = new Size(120, 23);
            numPrice.DecimalPlaces = 2;
            numPrice.Maximum       = 99999.99M;
            numPrice.Minimum       = 0;

            lblStock.Text      = "Stock:";
            lblStock.Location  = new Point(200, 87);
            lblStock.Size      = new Size(50, 23);
            lblStock.FontType  = MaterialSkin.MaterialSkinManager.fontType.Body2;

            numStock.Location = new Point(253, 84);
            numStock.Size     = new Size(100, 23);
            numStock.Maximum  = 99999;
            numStock.Minimum  = 0;

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

            // ── FormProducts ─────────────────────────────────────────────────────
            ClientSize    = new Size(780, 600);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text          = "Products";
            Controls.Add(dgvProducts);
            Controls.Add(pnlTop);
            Controls.Add(fieldsCard);
            Load += FormProducts_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel         pnlTop;
        private MaterialButton                     btnRefresh;
        private System.Windows.Forms.DataGridView  dgvProducts;
        private MaterialCard                       fieldsCard;
        private MaterialLabel                      lblStatus;
        private MaterialTextBox                    txtProductName;
        private MaterialTextBox                    txtCategory;
        private MaterialLabel                      lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private MaterialLabel                      lblStock;
        private System.Windows.Forms.NumericUpDown numStock;
        private MaterialButton                     btnAdd;
        private MaterialButton                     btnSave;
        private MaterialButton                     btnDelete;
        private MaterialButton                     btnClear;
    }
}
