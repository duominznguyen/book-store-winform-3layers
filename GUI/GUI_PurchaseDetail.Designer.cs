namespace GUI
{
    partial class GUI_PurchaseDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.btn_HuyTimKiem = new System.Windows.Forms.Button();
            this.rad_Sua = new System.Windows.Forms.RadioButton();
            this.dgv_Books = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_SearchValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbb_SearchOptions = new System.Windows.Forms.ComboBox();
            this.rad_Xoa = new System.Windows.Forms.RadioButton();
            this.txt_PurchaseQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SachThucThi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PurchasePrice = new System.Windows.Forms.TextBox();
            this.rad_TimKiem = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rad_Them = new System.Windows.Forms.RadioButton();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.txt_BookID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_PurchaseDetailID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_PurchaseID = new System.Windows.Forms.TextBox();
            this.btn_PrintReport = new System.Windows.Forms.Button();
            this.dgv_PurchaseDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Books)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PurchaseDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(279, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 46);
            this.label1.TabIndex = 23;
            this.label1.Text = "CHI TIẾT NHẬP HÀNG";
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(832, 257);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(159, 40);
            this.btn_LamMoi.TabIndex = 22;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // btn_HuyTimKiem
            // 
            this.btn_HuyTimKiem.Location = new System.Drawing.Point(708, 347);
            this.btn_HuyTimKiem.Name = "btn_HuyTimKiem";
            this.btn_HuyTimKiem.Size = new System.Drawing.Size(92, 44);
            this.btn_HuyTimKiem.TabIndex = 21;
            this.btn_HuyTimKiem.Text = "Hủy";
            this.btn_HuyTimKiem.UseVisualStyleBackColor = true;
            this.btn_HuyTimKiem.Click += new System.EventHandler(this.btn_HuyTimKiem_Click);
            // 
            // rad_Sua
            // 
            this.rad_Sua.AutoSize = true;
            this.rad_Sua.Location = new System.Drawing.Point(49, 428);
            this.rad_Sua.Name = "rad_Sua";
            this.rad_Sua.Size = new System.Drawing.Size(80, 33);
            this.rad_Sua.TabIndex = 1;
            this.rad_Sua.Text = "Sửa";
            this.rad_Sua.UseVisualStyleBackColor = true;
            // 
            // dgv_Books
            // 
            this.dgv_Books.AllowUserToAddRows = false;
            this.dgv_Books.AllowUserToDeleteRows = false;
            this.dgv_Books.AllowUserToOrderColumns = true;
            this.dgv_Books.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Books.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgv_Books.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Books.Location = new System.Drawing.Point(33, 609);
            this.dgv_Books.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.dgv_Books.Name = "dgv_Books";
            this.dgv_Books.ReadOnly = true;
            this.dgv_Books.RowHeadersVisible = false;
            this.dgv_Books.RowHeadersWidth = 62;
            this.dgv_Books.RowTemplate.Height = 28;
            this.dgv_Books.Size = new System.Drawing.Size(1083, 545);
            this.dgv_Books.TabIndex = 18;
            this.dgv_Books.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Books_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txt_SearchValue);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_LamMoi);
            this.groupBox1.Controls.Add(this.btn_HuyTimKiem);
            this.groupBox1.Controls.Add(this.rad_Sua);
            this.groupBox1.Controls.Add(this.cbb_SearchOptions);
            this.groupBox1.Controls.Add(this.dgv_Books);
            this.groupBox1.Controls.Add(this.rad_Xoa);
            this.groupBox1.Controls.Add(this.txt_PurchaseQuantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_SachThucThi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_PurchasePrice);
            this.groupBox1.Controls.Add(this.rad_TimKiem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rad_Them);
            this.groupBox1.Controls.Add(this.txt_Title);
            this.groupBox1.Controls.Add(this.txt_BookID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1044, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1157, 1195);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sách";
            // 
            // txt_SearchValue
            // 
            this.txt_SearchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchValue.Location = new System.Drawing.Point(419, 424);
            this.txt_SearchValue.Name = "txt_SearchValue";
            this.txt_SearchValue.Size = new System.Drawing.Size(381, 35);
            this.txt_SearchValue.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(291, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 29);
            this.label7.TabIndex = 24;
            this.label7.Text = "Từ khóa:";
            // 
            // cbb_SearchOptions
            // 
            this.cbb_SearchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_SearchOptions.FormattingEnabled = true;
            this.cbb_SearchOptions.Location = new System.Drawing.Point(419, 352);
            this.cbb_SearchOptions.Name = "cbb_SearchOptions";
            this.cbb_SearchOptions.Size = new System.Drawing.Size(271, 37);
            this.cbb_SearchOptions.TabIndex = 4;
            // 
            // rad_Xoa
            // 
            this.rad_Xoa.AutoSize = true;
            this.rad_Xoa.Location = new System.Drawing.Point(49, 505);
            this.rad_Xoa.Name = "rad_Xoa";
            this.rad_Xoa.Size = new System.Drawing.Size(82, 33);
            this.rad_Xoa.TabIndex = 2;
            this.rad_Xoa.Text = "Xóa";
            this.rad_Xoa.UseVisualStyleBackColor = true;
            // 
            // txt_PurchaseQuantity
            // 
            this.txt_PurchaseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PurchaseQuantity.Location = new System.Drawing.Point(266, 260);
            this.txt_PurchaseQuantity.Name = "txt_PurchaseQuantity";
            this.txt_PurchaseQuantity.Size = new System.Drawing.Size(534, 35);
            this.txt_PurchaseQuantity.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Số lượng:";
            // 
            // btn_SachThucThi
            // 
            this.btn_SachThucThi.Location = new System.Drawing.Point(856, 492);
            this.btn_SachThucThi.Name = "btn_SachThucThi";
            this.btn_SachThucThi.Size = new System.Drawing.Size(260, 90);
            this.btn_SachThucThi.TabIndex = 5;
            this.btn_SachThucThi.Text = "Thực thi";
            this.btn_SachThucThi.UseVisualStyleBackColor = true;
            this.btn_SachThucThi.Click += new System.EventHandler(this.btn_SachThucThi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tiêu đề:";
            // 
            // txt_PurchasePrice
            // 
            this.txt_PurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PurchasePrice.Location = new System.Drawing.Point(266, 191);
            this.txt_PurchasePrice.Name = "txt_PurchasePrice";
            this.txt_PurchasePrice.Size = new System.Drawing.Size(534, 35);
            this.txt_PurchasePrice.TabIndex = 10;
            // 
            // rad_TimKiem
            // 
            this.rad_TimKiem.AutoSize = true;
            this.rad_TimKiem.Location = new System.Drawing.Point(211, 353);
            this.rad_TimKiem.Name = "rad_TimKiem";
            this.rad_TimKiem.Size = new System.Drawing.Size(197, 33);
            this.rad_TimKiem.TabIndex = 3;
            this.rad_TimKiem.Text = "Tìm kiếm theo:";
            this.rad_TimKiem.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(118, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Giá nhập:";
            // 
            // rad_Them
            // 
            this.rad_Them.AutoSize = true;
            this.rad_Them.Location = new System.Drawing.Point(49, 353);
            this.rad_Them.Name = "rad_Them";
            this.rad_Them.Size = new System.Drawing.Size(101, 33);
            this.rad_Them.TabIndex = 0;
            this.rad_Them.Text = "Thêm";
            this.rad_Them.UseVisualStyleBackColor = true;
            // 
            // txt_Title
            // 
            this.txt_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Title.Location = new System.Drawing.Point(266, 127);
            this.txt_Title.MaxLength = 100;
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(534, 35);
            this.txt_Title.TabIndex = 6;
            // 
            // txt_BookID
            // 
            this.txt_BookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BookID.Location = new System.Drawing.Point(266, 69);
            this.txt_BookID.Name = "txt_BookID";
            this.txt_BookID.Size = new System.Drawing.Size(534, 35);
            this.txt_BookID.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mã sách:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_PurchaseDetailID);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_PurchaseID);
            this.groupBox2.Controls.Add(this.btn_PrintReport);
            this.groupBox2.Controls.Add(this.dgv_PurchaseDetails);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(992, 1081);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đơn hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(495, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 29);
            this.label6.TabIndex = 32;
            this.label6.Text = "Mã CTĐH";
            // 
            // txt_PurchaseDetailID
            // 
            this.txt_PurchaseDetailID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PurchaseDetailID.Location = new System.Drawing.Point(651, 66);
            this.txt_PurchaseDetailID.MaxLength = 100;
            this.txt_PurchaseDetailID.Name = "txt_PurchaseDetailID";
            this.txt_PurchaseDetailID.ReadOnly = true;
            this.txt_PurchaseDetailID.Size = new System.Drawing.Size(249, 35);
            this.txt_PurchaseDetailID.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(79, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 29);
            this.label10.TabIndex = 30;
            this.label10.Text = "Mã đơn:";
            // 
            // txt_PurchaseID
            // 
            this.txt_PurchaseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PurchaseID.Location = new System.Drawing.Point(196, 66);
            this.txt_PurchaseID.MaxLength = 100;
            this.txt_PurchaseID.Name = "txt_PurchaseID";
            this.txt_PurchaseID.ReadOnly = true;
            this.txt_PurchaseID.Size = new System.Drawing.Size(237, 35);
            this.txt_PurchaseID.TabIndex = 29;
            // 
            // btn_PrintReport
            // 
            this.btn_PrintReport.Location = new System.Drawing.Point(728, 977);
            this.btn_PrintReport.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.btn_PrintReport.Name = "btn_PrintReport";
            this.btn_PrintReport.Size = new System.Drawing.Size(227, 63);
            this.btn_PrintReport.TabIndex = 19;
            this.btn_PrintReport.Text = "In hóa đơn";
            this.btn_PrintReport.UseVisualStyleBackColor = true;
            this.btn_PrintReport.Click += new System.EventHandler(this.btn_PrintReport_Click);
            // 
            // dgv_PurchaseDetails
            // 
            this.dgv_PurchaseDetails.AllowUserToAddRows = false;
            this.dgv_PurchaseDetails.AllowUserToDeleteRows = false;
            this.dgv_PurchaseDetails.AllowUserToOrderColumns = true;
            this.dgv_PurchaseDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PurchaseDetails.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgv_PurchaseDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PurchaseDetails.Location = new System.Drawing.Point(34, 149);
            this.dgv_PurchaseDetails.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.dgv_PurchaseDetails.Name = "dgv_PurchaseDetails";
            this.dgv_PurchaseDetails.ReadOnly = true;
            this.dgv_PurchaseDetails.RowHeadersVisible = false;
            this.dgv_PurchaseDetails.RowHeadersWidth = 62;
            this.dgv_PurchaseDetails.RowTemplate.Height = 28;
            this.dgv_PurchaseDetails.Size = new System.Drawing.Size(921, 775);
            this.dgv_PurchaseDetails.TabIndex = 20;
            this.dgv_PurchaseDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PurchaseDetails_CellClick);
            // 
            // GUI_PurchaseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2303, 1334);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "GUI_PurchaseDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_PurchaseDetail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_PurchaseDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Books)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PurchaseDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.Button btn_HuyTimKiem;
        private System.Windows.Forms.RadioButton rad_Sua;
        private System.Windows.Forms.DataGridView dgv_Books;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad_Xoa;
        private System.Windows.Forms.TextBox txt_PurchaseQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_SachThucThi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_SearchOptions;
        private System.Windows.Forms.TextBox txt_PurchasePrice;
        private System.Windows.Forms.RadioButton rad_TimKiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rad_Them;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.TextBox txt_BookID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_PurchaseDetailID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_PurchaseID;
        private System.Windows.Forms.Button btn_PrintReport;
        private System.Windows.Forms.DataGridView dgv_PurchaseDetails;
        private System.Windows.Forms.TextBox txt_SearchValue;
        private System.Windows.Forms.Label label7;
    }
}