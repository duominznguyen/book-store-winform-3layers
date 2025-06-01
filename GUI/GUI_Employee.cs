using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BLL;

namespace GUI
{
    public partial class GUI_Employee : Form
    {
        private BLL_Employee _bllEmployee;
        public GUI_Employee()
        {
            InitializeComponent();
            _bllEmployee = new BLL_Employee();
        }

        private void GUI_Employee_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadSearchOptionsComboBox();
            LoadRoleComboBox();
        }

        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = _bllEmployee.GetAllEmployees();
                dgv_Employees.DataSource = dt;
                dgv_Employees.Columns["EmployeeID"].HeaderText = "Mã nhân viên";
                dgv_Employees.Columns["Name"].HeaderText = "Tên nhân viên";
                dgv_Employees.Columns["Email"].HeaderText = "Email";
                dgv_Employees.Columns["Phone"].HeaderText = "Số điện thoại";
                dgv_Employees.Columns["Address"].HeaderText = "Địa chỉ";
                dgv_Employees.Columns["Role"].HeaderText = "Chức vụ";
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
                    { "Name", "Tên nhân viên" },
                    { "Email", "Email" },
                    { "Phone", "Số điện thoại" },
                    { "Address", "Địa chỉ" },
                    { "EmployeeID", "Mã nhân viên" },
                    { "Role", "Chức vụ" },
                    { "General", "Tìm kiếm tổng quát" }
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

        private void LoadRoleComboBox()
        {
            try
            {
                Dictionary<string, string> roles = new Dictionary<string, string>
                {
                    { "Quản lý" , "Quản lý" },
                    { "Nhân viên" , "Nhân viên" },
                };
                cbb_Role.DataSource = new BindingSource(roles, null);
                cbb_Role.DisplayMember = "Value";
                cbb_Role.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void dgv_Employees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Employees.Rows[e.RowIndex];
                txt_EmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                txt_Name.Text = row.Cells["Name"].Value.ToString();
                txt_Email.Text = row.Cells["Email"].Value.ToString();
                txt_Phone.Text = row.Cells["Phone"].Value.ToString();
                rtxt_Address.Text = row.Cells["Address"].Value.ToString();
                cbb_Role.Text = row.Cells["Role"].Value.ToString();
            }
        }

        private void ClearInputFields()
        {
            txt_EmployeeID.Clear();
            txt_Name.Clear();
            txt_Email.Clear();
            txt_Phone.Clear();
            rtxt_Address.Clear();
            cbb_Role.SelectedIndex = -1;
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


        private Result IsFormatValidForAddingEmployee()
        {
            if (string.IsNullOrWhiteSpace(txt_EmployeeID.Text))
            {
                return new Result(false, "Mã nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txt_EmployeeID.Text) || !int.TryParse(txt_EmployeeID.Text, out _))
            {
                return new Result(false, "Mã nhân viên phải là số nguyên không dấu.");
            }
            if (string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                return new Result(false, "Tên nhân viên không được để trống.");
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
            if (string.IsNullOrWhiteSpace(cbb_Role.Text))
            {
                return new Result(false, "Chức vụ không được để trống.");
            }
            return new Result(true, "");
        }

        private void AddEmployee()
        {
            try
            {
                Result isValid = IsFormatValidForAddingEmployee();

                if (isValid.IsSuccess)
                {
                    Employee employee = new Employee
                    {
                        EmployeeID = int.Parse(txt_EmployeeID.Text),
                        Name = txt_Name.Text,
                        Email = txt_Email.Text,
                        Phone = txt_Phone.Text,
                        Address = rtxt_Address.Text,
                        Role = cbb_Role.Text
                    };
                    Result result = _bllEmployee.AddEmployee(employee);
                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Thêm nhân viên thành công.");
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(isValid.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
            finally
            {
                LoadDataGridView();
            }
        }

        private Result IsFormatValidForUpdatingEmployee()
        {
            if (string.IsNullOrWhiteSpace(txt_EmployeeID.Text))
            {
                return new Result(false, "Mã nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txt_EmployeeID.Text) || !int.TryParse(txt_EmployeeID.Text, out _))
            {
                return new Result(false, "Mã nhân viên phải là số nguyên không dấu.");
            }
            if (string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                return new Result(false, "Tên nhân viên không được để trống.");
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
            if (string.IsNullOrEmpty(cbb_Role.Text))
            {
                return new Result(false, "Chức vụ không được để trống.");
            }
            return new Result(true, "");
        }

        private void UpdateEmployee()
        {
            try
            {
                Result isValid = IsFormatValidForUpdatingEmployee();

                if (isValid.IsSuccess)
                {
                    Employee employee = new Employee
                    {
                        EmployeeID = int.Parse(txt_EmployeeID.Text),
                        Name = txt_Name.Text,
                        Email = txt_Email.Text,
                        Phone = txt_Phone.Text,
                        Address = rtxt_Address.Text,
                        Role = cbb_Role.Text
                    };
                    Result result = _bllEmployee.UpdateEmployee(employee);
                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công.");
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(isValid.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
            finally
            {
                LoadDataGridView();
            }

        }

        private Result IsFormatValidForDeletingEmployee()
        {
            if (string.IsNullOrWhiteSpace(txt_EmployeeID.Text))
            {
                return new Result(false, "Mã nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txt_EmployeeID.Text) || !int.TryParse(txt_EmployeeID.Text, out _))
            {
                return new Result(false, "Mã nhân viên phải là số nguyên không dấu.");
            }
            return new Result(true, "");
        }

        private void DeleteEmployee()
        {
            try
            {
                Result isValid = IsFormatValidForDeletingEmployee();
                if (isValid.IsSuccess)
                {
                    Result result = _bllEmployee.DeleteEmployee(int.Parse(txt_EmployeeID.Text));
                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Xóa nhân viên thành công.");
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(isValid.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
            finally
            {
                LoadDataGridView();
            }
        }


        private Result IsFormatValidForSearchingEmployee()
        {
            if (string.IsNullOrWhiteSpace(txt_SearchTerm.Text))
            {
                return new Result(false, "Từ khóa tìm kiếm không được để trống.");
            }
            if (cbb_SearchOptions.SelectedIndex == -1)
            {
                return new Result(false, "Vui lòng chọn tùy chọn tìm kiếm.");
            }
            return new Result(true, "");
        }


        private void SearchEmployee()
        {
            try
            {
                Result isValid = IsFormatValidForSearchingEmployee();
                if (isValid.IsSuccess)
                {
                    string searchOption = cbb_SearchOptions.SelectedValue.ToString();
                    string searchTerm = txt_SearchTerm.Text.Trim();                
                    MessageBox.Show(searchOption);
                    DataTable dt = _bllEmployee.SearchEmployees(searchOption, searchTerm);
                    dgv_Employees.DataSource = dt;
                }
                else
                {
                    MessageBox.Show(isValid.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }
        }

        private void btn_ThucThi_Click(object sender, EventArgs e)
        {
            if (rad_Them.Checked)
            {
                AddEmployee();
            }
            else if (rad_Sua.Checked)
            {
                UpdateEmployee();
            }
            else if (rad_Xoa.Checked)
            {
                DeleteEmployee();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchEmployee();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tùy chọn.");
            }
        }


    }
}
