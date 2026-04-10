namespace QuanLyHocSinhTHPT
{
    partial class frm_ChonDoiTuong
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
            this.btn_PhuHuynh_HocSinh = new System.Windows.Forms.Button();
            this.btn_GiaoVien = new System.Windows.Forms.Button();
            this.btn_QuanTriVien = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_PhuHuynh_HocSinh
            // 
            this.btn_PhuHuynh_HocSinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PhuHuynh_HocSinh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_PhuHuynh_HocSinh.Location = new System.Drawing.Point(110, 130);
            this.btn_PhuHuynh_HocSinh.MaximumSize = new System.Drawing.Size(240, 240);
            this.btn_PhuHuynh_HocSinh.MinimumSize = new System.Drawing.Size(240, 240);
            this.btn_PhuHuynh_HocSinh.Name = "btn_PhuHuynh_HocSinh";
            this.btn_PhuHuynh_HocSinh.Size = new System.Drawing.Size(240, 240);
            this.btn_PhuHuynh_HocSinh.TabIndex = 0;
            this.btn_PhuHuynh_HocSinh.Tag = "HocSinh";
            this.btn_PhuHuynh_HocSinh.Text = "Phụ huynh/Học sinh";
            this.btn_PhuHuynh_HocSinh.UseVisualStyleBackColor = true;
            this.btn_PhuHuynh_HocSinh.Click += new System.EventHandler(this.btn_PhuHuynh_HocSinh_Click);
            // 
            // btn_GiaoVien
            // 
            this.btn_GiaoVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GiaoVien.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_GiaoVien.Location = new System.Drawing.Point(407, 130);
            this.btn_GiaoVien.MaximumSize = new System.Drawing.Size(240, 240);
            this.btn_GiaoVien.MinimumSize = new System.Drawing.Size(240, 240);
            this.btn_GiaoVien.Name = "btn_GiaoVien";
            this.btn_GiaoVien.Size = new System.Drawing.Size(240, 240);
            this.btn_GiaoVien.TabIndex = 1;
            this.btn_GiaoVien.Tag = "GiaoVien";
            this.btn_GiaoVien.Text = "Giáo viên";
            this.btn_GiaoVien.UseVisualStyleBackColor = true;
            this.btn_GiaoVien.Click += new System.EventHandler(this.btn_GiaoVien_Click);
            // 
            // btn_QuanTriVien
            // 
            this.btn_QuanTriVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuanTriVien.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_QuanTriVien.Location = new System.Drawing.Point(700, 130);
            this.btn_QuanTriVien.MaximumSize = new System.Drawing.Size(240, 240);
            this.btn_QuanTriVien.MinimumSize = new System.Drawing.Size(240, 240);
            this.btn_QuanTriVien.Name = "btn_QuanTriVien";
            this.btn_QuanTriVien.Size = new System.Drawing.Size(240, 240);
            this.btn_QuanTriVien.TabIndex = 3;
            this.btn_QuanTriVien.Tag = "Admin";
            this.btn_QuanTriVien.Text = "Quản trị viên";
            this.btn_QuanTriVien.UseVisualStyleBackColor = true;
            this.btn_QuanTriVien.Click += new System.EventHandler(this.btn_QuanTriVien_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_Title.Location = new System.Drawing.Point(80, 31);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(895, 48);
            this.lbl_Title.TabIndex = 4;
            this.lbl_Title.Text = "VUI LÒNG CHỌN ĐỐI TƯỢNG ĐĂNG NHẬP";
            // 
            // frm_ChonDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1080, 439);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.btn_QuanTriVien);
            this.Controls.Add(this.btn_GiaoVien);
            this.Controls.Add(this.btn_PhuHuynh_HocSinh);
            this.Name = "frm_ChonDoiTuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Học Sinh - Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PhuHuynh_HocSinh;
        private System.Windows.Forms.Button btn_GiaoVien;
        private System.Windows.Forms.Button btn_QuanTriVien;
        private System.Windows.Forms.Label lbl_Title;
    }
}

