namespace GUI
{
    partial class GUI_Order
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_HuyTimKiem = new System.Windows.Forms.Button();
            this.btn_ThucThi = new System.Windows.Forms.Button();
            this.cbb_SearchOptions = new System.Windows.Forms.ComboBox();
            this.rad_TimKiem = new System.Windows.Forms.RadioButton();
            this.rad_Xoa = new System.Windows.Forms.RadioButton();
            this.rad_Sua = new System.Windows.Forms.RadioButton();
            this.rad_Them = new System.Windows.Forms.RadioButton();
            this.txt_MaNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_NgayLap = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_MaDH = new System.Windows.Forms.TextBox();
            this.txt_MaKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ChiTietHoaDon = new System.Windows.Forms.Button();
            this.dgv_DonBan = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DonBan)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btn_HuyTimKiem);
            this.groupBox1.Controls.Add(this.btn_ThucThi);
            this.groupBox1.Controls.Add(this.cbb_SearchOptions);
            this.groupBox1.Controls.Add(this.rad_TimKiem);
            this.groupBox1.Controls.Add(this.rad_Xoa);
            this.groupBox1.Controls.Add(this.rad_Sua);
            this.groupBox1.Controls.Add(this.rad_Them);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(95, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1575, 228);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btn_HuyTimKiem
            // 
            this.btn_HuyTimKiem.Location = new System.Drawing.Point(1013, 51);
            this.btn_HuyTimKiem.Name = "btn_HuyTimKiem";
            this.btn_HuyTimKiem.Size = new System.Drawing.Size(108, 53);
            this.btn_HuyTimKiem.TabIndex = 11;
            this.btn_HuyTimKiem.Text = "Hủy";
            this.btn_HuyTimKiem.UseVisualStyleBackColor = true;
            this.btn_HuyTimKiem.Click += new System.EventHandler(this.btn_HuyTimKiem_Click);
            // 
            // btn_ThucThi
            // 
            this.btn_ThucThi.Location = new System.Drawing.Point(1322, 64);
            this.btn_ThucThi.Name = "btn_ThucThi";
            this.btn_ThucThi.Size = new System.Drawing.Size(221, 86);
            this.btn_ThucThi.TabIndex = 12;
            this.btn_ThucThi.Text = "Thực thi";
            this.btn_ThucThi.UseVisualStyleBackColor = true;
            this.btn_ThucThi.Click += new System.EventHandler(this.btn_ThucThi_Click);
            // 
            // cbb_SearchOptions
            // 
            this.cbb_SearchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_SearchOptions.FormattingEnabled = true;
            this.cbb_SearchOptions.Location = new System.Drawing.Point(788, 126);
            this.cbb_SearchOptions.Name = "cbb_SearchOptions";
            this.cbb_SearchOptions.Size = new System.Drawing.Size(333, 37);
            this.cbb_SearchOptions.TabIndex = 10;
            // 
            // rad_TimKiem
            // 
            this.rad_TimKiem.AutoSize = true;
            this.rad_TimKiem.Location = new System.Drawing.Point(788, 61);
            this.rad_TimKiem.Name = "rad_TimKiem";
            this.rad_TimKiem.Size = new System.Drawing.Size(191, 33);
            this.rad_TimKiem.TabIndex = 9;
            this.rad_TimKiem.TabStop = true;
            this.rad_TimKiem.Text = "Tìm kiếm theo";
            this.rad_TimKiem.UseVisualStyleBackColor = true;
            // 
            // rad_Xoa
            // 
            this.rad_Xoa.AutoSize = true;
            this.rad_Xoa.Location = new System.Drawing.Point(529, 61);
            this.rad_Xoa.Name = "rad_Xoa";
            this.rad_Xoa.Size = new System.Drawing.Size(82, 33);
            this.rad_Xoa.TabIndex = 7;
            this.rad_Xoa.TabStop = true;
            this.rad_Xoa.Text = "Xóa";
            this.rad_Xoa.UseVisualStyleBackColor = true;
            // 
            // rad_Sua
            // 
            this.rad_Sua.AutoSize = true;
            this.rad_Sua.Location = new System.Drawing.Point(304, 61);
            this.rad_Sua.Name = "rad_Sua";
            this.rad_Sua.Size = new System.Drawing.Size(80, 33);
            this.rad_Sua.TabIndex = 7;
            this.rad_Sua.TabStop = true;
            this.rad_Sua.Text = "Sửa";
            this.rad_Sua.UseVisualStyleBackColor = true;
            // 
            // rad_Them
            // 
            this.rad_Them.AutoSize = true;
            this.rad_Them.Location = new System.Drawing.Point(59, 61);
            this.rad_Them.Name = "rad_Them";
            this.rad_Them.Size = new System.Drawing.Size(101, 33);
            this.rad_Them.TabIndex = 6;
            this.rad_Them.TabStop = true;
            this.rad_Them.Text = "Thêm";
            this.rad_Them.UseVisualStyleBackColor = true;
            // 
            // txt_MaNV
            // 
            this.txt_MaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaNV.Location = new System.Drawing.Point(125, 180);
            this.txt_MaNV.Name = "txt_MaNV";
            this.txt_MaNV.Size = new System.Drawing.Size(524, 35);
            this.txt_MaNV.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mã NV:";
            // 
            // dtp_NgayLap
            // 
            this.dtp_NgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayLap.Location = new System.Drawing.Point(903, 178);
            this.dtp_NgayLap.Name = "dtp_NgayLap";
            this.dtp_NgayLap.Size = new System.Drawing.Size(544, 35);
            this.dtp_NgayLap.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(783, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 29);
            this.label9.TabIndex = 17;
            this.label9.Text = "Ngày lập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mã ĐH:";
            // 
            // txt_MaDH
            // 
            this.txt_MaDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaDH.Location = new System.Drawing.Point(125, 75);
            this.txt_MaDH.MaxLength = 100;
            this.txt_MaDH.Name = "txt_MaDH";
            this.txt_MaDH.Size = new System.Drawing.Size(524, 35);
            this.txt_MaDH.TabIndex = 1;
            // 
            // txt_MaKH
            // 
            this.txt_MaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaKH.Location = new System.Drawing.Point(903, 72);
            this.txt_MaKH.Name = "txt_MaKH";
            this.txt_MaKH.Size = new System.Drawing.Size(544, 35);
            this.txt_MaKH.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(639, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(536, 46);
            this.label1.TabIndex = 24;
            this.label1.Text = "QUẢN LÝ ĐƠN BÁN HÀNG";
            // 
            // btn_ChiTietHoaDon
            // 
            this.btn_ChiTietHoaDon.Location = new System.Drawing.Point(1282, 272);
            this.btn_ChiTietHoaDon.Name = "btn_ChiTietHoaDon";
            this.btn_ChiTietHoaDon.Size = new System.Drawing.Size(273, 56);
            this.btn_ChiTietHoaDon.TabIndex = 5;
            this.btn_ChiTietHoaDon.Text = "Chi tiết hóa đơn";
            this.btn_ChiTietHoaDon.UseVisualStyleBackColor = true;
            this.btn_ChiTietHoaDon.Click += new System.EventHandler(this.btn_ChiTietHoaDon_Click);
            // 
            // dgv_DonBan
            // 
            this.dgv_DonBan.AllowUserToAddRows = false;
            this.dgv_DonBan.AllowUserToDeleteRows = false;
            this.dgv_DonBan.AllowUserToOrderColumns = true;
            this.dgv_DonBan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_DonBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DonBan.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgv_DonBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DonBan.Location = new System.Drawing.Point(95, 762);
            this.dgv_DonBan.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.dgv_DonBan.Name = "dgv_DonBan";
            this.dgv_DonBan.ReadOnly = true;
            this.dgv_DonBan.RowHeadersVisible = false;
            this.dgv_DonBan.RowHeadersWidth = 62;
            this.dgv_DonBan.RowTemplate.Height = 28;
            this.dgv_DonBan.Size = new System.Drawing.Size(1575, 446);
            this.dgv_DonBan.TabIndex = 13;
            this.dgv_DonBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DonBan_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(805, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "Mã KH:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btn_LamMoi);
            this.groupBox2.Controls.Add(this.btn_ChiTietHoaDon);
            this.groupBox2.Controls.Add(this.txt_MaNV);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtp_NgayLap);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_MaDH);
            this.groupBox2.Controls.Add(this.txt_MaKH);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(95, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1575, 349);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đơn hàng";
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(32, 263);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(171, 49);
            this.btn_LamMoi.TabIndex = 21;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // GUI_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1774, 1234);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_DonBan);
            this.Controls.Add(this.groupBox2);
            this.Name = "GUI_Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhà sách Nhã Nam - Bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_Order_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DonBan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_HuyTimKiem;
        private System.Windows.Forms.Button btn_ThucThi;
        private System.Windows.Forms.ComboBox cbb_SearchOptions;
        private System.Windows.Forms.RadioButton rad_TimKiem;
        private System.Windows.Forms.RadioButton rad_Xoa;
        private System.Windows.Forms.RadioButton rad_Sua;
        private System.Windows.Forms.RadioButton rad_Them;
        private System.Windows.Forms.TextBox txt_MaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_NgayLap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_MaDH;
        private System.Windows.Forms.TextBox txt_MaKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ChiTietHoaDon;
        private System.Windows.Forms.DataGridView dgv_DonBan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_LamMoi;
    }
}