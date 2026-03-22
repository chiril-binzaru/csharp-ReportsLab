using MaterialSkin.Controls;

namespace ReportsLab
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainLayout  = new TableLayoutPanel();
            pnlButtons  = new Panel();
            btnProducts = new MaterialButton();
            btnSales    = new MaterialButton();
            btnReports  = new MaterialButton();
            mainLayout.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // mainLayout — 3 rows: top spacer | buttons | bottom spacer
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 144F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainLayout.Controls.Add(pnlButtons, 0, 1);
            mainLayout.Dock     = DockStyle.Fill;
            mainLayout.Name     = "mainLayout";
            mainLayout.TabIndex = 0;

            // pnlButtons — Anchor=None centers it horizontally in the TLP cell
            pnlButtons.Anchor   = AnchorStyles.None;
            pnlButtons.Name     = "pnlButtons";
            pnlButtons.Size     = new Size(200, 144);
            pnlButtons.TabIndex = 0;
            pnlButtons.Controls.Add(btnProducts);
            pnlButtons.Controls.Add(btnSales);
            pnlButtons.Controls.Add(btnReports);

            // btnProducts
            btnProducts.AutoSizeMode     = AutoSizeMode.GrowOnly;
            btnProducts.Density          = MaterialButton.MaterialButtonDensity.Default;
            btnProducts.Depth            = 0;
            btnProducts.HighEmphasis     = true;
            btnProducts.Icon             = null;
            btnProducts.Location         = new Point(0, 0);
            btnProducts.Margin           = new Padding(4, 6, 4, 6);
            btnProducts.MouseState       = MaterialSkin.MouseState.HOVER;
            btnProducts.Name             = "btnProducts";
            btnProducts.NoAccentTextColor = Color.Empty;
            btnProducts.Size             = new Size(200, 36);
            btnProducts.TabIndex         = 0;
            btnProducts.Text             = "PRODUCTS";
            btnProducts.Type             = MaterialButton.MaterialButtonType.Contained;
            btnProducts.UseAccentColor   = false;
            btnProducts.Click           += btnProducts_Click;

            // btnSales
            btnSales.AutoSizeMode     = AutoSizeMode.GrowOnly;
            btnSales.Density          = MaterialButton.MaterialButtonDensity.Default;
            btnSales.Depth            = 0;
            btnSales.HighEmphasis     = true;
            btnSales.Icon             = null;
            btnSales.Location         = new Point(0, 50);
            btnSales.Margin           = new Padding(4, 6, 4, 6);
            btnSales.MouseState       = MaterialSkin.MouseState.HOVER;
            btnSales.Name             = "btnSales";
            btnSales.NoAccentTextColor = Color.Empty;
            btnSales.Size             = new Size(200, 36);
            btnSales.TabIndex         = 1;
            btnSales.Text             = "SALES";
            btnSales.Type             = MaterialButton.MaterialButtonType.Contained;
            btnSales.UseAccentColor   = false;
            btnSales.Click           += btnSales_Click;

            // btnReports
            btnReports.AutoSizeMode     = AutoSizeMode.GrowOnly;
            btnReports.Density          = MaterialButton.MaterialButtonDensity.Default;
            btnReports.Depth            = 0;
            btnReports.HighEmphasis     = true;
            btnReports.Icon             = null;
            btnReports.Location         = new Point(0, 100);
            btnReports.Margin           = new Padding(4, 6, 4, 6);
            btnReports.MouseState       = MaterialSkin.MouseState.HOVER;
            btnReports.Name             = "btnReports";
            btnReports.NoAccentTextColor = Color.Empty;
            btnReports.Size             = new Size(200, 36);
            btnReports.TabIndex         = 2;
            btnReports.Text             = "REPORTS";
            btnReports.Type             = MaterialButton.MaterialButtonType.Contained;
            btnReports.UseAccentColor   = false;
            btnReports.Click           += btnReports_Click;

            // MainForm
            ClientSize    = new Size(400, 362);
            Controls.Add(mainLayout);
            MaximumSize   = new Size(400, 362);
            MinimumSize   = new Size(400, 362);
            Name          = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text          = "Store Sales Management";
            mainLayout.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel mainLayout;
        private Panel             pnlButtons;
        private MaterialButton    btnProducts;
        private MaterialButton    btnSales;
        private MaterialButton    btnReports;
    }
}
