namespace QuanLyHocSinhTHPT.GUI
{
    partial class ucQuanLyDiemDanh
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.dt_NgayDiemDanh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_lammoi = new Guna.UI2.WinForms.Guna2Button();
            this.cbb_lop = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDanhSach = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gridDanhSach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnThongTin = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.cbb_trangthai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btn_huy = new Guna.UI2.WinForms.Guna2Button();
            this.btn_luu = new Guna.UI2.WinForms.Guna2Button();
            this.txt_diem15p_lan1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblThongTinChiTiet = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_mahs = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel1.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSach)).BeginInit();
            this.pnThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTieuDe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1768, 101);
            this.panel1.TabIndex = 20;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Arial", 35F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblTieuDe.Location = new System.Drawing.Point(89, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(524, 66);
            this.lblTieuDe.TabIndex = 14;
            this.lblTieuDe.Text = "Quản lý điểm danh";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.Controls.Add(this.dt_NgayDiemDanh);
            this.guna2GradientPanel1.Controls.Add(this.btn_lammoi);
            this.guna2GradientPanel1.Controls.Add(this.cbb_lop);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel1.Controls.Add(this.lblDanhSach);
            this.guna2GradientPanel1.Controls.Add(this.gridDanhSach);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(37, 132);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.BorderRadius = 0;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1154, 780);
            this.guna2GradientPanel1.TabIndex = 21;
            // 
            // dt_NgayDiemDanh
            // 
            this.dt_NgayDiemDanh.Checked = true;
            this.dt_NgayDiemDanh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dt_NgayDiemDanh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_NgayDiemDanh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_NgayDiemDanh.Location = new System.Drawing.Point(250, 102);
            this.dt_NgayDiemDanh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dt_NgayDiemDanh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dt_NgayDiemDanh.Name = "dt_NgayDiemDanh";
            this.dt_NgayDiemDanh.Size = new System.Drawing.Size(200, 36);
            this.dt_NgayDiemDanh.TabIndex = 44;
            this.dt_NgayDiemDanh.Value = new System.DateTime(2026, 5, 5, 19, 20, 41, 187);
            this.dt_NgayDiemDanh.ValueChanged += new System.EventHandler(this.dt_NgayDiemDanh_ValueChanged);
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.BorderRadius = 10;
            this.btn_lammoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_lammoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_lammoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_lammoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_lammoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(107)))));
            this.btn_lammoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_lammoi.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_lammoi.Location = new System.Drawing.Point(978, 24);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(164, 49);
            this.btn_lammoi.TabIndex = 28;
            this.btn_lammoi.Text = "Làm mới";
            // 
            // cbb_lop
            // 
            this.cbb_lop.BackColor = System.Drawing.Color.Transparent;
            this.cbb_lop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_lop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_lop.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_lop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_lop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_lop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_lop.ItemHeight = 30;
            this.cbb_lop.Location = new System.Drawing.Point(574, 102);
            this.cbb_lop.Name = "cbb_lop";
            this.cbb_lop.Size = new System.Drawing.Size(107, 36);
            this.cbb_lop.TabIndex = 40;
            this.cbb_lop.SelectedIndexChanged += new System.EventHandler(this.cbb_lop_SelectedIndexChanged);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(502, 104);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(108, 31);
            this.guna2HtmlLabel3.TabIndex = 39;
            this.guna2HtmlLabel3.Text = "Lớp";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(29, 102);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(285, 31);
            this.guna2HtmlLabel1.TabIndex = 35;
            this.guna2HtmlLabel1.Text = "Ngày điểm danh";
            // 
            // lblDanhSach
            // 
            this.lblDanhSach.AutoSize = false;
            this.lblDanhSach.BackColor = System.Drawing.Color.White;
            this.lblDanhSach.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblDanhSach.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblDanhSach.Location = new System.Drawing.Point(40, 24);
            this.lblDanhSach.Name = "lblDanhSach";
            this.lblDanhSach.Size = new System.Drawing.Size(615, 49);
            this.lblDanhSach.TabIndex = 26;
            this.lblDanhSach.TabStop = false;
            this.lblDanhSach.Text = "Danh sách điểm danh";
            // 
            // gridDanhSach
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gridDanhSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDanhSach.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDanhSach.ColumnHeadersHeight = 20;
            this.gridDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDanhSach.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridDanhSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridDanhSach.Location = new System.Drawing.Point(29, 164);
            this.gridDanhSach.Name = "gridDanhSach";
            this.gridDanhSach.ReadOnly = true;
            this.gridDanhSach.RowHeadersVisible = false;
            this.gridDanhSach.RowHeadersWidth = 51;
            this.gridDanhSach.RowTemplate.Height = 24;
            this.gridDanhSach.Size = new System.Drawing.Size(1102, 515);
            this.gridDanhSach.TabIndex = 8;
            this.gridDanhSach.TabStop = false;
            this.gridDanhSach.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gridDanhSach.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridDanhSach.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridDanhSach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridDanhSach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridDanhSach.ThemeStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.gridDanhSach.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridDanhSach.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gridDanhSach.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridDanhSach.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDanhSach.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridDanhSach.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gridDanhSach.ThemeStyle.HeaderStyle.Height = 20;
            this.gridDanhSach.ThemeStyle.ReadOnly = true;
            this.gridDanhSach.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gridDanhSach.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridDanhSach.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDanhSach.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridDanhSach.ThemeStyle.RowsStyle.Height = 24;
            this.gridDanhSach.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridDanhSach.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDanhSach_CellClick);
            this.gridDanhSach.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridDanhSach_CellFormatting);
            this.gridDanhSach.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDanhSach_CellValueChanged);
            this.gridDanhSach.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridDanhSach_CurrentCellDirtyStateChanged);
            // 
            // pnThongTin
            // 
            this.pnThongTin.BackColor = System.Drawing.Color.Transparent;
            this.pnThongTin.BorderRadius = 10;
            this.pnThongTin.Controls.Add(this.cbb_trangthai);
            this.pnThongTin.Controls.Add(this.btn_huy);
            this.pnThongTin.Controls.Add(this.btn_luu);
            this.pnThongTin.Controls.Add(this.txt_diem15p_lan1);
            this.pnThongTin.Controls.Add(this.guna2HtmlLabel5);
            this.pnThongTin.Controls.Add(this.guna2HtmlLabel6);
            this.pnThongTin.Controls.Add(this.lblThongTinChiTiet);
            this.pnThongTin.Controls.Add(this.txt_mahs);
            this.pnThongTin.Controls.Add(this.guna2HtmlLabel11);
            this.pnThongTin.FillColor = System.Drawing.Color.White;
            this.pnThongTin.FillColor2 = System.Drawing.Color.White;
            this.pnThongTin.Location = new System.Drawing.Point(1212, 132);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(517, 716);
            this.pnThongTin.TabIndex = 22;
            // 
            // cbb_trangthai
            // 
            this.cbb_trangthai.BackColor = System.Drawing.Color.Transparent;
            this.cbb_trangthai.BorderRadius = 10;
            this.cbb_trangthai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_trangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_trangthai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_trangthai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_trangthai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_trangthai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_trangthai.ItemHeight = 30;
            this.cbb_trangthai.Location = new System.Drawing.Point(167, 158);
            this.cbb_trangthai.Name = "cbb_trangthai";
            this.cbb_trangthai.Size = new System.Drawing.Size(218, 36);
            this.cbb_trangthai.TabIndex = 45;
            // 
            // btn_huy
            // 
            this.btn_huy.BorderRadius = 10;
            this.btn_huy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_huy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_huy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_huy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_huy.FillColor = System.Drawing.Color.Silver;
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_huy.ForeColor = System.Drawing.Color.White;
            this.btn_huy.Location = new System.Drawing.Point(291, 626);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(173, 53);
            this.btn_huy.TabIndex = 41;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.BorderRadius = 10;
            this.btn_luu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_luu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_luu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_luu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_luu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(107)))));
            this.btn_luu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_luu.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_luu.Location = new System.Drawing.Point(97, 626);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(172, 53);
            this.btn_luu.TabIndex = 40;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // txt_diem15p_lan1
            // 
            this.txt_diem15p_lan1.AutoSize = true;
            this.txt_diem15p_lan1.BackColor = System.Drawing.Color.White;
            this.txt_diem15p_lan1.BorderRadius = 10;
            this.txt_diem15p_lan1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_diem15p_lan1.DefaultText = "";
            this.txt_diem15p_lan1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_diem15p_lan1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_diem15p_lan1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_diem15p_lan1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_diem15p_lan1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_diem15p_lan1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_diem15p_lan1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_diem15p_lan1.Location = new System.Drawing.Point(167, 211);
            this.txt_diem15p_lan1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_diem15p_lan1.Name = "txt_diem15p_lan1";
            this.txt_diem15p_lan1.PlaceholderText = "";
            this.txt_diem15p_lan1.SelectedText = "";
            this.txt_diem15p_lan1.Size = new System.Drawing.Size(263, 120);
            this.txt_diem15p_lan1.TabIndex = 30;
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.AutoSize = false;
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.White;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Arial", 11F);
            this.guna2HtmlLabel5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(60, 221);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(234, 27);
            this.guna2HtmlLabel5.TabIndex = 31;
            this.guna2HtmlLabel5.Text = "Ghi chú:";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.AutoSize = false;
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.White;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Arial", 11F);
            this.guna2HtmlLabel6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(60, 167);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(234, 27);
            this.guna2HtmlLabel6.TabIndex = 29;
            this.guna2HtmlLabel6.Text = "Trạng thái:";
            // 
            // lblThongTinChiTiet
            // 
            this.lblThongTinChiTiet.AutoSize = false;
            this.lblThongTinChiTiet.BackColor = System.Drawing.Color.White;
            this.lblThongTinChiTiet.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblThongTinChiTiet.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblThongTinChiTiet.Location = new System.Drawing.Point(26, 24);
            this.lblThongTinChiTiet.Name = "lblThongTinChiTiet";
            this.lblThongTinChiTiet.Size = new System.Drawing.Size(473, 49);
            this.lblThongTinChiTiet.TabIndex = 27;
            this.lblThongTinChiTiet.Text = "Thông tin chi tiết";
            // 
            // txt_mahs
            // 
            this.txt_mahs.AutoSize = true;
            this.txt_mahs.BackColor = System.Drawing.Color.White;
            this.txt_mahs.BorderRadius = 10;
            this.txt_mahs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_mahs.DefaultText = "";
            this.txt_mahs.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_mahs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_mahs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_mahs.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_mahs.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_mahs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_mahs.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_mahs.Location = new System.Drawing.Point(167, 85);
            this.txt_mahs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_mahs.Name = "txt_mahs";
            this.txt_mahs.PlaceholderText = "";
            this.txt_mahs.SelectedText = "";
            this.txt_mahs.Size = new System.Drawing.Size(298, 46);
            this.txt_mahs.TabIndex = 19;
            // 
            // guna2HtmlLabel11
            // 
            this.guna2HtmlLabel11.AutoSize = false;
            this.guna2HtmlLabel11.BackColor = System.Drawing.Color.White;
            this.guna2HtmlLabel11.Font = new System.Drawing.Font("Arial", 11F);
            this.guna2HtmlLabel11.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.guna2HtmlLabel11.Location = new System.Drawing.Point(57, 96);
            this.guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            this.guna2HtmlLabel11.Size = new System.Drawing.Size(212, 27);
            this.guna2HtmlLabel11.TabIndex = 13;
            this.guna2HtmlLabel11.Text = "Mã HS:";
            // 
            // ucQuanLyDiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnThongTin);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "ucQuanLyDiemDanh";
            this.Size = new System.Drawing.Size(1768, 1050);
            this.Load += new System.EventHandler(this.ucQuanLyDiemDanh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSach)).EndInit();
            this.pnThongTin.ResumeLayout(false);
            this.pnThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTieuDe;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button btn_lammoi;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_lop;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDanhSach;
        private Guna.UI2.WinForms.Guna2DataGridView gridDanhSach;
        private Guna.UI2.WinForms.Guna2GradientPanel pnThongTin;
        private Guna.UI2.WinForms.Guna2Button btn_huy;
        private Guna.UI2.WinForms.Guna2Button btn_luu;
        private Guna.UI2.WinForms.Guna2TextBox txt_diem15p_lan1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblThongTinChiTiet;
        private Guna.UI2.WinForms.Guna2TextBox txt_mahs;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2DateTimePicker dt_NgayDiemDanh;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_trangthai;
    }
}
