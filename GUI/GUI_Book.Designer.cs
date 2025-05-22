namespace GUI
{
    partial class GUI_Book
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
            this.btn_HuyTimKiem = new System.Windows.Forms.Button();
            this.btn_ThucThi = new System.Windows.Forms.Button();
            this.cbb_LuaChonTimKiem = new System.Windows.Forms.ComboBox();
            this.rad_TimKiem = new System.Windows.Forms.RadioButton();
            this.rad_Xoa = new System.Windows.Forms.RadioButton();
            this.rad_Sua = new System.Windows.Forms.RadioButton();
            this.rad_Them = new System.Windows.Forms.RadioButton();
            this.txt_TonKho = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_NhaXB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.cbb_TheLoai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Gia = new System.Windows.Forms.TextBox();
            this.rtxt_MoTa = new System.Windows.Forms.RichTextBox();
            this.dgv_Sach = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TacGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TieuDe = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btn_HuyTimKiem);
            this.groupBox2.Controls.Add(this.btn_ThucThi);
            this.groupBox2.Controls.Add(this.cbb_LuaChonTimKiem);
            this.groupBox2.Controls.Add(this.rad_TimKiem);
            this.groupBox2.Controls.Add(this.rad_Xoa);
            this.groupBox2.Controls.Add(this.rad_Sua);
            this.groupBox2.Controls.Add(this.rad_Them);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(140, 606);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1485, 202);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btn_HuyTimKiem
            // 
            this.btn_HuyTimKiem.Location = new System.Drawing.Point(904, 48);
            this.btn_HuyTimKiem.Name = "btn_HuyTimKiem";
            this.btn_HuyTimKiem.Size = new System.Drawing.Size(98, 52);
            this.btn_HuyTimKiem.TabIndex = 22;
            this.btn_HuyTimKiem.Text = "Hủy";
            this.btn_HuyTimKiem.UseVisualStyleBackColor = true;
            this.btn_HuyTimKiem.Click += new System.EventHandler(this.btn_HuyTimKiem_Click);
            // 
            // btn_ThucThi
            // 
            this.btn_ThucThi.Location = new System.Drawing.Point(1196, 48);
            this.btn_ThucThi.Name = "btn_ThucThi";
            this.btn_ThucThi.Size = new System.Drawing.Size(220, 86);
            this.btn_ThucThi.TabIndex = 5;
            this.btn_ThucThi.Text = "Thực thi";
            this.btn_ThucThi.UseVisualStyleBackColor = true;
            this.btn_ThucThi.Click += new System.EventHandler(this.btn_ThucThi_Click);
            // 
            // cbb_LuaChonTimKiem
            // 
            this.cbb_LuaChonTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_LuaChonTimKiem.FormattingEnabled = true;
            this.cbb_LuaChonTimKiem.Location = new System.Drawing.Point(669, 122);
            this.cbb_LuaChonTimKiem.Name = "cbb_LuaChonTimKiem";
            this.cbb_LuaChonTimKiem.Size = new System.Drawing.Size(332, 37);
            this.cbb_LuaChonTimKiem.TabIndex = 4;
            // 
            // rad_TimKiem
            // 
            this.rad_TimKiem.AutoSize = true;
            this.rad_TimKiem.Location = new System.Drawing.Point(669, 55);
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
            this.rad_Xoa.Location = new System.Drawing.Point(464, 55);
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
            this.rad_Sua.Location = new System.Drawing.Point(255, 55);
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
            this.rad_Them.Location = new System.Drawing.Point(26, 55);
            this.rad_Them.Name = "rad_Them";
            this.rad_Them.Size = new System.Drawing.Size(101, 33);
            this.rad_Them.TabIndex = 0;
            this.rad_Them.TabStop = true;
            this.rad_Them.Text = "Thêm";
            this.rad_Them.UseVisualStyleBackColor = true;
            // 
            // txt_TonKho
            // 
            this.txt_TonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TonKho.Location = new System.Drawing.Point(814, 345);
            this.txt_TonKho.Name = "txt_TonKho";
            this.txt_TonKho.Size = new System.Drawing.Size(194, 35);
            this.txt_TonKho.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(700, 348);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 29);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tồn kho:";
            // 
            // txt_NhaXB
            // 
            this.txt_NhaXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NhaXB.Location = new System.Drawing.Point(141, 266);
            this.txt_NhaXB.MaxLength = 100;
            this.txt_NhaXB.Name = "txt_NhaXB";
            this.txt_NhaXB.Size = new System.Drawing.Size(475, 35);
            this.txt_NhaXB.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 29);
            this.label7.TabIndex = 19;
            this.label7.Text = "Nhà XB:";
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(1245, 338);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(171, 49);
            this.btn_LamMoi.TabIndex = 17;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // cbb_TheLoai
            // 
            this.cbb_TheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TheLoai.FormattingEnabled = true;
            this.cbb_TheLoai.Location = new System.Drawing.Point(814, 264);
            this.cbb_TheLoai.Name = "cbb_TheLoai";
            this.cbb_TheLoai.Size = new System.Drawing.Size(602, 37);
            this.cbb_TheLoai.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(703, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "Thể loại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(725, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Mô tả:";
            // 
            // txt_Gia
            // 
            this.txt_Gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Gia.Location = new System.Drawing.Point(141, 343);
            this.txt_Gia.Name = "txt_Gia";
            this.txt_Gia.Size = new System.Drawing.Size(475, 35);
            this.txt_Gia.TabIndex = 10;
            // 
            // rtxt_MoTa
            // 
            this.rtxt_MoTa.Location = new System.Drawing.Point(809, 45);
            this.rtxt_MoTa.MaxLength = 100;
            this.rtxt_MoTa.Name = "rtxt_MoTa";
            this.rtxt_MoTa.Size = new System.Drawing.Size(607, 184);
            this.rtxt_MoTa.TabIndex = 16;
            this.rtxt_MoTa.Text = "";
            // 
            // dgv_Sach
            // 
            this.dgv_Sach.AllowUserToAddRows = false;
            this.dgv_Sach.AllowUserToDeleteRows = false;
            this.dgv_Sach.AllowUserToOrderColumns = true;
            this.dgv_Sach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_Sach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Sach.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgv_Sach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Sach.Location = new System.Drawing.Point(140, 846);
            this.dgv_Sach.Name = "dgv_Sach";
            this.dgv_Sach.ReadOnly = true;
            this.dgv_Sach.RowHeadersVisible = false;
            this.dgv_Sach.RowHeadersWidth = 62;
            this.dgv_Sach.RowTemplate.Height = 28;
            this.dgv_Sach.Size = new System.Drawing.Size(1485, 423);
            this.dgv_Sach.TabIndex = 11;
            this.dgv_Sach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Sach_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Giá:";
            // 
            // txt_TacGia
            // 
            this.txt_TacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TacGia.Location = new System.Drawing.Point(142, 194);
            this.txt_TacGia.MaxLength = 50;
            this.txt_TacGia.Name = "txt_TacGia";
            this.txt_TacGia.Size = new System.Drawing.Size(475, 35);
            this.txt_TacGia.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tác giả:";
            // 
            // txt_TieuDe
            // 
            this.txt_TieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TieuDe.Location = new System.Drawing.Point(141, 120);
            this.txt_TieuDe.MaxLength = 100;
            this.txt_TieuDe.Name = "txt_TieuDe";
            this.txt_TieuDe.Size = new System.Drawing.Size(475, 35);
            this.txt_TieuDe.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txt_TonKho);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_NhaXB);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_LamMoi);
            this.groupBox1.Controls.Add(this.cbb_TheLoai);
            this.groupBox1.Controls.Add(this.rtxt_MoTa);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_Gia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_TacGia);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_TieuDe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(140, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1485, 431);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tiêu đề: ";
            // 
            // txt_Id
            // 
            this.txt_Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Id.Location = new System.Drawing.Point(141, 45);
            this.txt_Id.MaxLength = 10;
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(475, 35);
            this.txt_Id.TabIndex = 0;
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
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(624, 66);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(452, 64);
            this.label9.TabIndex = 12;
            this.label9.Text = "QUẢN LÝ SÁCH";
            // 
            // GUI_Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 1329);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv_Sach);
            this.Controls.Add(this.groupBox1);
            this.Name = "GUI_Book";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "`";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_Book_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_HuyTimKiem;
        private System.Windows.Forms.Button btn_ThucThi;
        private System.Windows.Forms.ComboBox cbb_LuaChonTimKiem;
        private System.Windows.Forms.RadioButton rad_TimKiem;
        private System.Windows.Forms.RadioButton rad_Xoa;
        private System.Windows.Forms.RadioButton rad_Sua;
        private System.Windows.Forms.RadioButton rad_Them;
        private System.Windows.Forms.TextBox txt_TonKho;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_NhaXB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.ComboBox cbb_TheLoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Gia;
        private System.Windows.Forms.RichTextBox rtxt_MoTa;
        private System.Windows.Forms.DataGridView dgv_Sach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_TacGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TieuDe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
    }
}