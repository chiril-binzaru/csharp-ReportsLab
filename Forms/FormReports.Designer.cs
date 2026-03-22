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
            pnlTop        = new Panel();
            lblReport     = new Label();
            cmbReport     = new ComboBox();
            lblFrom       = new Label();
            dtpFrom       = new DateTimePicker();
            lblTo         = new Label();
            dtpTo         = new DateTimePicker();
            btnGenerate   = new Button();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();

            // ── pnlTop ───────────────────────────────────────────────────────────
            pnlTop.Dock    = DockStyle.Top;
            pnlTop.Height  = 58;
            pnlTop.Controls.AddRange(new Control[]
            {
                lblReport, cmbReport,
                lblFrom, dtpFrom,
                lblTo,   dtpTo,
                btnGenerate
            });

            // lblReport
            lblReport.Text      = "Report:";
            lblReport.Location  = new Point(10, 18);
            lblReport.Size      = new Size(52, 23);
            lblReport.TextAlign = ContentAlignment.MiddleLeft;

            // cmbReport
            cmbReport.Location      = new Point(64, 15);
            cmbReport.Size          = new Size(190, 23);
            cmbReport.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReport.SelectedIndexChanged += cmbReport_SelectedIndexChanged;

            // lblFrom (hidden unless Report 2 is selected)
            lblFrom.Text      = "From:";
            lblFrom.Location  = new Point(268, 18);
            lblFrom.Size      = new Size(44, 23);
            lblFrom.TextAlign = ContentAlignment.MiddleLeft;
            lblFrom.Visible   = false;

            // dtpFrom
            dtpFrom.Location = new Point(314, 15);
            dtpFrom.Size     = new Size(130, 23);
            dtpFrom.Format   = DateTimePickerFormat.Short;
            dtpFrom.Value    = DateTime.Today.AddMonths(-1);
            dtpFrom.Visible  = false;

            // lblTo
            lblTo.Text      = "To:";
            lblTo.Location  = new Point(454, 18);
            lblTo.Size      = new Size(26, 23);
            lblTo.TextAlign = ContentAlignment.MiddleLeft;
            lblTo.Visible   = false;

            // dtpTo
            dtpTo.Location = new Point(482, 15);
            dtpTo.Size     = new Size(130, 23);
            dtpTo.Format   = DateTimePickerFormat.Short;
            dtpTo.Value    = DateTime.Today;
            dtpTo.Visible  = false;

            // btnGenerate
            btnGenerate.Text     = "Generate Report";
            btnGenerate.Location = new Point(820, 13);
            btnGenerate.Size     = new Size(130, 30);
            btnGenerate.Click   += btnGenerate_Click;

            // ── reportViewer1 ────────────────────────────────────────────────────
            reportViewer1.Dock = DockStyle.Fill;

            // ── FormReports ──────────────────────────────────────────────────────
            ClientSize    = new Size(980, 680);
            StartPosition = FormStartPosition.CenterParent;
            Text          = "Reports";
            Controls.Add(reportViewer1);   // add Fill control first
            Controls.Add(pnlTop);          // then Top panel (paints over fill top edge)
            Load += FormReports_Load;
            ResumeLayout(false);
        }

        private Panel                                pnlTop;
        private Label                                lblReport;
        private ComboBox                             cmbReport;
        private Label                                lblFrom;
        private DateTimePicker                       dtpFrom;
        private Label                                lblTo;
        private DateTimePicker                       dtpTo;
        private Button                               btnGenerate;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
