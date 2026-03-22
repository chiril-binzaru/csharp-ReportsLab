using MaterialSkin.Controls;
using System.Windows.Forms;

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
            formLayout = new TableLayoutPanel();
            pnlTop = new Panel();
            btnRefresh = new MaterialButton();
            dgvProducts = new DataGridView();
            fieldsCard = new MaterialCard();
            lblStatus = new MaterialLabel();
            txtProductName = new MaterialTextBox();
            txtCategory = new MaterialTextBox();
            lblPrice = new MaterialLabel();
            numPrice = new NumericUpDown();
            lblStock = new MaterialLabel();
            numStock = new NumericUpDown();
            btnAdd = new MaterialButton();
            btnSave = new MaterialButton();
            btnDelete = new MaterialButton();
            btnClear = new MaterialButton();
            formLayout.SuspendLayout();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            fieldsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            SuspendLayout();
            // 
            // formLayout
            // 
            formLayout.ColumnCount = 1;
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formLayout.Controls.Add(pnlTop, 0, 0);
            formLayout.Controls.Add(dgvProducts, 0, 1);
            formLayout.Controls.Add(fieldsCard, 0, 2);
            formLayout.Dock = DockStyle.Fill;
            formLayout.Location = new Point(3, 64);
            formLayout.Name = "formLayout";
            formLayout.RowCount = 3;
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 172F));
            formLayout.Size = new Size(774, 533);
            formLayout.TabIndex = 0;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Dock = DockStyle.Fill;
            pnlTop.Location = new Point(3, 3);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(768, 40);
            pnlTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRefresh.Density = MaterialButton.MaterialButtonDensity.Default;
            btnRefresh.Depth = 0;
            btnRefresh.HighEmphasis = false;
            btnRefresh.Icon = null;
            btnRefresh.Location = new Point(8, 8);
            btnRefresh.Margin = new Padding(4, 6, 4, 6);
            btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.NoAccentTextColor = Color.Empty;
            btnRefresh.Size = new Size(84, 36);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "REFRESH";
            btnRefresh.Type = MaterialButton.MaterialButtonType.Outlined;
            btnRefresh.UseAccentColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(3, 49);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(768, 309);
            dgvProducts.TabIndex = 1;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // fieldsCard
            // 
            fieldsCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fieldsCard.BackColor = Color.FromArgb(255, 255, 255);
            fieldsCard.Controls.Add(lblStatus);
            fieldsCard.Controls.Add(txtProductName);
            fieldsCard.Controls.Add(txtCategory);
            fieldsCard.Controls.Add(lblPrice);
            fieldsCard.Controls.Add(numPrice);
            fieldsCard.Controls.Add(lblStock);
            fieldsCard.Controls.Add(numStock);
            fieldsCard.Controls.Add(btnAdd);
            fieldsCard.Controls.Add(btnSave);
            fieldsCard.Controls.Add(btnDelete);
            fieldsCard.Controls.Add(btnClear);
            fieldsCard.Depth = 0;
            fieldsCard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            fieldsCard.Location = new Point(14, 375);
            fieldsCard.Margin = new Padding(0);
            fieldsCard.MouseState = MaterialSkin.MouseState.HOVER;
            fieldsCard.Name = "fieldsCard";
            fieldsCard.Padding = new Padding(12, 6, 12, 6);
            fieldsCard.Size = new Size(774, 172);
            fieldsCard.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Depth = 0;
            lblStatus.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStatus.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblStatus.Location = new Point(14, 6);
            lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(746, 18);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "New product";
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProductName.AnimateReadOnly = false;
            txtProductName.BorderStyle = BorderStyle.None;
            txtProductName.Depth = 0;
            txtProductName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProductName.Hint = "Product Name";
            txtProductName.LeadingIcon = null;
            txtProductName.Location = new Point(12, 24);
            txtProductName.MaxLength = 50;
            txtProductName.MouseState = MaterialSkin.MouseState.OUT;
            txtProductName.Multiline = false;
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(422, 48);
            txtProductName.TabIndex = 1;
            txtProductName.Text = "";
            txtProductName.TrailingIcon = null;
            // 
            // txtCategory
            // 
            txtCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCategory.AnimateReadOnly = false;
            txtCategory.BorderStyle = BorderStyle.None;
            txtCategory.Depth = 0;
            txtCategory.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCategory.Hint = "Category";
            txtCategory.LeadingIcon = null;
            txtCategory.Location = new Point(440, 24);
            txtCategory.MaxLength = 50;
            txtCategory.MouseState = MaterialSkin.MouseState.OUT;
            txtCategory.Multiline = false;
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(322, 48);
            txtCategory.TabIndex = 2;
            txtCategory.Text = "";
            txtCategory.TrailingIcon = null;
            // 
            // lblPrice
            // 
            lblPrice.Depth = 0;
            lblPrice.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPrice.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblPrice.Location = new Point(14, 87);
            lblPrice.MouseState = MaterialSkin.MouseState.HOVER;
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(46, 23);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Price:";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(63, 84);
            numPrice.Maximum = new decimal(new int[] { 9999999, 0, 0, 131072 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(120, 27);
            numPrice.TabIndex = 4;
            // 
            // lblStock
            // 
            lblStock.Depth = 0;
            lblStock.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStock.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblStock.Location = new Point(200, 87);
            lblStock.MouseState = MaterialSkin.MouseState.HOVER;
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(50, 23);
            lblStock.TabIndex = 5;
            lblStock.Text = "Stock:";
            // 
            // numStock
            // 
            numStock.Location = new Point(253, 84);
            numStock.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(100, 27);
            numStock.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAdd.Density = MaterialButton.MaterialButtonDensity.Default;
            btnAdd.Depth = 0;
            btnAdd.HighEmphasis = true;
            btnAdd.Icon = null;
            btnAdd.Location = new Point(12, 122);
            btnAdd.Margin = new Padding(4, 6, 4, 6);
            btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            btnAdd.Name = "btnAdd";
            btnAdd.NoAccentTextColor = Color.Empty;
            btnAdd.Size = new Size(64, 36);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "ADD";
            btnAdd.Type = MaterialButton.MaterialButtonType.Contained;
            btnAdd.UseAccentColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.Density = MaterialButton.MaterialButtonDensity.Default;
            btnSave.Depth = 0;
            btnSave.HighEmphasis = true;
            btnSave.Icon = null;
            btnSave.Location = new Point(112, 122);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            btnSave.Name = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size = new Size(64, 36);
            btnSave.TabIndex = 8;
            btnSave.Text = "SAVE";
            btnSave.Type = MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDelete.Density = MaterialButton.MaterialButtonDensity.Default;
            btnDelete.Depth = 0;
            btnDelete.HighEmphasis = true;
            btnDelete.Icon = null;
            btnDelete.Location = new Point(212, 122);
            btnDelete.Margin = new Padding(4, 6, 4, 6);
            btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            btnDelete.Name = "btnDelete";
            btnDelete.NoAccentTextColor = Color.Empty;
            btnDelete.Size = new Size(73, 36);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "DELETE";
            btnDelete.Type = MaterialButton.MaterialButtonType.Outlined;
            btnDelete.UseAccentColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClear.Density = MaterialButton.MaterialButtonDensity.Default;
            btnClear.Depth = 0;
            btnClear.HighEmphasis = true;
            btnClear.Icon = null;
            btnClear.Location = new Point(312, 122);
            btnClear.Margin = new Padding(4, 6, 4, 6);
            btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            btnClear.Name = "btnClear";
            btnClear.NoAccentTextColor = Color.Empty;
            btnClear.Size = new Size(66, 36);
            btnClear.TabIndex = 10;
            btnClear.Text = "CLEAR";
            btnClear.Type = MaterialButton.MaterialButtonType.Text;
            btnClear.UseAccentColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // FormProducts
            // 
            ClientSize = new Size(780, 600);
            Controls.Add(formLayout);
            MinimumSize = new Size(560, 380);
            Name = "FormProducts";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Products";
            Load += FormProducts_Load;
            formLayout.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            fieldsCard.ResumeLayout(false);
            fieldsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel                   formLayout;
        private System.Windows.Forms.Panel         pnlTop;
        private MaterialButton                     btnRefresh;
        private System.Windows.Forms.DataGridView  dgvProducts;
        private MaterialCard                       fieldsCard;
        private MaterialLabel                      lblStatus;
        private MaterialTextBox                    txtProductName;
        private MaterialTextBox                    txtCategory;
        private MaterialLabel                      lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private MaterialLabel                      lblStock;
        private System.Windows.Forms.NumericUpDown numStock;
        private MaterialButton                     btnAdd;
        private MaterialButton                     btnSave;
        private MaterialButton                     btnDelete;
        private MaterialButton                     btnClear;
    }
}
