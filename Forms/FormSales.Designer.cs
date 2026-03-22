using MaterialSkin.Controls;
using System.Windows.Forms;

namespace ReportsLab.Forms
{
    partial class FormSales
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            formLayout   = new TableLayoutPanel();
            pnlTop       = new Panel();
            btnRefresh   = new MaterialButton();
            dgvSales     = new DataGridView();
            fieldsCard   = new MaterialCard();
            lblStatus    = new MaterialLabel();
            cmbProduct   = new MaterialComboBox();
            lblDate      = new MaterialLabel();
            dtpSaleDate  = new DateTimePicker();
            lblQuantity  = new MaterialLabel();
            numQuantity  = new NumericUpDown();
            lblSalePrice = new MaterialLabel();
            numSalePrice = new NumericUpDown();
            btnAdd       = new MaterialButton();
            btnSave      = new MaterialButton();
            btnDelete    = new MaterialButton();
            btnClear     = new MaterialButton();
            formLayout.SuspendLayout();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            fieldsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).BeginInit();
            SuspendLayout();

            // formLayout
            formLayout.ColumnCount = 1;
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formLayout.Controls.Add(pnlTop,     0, 0);
            formLayout.Controls.Add(dgvSales,   0, 1);
            formLayout.Controls.Add(fieldsCard, 0, 2);
            formLayout.Dock     = DockStyle.Fill;
            formLayout.Location = new Point(3, 64);
            formLayout.Name     = "formLayout";
            formLayout.RowCount = 3;
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 172F));
            formLayout.Size     = new Size(814, 533);
            formLayout.TabIndex = 0;

            // pnlTop
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Dock     = DockStyle.Fill;
            pnlTop.Location = new Point(3, 3);
            pnlTop.Name     = "pnlTop";
            pnlTop.Size     = new Size(808, 40);
            pnlTop.TabIndex = 0;

            // btnRefresh
            btnRefresh.AutoSizeMode     = AutoSizeMode.GrowAndShrink;
            btnRefresh.Density          = MaterialButton.MaterialButtonDensity.Default;
            btnRefresh.Depth            = 0;
            btnRefresh.HighEmphasis     = false;
            btnRefresh.Icon             = null;
            btnRefresh.Location         = new Point(8, 8);
            btnRefresh.Margin           = new Padding(4, 6, 4, 6);
            btnRefresh.MouseState       = MaterialSkin.MouseState.HOVER;
            btnRefresh.Name             = "btnRefresh";
            btnRefresh.NoAccentTextColor = Color.Empty;
            btnRefresh.Size             = new Size(84, 36);
            btnRefresh.TabIndex         = 0;
            btnRefresh.Text             = "REFRESH";
            btnRefresh.Type             = MaterialButton.MaterialButtonType.Outlined;
            btnRefresh.UseAccentColor   = false;
            btnRefresh.Click           += btnRefresh_Click;

            // dgvSales
            dgvSales.AllowUserToAddRows  = false;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.BorderStyle         = BorderStyle.None;
            dgvSales.ColumnHeadersHeight = 29;
            dgvSales.Dock                = DockStyle.Fill;
            dgvSales.Location            = new Point(3, 49);
            dgvSales.MultiSelect         = false;
            dgvSales.Name                = "dgvSales";
            dgvSales.ReadOnly            = true;
            dgvSales.RowHeadersWidth     = 51;
            dgvSales.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.Size                = new Size(808, 309);
            dgvSales.TabIndex            = 1;
            dgvSales.SelectionChanged   += dgvSales_SelectionChanged;

            // fieldsCard
            // Margin=0 so the TLP row gives the card the full 172px (not 172-28=144).
            // Size must be set here (before PerformLayout below) so anchor distances
            // for child controls are calculated against the correct 814×172 reference.
            fieldsCard.Anchor     = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fieldsCard.BackColor  = Color.FromArgb(255, 255, 255);
            fieldsCard.Depth      = 0;
            fieldsCard.ForeColor  = Color.FromArgb(222, 0, 0, 0);
            fieldsCard.Location   = new Point(0, 361);
            fieldsCard.Margin     = new Padding(0);
            fieldsCard.MouseState = MaterialSkin.MouseState.HOVER;
            fieldsCard.Name       = "fieldsCard";
            fieldsCard.Padding    = new Padding(12, 6, 12, 6);
            fieldsCard.Size       = new Size(814, 172);
            fieldsCard.TabIndex   = 2;
            fieldsCard.Controls.Add(lblStatus);
            fieldsCard.Controls.Add(cmbProduct);
            fieldsCard.Controls.Add(lblDate);
            fieldsCard.Controls.Add(dtpSaleDate);
            fieldsCard.Controls.Add(lblQuantity);
            fieldsCard.Controls.Add(numQuantity);
            fieldsCard.Controls.Add(lblSalePrice);
            fieldsCard.Controls.Add(numSalePrice);
            fieldsCard.Controls.Add(btnAdd);
            fieldsCard.Controls.Add(btnSave);
            fieldsCard.Controls.Add(btnDelete);
            fieldsCard.Controls.Add(btnClear);

            // lblStatus — stretches full width
            lblStatus.Anchor     = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Depth      = 0;
            lblStatus.Font       = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStatus.FontType   = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblStatus.Location   = new Point(14, 6);
            lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            lblStatus.Name       = "lblStatus";
            lblStatus.Size       = new Size(786, 18);
            lblStatus.TabIndex   = 0;
            lblStatus.Text       = "New sale";

            // cmbProduct — stretches, right margin reserves space for date group
            // card width=814: right margin = 12(pad)+6(gap)+68(lbl)+6(gap)+142(dtp) = 234
            cmbProduct.Anchor                  = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbProduct.Depth                   = 0;
            cmbProduct.DropDownStyle           = ComboBoxStyle.DropDownList;
            cmbProduct.Hint                    = "Product";
            cmbProduct.Location                = new Point(12, 24);
            cmbProduct.MouseState              = MaterialSkin.MouseState.OUT;
            cmbProduct.Name                    = "cmbProduct";
            cmbProduct.Size                    = new Size(568, 48);
            cmbProduct.TabIndex                = 1;
            cmbProduct.SelectedIndexChanged   += cmbProduct_SelectedIndexChanged;

            // lblDate — pinned to right  (right dist = 814 - (586+68) = 160)
            lblDate.Anchor     = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.Depth      = 0;
            lblDate.Font       = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDate.FontType   = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblDate.Location   = new Point(586, 36);
            lblDate.MouseState = MaterialSkin.MouseState.HOVER;
            lblDate.Name       = "lblDate";
            lblDate.Size       = new Size(68, 23);
            lblDate.TabIndex   = 2;
            lblDate.Text       = "Sale Date:";

            // dtpSaleDate — pinned to right  (right dist = 814 - (660+142) = 12)
            dtpSaleDate.Anchor   = AnchorStyles.Top | AnchorStyles.Right;
            dtpSaleDate.Format   = DateTimePickerFormat.Short;
            dtpSaleDate.Location = new Point(660, 35);
            dtpSaleDate.Name     = "dtpSaleDate";
            dtpSaleDate.Size     = new Size(142, 27);
            dtpSaleDate.TabIndex = 3;
            dtpSaleDate.Value    = DateTime.Today;

            // Row 2 — fixed, left-anchored
            lblQuantity.Depth      = 0;
            lblQuantity.Font       = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblQuantity.FontType   = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblQuantity.Location   = new Point(14, 88);
            lblQuantity.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuantity.Name       = "lblQuantity";
            lblQuantity.Size       = new Size(38, 23);
            lblQuantity.TabIndex   = 4;
            lblQuantity.Text       = "Qty:";

            numQuantity.Location = new Point(55, 85);
            numQuantity.Maximum  = 9999;
            numQuantity.Minimum  = 1;
            numQuantity.Name     = "numQuantity";
            numQuantity.Size     = new Size(100, 27);
            numQuantity.TabIndex = 5;
            numQuantity.Value    = 1;

            lblSalePrice.Depth      = 0;
            lblSalePrice.Font       = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSalePrice.FontType   = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSalePrice.Location   = new Point(172, 88);
            lblSalePrice.MouseState = MaterialSkin.MouseState.HOVER;
            lblSalePrice.Name       = "lblSalePrice";
            lblSalePrice.Size       = new Size(75, 23);
            lblSalePrice.TabIndex   = 6;
            lblSalePrice.Text       = "Sale Price:";

            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Location      = new Point(250, 85);
            numSalePrice.Maximum       = new decimal(new int[] { 9999999, 0, 0, 131072 });
            numSalePrice.Name          = "numSalePrice";
            numSalePrice.Size          = new Size(120, 27);
            numSalePrice.TabIndex      = 7;

            // Buttons
            btnAdd.AutoSizeMode      = AutoSizeMode.GrowAndShrink;
            btnAdd.Density           = MaterialButton.MaterialButtonDensity.Default;
            btnAdd.Depth             = 0;
            btnAdd.HighEmphasis      = true;
            btnAdd.Icon              = null;
            btnAdd.Location          = new Point(12, 122);
            btnAdd.Margin            = new Padding(4, 6, 4, 6);
            btnAdd.MouseState        = MaterialSkin.MouseState.HOVER;
            btnAdd.Name              = "btnAdd";
            btnAdd.NoAccentTextColor = Color.Empty;
            btnAdd.Size              = new Size(64, 36);
            btnAdd.TabIndex          = 8;
            btnAdd.Text              = "ADD";
            btnAdd.Type              = MaterialButton.MaterialButtonType.Contained;
            btnAdd.UseAccentColor    = false;
            btnAdd.Click            += btnAdd_Click;

            btnSave.AutoSizeMode      = AutoSizeMode.GrowAndShrink;
            btnSave.Density           = MaterialButton.MaterialButtonDensity.Default;
            btnSave.Depth             = 0;
            btnSave.HighEmphasis      = true;
            btnSave.Icon              = null;
            btnSave.Location          = new Point(112, 122);
            btnSave.Margin            = new Padding(4, 6, 4, 6);
            btnSave.MouseState        = MaterialSkin.MouseState.HOVER;
            btnSave.Name              = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size              = new Size(64, 36);
            btnSave.TabIndex          = 9;
            btnSave.Text              = "SAVE";
            btnSave.Type              = MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor    = false;
            btnSave.Click            += btnSave_Click;

            btnDelete.AutoSizeMode      = AutoSizeMode.GrowAndShrink;
            btnDelete.Density           = MaterialButton.MaterialButtonDensity.Default;
            btnDelete.Depth             = 0;
            btnDelete.HighEmphasis      = true;
            btnDelete.Icon              = null;
            btnDelete.Location          = new Point(212, 122);
            btnDelete.Margin            = new Padding(4, 6, 4, 6);
            btnDelete.MouseState        = MaterialSkin.MouseState.HOVER;
            btnDelete.Name              = "btnDelete";
            btnDelete.NoAccentTextColor = Color.Empty;
            btnDelete.Size              = new Size(73, 36);
            btnDelete.TabIndex          = 10;
            btnDelete.Text              = "DELETE";
            btnDelete.Type              = MaterialButton.MaterialButtonType.Outlined;
            btnDelete.UseAccentColor    = false;
            btnDelete.Click            += btnDelete_Click;

            btnClear.AutoSizeMode      = AutoSizeMode.GrowAndShrink;
            btnClear.Density           = MaterialButton.MaterialButtonDensity.Default;
            btnClear.Depth             = 0;
            btnClear.HighEmphasis      = true;
            btnClear.Icon              = null;
            btnClear.Location          = new Point(312, 122);
            btnClear.Margin            = new Padding(4, 6, 4, 6);
            btnClear.MouseState        = MaterialSkin.MouseState.HOVER;
            btnClear.Name              = "btnClear";
            btnClear.NoAccentTextColor = Color.Empty;
            btnClear.Size              = new Size(66, 36);
            btnClear.TabIndex          = 11;
            btnClear.Text              = "CLEAR";
            btnClear.Type              = MaterialButton.MaterialButtonType.Text;
            btnClear.UseAccentColor    = false;
            btnClear.Click            += btnClear_Click;

            // FormSales
            ClientSize    = new Size(820, 600);
            Controls.Add(formLayout);
            MinimumSize   = new Size(560, 380);
            Name          = "FormSales";
            StartPosition = FormStartPosition.CenterParent;
            Text          = "Sales";
            Load         += FormSales_Load;
            formLayout.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            fieldsCard.ResumeLayout(false);
            fieldsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel                    formLayout;
        private System.Windows.Forms.Panel          pnlTop;
        private MaterialButton                      btnRefresh;
        private System.Windows.Forms.DataGridView   dgvSales;
        private MaterialCard                        fieldsCard;
        private MaterialLabel                       lblStatus;
        private MaterialComboBox                    cmbProduct;
        private MaterialLabel                       lblDate;
        private System.Windows.Forms.DateTimePicker dtpSaleDate;
        private MaterialLabel                       lblQuantity;
        private System.Windows.Forms.NumericUpDown  numQuantity;
        private MaterialLabel                       lblSalePrice;
        private System.Windows.Forms.NumericUpDown  numSalePrice;
        private MaterialButton                      btnAdd;
        private MaterialButton                      btnSave;
        private MaterialButton                      btnDelete;
        private MaterialButton                      btnClear;
    }
}
