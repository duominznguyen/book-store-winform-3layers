using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class GUI_Main : Form
    {
        private Account _account;
        private BLL_Employee _bllEmployee;
        private ContextMenuStrip contextMenuStrip;  

        public GUI_Main(Account account)
        {
            InitializeComponent();
            _bllEmployee = new BLL_Employee();
            _account = account;
            contextMenuStrip = new ContextMenuStrip();
        }


        private void GUI_Main_Load(object sender, EventArgs e)
        {
            DataRow employeeRow = _bllEmployee.GetEmployeeById(_account.EmployeeId).Rows[0];

            string userRole = employeeRow["Role"].ToString();
            if (userRole == "Nhân viên")
            {

                btn_Sach.Visible = false;
                ptb_KhoSach.Visible = false;

                btn_TheLoaiSach.Visible = false;
                ptb_TheLoaiSach.Visible = false;

                btn_NhanVien.Visible = false;
                ptb_NhanVien.Visible = false;

                btn_TaiKhoan.Visible = false;
                ptb_TaiKhoan.Visible = false;

                btn_ThongKe.Visible = false;
                ptb_ThongKe.Visible = false;
            }

            txt_employeeName.Text = userRole.ToString() + " - " + employeeRow["Name"].ToString();

        }



        private void btn_Sach_Click(object sender, EventArgs e)
        {
            GUI_Book bookForm = new GUI_Book();
            bookForm.FormClosed += (s, args) => this.Show();
            bookForm.Show();
            this.Hide();
        }

        private void btn_TheLoaiSach_Click(object sender, EventArgs e)
        {
            GUI_BookCategory bookCategoryForm = new GUI_BookCategory();
            bookCategoryForm.FormClosed += (s, args) => this.Show();
            bookCategoryForm.Show();
            this.Hide();
        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            GUI_Order orderForm = new GUI_Order();
            orderForm.FormClosed += (s, args) => this.Show();
            orderForm.Show();
            this.Hide();
        }

        private void btn_NhapHang_Click(object sender, EventArgs e)
        {
            GUI_Purchase purchaseForm = new GUI_Purchase();
            purchaseForm.FormClosed += (s, args) => this.Show();
            purchaseForm.Show();
            this.Hide();
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            GUI_Employee employeeForm = new GUI_Employee();
            employeeForm.FormClosed += (s, args) => this.Show();
            employeeForm.Show();
            this.Hide();

        }

        private void btn_Account_Click(object sender, EventArgs e)
        {
            GUI_Account accountForm = new GUI_Account();
            accountForm.FormClosed += (s, args) => this.Show();
            accountForm.Show();
            this.Hide();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            GUI_Customer customerForm = new GUI_Customer();
            customerForm.FormClosed += (s, args) => this.Show();
            customerForm.Show();
            this.Hide();

        }

        private void btn_NhaCC_Click(object sender, EventArgs e)
        {
            GUI_Supplier supplierForm = new GUI_Supplier();
            supplierForm.FormClosed += (s, args) => this.Show();
            supplierForm.Show();
            this.Hide();

        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            GUI_Statistical statisticalForm = new GUI_Statistical();
            statisticalForm.FormClosed += (s, args) => this.Show();
            statisticalForm.Show();
            this.Hide();
        }


        private void cmsi_SignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                GUI_LogIn loginForm = new GUI_LogIn();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

    }
}
