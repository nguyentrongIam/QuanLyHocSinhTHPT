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
            this.btn_PhuHuynh = new System.Windows.Forms.Button();
            this.btn_GiaoVien_HocSinh = new System.Windows.Forms.Button();
            this.btn_QuanTriVien = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_PhuHuynh
            // 
            this.btn_PhuHuynh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PhuHuynh.Location = new System.Drawing.Point(37, 99);
            this.btn_PhuHuynh.Name = "btn_PhuHuynh";
            this.btn_PhuHuynh.Size = new System.Drawing.Size(205, 74);
            this.btn_PhuHuynh.TabIndex = 0;
            this.btn_PhuHuynh.Text = "Phụ huynh";
            this.btn_PhuHuynh.UseVisualStyleBackColor = true;
            // 
            // btn_GiaoVien_HocSinh
            // 
            this.btn_GiaoVien_HocSinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GiaoVien_HocSinh.Location = new System.Drawing.Point(262, 99);
            this.btn_GiaoVien_HocSinh.Name = "btn_GiaoVien_HocSinh";
            this.btn_GiaoVien_HocSinh.Size = new System.Drawing.Size(268, 74);
            this.btn_GiaoVien_HocSinh.TabIndex = 1;
            this.btn_GiaoVien_HocSinh.Text = "Giáo viên/Học sinh";
            this.btn_GiaoVien_HocSinh.UseVisualStyleBackColor = true;
            // 
            // btn_QuanTriVien
            // 
            this.btn_QuanTriVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuanTriVien.Location = new System.Drawing.Point(551, 99);
            this.btn_QuanTriVien.Name = "btn_QuanTriVien";
            this.btn_QuanTriVien.Size = new System.Drawing.Size(205, 74);
            this.btn_QuanTriVien.TabIndex = 3;
            this.btn_QuanTriVien.Text = "Quản trị viên";
            this.btn_QuanTriVien.UseVisualStyleBackColor = true;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(25, 31);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(738, 45);
            this.lbl_Title.TabIndex = 4;
            this.lbl_Title.Text = "VUI LÒNG CHỌN ĐỐI TƯỢNG ĐĂNG NHẬP";
            // 
            // frm_ChonDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 211);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.btn_QuanTriVien);
            this.Controls.Add(this.btn_GiaoVien_HocSinh);
            this.Controls.Add(this.btn_PhuHuynh);
            this.Name = "frm_ChonDoiTuong";
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_PhuHuynh;
        private System.Windows.Forms.Button btn_GiaoVien_HocSinh;
        private System.Windows.Forms.Button btn_QuanTriVien;
        private System.Windows.Forms.Label lbl_Title;
    }
}

