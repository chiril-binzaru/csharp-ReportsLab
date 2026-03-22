using ReportsLab.Forms;

namespace ReportsLab
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            using var form = new FormProducts();
            form.ShowDialog(this);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            using var form = new FormSales();
            form.ShowDialog(this);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            using var form = new FormReports();
            form.ShowDialog(this);
        }
    }
}
