using MaterialSkin.Controls;
using System.Windows.Forms;

namespace ReportsLab.Forms
{
    partial class FormReports
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop        = new System.Windows.Forms.Panel();
            tblTop        = new TableLayoutPanel();
            pnlControls   = new System.Windows.Forms.Panel();
            cmbReport     = new MaterialComboBox();
            lblFrom       = new MaterialLabel();
            dtpFrom       = new System.Windows.Forms.DateTimePicker();
            lblTo         = new MaterialLabel();
            dtpTo         = new System.Windows.Forms.DateTimePicker();
            lblCategory   = new MaterialLabel();
            cmbCategory   = new MaterialComboBox();
            lblProduct      = new MaterialLabel();
            cmbProduct      = new MaterialComboBox();
            lblMultiCat     = new MaterialLabel();
            clbCategories   = new System.Windows.Forms.CheckedListBox();
            pnlGenerate     = new System.Windows.Forms.Panel();
            btnGenerate   = new MaterialButton();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();

            // ── pnlTop ───────────────────────────────────────────────────────────
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Height = 72;
            pnlTop.Controls.Add(tblTop);

            // ── tblTop (splits toolbar: stretching left area | fixed right button) ─
            tblTop.Dock        = System.Windows.Forms.DockStyle.Fill;
            tblTop.ColumnCount = 2;
            tblTop.RowCount    = 1;
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // left: controls
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 196)); // right: generate
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tblTop.Controls.Add(pnlControls, 0, 0);
            tblTop.Controls.Add(pnlGenerate, 1, 0);

            // ── pnlControls (report selector + optional date pickers) ─────────────
            pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlControls.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                cmbReport, lblFrom, dtpFrom, lblTo, dtpTo,
                lblCategory, cmbCategory, lblProduct, cmbProduct,
                lblMultiCat, clbCategories
            });

            cmbReport.Hint                  = "Report Type";
            cmbReport.Location              = new Point(10, 12);
            cmbReport.Size                  = new Size(280, 48);
            cmbReport.Anchor                = AnchorStyles.Top | AnchorStyles.Left;
            cmbReport.DropDownStyle         = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbReport.SelectedIndexChanged += cmbReport_SelectedIndexChanged;

            lblFrom.Text      = "From:";
            lblFrom.Location  = new Point(296, 30);
            lblFrom.Size      = new Size(42, 23);
            lblFrom.Anchor    = AnchorStyles.Top | AnchorStyles.Left;
            lblFrom.FontType  = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblFrom.Visible   = false;

            dtpFrom.Location = new Point(341, 28);
            dtpFrom.Size     = new Size(140, 23);
            dtpFrom.Anchor   = AnchorStyles.Top | AnchorStyles.Left;
            dtpFrom.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFrom.Value    = DateTime.Today.AddMonths(-1);
            dtpFrom.Visible  = false;

            lblTo.Text     = "To:";
            lblTo.Location = new Point(492, 30);
            lblTo.Size     = new Size(28, 23);
            lblTo.Anchor   = AnchorStyles.Top | AnchorStyles.Left;
            lblTo.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblTo.Visible  = false;

            dtpTo.Location = new Point(523, 28);
            dtpTo.Size     = new Size(140, 23);
            dtpTo.Anchor   = AnchorStyles.Top | AnchorStyles.Left;
            dtpTo.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpTo.Value    = DateTime.Today;
            dtpTo.Visible  = false;

            lblCategory.Text     = "Category:";
            lblCategory.Location = new Point(296, 30);
            lblCategory.Size     = new Size(68, 23);
            lblCategory.Anchor   = AnchorStyles.Top | AnchorStyles.Left;
            lblCategory.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblCategory.Visible  = false;

            cmbCategory.Hint                  = "Category";
            cmbCategory.Location              = new Point(368, 14);
            cmbCategory.Size                  = new Size(200, 48);
            cmbCategory.Anchor                = AnchorStyles.Top | AnchorStyles.Left;
            cmbCategory.DropDownStyle         = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCategory.Visible               = false;

            lblProduct.Text     = "Product:";
            lblProduct.Location = new Point(296, 30);
            lblProduct.Size     = new Size(62, 23);
            lblProduct.Anchor   = AnchorStyles.Top | AnchorStyles.Left;
            lblProduct.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblProduct.Visible  = false;

            cmbProduct.Hint                  = "Product";
            cmbProduct.Location              = new Point(362, 14);
            cmbProduct.Size                  = new Size(230, 48);
            cmbProduct.Anchor                = AnchorStyles.Top | AnchorStyles.Left;
            cmbProduct.DropDownStyle         = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbProduct.Visible               = false;

            lblMultiCat.Text     = "Categories:";
            lblMultiCat.Location = new Point(296, 16);
            lblMultiCat.Size     = new Size(78, 23);
            lblMultiCat.Anchor   = AnchorStyles.Top | AnchorStyles.Left;
            lblMultiCat.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblMultiCat.Visible  = false;

            clbCategories.Location        = new Point(378, 10);
            clbCategories.Size            = new Size(220, 52);
            clbCategories.Anchor          = AnchorStyles.Top | AnchorStyles.Left;
            clbCategories.CheckOnClick    = true;
            clbCategories.Visible         = false;

            // ── pnlGenerate (holds the Generate button, always right-aligned) ──────
            pnlGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlGenerate.Controls.Add(btnGenerate);

            btnGenerate.Text         = "GENERATE REPORT";
            btnGenerate.Location     = new Point(12, 18);
            btnGenerate.Size         = new Size(170, 36);
            btnGenerate.Anchor       = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnGenerate.Type         = MaterialButton.MaterialButtonType.Contained;
            btnGenerate.HighEmphasis = true;
            btnGenerate.Click       += btnGenerate_Click;

            // ── reportViewer1 ────────────────────────────────────────────────────
            reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

            // ── FormReports ───────────────────────────────────────────────────────
            ClientSize    = new Size(1020, 700);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text          = "Reports";
            Controls.Add(reportViewer1);
            Controls.Add(pnlTop);
            Load += FormReports_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlTop;
        private TableLayoutPanel                    tblTop;
        private System.Windows.Forms.Panel          pnlControls;
        private MaterialComboBox                    cmbReport;
        private MaterialLabel                       lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private MaterialLabel                       lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private MaterialLabel                       lblCategory;
        private MaterialComboBox                    cmbCategory;
        private MaterialLabel                       lblProduct;
        private MaterialComboBox                    cmbProduct;
        private MaterialLabel                       lblMultiCat;
        private System.Windows.Forms.CheckedListBox clbCategories;
        private System.Windows.Forms.Panel          pnlGenerate;
        private MaterialButton                      btnGenerate;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
