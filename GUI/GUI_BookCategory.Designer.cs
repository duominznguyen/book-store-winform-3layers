namespace GUI
{
    partial class GUI_BookCategory
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
            this.dgv_BookCategory = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_HuyTimKiem = new System.Windows.Forms.Button();
            this.btn_ThucThi = new System.Windows.Forms.Button();
            this.cbb_SearchOptions = new System.Windows.Forms.ComboBox();
            this.rad_TimKiem = new System.Windows.Forms.RadioButton();
            this.rad_Xoa = new System.Windows.Forms.RadioButton();
            this.rad_Sua = new System.Windows.Forms.RadioButton();
            this.rad_Them = new System.Windows.Forms.RadioButton();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.txt_CategoryName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CategoryID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BookCategory)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_BookCategory
            // 
            this.dgv_BookCategory.AllowUserToAddRows = false;
            this.dgv_BookCategory.AllowUserToDeleteRows = false;
            this.dgv_BookCategory.AllowUserToOrderColumns = true;
            this.dgv_BookCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_BookCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_BookCategory.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgv_BookCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BookCategory.Location = new System.Drawing.Point(135, 693);
            this.dgv_BookCategory.Name = "dgv_BookCategory";
            this.dgv_BookCategory.ReadOnly = true;
            this.dgv_BookCategory.RowHeadersVisible = false;
            this.dgv_BookCategory.RowHeadersWidth = 62;
            this.dgv_BookCategory.RowTemplate.Height = 28;
            this.dgv_BookCategory.Size = new System.Drawing.Size(1515, 489);
            this.dgv_BookCategory.TabIndex = 14;
            this.dgv_BookCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_BookCategory_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btn_HuyTimKiem);
            this.groupBox2.Controls.Add(this.btn_ThucThi);
            this.groupBox2.Controls.Add(this.cbb_SearchOptions);
            this.groupBox2.Controls.Add(this.rad_TimKiem);
            this.groupBox2.Controls.Add(this.rad_Xoa);
            this.groupBox2.Controls.Add(this.rad_Sua);
            this.groupBox2.Controls.Add(this.rad_Them);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(135, 462);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1515, 211);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btn_HuyTimKiem
            // 
            this.btn_HuyTimKiem.Location = new System.Drawing.Point(945, 42);
            this.btn_HuyTimKiem.Name = "btn_HuyTimKiem";
            this.btn_HuyTimKiem.Size = new System.Drawing.Size(98, 50);
            this.btn_HuyTimKiem.TabIndex = 23;
            this.btn_HuyTimKiem.Text = "Hủy";
            this.btn_HuyTimKiem.UseVisualStyleBackColor = true;
            this.btn_HuyTimKiem.Click += new System.EventHandler(this.btn_HuyTimKiem_Click);
            // 
            // btn_ThucThi
            // 
            this.btn_ThucThi.Location = new System.Drawing.Point(1247, 48);
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
            this.cbb_SearchOptions.Location = new System.Drawing.Point(710, 126);
            this.cbb_SearchOptions.Name = "cbb_SearchOptions";
            this.cbb_SearchOptions.Size = new System.Drawing.Size(333, 37);
            this.cbb_SearchOptions.TabIndex = 4;
            // 
            // rad_TimKiem
            // 
            this.rad_TimKiem.AutoSize = true;
            this.rad_TimKiem.Location = new System.Drawing.Point(710, 51);
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
            this.rad_Xoa.Location = new System.Drawing.Point(493, 48);
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
            this.rad_Sua.Location = new System.Drawing.Point(267, 48);
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
            this.rad_Them.Location = new System.Drawing.Point(16, 48);
            this.rad_Them.Name = "rad_Them";
            this.rad_Them.Size = new System.Drawing.Size(101, 33);
            this.rad_Them.TabIndex = 0;
            this.rad_Them.TabStop = true;
            this.rad_Them.Text = "Thêm";
            this.rad_Them.UseVisualStyleBackColor = true;
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(1326, 157);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(142, 49);
            this.btn_LamMoi.TabIndex = 17;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // txt_CategoryName
            // 
            this.txt_CategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CategoryName.Location = new System.Drawing.Point(176, 141);
            this.txt_CategoryName.MaxLength = 50;
            this.txt_CategoryName.Name = "txt_CategoryName";
            this.txt_CategoryName.Size = new System.Drawing.Size(565, 35);
            this.txt_CategoryName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thể loại:";
            // 
            // txt_CategoryID
            // 
            this.txt_CategoryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CategoryID.Location = new System.Drawing.Point(176, 62);
            this.txt_CategoryID.Name = "txt_CategoryID";
            this.txt_CategoryID.Size = new System.Drawing.Size(565, 35);
            this.txt_CategoryID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btn_LamMoi);
            this.groupBox1.Controls.Add(this.txt_CategoryName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_CategoryID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(135, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1515, 228);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thể loại sách";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(525, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(730, 64);
            this.label3.TabIndex = 15;
            this.label3.Text = "QUẢN LÝ THỂ LOẠI SÁCH";
            // 
            // GUI_BookCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1773, 1228);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_BookCategory);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GUI_BookCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_BookCategory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_BookCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BookCategory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_BookCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_HuyTimKiem;
        private System.Windows.Forms.Button btn_ThucThi;
        private System.Windows.Forms.ComboBox cbb_SearchOptions;
        private System.Windows.Forms.RadioButton rad_TimKiem;
        private System.Windows.Forms.RadioButton rad_Xoa;
        private System.Windows.Forms.RadioButton rad_Sua;
        private System.Windows.Forms.RadioButton rad_Them;
        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.TextBox txt_CategoryName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CategoryID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}