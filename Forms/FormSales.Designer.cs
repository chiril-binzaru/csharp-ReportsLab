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
            tabControl      = new TabControl();
            tabPageList     = new TabPage();
            pnlRefresh      = new Panel();
            btnRefreshSales = new Button();
            dgvSales        = new DataGridView();
            tabPageRecord   = new TabPage();
            pnlRecordFields = new Panel();
            lblProduct      = new Label();
            cmbProduct      = new ComboBox();
            lblSaleDate     = new Label();
            dtpSaleDate     = new DateTimePicker();
            lblQuantity     = new Label();
            numQuantity     = new NumericUpDown();
            lblSalePrice    = new Label();
            numSalePrice    = new NumericUpDown();
            btnRecordSale   = new Button();
            SuspendLayout();

            // ── tabControl ───────────────────────────────────────────────────────
            tabControl.Dock = DockStyle.Fill;
            tabControl.Controls.Add(tabPageList);
            tabControl.Controls.Add(tabPageRecord);

            // ── tabPageList ──────────────────────────────────────────────────────
            tabPageList.Text    = "Sales List";
            tabPageList.Padding = new Padding(3);
            tabPageList.Controls.Add(dgvSales);
            tabPageList.Controls.Add(pnlRefresh);

            // pnlRefresh
            pnlRefresh.Dock   = DockStyle.Top;
            pnlRefresh.Height = 40;
            pnlRefresh.Controls.Add(btnRefreshSales);

            // btnRefreshSales
            btnRefreshSales.Text     = "Refresh";
            btnRefreshSales.Location = new Point(8, 7);
            btnRefreshSales.Size     = new Size(90, 26);
            btnRefreshSales.Click   += btnRefreshSales_Click;

            // dgvSales
            dgvSales.Dock                = DockStyle.Fill;
            dgvSales.ReadOnly            = true;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.AllowUserToAddRows  = false;
            dgvSales.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.MultiSelect         = false;

            // ── tabPageRecord ────────────────────────────────────────────────────
            tabPageRecord.Text = "Record Sale";
            tabPageRecord.Controls.Add(pnlRecordFields);

            // pnlRecordFields
            pnlRecordFields.Location = new Point(30, 20);
            pnlRecordFields.Size     = new Size(400, 280);

            // Row 0 – Product
            lblProduct.Text     = "Product:";
            lblProduct.Location = new Point(0,   14);
            lblProduct.Size     = new Size(115,  23);
            cmbProduct.Location = new Point(125,  10);
            cmbProduct.Size     = new Size(240,  23);
            cmbProduct.DropDownStyle         = ComboBoxStyle.DropDownList;
            cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;

            // Row 1 – Sale Date
            lblSaleDate.Text     = "Sale Date:";
            lblSaleDate.Location = new Point(0,   54);
            lblSaleDate.Size     = new Size(115,  23);
            dtpSaleDate.Location = new Point(125,  50);
            dtpSaleDate.Size     = new Size(180,  23);
            dtpSaleDate.Format   = DateTimePickerFormat.Short;
            dtpSaleDate.Value    = DateTime.Today;

            // Row 2 – Quantity
            lblQuantity.Text     = "Quantity:";
            lblQuantity.Location = new Point(0,   94);
            lblQuantity.Size     = new Size(115,  23);
            numQuantity.Location = new Point(125,  90);
            numQuantity.Size     = new Size(130,  23);
            numQuantity.Minimum  = 1;
            numQuantity.Maximum  = 9999;
            numQuantity.Value    = 1;

            // Row 3 – Sale Price
            lblSalePrice.Text     = "Sale Price:";
            lblSalePrice.Location = new Point(0,  134);
            lblSalePrice.Size     = new Size(115,  23);
            numSalePrice.Location = new Point(125, 130);
            numSalePrice.Size     = new Size(130,  23);
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Maximum  = 99999.99M;
            numSalePrice.Minimum  = 0;

            // Button
            btnRecordSale.Text     = "Record Sale";
            btnRecordSale.Location = new Point(125, 185);
            btnRecordSale.Size     = new Size(130,  35);
            btnRecordSale.Click   += btnRecordSale_Click;

            pnlRecordFields.Controls.AddRange(new Control[]
            {
                lblProduct,   cmbProduct,
                lblSaleDate,  dtpSaleDate,
                lblQuantity,  numQuantity,
                lblSalePrice, numSalePrice,
                btnRecordSale
            });

            // ── FormSales ────────────────────────────────────────────────────────
            ClientSize    = new Size(800, 520);
            StartPosition = FormStartPosition.CenterParent;
            Text          = "Sales Management";
            Controls.Add(tabControl);
            Load += FormSales_Load;
            ResumeLayout(false);
        }

        private TabControl    tabControl;
        private TabPage       tabPageList;
        private TabPage       tabPageRecord;
        private Panel         pnlRefresh;
        private Button        btnRefreshSales;
        private DataGridView  dgvSales;
        private Panel         pnlRecordFields;
        private Label         lblProduct;
        private ComboBox      cmbProduct;
        private Label         lblSaleDate;
        private DateTimePicker dtpSaleDate;
        private Label         lblQuantity;
        private NumericUpDown numQuantity;
        private Label         lblSalePrice;
        private NumericUpDown numSalePrice;
        private Button        btnRecordSale;
    }
}
