namespace GUI
{
    partial class GUI_OrderDetail
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_MaCTDH = new System.Windows.Forms.TextBox();
            this.btn_PrintOrder = new System.Windows.Forms.Button();
            this.dgv_DanhSachHangHoa = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_MaDH = new System.Windows.Forms.TextBox();
            this.dgv_Sach = new System.Windows.Forms.DataGridView();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.btn_HuyTimKiem = new System.Windows.Forms.Button();
            this.rad_Sua = new System.Windows.Forms.RadioButton();
            this.rad_Xoa = new System.Windows.Forms.RadioButton();
            this.txt_SoLuongBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SachThucThi = new System.Windows.Forms.Button();
            this.cbb_SearchOptions = new System.Windows.Forms.ComboBox();
            this.txt_GiaBan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rad_TimKiem = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rad_Them = new System.Windows.Forms.RadioButton();
            this.txt_TieuDe = new System.Windows.Forms.TextBox();
            this.txt_MaSach = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_SearchTerm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachHangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_MaCTDH);
            this.groupBox2.Controls.Add(this.btn_PrintOrder);
            this.groupBox2.Controls.Add(this.dgv_DanhSachHangHoa);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_MaDH);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(108, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1154, 992);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đơn hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(688, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 29);
            this.label6.TabIndex = 24;
            this.label6.Text = "Mã CTĐH:";
            // 
            // txt_MaCTDH
            // 
            this.txt_MaCTDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaCTDH.Location = new System.Drawing.Point(834, 59);
            this.txt_MaCTDH.MaxLength = 100;
            this.txt_MaCTDH.Name = "txt_MaCTDH";
            this.txt_MaCTDH.ReadOnly = true;
            this.txt_MaCTDH.Size = new System.Drawing.Size(269, 35);
            this.txt_MaCTDH.TabIndex = 23;
            // 
            // btn_PrintOrder
            // 
            this.btn_PrintOrder.Location = new System.Drawing.Point(898, 899);
            this.btn_PrintOrder.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.btn_PrintOrder.Name = "btn_PrintOrder";
            this.btn_PrintOrder.Size = new System.Drawing.Size(227, 63);
            this.btn_PrintOrder.TabIndex = 19;
            this.btn_PrintOrder.Text = "In hóa đơn";
            this.btn_PrintOrder.UseVisualStyleBackColor = true;
            this.btn_PrintOrder.Click += new System.EventHandler(this.btn_PrintOrder_Click);
            // 
            // dgv_DanhSachHangHoa
            // 
            this.dgv_DanhSachHangHoa.AllowUserToAddRows = false;
            this.dgv_DanhSachHangHoa.AllowUserToDeleteRows = false;
            this.dgv_DanhSachHangHoa.AllowUserToOrderColumns = true;
            this.dgv_DanhSachHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DanhSachHangHoa.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgv_DanhSachHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachHangHoa.Location = new System.Drawing.Point(32, 178);
            this.dgv_DanhSachHangHoa.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.dgv_DanhSachHangHoa.Name = "dgv_DanhSachHangHoa";
            this.dgv_DanhSachHangHoa.ReadOnly = true;
            this.dgv_DanhSachHangHoa.RowHeadersVisible = false;
            this.dgv_DanhSachHangHoa.RowHeadersWidth = 62;
            this.dgv_DanhSachHangHoa.RowTemplate.Height = 28;
            this.dgv_DanhSachHangHoa.Size = new System.Drawing.Size(1093, 691);
            this.dgv_DanhSachHangHoa.TabIndex = 20;
            this.dgv_DanhSachHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DanhSachHangHoa_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 29);
            this.label7.TabIndex = 22;
            this.label7.Text = "Mã đơn:";
            // 
            // txt_MaDH
            // 
            this.txt_MaDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaDH.Location = new System.Drawing.Point(144, 56);
            this.txt_MaDH.MaxLength = 100;
            this.txt_MaDH.Name = "txt_MaDH";
            this.txt_MaDH.ReadOnly = true;
            this.txt_MaDH.Size = new System.Drawing.Size(245, 35);
            this.txt_MaDH.TabIndex = 21;
            // 
            // dgv_Sach
            // 
            this.dgv_Sach.AllowUserToAddRows = false;
            this.dgv_Sach.AllowUserToDeleteRows = false;
            this.dgv_Sach.AllowUserToOrderColumns = true;
            this.dgv_Sach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Sach.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgv_Sach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Sach.Location = new System.Drawing.Point(54, 593);
            this.dgv_Sach.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.dgv_Sach.Name = "dgv_Sach";
            this.dgv_Sach.ReadOnly = true;
            this.dgv_Sach.RowHeadersVisible = false;
            this.dgv_Sach.RowHeadersWidth = 62;
            this.dgv_Sach.RowTemplate.Height = 28;
            this.dgv_Sach.Size = new System.Drawing.Size(945, 468);
            this.dgv_Sach.TabIndex = 18;
            this.dgv_Sach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Sach_CellClick);
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(843, 301);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(156, 40);
            this.btn_LamMoi.TabIndex = 20;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // btn_HuyTimKiem
            // 
            this.btn_HuyTimKiem.Location = new System.Drawing.Point(612, 373);
            this.btn_HuyTimKiem.Name = "btn_HuyTimKiem";
            this.btn_HuyTimKiem.Size = new System.Drawing.Size(137, 62);
            this.btn_HuyTimKiem.TabIndex = 19;
            this.btn_HuyTimKiem.Text = "Hủy";
            this.btn_HuyTimKiem.UseVisualStyleBackColor = true;
            this.btn_HuyTimKiem.Click += new System.EventHandler(this.btn_HuyTimKiem_Click);
            // 
            // rad_Sua
            // 
            this.rad_Sua.AutoSize = true;
            this.rad_Sua.Location = new System.Drawing.Point(262, 512);
            this.rad_Sua.Name = "rad_Sua";
            this.rad_Sua.Size = new System.Drawing.Size(80, 33);
            this.rad_Sua.TabIndex = 1;
            this.rad_Sua.TabStop = true;
            this.rad_Sua.Text = "Sửa";
            this.rad_Sua.UseVisualStyleBackColor = true;
            // 
            // rad_Xoa
            // 
            this.rad_Xoa.AutoSize = true;
            this.rad_Xoa.Location = new System.Drawing.Point(464, 512);
            this.rad_Xoa.Name = "rad_Xoa";
            this.rad_Xoa.Size = new System.Drawing.Size(82, 33);
            this.rad_Xoa.TabIndex = 2;
            this.rad_Xoa.TabStop = true;
            this.rad_Xoa.Text = "Xóa";
            this.rad_Xoa.UseVisualStyleBackColor = true;
            // 
            // txt_SoLuongBan
            // 
            this.txt_SoLuongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoLuongBan.Location = new System.Drawing.Point(207, 257);
            this.txt_SoLuongBan.Name = "txt_SoLuongBan";
            this.txt_SoLuongBan.Size = new System.Drawing.Size(623, 35);
            this.txt_SoLuongBan.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Số lượng bán:";
            // 
            // btn_SachThucThi
            // 
            this.btn_SachThucThi.Location = new System.Drawing.Point(843, 398);
            this.btn_SachThucThi.Name = "btn_SachThucThi";
            this.btn_SachThucThi.Size = new System.Drawing.Size(156, 147);
            this.btn_SachThucThi.TabIndex = 5;
            this.btn_SachThucThi.Text = "Thực thi";
            this.btn_SachThucThi.UseVisualStyleBackColor = true;
            this.btn_SachThucThi.Click += new System.EventHandler(this.btn_SachThucThi_Click);
            // 
            // cbb_SearchOptions
            // 
            this.cbb_SearchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_SearchOptions.FormattingEnabled = true;
            this.cbb_SearchOptions.Location = new System.Drawing.Point(266, 387);
            this.cbb_SearchOptions.Name = "cbb_SearchOptions";
            this.cbb_SearchOptions.Size = new System.Drawing.Size(312, 37);
            this.cbb_SearchOptions.TabIndex = 4;
            // 
            // txt_GiaBan
            // 
            this.txt_GiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GiaBan.Location = new System.Drawing.Point(207, 188);
            this.txt_GiaBan.Name = "txt_GiaBan";
            this.txt_GiaBan.Size = new System.Drawing.Size(623, 35);
            this.txt_GiaBan.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tiêu đề:";
            // 
            // rad_TimKiem
            // 
            this.rad_TimKiem.AutoSize = true;
            this.rad_TimKiem.Location = new System.Drawing.Point(69, 388);
            this.rad_TimKiem.Name = "rad_TimKiem";
            this.rad_TimKiem.Size = new System.Drawing.Size(191, 33);
            this.rad_TimKiem.TabIndex = 3;
            this.rad_TimKiem.TabStop = true;
            this.rad_TimKiem.Text = "Tìm kiếm theo";
            this.rad_TimKiem.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Giá bán:";
            // 
            // rad_Them
            // 
            this.rad_Them.AutoSize = true;
            this.rad_Them.Location = new System.Drawing.Point(65, 512);
            this.rad_Them.Name = "rad_Them";
            this.rad_Them.Size = new System.Drawing.Size(101, 33);
            this.rad_Them.TabIndex = 0;
            this.rad_Them.Text = "Thêm";
            this.rad_Them.UseVisualStyleBackColor = true;
            // 
            // txt_TieuDe
            // 
            this.txt_TieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TieuDe.Location = new System.Drawing.Point(207, 124);
            this.txt_TieuDe.MaxLength = 100;
            this.txt_TieuDe.Name = "txt_TieuDe";
            this.txt_TieuDe.Size = new System.Drawing.Size(623, 35);
            this.txt_TieuDe.TabIndex = 6;
            // 
            // txt_MaSach
            // 
            this.txt_MaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaSach.Location = new System.Drawing.Point(207, 66);
            this.txt_MaSach.Name = "txt_MaSach";
            this.txt_MaSach.Size = new System.Drawing.Size(623, 35);
            this.txt_MaSach.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_SearchTerm);
            this.groupBox1.Controls.Add(this.btn_LamMoi);
            this.groupBox1.Controls.Add(this.btn_HuyTimKiem);
            this.groupBox1.Controls.Add(this.rad_Sua);
            this.groupBox1.Controls.Add(this.dgv_Sach);
            this.groupBox1.Controls.Add(this.rad_Xoa);
            this.groupBox1.Controls.Add(this.txt_SoLuongBan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_SachThucThi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbb_SearchOptions);
            this.groupBox1.Controls.Add(this.txt_GiaBan);
            this.groupBox1.Controls.Add(this.rad_TimKiem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rad_Them);
            this.groupBox1.Controls.Add(this.txt_TieuDe);
            this.groupBox1.Controls.Add(this.txt_MaSach);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1440, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1039, 1091);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(139, 457);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 29);
            this.label8.TabIndex = 22;
            this.label8.Text = "Nội dung:";
            // 
            // txt_SearchTerm
            // 
            this.txt_SearchTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchTerm.Location = new System.Drawing.Point(262, 454);
            this.txt_SearchTerm.Name = "txt_SearchTerm";
            this.txt_SearchTerm.Size = new System.Drawing.Size(487, 35);
            this.txt_SearchTerm.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "ID Sách:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(447, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 40);
            this.label1.TabIndex = 21;
            this.label1.Text = "CHI TIẾT ĐƠN BÁN HÀNG";
            // 
            // GUI_OrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2543, 1225);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "GUI_OrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_OrderDetail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_OrderDetail_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachHangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_MaCTDH;
        private System.Windows.Forms.Button btn_PrintOrder;
        private System.Windows.Forms.DataGridView dgv_DanhSachHangHoa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_MaDH;
        private System.Windows.Forms.DataGridView dgv_Sach;
        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.Button btn_HuyTimKiem;
        private System.Windows.Forms.RadioButton rad_Sua;
        private System.Windows.Forms.RadioButton rad_Xoa;
        private System.Windows.Forms.TextBox txt_SoLuongBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_SachThucThi;
        private System.Windows.Forms.ComboBox cbb_SearchOptions;
        private System.Windows.Forms.TextBox txt_GiaBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rad_TimKiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rad_Them;
        private System.Windows.Forms.TextBox txt_TieuDe;
        private System.Windows.Forms.TextBox txt_MaSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_SearchTerm;
    }
}