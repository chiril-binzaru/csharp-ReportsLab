using MaterialSkin.Controls;

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
            cmbReport     = new MaterialComboBox();
            lblFrom       = new MaterialLabel();
            dtpFrom       = new System.Windows.Forms.DateTimePicker();
            lblTo         = new MaterialLabel();
            dtpTo         = new System.Windows.Forms.DateTimePicker();
            btnGenerate   = new MaterialButton();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();

            // ── pnlTop ───────────────────────────────────────────────────────────
            pnlTop.Dock   = System.Windows.Forms.DockStyle.Top;
            pnlTop.Height = 72;
            pnlTop.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                cmbReport, lblFrom, dtpFrom, lblTo, dtpTo, btnGenerate
            });

            // cmbReport
            cmbReport.Hint                  = "Report Type";
            cmbReport.Location              = new Point(10, 12);
            cmbReport.Size                  = new Size(230, 48);
            cmbReport.DropDownStyle         = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbReport.SelectedIndexChanged += cmbReport_SelectedIndexChanged;

            // lblFrom (hidden unless Sales by Period)
            lblFrom.Text      = "From:";
            lblFrom.Location  = new Point(256, 30);
            lblFrom.Size      = new Size(42, 23);
            lblFrom.FontType  = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblFrom.Visible   = false;

            // dtpFrom
            dtpFrom.Location = new Point(301, 28);
            dtpFrom.Size     = new Size(140, 23);
            dtpFrom.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFrom.Value    = DateTime.Today.AddMonths(-1);
            dtpFrom.Visible  = false;

            // lblTo
            lblTo.Text     = "To:";
            lblTo.Location = new Point(452, 30);
            lblTo.Size     = new Size(28, 23);
            lblTo.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblTo.Visible  = false;

            // dtpTo
            dtpTo.Location = new Point(483, 28);
            dtpTo.Size     = new Size(140, 23);
            dtpTo.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpTo.Value    = DateTime.Today;
            dtpTo.Visible  = false;

            // btnGenerate
            btnGenerate.Text         = "GENERATE REPORT";
            btnGenerate.Location     = new Point(820, 18);
            btnGenerate.Size         = new Size(170, 36);
            btnGenerate.Type         = MaterialButton.MaterialButtonType.Contained;
            btnGenerate.HighEmphasis = true;
            btnGenerate.Click       += btnGenerate_Click;

            // ── reportViewer1 ────────────────────────────────────────────────────
            reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

            // ── FormReports ──────────────────────────────────────────────────────
            ClientSize    = new Size(1020, 700);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text          = "Reports";
            Controls.Add(reportViewer1);
            Controls.Add(pnlTop);
            Load += FormReports_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlTop;
        private MaterialComboBox                    cmbReport;
        private MaterialLabel                       lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private MaterialLabel                       lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private MaterialButton                      btnGenerate;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
