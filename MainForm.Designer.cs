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
            btnProducts = new MaterialButton();
            btnSales    = new MaterialButton();
            btnReports  = new MaterialButton();
            SuspendLayout();

            // btnProducts
            btnProducts.Text         = "PRODUCTS";
            btnProducts.Location     = new Point(100, 110);
            btnProducts.Size         = new Size(200, 40);
            btnProducts.Type         = MaterialButton.MaterialButtonType.Contained;
            btnProducts.HighEmphasis = true;
            btnProducts.Click       += btnProducts_Click;

            // btnSales
            btnSales.Text         = "SALES";
            btnSales.Location     = new Point(100, 165);
            btnSales.Size         = new Size(200, 40);
            btnSales.Type         = MaterialButton.MaterialButtonType.Contained;
            btnSales.HighEmphasis = true;
            btnSales.Click       += btnSales_Click;

            // btnReports
            btnReports.Text         = "REPORTS";
            btnReports.Location     = new Point(100, 220);
            btnReports.Size         = new Size(200, 40);
            btnReports.Type         = MaterialButton.MaterialButtonType.Contained;
            btnReports.HighEmphasis = true;
            btnReports.Click       += btnReports_Click;

            // MainForm
            ClientSize    = new Size(400, 340);
            StartPosition = FormStartPosition.CenterScreen;
            Text          = "Store Sales Management";
            Controls.AddRange(new Control[] { btnProducts, btnSales, btnReports });
            ResumeLayout(false);
        }

        private MaterialButton btnProducts;
        private MaterialButton btnSales;
        private MaterialButton btnReports;
    }
}
