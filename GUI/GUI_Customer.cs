using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entities;

namespace GUI
{
    public partial class GUI_Customer : Form
    {
        private BLL_Customer _bllCustomer;

        public GUI_Customer()
        {
            InitializeComponent();
            _bllCustomer = new BLL_Customer();
        }

        private void GUI_Customer_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadSearchOptionsComboBox();
        }

        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = _bllCustomer.GetAllCustomers();
                dgv_Customers.DataSource = dt;
                dgv_Customers.Columns["CustomerID"].HeaderText = "Mã Khách Hàng";
                dgv_Customers.Columns["Name"].HeaderText = "Tên Khách Hàng";
                dgv_Customers.Columns["Address"].HeaderText = "Địa Chỉ";
                dgv_Customers.Columns["Email"].HeaderText = "Email";
                dgv_Customers.Columns["Phone"].HeaderText = "Số Điện Thoại";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadSearchOptionsComboBox()
        {
            try
            {
                Dictionary<string, string> searchOptions = new Dictionary<string, string>
                {

                    { "Name", "Tên Khách Hàng" },
                    { "Email", "Email" },
                    { "Phone", "Số Điện Thoại" },
                    { "Address", "Địa Chỉ" },
                    { "CustomerID", "Mã Khách Hàng" },
                    { "All", "Tất Cả"}
                };

                cbb_SearchOptions.DataSource = new BindingSource(searchOptions, null);
                cbb_SearchOptions.DisplayMember = "Value";
                cbb_SearchOptions.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void dgv_Customers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Customers.Rows[e.RowIndex];
                txt_CustomerID.Text = row.Cells["CustomerID"].Value.ToString();
                txt_Name.Text = row.Cells["Name"].Value.ToString();
                txt_Email.Text = row.Cells["Email"].Value.ToString();
                txt_Phone.Text = row.Cells["Phone"].Value.ToString();
                rtxt_Address.Text = row.Cells["Address"].Value.ToString();
            }
        }


        private void ClearInputFields()
        {
            txt_CustomerID.Clear();
            txt_Name.Clear();
            txt_Email.Clear();
            txt_Phone.Clear();
            rtxt_Address.Clear();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void btn_HuyTimKiem_Click(object sender, EventArgs e)
        {
            txt_SearchTerm.Clear();
            LoadDataGridView();
        }

        private Result IsFormatValidForAddingCustomer()
        {
            if (string.IsNullOrWhiteSpace(txt_CustomerID.Text))
            {
                return new Result(false, "Mã khách hàng không được để trống.");
            }
            if (!int.TryParse(txt_CustomerID.Text, out _))
            {
                return new Result(false, "Mã khách hàng phải là số nguyên không dấu.");
            }
            if (string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                return new Result(false, "Tên khách hàng không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                return new Result(false, "Email không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txt_Phone.Text))
            {
                return new Result(false, "Số điện thoại không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(rtxt_Address.Text))
            {
                return new Result(false, "Địa chỉ không được để trống.");
            }
            return new Result(true, "");
        }

        private void AddCustomer()
        {
            try
            {
                if (IsFormatValidForAddingCustomer().IsSuccess)
                {
                    Customer customer = new Customer
                    {
                        CustomerID = int.Parse(txt_CustomerID.Text),
                        Name = txt_Name.Text,
                        Email = txt_Email.Text,
                        Phone = txt_Phone.Text,
                        Address = rtxt_Address.Text
                    };
                    Result result = _bllCustomer.AddCustomer(customer);
                    if (result.IsSuccess)
                    {
                        ClearInputFields();
                        MessageBox.Show("Thêm khách hàng thành công.");
                        
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(IsFormatValidForAddingCustomer().Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
            }
            finally
            {
                LoadDataGridView();
                
            }
        }

        private Result IsFormatValidForUpdatingCustomer()
        {
            if (string.IsNullOrWhiteSpace(txt_CustomerID.Text))
            {
                return new Result(false, "Mã khách hàng không được để trống.");
            }
            if (!int.TryParse(txt_CustomerID.Text, out _))
            {
                return new Result(false, "Mã khách hàng phải là số nguyên không dấu.");
            }
            if (string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                return new Result(false, "Tên khách hàng không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                return new Result(false, "Email không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txt_Phone.Text))
            {
                return new Result(false, "Số điện thoại không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(rtxt_Address.Text))
            {
                return new Result(false, "Địa chỉ không được để trống.");
            }
            return new Result(true, "");
        }

        private void UpdateCustomer()
        {
            try
            {
                if (IsFormatValidForUpdatingCustomer().IsSuccess)
                {
                    Customer customer = new Customer
                    {
                        CustomerID = int.Parse(txt_CustomerID.Text),
                        Name = txt_Name.Text,
                        Email = txt_Email.Text,
                        Phone = txt_Phone.Text,
                        Address = rtxt_Address.Text
                    };
                    Result result = _bllCustomer.UpdateCustomer(customer);
                    if (result.IsSuccess)
                    {
                        ClearInputFields();
                        MessageBox.Show("Cập nhật khách hàng thành công.");
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(IsFormatValidForUpdatingCustomer().Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
            finally
            {
                LoadDataGridView();
            }
        }


        private Result IsFormatValidForDeletingCustomer()
        {
            if (string.IsNullOrWhiteSpace(txt_CustomerID.Text))
            {
                return new Result(false, "Mã khách hàng không được để trống.");
            }
            if (!int.TryParse(txt_CustomerID.Text, out _))
            {
                return new Result(false, "Mã khách hàng phải là số nguyên không dấu.");
            }
            return new Result(true, "");
        }

        private void DeleteCustomer()
        {
            try
            {
                if (IsFormatValidForDeletingCustomer().IsSuccess)
                {
                    int customerId = int.Parse(txt_CustomerID.Text);
                    Result result = _bllCustomer.DeleteCustomer(customerId);
                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Xóa khách hàng thành công.");
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(IsFormatValidForDeletingCustomer().Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
            }
            finally
            {
                LoadDataGridView();
                ClearInputFields();
            }
        }


        private Result IsFormatValidForSearch()
        {
            if (cbb_SearchOptions.SelectedValue == null)
            {
                return new Result(false, "Vui lòng chọn tùy chọn tìm kiếm.");
            }
         
            if (string.IsNullOrWhiteSpace(txt_SearchTerm.Text))
            {
                return new Result(false, "Từ khóa tìm kiếm không được để trống.");
            }

            return new Result(true, "");
        }

        private void SearchCustomer()
        {
            try
            {
                if (IsFormatValidForSearch().IsSuccess)
                {
                    string searchTerm = txt_SearchTerm.Text;
                    string searchOption = cbb_SearchOptions.SelectedValue.ToString();
                    DataTable dt = _bllCustomer.SearchCustomers(searchTerm, searchOption);
                    dgv_Customers.DataSource = dt;
                }
                else
                {
                    MessageBox.Show(IsFormatValidForSearch().Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
        }

        private void btn_ThucThi_Click(object sender, EventArgs e)
        {
            if (rad_Them.Checked)
            {
                AddCustomer();
            }
            else if (rad_Sua.Checked)
            {
                UpdateCustomer();
            }
            else if (rad_Xoa.Checked)
            {
                DeleteCustomer();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchCustomer();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chức năng.");
            }
        }
    }
}
