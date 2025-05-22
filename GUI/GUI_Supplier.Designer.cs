namespace GUI
{
    partial class GUI_Supplier
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
            this.rtxt_Address = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SupplierId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Suppliers = new System.Windows.Forms.DataGridView();
            this.btn_HuyTimKiem = new System.Windows.Forms.Button();
            this.btn_ThucThi = new System.Windows.Forms.Button();
            this.cbb_SearchOptions = new System.Windows.Forms.ComboBox();
            this.rad_TimKiem = new System.Windows.Forms.RadioButton();
            this.rad_Xoa = new System.Windows.Forms.RadioButton();
            this.rad_Sua = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rad_Them = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SearchTerm = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Suppliers)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(1415, 279);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(142, 49);
            this.btn_LamMoi.TabIndex = 17;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // rtxt_Address
            // 
            this.rtxt_Address.Location = new System.Drawing.Point(897, 43);
            this.rtxt_Address.MaxLength = 255;
            this.rtxt_Address.Name = "rtxt_Address";
            this.rtxt_Address.Size = new System.Drawing.Size(660, 210);
            this.rtxt_Address.TabIndex = 16;
            this.rtxt_Address.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(784, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Địa chỉ:";
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(143, 151);
            this.txt_Name.MaxLength = 100;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(511, 35);
            this.txt_Name.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên NCC:";
            // 
            // txt_SupplierId
            // 
            this.txt_SupplierId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SupplierId.Location = new System.Drawing.Point(143, 45);
            this.txt_SupplierId.Name = "txt_SupplierId";
            this.txt_SupplierId.Size = new System.Drawing.Size(511, 35);
            this.txt_SupplierId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID:";
            // 
            // dgv_Suppliers
            // 
            this.dgv_Suppliers.AllowUserToAddRows = false;
            this.dgv_Suppliers.AllowUserToDeleteRows = false;
            this.dgv_Suppliers.AllowUserToOrderColumns = true;
            this.dgv_Suppliers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_Suppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Suppliers.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgv_Suppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Suppliers.Location = new System.Drawing.Point(158, 808);
            this.dgv_Suppliers.Name = "dgv_Suppliers";
            this.dgv_Suppliers.ReadOnly = true;
            this.dgv_Suppliers.RowHeadersVisible = false;
            this.dgv_Suppliers.RowHeadersWidth = 62;
            this.dgv_Suppliers.RowTemplate.Height = 28;
            this.dgv_Suppliers.Size = new System.Drawing.Size(1611, 440);
            this.dgv_Suppliers.TabIndex = 17;
            this.dgv_Suppliers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Suppliers_CellClick);
            // 
            // btn_HuyTimKiem
            // 
            this.btn_HuyTimKiem.Location = new System.Drawing.Point(1103, 59);
            this.btn_HuyTimKiem.Name = "btn_HuyTimKiem";
            this.btn_HuyTimKiem.Size = new System.Drawing.Size(105, 53);
            this.btn_HuyTimKiem.TabIndex = 23;
            this.btn_HuyTimKiem.Text = "Hủy";
            this.btn_HuyTimKiem.UseVisualStyleBackColor = true;
            this.btn_HuyTimKiem.Click += new System.EventHandler(this.btn_HuyTimKiem_Click);
            // 
            // btn_ThucThi
            // 
            this.btn_ThucThi.Location = new System.Drawing.Point(1336, 66);
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
            this.cbb_SearchOptions.Location = new System.Drawing.Point(746, 68);
            this.cbb_SearchOptions.Name = "cbb_SearchOptions";
            this.cbb_SearchOptions.Size = new System.Drawing.Size(333, 37);
            this.cbb_SearchOptions.TabIndex = 4;
            // 
            // rad_TimKiem
            // 
            this.rad_TimKiem.AutoSize = true;
            this.rad_TimKiem.Location = new System.Drawing.Point(537, 69);
            this.rad_TimKiem.Name = "rad_TimKiem";
            this.rad_TimKiem.Size = new System.Drawing.Size(191, 33);
            this.rad_TimKiem.TabIndex = 3;
            this.rad_TimKiem.TabStop = true;
            this.rad_TimKiem.Text = "Tìm kiếm theo";
            this.rad_TimKiem.UseVisualStyleBackColor = true;
            // 
            // rad_Xoa
            // 
            this.rad_Xoa.AutoSize = true;
            this.rad_Xoa.Location = new System.Drawing.Point(122, 144);
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
            this.rad_Sua.Location = new System.Drawing.Point(339, 66);
            this.rad_Sua.Name = "rad_Sua";
            this.rad_Sua.Size = new System.Drawing.Size(80, 33);
            this.rad_Sua.TabIndex = 1;
            this.rad_Sua.TabStop = true;
            this.rad_Sua.Text = "Sửa";
            this.rad_Sua.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.txt_SearchTerm);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btn_HuyTimKiem);
            this.groupBox2.Controls.Add(this.btn_ThucThi);
            this.groupBox2.Controls.Add(this.cbb_SearchOptions);
            this.groupBox2.Controls.Add(this.rad_TimKiem);
            this.groupBox2.Controls.Add(this.rad_Xoa);
            this.groupBox2.Controls.Add(this.rad_Sua);
            this.groupBox2.Controls.Add(this.rad_Them);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(158, 563);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1625, 207);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(542, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 29);
            this.label6.TabIndex = 24;
            this.label6.Text = "Từ khóa :";
            // 
            // rad_Them
            // 
            this.rad_Them.AutoSize = true;
            this.rad_Them.Location = new System.Drawing.Point(122, 66);
            this.rad_Them.Name = "rad_Them";
            this.rad_Them.Size = new System.Drawing.Size(101, 33);
            this.rad_Them.TabIndex = 0;
            this.rad_Them.TabStop = true;
            this.rad_Them.Text = "Thêm";
            this.rad_Them.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btn_LamMoi);
            this.groupBox1.Controls.Add(this.rtxt_Address);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_Phone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_SupplierId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(158, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1625, 347);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhà cung cấp";
            // 
            // txt_Phone
            // 
            this.txt_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Phone.Location = new System.Drawing.Point(143, 254);
            this.txt_Phone.MaxLength = 12;
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(511, 35);
            this.txt_Phone.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Số ĐT:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(668, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(637, 55);
            this.label4.TabIndex = 18;
            this.label4.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            // 
            // txt_SearchTerm
            // 
            this.txt_SearchTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchTerm.Location = new System.Drawing.Point(746, 144);
            this.txt_SearchTerm.MaxLength = 12;
            this.txt_SearchTerm.Name = "txt_SearchTerm";
            this.txt_SearchTerm.Size = new System.Drawing.Size(462, 35);
            this.txt_SearchTerm.TabIndex = 18;
            // 
            // GUI_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1905, 1285);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_Suppliers);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GUI_Supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_Supplier";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_Supplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Suppliers)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.RichTextBox rtxt_Address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SupplierId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Suppliers;
        private System.Windows.Forms.Button btn_HuyTimKiem;
        private System.Windows.Forms.Button btn_ThucThi;
        private System.Windows.Forms.ComboBox cbb_SearchOptions;
        private System.Windows.Forms.RadioButton rad_TimKiem;
        private System.Windows.Forms.RadioButton rad_Xoa;
        private System.Windows.Forms.RadioButton rad_Sua;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rad_Them;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_SearchTerm;
    }
}