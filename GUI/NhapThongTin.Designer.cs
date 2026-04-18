namespace QuanLyHocSinhTHPT.GUI
{
    partial class frm_NhapThongTin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_TenDangNhap = new System.Windows.Forms.TextBox();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.lbl_TenDangNhap = new System.Windows.Forms.Label();
            this.lbl_MatKhau = new System.Windows.Forms.Label();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.lbl_QuayLai = new System.Windows.Forms.Label();
            this.lbl_VaiTro = new System.Windows.Forms.Label();
            this.ckb_HienThiMatKhau = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt_TenDangNhap
            // 
            this.txt_TenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenDangNhap.Location = new System.Drawing.Point(360, 60);
            this.txt_TenDangNhap.Name = "txt_TenDangNhap";
            this.txt_TenDangNhap.Size = new System.Drawing.Size(280, 32);
            this.txt_TenDangNhap.TabIndex = 1;
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.AutoSize = true;
            this.btn_DangNhap.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_DangNhap.Location = new System.Drawing.Point(402, 195);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(160, 44);
            this.btn_DangNhap.TabIndex = 2;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // lbl_TenDangNhap
            // 
            this.lbl_TenDangNhap.AutoSize = true;
            this.lbl_TenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenDangNhap.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_TenDangNhap.Location = new System.Drawing.Point(359, 30);
            this.lbl_TenDangNhap.Name = "lbl_TenDangNhap";
            this.lbl_TenDangNhap.Size = new System.Drawing.Size(156, 26);
            this.lbl_TenDangNhap.TabIndex = 3;
            this.lbl_TenDangNhap.Text = "Tên đăng nhập";
            // 
            // lbl_MatKhau
            // 
            this.lbl_MatKhau.AutoSize = true;
            this.lbl_MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MatKhau.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_MatKhau.Location = new System.Drawing.Point(359, 105);
            this.lbl_MatKhau.Name = "lbl_MatKhau";
            this.lbl_MatKhau.Size = new System.Drawing.Size(101, 26);
            this.lbl_MatKhau.TabIndex = 5;
            this.lbl_MatKhau.Text = "Mật khẩu";
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MatKhau.Location = new System.Drawing.Point(360, 135);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Size = new System.Drawing.Size(280, 32);
            this.txt_MatKhau.TabIndex = 4;
            // 
            // lbl_QuayLai
            // 
            this.lbl_QuayLai.AutoSize = true;
            this.lbl_QuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuayLai.Location = new System.Drawing.Point(12, 9);
            this.lbl_QuayLai.Name = "lbl_QuayLai";
            this.lbl_QuayLai.Size = new System.Drawing.Size(85, 20);
            this.lbl_QuayLai.TabIndex = 7;
            this.lbl_QuayLai.Text = "< Quay lại";
            this.lbl_QuayLai.Click += new System.EventHandler(this.lbl_QuayLai_Click);
            // 
            // lbl_VaiTro
            // 
            this.lbl_VaiTro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VaiTro.Location = new System.Drawing.Point(12, 58);
            this.lbl_VaiTro.Name = "lbl_VaiTro";
            this.lbl_VaiTro.Size = new System.Drawing.Size(322, 131);
            this.lbl_VaiTro.TabIndex = 8;
            this.lbl_VaiTro.Text = "Vai trò";
            this.lbl_VaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckb_HienThiMatKhau
            // 
            this.ckb_HienThiMatKhau.AutoSize = true;
            this.ckb_HienThiMatKhau.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_HienThiMatKhau.Location = new System.Drawing.Point(581, 186);
            this.ckb_HienThiMatKhau.Name = "ckb_HienThiMatKhau";
            this.ckb_HienThiMatKhau.Size = new System.Drawing.Size(111, 20);
            this.ckb_HienThiMatKhau.TabIndex = 9;
            this.ckb_HienThiMatKhau.Text = "hiện mật khẩu";
            this.ckb_HienThiMatKhau.UseVisualStyleBackColor = false;
            this.ckb_HienThiMatKhau.CheckedChanged += new System.EventHandler(this.ckb_HienThiMatKhau_CheckedChanged);
            // 
            // frm_NhapThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(727, 261);
            this.Controls.Add(this.ckb_HienThiMatKhau);
            this.Controls.Add(this.lbl_VaiTro);
            this.Controls.Add(this.lbl_QuayLai);
            this.Controls.Add(this.lbl_MatKhau);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.lbl_TenDangNhap);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.txt_TenDangNhap);
            this.Name = "frm_NhapThongTin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Học Sinh - Đăng nhập";
            this.Load += new System.EventHandler(this.frm_NhapThongTin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_TenDangNhap;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Label lbl_TenDangNhap;
        private System.Windows.Forms.Label lbl_MatKhau;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Label lbl_QuayLai;
        private System.Windows.Forms.Label lbl_VaiTro;
        private System.Windows.Forms.CheckBox ckb_HienThiMatKhau;
    }
}