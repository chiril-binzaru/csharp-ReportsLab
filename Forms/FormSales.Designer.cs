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
            pnlTop      = new Panel();
            btnRefresh  = new Button();
            dgvSales    = new DataGridView();
            pnlFields   = new Panel();
            lblStatus   = new Label();
            lblProduct  = new Label();
            cmbProduct  = new ComboBox();
            lblSaleDate = new Label();
            dtpSaleDate = new DateTimePicker();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblSalePrice = new Label();
            numSalePrice = new NumericUpDown();
            btnAdd      = new Button();
            btnSave     = new Button();
            btnDelete   = new Button();
            btnClear    = new Button();
            SuspendLayout();

            // ── pnlTop ───────────────────────────────────────────────────────────
            pnlTop.Dock   = DockStyle.Top;
            pnlTop.Height = 40;
            pnlTop.Controls.Add(btnRefresh);

            btnRefresh.Text     = "Refresh";
            btnRefresh.Location = new Point(8, 7);
            btnRefresh.Size     = new Size(90, 26);
            btnRefresh.Click   += btnRefresh_Click;

            // ── dgvSales ─────────────────────────────────────────────────────────
            dgvSales.Dock                = DockStyle.Fill;
            dgvSales.ReadOnly            = true;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.AllowUserToAddRows  = false;
            dgvSales.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.MultiSelect         = false;
            dgvSales.SelectionChanged   += dgvSales_SelectionChanged;

            // ── pnlFields ────────────────────────────────────────────────────────
            pnlFields.Dock      = DockStyle.Bottom;
            pnlFields.Height    = 148;
            pnlFields.BackColor = System.Drawing.SystemColors.ControlLight;
            pnlFields.Controls.AddRange(new Control[]
            {
                lblStatus,
                lblProduct, cmbProduct, lblSaleDate, dtpSaleDate,
                lblQuantity, numQuantity, lblSalePrice, numSalePrice,
                btnAdd, btnSave, btnDelete, btnClear
            });

            // lblStatus
            lblStatus.Text      = "New sale";
            lblStatus.Location  = new Point(10, 8);
            lblStatus.Size      = new Size(600, 18);
            lblStatus.ForeColor = System.Drawing.Color.SteelBlue;
            lblStatus.Font      = new Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);

            // Row 1 ── Product | Sale Date
            lblProduct.Text      = "Product:";
            lblProduct.Location  = new Point(10, 33);
            lblProduct.Size      = new Size(65, 23);
            lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            cmbProduct.Location          = new Point(78, 31);
            cmbProduct.Size              = new Size(260, 23);
            cmbProduct.DropDownStyle     = ComboBoxStyle.DropDownList;
            cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;

            lblSaleDate.Text      = "Sale Date:";
            lblSaleDate.Location  = new Point(352, 33);
            lblSaleDate.Size      = new Size(72, 23);
            lblSaleDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            dtpSaleDate.Location = new Point(427, 31);
            dtpSaleDate.Size     = new Size(150, 23);
            dtpSaleDate.Format   = DateTimePickerFormat.Short;
            dtpSaleDate.Value    = DateTime.Today;

            // Row 2 ── Quantity | Sale Price
            lblQuantity.Text      = "Quantity:";
            lblQuantity.Location  = new Point(10, 67);
            lblQuantity.Size      = new Size(65, 23);
            lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            numQuantity.Location = new Point(78, 65);
            numQuantity.Size     = new Size(100, 23);
            numQuantity.Minimum  = 1;
            numQuantity.Maximum  = 9999;
            numQuantity.Value    = 1;

            lblSalePrice.Text      = "Sale Price:";
            lblSalePrice.Location  = new Point(195, 67);
            lblSalePrice.Size      = new Size(78, 23);
            lblSalePrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            numSalePrice.Location      = new Point(276, 65);
            numSalePrice.Size          = new Size(120, 23);
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Maximum       = 99999.99M;
            numSalePrice.Minimum       = 0;

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

            // ── FormSales ────────────────────────────────────────────────────────
            ClientSize    = new Size(830, 560);
            StartPosition = FormStartPosition.CenterParent;
            Text          = "Sales Management";
            Controls.Add(dgvSales);
            Controls.Add(pnlTop);
            Controls.Add(pnlFields);
            Load += FormSales_Load;
            ResumeLayout(false);
        }

        private Panel          pnlTop;
        private Button         btnRefresh;
        private DataGridView   dgvSales;
        private Panel          pnlFields;
        private Label          lblStatus;
        private Label          lblProduct;
        private ComboBox       cmbProduct;
        private Label          lblSaleDate;
        private DateTimePicker dtpSaleDate;
        private Label          lblQuantity;
        private NumericUpDown  numQuantity;
        private Label          lblSalePrice;
        private NumericUpDown  numSalePrice;
        private Button         btnAdd;
        private Button         btnSave;
        private Button         btnDelete;
        private Button         btnClear;
    }
}
