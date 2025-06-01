using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Account : Form
    {
        private BLL_Account _bllAccount;
        public GUI_Account()
        {
            InitializeComponent();
            _bllAccount = new BLL_Account();
        }

        private void GUI_Account_Load(object sender, EventArgs e)
        {
            LoadAccountSDataGridView();
            LoadSearchOptionsComboBox();

            txt_Password.UseSystemPasswordChar = true;
        }

        private DataTable GetAllAccount_Employee()
        {
            try
            {
                DataTable result = new DataTable();
                result = _bllAccount.GetAllAccount_Employee();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void LoadAccountSDataGridView()
        {
            try
            {
                dgv_Accounts.DataSource = GetAllAccount_Employee();
                FormatAccountsDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSearchOptionsComboBox()
        {
            try
            {
                Dictionary<string, string> searchOptions = new Dictionary<string, string>
                {
                    {"Username", "Tên đăng nhập" },
                    { "EmployeeId", "Mã nhân viên" },
                    { "Name", "Tên nhân viên" },
                    { "Role", "Chức vụ" }
                };
                cbb_SearchOptions.DataSource = new BindingSource(searchOptions, null);
                cbb_SearchOptions.DisplayMember = "Value";
                cbb_SearchOptions.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormatAccountsDataGridView()
        {
            dgv_Accounts.Columns["Username"].HeaderText = "Tên đăng nhập";
            dgv_Accounts.Columns["Password"].Visible = false;
            dgv_Accounts.Columns["EmployeeId"].HeaderText = "Mã nhân viên";
            dgv_Accounts.Columns["Name"].HeaderText = "Tên nhân viên";
            dgv_Accounts.Columns["Role"].HeaderText = "Chức vụ";
        }

        private void dgv_Accounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Accounts.Rows[e.RowIndex];
                txt_Username.Text = row.Cells["Username"].Value.ToString();
                txt_Password.Text = row.Cells["Password"].Value.ToString();
                txt_EmployeeID.Text = row.Cells["EmployeeId"].Value.ToString();
            }
        }

        private void ClearInputFields()
        {
            txt_Username.Clear();
            txt_Password.Clear();
            txt_EmployeeID.Clear();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void ptb_PasswordChar_Click(object sender, EventArgs e)
        {
            if (txt_Password.UseSystemPasswordChar)
            {
                txt_Password.UseSystemPasswordChar = false;

            }
            else
            {
                txt_Password.UseSystemPasswordChar = true;
            }
        }

        private Result IsFormatValidForAdding()
        {
            if (string.IsNullOrEmpty(txt_Username.Text))
            {
                return new Result(false, "Tên đăng nhập không được để trống");
            }
            if (string.IsNullOrEmpty(txt_Password.Text))
            {
                return new Result(false, "Mật khẩu không được để trống");
            }
            if (string.IsNullOrEmpty(txt_EmployeeID.Text))
            {
                return new Result(false, "Mã nhân viên không được để trống");
            }
            return new Result(true, "");

        }

        private void AddAccount()
        {
            try
            {
                Result isValid = IsFormatValidForAdding();
                if (!isValid.IsSuccess)
                {
                    MessageBox.Show(isValid.Message);
                    return;
                }
                Account account = new Account
                {
                    Username = txt_Username.Text,
                    Password = txt_Password.Text,
                    EmployeeId = int.Parse(txt_EmployeeID.Text)
                };
                Result result = _bllAccount.AddAccount(account);
                if (result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                LoadAccountSDataGridView();

            }
        }

        private Result IsFormatValidForUpdating()
        {
            if (string.IsNullOrEmpty(txt_Username.Text))
            {
                return new Result(false, "Tên đăng nhập không được để trống");
            }
            if (string.IsNullOrEmpty(txt_Password.Text))
            {
                return new Result(false, "Mật khẩu không được để trống");
            }
            if (string.IsNullOrEmpty(txt_EmployeeID.Text))
            {
                return new Result(false, "Mã nhân viên không được để trống");
            }
            return new Result(true, "");
        }

        private void UpdateAccount()
        {
            try
            {
                Result isValid = IsFormatValidForUpdating();
                if (!isValid.IsSuccess)
                {
                    MessageBox.Show(isValid.Message);
                    return;
                }
                Account account = new Account
                {
                    Username = txt_Username.Text,
                    Password = txt_Password.Text,
                    EmployeeId = int.Parse(txt_EmployeeID.Text)
                };
                Result result = _bllAccount.UpdateAccount(account);
                if (result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadAccountSDataGridView();
            }
        }

        private Result IsFormatValidForDeleting()
        {
            if (string.IsNullOrEmpty(txt_Username.Text))
            {
                return new Result(false, "Tên đăng nhập không được để trống");
            }
            return new Result(true, "");
        }

        private void DeleteAccount()
        {
            try
            {
                Result isValid = IsFormatValidForDeleting();
                if (!isValid.IsSuccess)
                {
                    MessageBox.Show(isValid.Message);
                    return;
                }
                string username = txt_Username.Text;
                Result result = _bllAccount.DeleteAccount(username);
                if (result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadAccountSDataGridView();
            }
        }


        private Result IsFormatValidForSearching()
        {
            if (string.IsNullOrEmpty(txt_SearchValue.Text))
            {
                return new Result(false, "Vui lòng từ khóa tìm kiếm");
            }

            if (cbb_SearchOptions.SelectedValue == null)
            {
                return new Result(false, "Vui lòng chọn tùy chọn tìm kiếm");
            }

            return new Result(true, "");
        }

        private DataTable FilterAccount(string SearchOption, string searchValue)
        {
            try
            {
                DataTable data = GetAllAccount_Employee();
                DataView dv = new DataView(data);

                if (data.Columns[SearchOption].DataType == typeof(int))
                {
                    dv.RowFilter = $"{SearchOption} = {searchValue}";
                }
                else if (data.Columns[SearchOption].DataType == typeof(string))
                {
                    dv.RowFilter = $"{SearchOption} LIKE '%{searchValue}%'";
                }

                return dv.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void SearchAccount()
        {
            try
            {
                Result isValid = IsFormatValidForSearching();
                if (!isValid.IsSuccess)
                {
                    MessageBox.Show(isValid.Message);
                    return;
                }
                string searchOption = cbb_SearchOptions.SelectedValue.ToString();
                string searchValue = txt_SearchValue.Text.Trim();
                DataTable filteredData = FilterAccount(searchOption, searchValue);
                if (filteredData != null && filteredData.Rows.Count > 0)
                {
                    dgv_Accounts.DataSource = filteredData;
                    FormatAccountsDataGridView();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.");
                    LoadAccountSDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ThucThi_Click(object sender, EventArgs e)
        {
            if (rad_Them.Checked)
            {
                AddAccount();
            }
            else if (rad_Sua.Checked)
            {
                UpdateAccount();
            }
            else if (rad_Xoa.Checked)
            {
                DeleteAccount();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchAccount();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chức năng.");
            }
        }

        private void btn_HuyTimKiem_Click(object sender, EventArgs e)
        {
            txt_SearchValue.Clear();
            LoadAccountSDataGridView();
        }

        private void GUI_Account_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
