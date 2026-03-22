using MaterialSkin;
using MaterialSkin.Controls;
using ReportsLab.Forms;

namespace ReportsLab
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();

            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(
                Primary.Blue700, Primary.Blue900,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE);
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
