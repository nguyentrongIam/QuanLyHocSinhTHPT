namespace QuanLyHocSinhTHPT
{
    partial class FrmXemDanhSach
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
            this.btn_Xemdanhsach = new System.Windows.Forms.Label();
            this.gird_Danhsach = new System.Windows.Forms.DataGridView();
            this.cbb_Chonlop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Chon = new System.Windows.Forms.Button();
            this.lbl_QuayLai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gird_Danhsach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Xemdanhsach
            // 
            this.btn_Xemdanhsach.AutoSize = true;
            this.btn_Xemdanhsach.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xemdanhsach.Location = new System.Drawing.Point(352, 29);
            this.btn_Xemdanhsach.Name = "btn_Xemdanhsach";
            this.btn_Xemdanhsach.Size = new System.Drawing.Size(321, 29);
            this.btn_Xemdanhsach.TabIndex = 0;
            this.btn_Xemdanhsach.Text = "Xem danh sách sinh viên";
            // 
            // gird_Danhsach
            // 
            this.gird_Danhsach.AllowUserToResizeRows = false;
            this.gird_Danhsach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gird_Danhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gird_Danhsach.Location = new System.Drawing.Point(35, 281);
            this.gird_Danhsach.Name = "gird_Danhsach";
            this.gird_Danhsach.ReadOnly = true;
            this.gird_Danhsach.RowHeadersWidth = 51;
            this.gird_Danhsach.RowTemplate.Height = 24;
            this.gird_Danhsach.Size = new System.Drawing.Size(998, 436);
            this.gird_Danhsach.TabIndex = 1;
            // 
            // cbb_Chonlop
            // 
            this.cbb_Chonlop.FormattingEnabled = true;
            this.cbb_Chonlop.Location = new System.Drawing.Point(140, 40);
            this.cbb_Chonlop.Name = "cbb_Chonlop";
            this.cbb_Chonlop.Size = new System.Drawing.Size(141, 24);
            this.cbb_Chonlop.TabIndex = 2;
            this.cbb_Chonlop.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn lớp: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Chon);
            this.groupBox1.Controls.Add(this.cbb_Chonlop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 173);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn lớp";
            // 
            // btn_Chon
            // 
            this.btn_Chon.Location = new System.Drawing.Point(140, 82);
            this.btn_Chon.Name = "btn_Chon";
            this.btn_Chon.Size = new System.Drawing.Size(141, 68);
            this.btn_Chon.TabIndex = 4;
            this.btn_Chon.Text = "Chọn";
            this.btn_Chon.UseVisualStyleBackColor = true;
            this.btn_Chon.Click += new System.EventHandler(this.btn_Chon_Click);
            // 
            // lbl_QuayLai
            // 
            this.lbl_QuayLai.AutoSize = true;
            this.lbl_QuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuayLai.Location = new System.Drawing.Point(31, 9);
            this.lbl_QuayLai.Name = "lbl_QuayLai";
            this.lbl_QuayLai.Size = new System.Drawing.Size(85, 20);
            this.lbl_QuayLai.TabIndex = 8;
            this.lbl_QuayLai.Text = "< Quay lại";
            this.lbl_QuayLai.Click += new System.EventHandler(this.lbl_QuayLai_Click);
            // 
            // FrmXemDanhSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 729);
            this.Controls.Add(this.lbl_QuayLai);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gird_Danhsach);
            this.Controls.Add(this.btn_Xemdanhsach);
            this.Name = "FrmXemDanhSach";
            this.Text = "XemDanhSach";
            this.Load += new System.EventHandler(this.XemDanhSach_Load);
            this.Click += new System.EventHandler(this.FrmXemDanhSach_Click);
            ((System.ComponentModel.ISupportInitialize)(this.gird_Danhsach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btn_Xemdanhsach;
        private System.Windows.Forms.DataGridView gird_Danhsach;
        private System.Windows.Forms.ComboBox cbb_Chonlop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Chon;
        private System.Windows.Forms.Label lbl_QuayLai;
    }
}