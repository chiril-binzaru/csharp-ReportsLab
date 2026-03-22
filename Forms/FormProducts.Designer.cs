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
            pnlTop         = new Panel();
            btnRefresh     = new Button();
            dgvProducts    = new DataGridView();
            pnlFields      = new Panel();
            lblStatus      = new Label();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblCategory    = new Label();
            txtCategory    = new TextBox();
            lblPrice       = new Label();
            numPrice       = new NumericUpDown();
            lblStock       = new Label();
            numStock       = new NumericUpDown();
            btnAdd         = new Button();
            btnSave        = new Button();
            btnDelete      = new Button();
            btnClear       = new Button();
            SuspendLayout();

            // ── pnlTop ───────────────────────────────────────────────────────────
            pnlTop.Dock   = DockStyle.Top;
            pnlTop.Height = 40;
            pnlTop.Controls.Add(btnRefresh);

            btnRefresh.Text     = "Refresh";
            btnRefresh.Location = new Point(8, 7);
            btnRefresh.Size     = new Size(90, 26);
            btnRefresh.Click   += btnRefresh_Click;

            // ── dgvProducts ──────────────────────────────────────────────────────
            dgvProducts.Dock                = DockStyle.Fill;
            dgvProducts.ReadOnly            = true;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.AllowUserToAddRows  = false;
            dgvProducts.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect         = false;
            dgvProducts.SelectionChanged   += dgvProducts_SelectionChanged;

            // ── pnlFields ────────────────────────────────────────────────────────
            pnlFields.Dock      = DockStyle.Bottom;
            pnlFields.Height    = 148;
            pnlFields.BackColor = System.Drawing.SystemColors.ControlLight;
            pnlFields.Padding   = new Padding(10, 8, 10, 8);
            pnlFields.Controls.AddRange(new Control[]
            {
                lblStatus,
                lblProductName, txtProductName, lblCategory, txtCategory,
                lblPrice, numPrice, lblStock, numStock,
                btnAdd, btnSave, btnDelete, btnClear
            });

            // lblStatus
            lblStatus.Text      = "New product";
            lblStatus.Location  = new Point(10, 8);
            lblStatus.Size      = new Size(500, 18);
            lblStatus.ForeColor = System.Drawing.Color.SteelBlue;
            lblStatus.Font      = new Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);

            // Row 1 ── Product Name | Category
            lblProductName.Text     = "Product Name:";
            lblProductName.Location = new Point(10, 33);
            lblProductName.Size     = new Size(95, 23);
            lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtProductName.Location = new Point(108, 31);
            txtProductName.Size     = new Size(200, 23);

            lblCategory.Text     = "Category:";
            lblCategory.Location = new Point(322, 33);
            lblCategory.Size     = new Size(70, 23);
            lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtCategory.Location = new Point(395, 31);
            txtCategory.Size     = new Size(180, 23);

            // Row 2 ── Price | Stock
            lblPrice.Text     = "Price:";
            lblPrice.Location = new Point(10, 67);
            lblPrice.Size     = new Size(95, 23);
            lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            numPrice.Location      = new Point(108, 65);
            numPrice.Size          = new Size(120, 23);
            numPrice.DecimalPlaces = 2;
            numPrice.Maximum       = 99999.99M;
            numPrice.Minimum       = 0;

            lblStock.Text     = "Stock:";
            lblStock.Location = new Point(245, 67);
            lblStock.Size     = new Size(55, 23);
            lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            numStock.Location = new Point(303, 65);
            numStock.Size     = new Size(100, 23);
            numStock.Maximum  = 99999;
            numStock.Minimum  = 0;

            // Row 3 ── Buttons
            btnAdd.Text     = "Add";
            btnAdd.Location = new Point(10, 103);
            btnAdd.Size     = new Size(90, 32);
            btnAdd.Click   += btnAdd_Click;

            btnSave.Text     = "Save";
            btnSave.Location = new Point(110, 103);
            btnSave.Size     = new Size(90, 32);
            btnSave.Click   += btnSave_Click;

            btnDelete.Text      = "Delete";
            btnDelete.Location  = new Point(210, 103);
            btnDelete.Size      = new Size(90, 32);
            btnDelete.ForeColor = System.Drawing.Color.DarkRed;
            btnDelete.Click    += btnDelete_Click;

            btnClear.Text     = "Clear";
            btnClear.Location = new Point(310, 103);
            btnClear.Size     = new Size(90, 32);
            btnClear.Click   += btnClear_Click;

            // ── FormProducts ─────────────────────────────────────────────────────
            ClientSize    = new Size(780, 560);
            StartPosition = FormStartPosition.CenterParent;
            Text          = "Products Management";
            // order matters: Fill must be added before Top/Bottom
            Controls.Add(dgvProducts);
            Controls.Add(pnlTop);
            Controls.Add(pnlFields);
            Load += FormProducts_Load;
            ResumeLayout(false);
        }

        private Panel         pnlTop;
        private Button        btnRefresh;
        private DataGridView  dgvProducts;
        private Panel         pnlFields;
        private Label         lblStatus;
        private Label         lblProductName;
        private TextBox       txtProductName;
        private Label         lblCategory;
        private TextBox       txtCategory;
        private Label         lblPrice;
        private NumericUpDown numPrice;
        private Label         lblStock;
        private NumericUpDown numStock;
        private Button        btnAdd;
        private Button        btnSave;
        private Button        btnDelete;
        private Button        btnClear;
    }
}
