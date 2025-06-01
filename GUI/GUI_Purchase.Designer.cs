namespace GUI
{
    partial class GUI_Purchase
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
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.txt_SupplierID = new System.Windows.Forms.TextBox();
            this.btn_PurchaseDetail = new System.Windows.Forms.Button();
            this.txt_EmployeeID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_PurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_PurchaseID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_SearchTerm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_HuyTimKiem = new System.Windows.Forms.Button();
            this.btn_ThucThi = new System.Windows.Forms.Button();
            this.cbb_SearchOptions = new System.Windows.Forms.ComboBox();
            this.rad_TimKiem = new System.Windows.Forms.RadioButton();
            this.rad_Xoa = new System.Windows.Forms.RadioButton();
            this.rad_Sua = new System.Windows.Forms.RadioButton();
            this.rad_Them = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Purchases = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_SupplierName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_EmployeeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Purchases)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(75, 349);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(144, 47);
            this.btn_LamMoi.TabIndex = 23;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // txt_SupplierID
            // 
            this.txt_SupplierID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SupplierID.Location = new System.Drawing.Point(1080, 141);
            this.txt_SupplierID.Name = "txt_SupplierID";
            this.txt_SupplierID.Size = new System.Drawing.Size(558, 35);
            this.txt_SupplierID.TabIndex = 22;
            // 
            // btn_PurchaseDetail
            // 
            this.btn_PurchaseDetail.Location = new System.Drawing.Point(1348, 349);
            this.btn_PurchaseDetail.Name = "btn_PurchaseDetail";
            this.btn_PurchaseDetail.Size = new System.Drawing.Size(360, 56);
            this.btn_PurchaseDetail.TabIndex = 21;
            this.btn_PurchaseDetail.Text = "Chi tiết hóa đơn nhập";
            this.btn_PurchaseDetail.UseVisualStyleBackColor = true;
            this.btn_PurchaseDetail.Click += new System.EventHandler(this.btn_PurchaseDetail_Click);
            // 
            // txt_EmployeeID
            // 
            this.txt_EmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmployeeID.Location = new System.Drawing.Point(194, 141);
            this.txt_EmployeeID.Name = "txt_EmployeeID";
            this.txt_EmployeeID.Size = new System.Drawing.Size(568, 35);
            this.txt_EmployeeID.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mã NV:";
            // 
            // dtp_PurchaseDate
            // 
            this.dtp_PurchaseDate.CustomFormat = "dd/MM/yyyy";
            this.dtp_PurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_PurchaseDate.Location = new System.Drawing.Point(1080, 69);
            this.dtp_PurchaseDate.Name = "dtp_PurchaseDate";
            this.dtp_PurchaseDate.Size = new System.Drawing.Size(558, 35);
            this.dtp_PurchaseDate.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(931, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 29);
            this.label9.TabIndex = 17;
            this.label9.Text = "Ngày lập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mã ĐH:";
            // 
            // txt_PurchaseID
            // 
            this.txt_PurchaseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PurchaseID.Location = new System.Drawing.Point(193, 71);
            this.txt_PurchaseID.MaxLength = 100;
            this.txt_PurchaseID.Name = "txt_PurchaseID";
            this.txt_PurchaseID.Size = new System.Drawing.Size(569, 35);
            this.txt_PurchaseID.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(935, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "Mã NCC:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txt_SearchTerm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_HuyTimKiem);
            this.groupBox1.Controls.Add(this.btn_ThucThi);
            this.groupBox1.Controls.Add(this.cbb_SearchOptions);
            this.groupBox1.Controls.Add(this.rad_TimKiem);
            this.groupBox1.Controls.Add(this.rad_Xoa);
            this.groupBox1.Controls.Add(this.rad_Sua);
            this.groupBox1.Controls.Add(this.rad_Them);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(98, 621);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1811, 219);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // txt_SearchTerm
            // 
            this.txt_SearchTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchTerm.Location = new System.Drawing.Point(739, 130);
            this.txt_SearchTerm.Name = "txt_SearchTerm";
            this.txt_SearchTerm.Size = new System.Drawing.Size(449, 35);
            this.txt_SearchTerm.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(606, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 29);
            this.label3.TabIndex = 25;
            this.label3.Text = "Từ khóa: ";
            // 
            // btn_HuyTimKiem
            // 
            this.btn_HuyTimKiem.Location = new System.Drawing.Point(1080, 52);
            this.btn_HuyTimKiem.Name = "btn_HuyTimKiem";
            this.btn_HuyTimKiem.Size = new System.Drawing.Size(108, 53);
            this.btn_HuyTimKiem.TabIndex = 22;
            this.btn_HuyTimKiem.Text = "Hủy";
            this.btn_HuyTimKiem.UseVisualStyleBackColor = true;
            this.btn_HuyTimKiem.Click += new System.EventHandler(this.btn_HuyTimKiem_Click);
            // 
            // btn_ThucThi
            // 
            this.btn_ThucThi.Location = new System.Drawing.Point(1472, 58);
            this.btn_ThucThi.Name = "btn_ThucThi";
            this.btn_ThucThi.Size = new System.Drawing.Size(221, 86);
            this.btn_ThucThi.TabIndex = 5;
            this.btn_ThucThi.Text = "Thực thi";
            this.btn_ThucThi.UseVisualStyleBackColor = true;
            this.btn_ThucThi.Click += new System.EventHandler(this.btn_ThucThi_Click);
            // 
            // cbb_SearchOptions
            // 
            this.cbb_SearchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_SearchOptions.FormattingEnabled = true;
            this.cbb_SearchOptions.Location = new System.Drawing.Point(739, 61);
            this.cbb_SearchOptions.Name = "cbb_SearchOptions";
            this.cbb_SearchOptions.Size = new System.Drawing.Size(306, 37);
            this.cbb_SearchOptions.TabIndex = 4;
            // 
            // rad_TimKiem
            // 
            this.rad_TimKiem.AutoSize = true;
            this.rad_TimKiem.Location = new System.Drawing.Point(515, 62);
            this.rad_TimKiem.Name = "rad_TimKiem";
            this.rad_TimKiem.Size = new System.Drawing.Size(203, 33);
            this.rad_TimKiem.TabIndex = 3;
            this.rad_TimKiem.TabStop = true;
            this.rad_TimKiem.Text = "Tìm kiếm theo: ";
            this.rad_TimKiem.UseVisualStyleBackColor = true;
            // 
            // rad_Xoa
            // 
            this.rad_Xoa.AutoSize = true;
            this.rad_Xoa.Location = new System.Drawing.Point(87, 131);
            this.rad_Xoa.Name = "rad_Xoa";
            this.rad_Xoa.Size = new System.Drawing.Size(82, 33);
            this.rad_Xoa.TabIndex = 2;
            this.rad_Xoa.TabStop = true;
            this.rad_Xoa.Text = "Xóa";
            this.rad_Xoa.UseVisualStyleBackColor = true;
            // 
            // rad_Sua
            // 
            this.rad_Sua.AutoSize = true;
            this.rad_Sua.Location = new System.Drawing.Point(308, 62);
            this.rad_Sua.Name = "rad_Sua";
            this.rad_Sua.Size = new System.Drawing.Size(80, 33);
            this.rad_Sua.TabIndex = 1;
            this.rad_Sua.TabStop = true;
            this.rad_Sua.Text = "Sửa";
            this.rad_Sua.UseVisualStyleBackColor = true;
            // 
            // rad_Them
            // 
            this.rad_Them.AutoSize = true;
            this.rad_Them.Location = new System.Drawing.Point(87, 62);
            this.rad_Them.Name = "rad_Them";
            this.rad_Them.Size = new System.Drawing.Size(101, 33);
            this.rad_Them.TabIndex = 0;
            this.rad_Them.TabStop = true;
            this.rad_Them.Text = "Thêm";
            this.rad_Them.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(753, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 46);
            this.label1.TabIndex = 27;
            this.label1.Text = "QUẢN LÝ NHẬP HÀNG";
            // 
            // dgv_Purchases
            // 
            this.dgv_Purchases.AllowUserToAddRows = false;
            this.dgv_Purchases.AllowUserToDeleteRows = false;
            this.dgv_Purchases.AllowUserToOrderColumns = true;
            this.dgv_Purchases.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_Purchases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Purchases.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgv_Purchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Purchases.Location = new System.Drawing.Point(98, 884);
            this.dgv_Purchases.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.dgv_Purchases.Name = "dgv_Purchases";
            this.dgv_Purchases.ReadOnly = true;
            this.dgv_Purchases.RowHeadersVisible = false;
            this.dgv_Purchases.RowHeadersWidth = 62;
            this.dgv_Purchases.RowTemplate.Height = 28;
            this.dgv_Purchases.Size = new System.Drawing.Size(1811, 425);
            this.dgv_Purchases.TabIndex = 26;
            this.dgv_Purchases.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Purchases_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.txt_SupplierName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_EmployeeName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_LamMoi);
            this.groupBox2.Controls.Add(this.txt_SupplierID);
            this.groupBox2.Controls.Add(this.btn_PurchaseDetail);
            this.groupBox2.Controls.Add(this.txt_EmployeeID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtp_PurchaseDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_PurchaseID);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(98, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1811, 423);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đơn hàng";
            // 
            // txt_SupplierName
            // 
            this.txt_SupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SupplierName.Location = new System.Drawing.Point(1080, 214);
            this.txt_SupplierName.Name = "txt_SupplierName";
            this.txt_SupplierName.ReadOnly = true;
            this.txt_SupplierName.Size = new System.Drawing.Size(558, 35);
            this.txt_SupplierName.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(932, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 29);
            this.label7.TabIndex = 27;
            this.label7.Text = "Tên NCC:";
            // 
            // txt_EmployeeName
            // 
            this.txt_EmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmployeeName.Location = new System.Drawing.Point(194, 214);
            this.txt_EmployeeName.Name = "txt_EmployeeName";
            this.txt_EmployeeName.ReadOnly = true;
            this.txt_EmployeeName.Size = new System.Drawing.Size(568, 35);
            this.txt_EmployeeName.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 29);
            this.label4.TabIndex = 25;
            this.label4.Text = "Tên NV:";
            // 
            // GUI_Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1998, 1391);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Purchases);
            this.Controls.Add(this.groupBox2);
            this.Name = "GUI_Purchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhà sách Nhã Nam - Nhập hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_Purchase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Purchases)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.TextBox txt_SupplierID;
        private System.Windows.Forms.Button btn_PurchaseDetail;
        private System.Windows.Forms.TextBox txt_EmployeeID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_PurchaseDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_PurchaseID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_HuyTimKiem;
        private System.Windows.Forms.Button btn_ThucThi;
        private System.Windows.Forms.ComboBox cbb_SearchOptions;
        private System.Windows.Forms.RadioButton rad_TimKiem;
        private System.Windows.Forms.RadioButton rad_Xoa;
        private System.Windows.Forms.RadioButton rad_Sua;
        private System.Windows.Forms.RadioButton rad_Them;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Purchases;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_SearchTerm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_EmployeeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SupplierName;
        private System.Windows.Forms.Label label7;
    }
}