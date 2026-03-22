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
            tabControl         = new TabControl();
            tabPageList        = new TabPage();
            pnlRefresh         = new Panel();
            btnRefreshProducts = new Button();
            dgvProducts        = new DataGridView();
            tabPageAdd         = new TabPage();
            pnlAddFields       = new Panel();
            lblProductName     = new Label();
            txtProductName     = new TextBox();
            lblCategory        = new Label();
            txtCategory        = new TextBox();
            lblPrice           = new Label();
            numPrice           = new NumericUpDown();
            lblStock           = new Label();
            numStock           = new NumericUpDown();
            btnAddProduct      = new Button();
            SuspendLayout();

            // ── tabControl ───────────────────────────────────────────────────────
            tabControl.Dock = DockStyle.Fill;
            tabControl.Controls.Add(tabPageList);
            tabControl.Controls.Add(tabPageAdd);

            // ── tabPageList ──────────────────────────────────────────────────────
            tabPageList.Text    = "Products List";
            tabPageList.Padding = new Padding(3);
            tabPageList.Controls.Add(dgvProducts);
            tabPageList.Controls.Add(pnlRefresh);

            // pnlRefresh
            pnlRefresh.Dock   = DockStyle.Top;
            pnlRefresh.Height = 40;
            pnlRefresh.Controls.Add(btnRefreshProducts);

            // btnRefreshProducts
            btnRefreshProducts.Text     = "Refresh";
            btnRefreshProducts.Location = new Point(8, 7);
            btnRefreshProducts.Size     = new Size(90, 26);
            btnRefreshProducts.Click   += btnRefreshProducts_Click;

            // dgvProducts
            dgvProducts.Dock                  = DockStyle.Fill;
            dgvProducts.ReadOnly              = true;
            dgvProducts.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.AllowUserToAddRows    = false;
            dgvProducts.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect           = false;

            // ── tabPageAdd ───────────────────────────────────────────────────────
            tabPageAdd.Text = "Add Product";
            tabPageAdd.Controls.Add(pnlAddFields);

            // pnlAddFields  (acts as a centred field container)
            pnlAddFields.Location = new Point(30, 20);
            pnlAddFields.Size     = new Size(380, 260);

            // Row 0 – Product Name
            lblProductName.Text     = "Product Name:";
            lblProductName.Location = new Point(0,   14);
            lblProductName.Size     = new Size(115,  23);
            txtProductName.Location = new Point(125,  10);
            txtProductName.Size     = new Size(220,  23);

            // Row 1 – Category
            lblCategory.Text     = "Category:";
            lblCategory.Location = new Point(0,   54);
            lblCategory.Size     = new Size(115,  23);
            txtCategory.Location = new Point(125,  50);
            txtCategory.Size     = new Size(220,  23);

            // Row 2 – Price
            lblPrice.Text     = "Price:";
            lblPrice.Location = new Point(0,   94);
            lblPrice.Size     = new Size(115,  23);
            numPrice.Location = new Point(125,  90);
            numPrice.Size     = new Size(130,  23);
            numPrice.DecimalPlaces = 2;
            numPrice.Maximum  = 99999.99M;
            numPrice.Minimum  = 0;

            // Row 3 – Stock
            lblStock.Text     = "Initial Stock:";
            lblStock.Location = new Point(0,  134);
            lblStock.Size     = new Size(115,  23);
            numStock.Location = new Point(125, 130);
            numStock.Size     = new Size(130,  23);
            numStock.Maximum  = 99999;
            numStock.Minimum  = 0;

            // Button
            btnAddProduct.Text     = "Add Product";
            btnAddProduct.Location = new Point(125, 185);
            btnAddProduct.Size     = new Size(130,  35);
            btnAddProduct.Click   += btnAddProduct_Click;

            pnlAddFields.Controls.AddRange(new Control[]
            {
                lblProductName, txtProductName,
                lblCategory,    txtCategory,
                lblPrice,       numPrice,
                lblStock,       numStock,
                btnAddProduct
            });

            // ── FormProducts ─────────────────────────────────────────────────────
            ClientSize    = new Size(750, 520);
            StartPosition = FormStartPosition.CenterParent;
            Text          = "Products Management";
            Controls.Add(tabControl);
            Load += FormProducts_Load;
            ResumeLayout(false);
        }

        private TabControl       tabControl;
        private TabPage          tabPageList;
        private TabPage          tabPageAdd;
        private Panel            pnlRefresh;
        private Button           btnRefreshProducts;
        private DataGridView     dgvProducts;
        private Panel            pnlAddFields;
        private Label            lblProductName;
        private TextBox          txtProductName;
        private Label            lblCategory;
        private TextBox          txtCategory;
        private Label            lblPrice;
        private NumericUpDown    numPrice;
        private Label            lblStock;
        private NumericUpDown    numStock;
        private Button           btnAddProduct;
    }
}
