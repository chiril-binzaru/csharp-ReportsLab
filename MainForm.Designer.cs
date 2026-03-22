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
            lblTitle    = new Label();
            btnProducts = new Button();
            btnSales    = new Button();
            btnReports  = new Button();
            SuspendLayout();

            // lblTitle
            lblTitle.Text      = "Store Sales Management";
            lblTitle.Font      = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location  = new Point(50, 35);
            lblTitle.Size      = new Size(300, 45);

            // btnProducts
            btnProducts.Text     = "Products";
            btnProducts.Location = new Point(125, 115);
            btnProducts.Size     = new Size(150, 45);
            btnProducts.Font     = new Font("Segoe UI", 10F);
            btnProducts.Click   += btnProducts_Click;

            // btnSales
            btnSales.Text     = "Sales";
            btnSales.Location = new Point(125, 175);
            btnSales.Size     = new Size(150, 45);
            btnSales.Font     = new Font("Segoe UI", 10F);
            btnSales.Click   += btnSales_Click;

            // btnReports
            btnReports.Text     = "Reports";
            btnReports.Location = new Point(125, 235);
            btnReports.Size     = new Size(150, 45);
            btnReports.Font     = new Font("Segoe UI", 10F);
            btnReports.Click   += btnReports_Click;

            // MainForm
            ClientSize        = new Size(400, 325);
            FormBorderStyle   = FormBorderStyle.FixedSingle;
            MaximizeBox       = false;
            StartPosition     = FormStartPosition.CenterScreen;
            Text              = "Store Sales Management";
            Controls.AddRange(new Control[] { lblTitle, btnProducts, btnSales, btnReports });
            ResumeLayout(false);
        }

        private Label  lblTitle;
        private Button btnProducts;
        private Button btnSales;
        private Button btnReports;
    }
}
