using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class GUI_Supplier : Form
    {
        private BLL_Supplier _bllSupplier;
        public GUI_Supplier()
        {
            InitializeComponent();
            _bllSupplier = new BLL_Supplier();
        }

        private void GUI_Supplier_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadSearchOptionsCbb();
        }

        private void LoadDataGridView()
        {
            DataTable dt = _bllSupplier.GetAllSuppliers();
            dgv_Suppliers.DataSource = dt;
            dgv_Suppliers.Columns["SupplierId"].HeaderText = "Mã nhà cung cấp";
            dgv_Suppliers.Columns["Name"].HeaderText = "Tên nhà cung cấp";
            dgv_Suppliers.Columns["Phone"].HeaderText = "Số điện thoại";
            dgv_Suppliers.Columns["Address"].HeaderText = "Địa chỉ";
        }

        private void LoadSearchOptionsCbb()
        {
            cbb_SearchOptions.DataSource = new List<string>
            {
                "Tên",
                "Số điện thoại",
                "Địa chỉ",
                "Mã nhà cung cấp",
                "Chung"
            };
        }

        private void dgv_Suppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Suppliers.Rows[e.RowIndex];
                txt_SupplierId.Text = row.Cells["SupplierId"].Value.ToString();
                txt_Name.Text = row.Cells["Name"].Value.ToString();
                txt_Phone.Text = row.Cells["Phone"].Value.ToString();
                rtxt_Address.Text = row.Cells["Address"].Value.ToString();
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            txt_SupplierId.Clear();
            txt_Name.Clear();
            txt_Phone.Clear();
            rtxt_Address.Clear();
        }

        private void btn_HuyTimKiem_Click(object sender, EventArgs e)
        {
            txt_SearchTerm.Clear();
            LoadDataGridView();
        }

        private void btn_ThucThi_Click(object sender, EventArgs e)
        {
            if (rad_Them.Checked)
            {
                AddSupplier();
            }
            else if (rad_Sua.Checked)
            {
                UpdateSupplier();
            }
            else if (rad_Xoa.Checked)
            {
                DeleteSupplier();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchSuppliers();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chức năng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool IsValidInputForAdding()
        {
            if (string.IsNullOrWhiteSpace(txt_Name.Text) || string.IsNullOrWhiteSpace(txt_Phone.Text) || string.IsNullOrWhiteSpace(rtxt_Address.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txt_SupplierId.Text, out int supplierId))
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool IsValidInputForUpdating()
        {
            if (string.IsNullOrWhiteSpace(txt_SupplierId.Text) || string.IsNullOrWhiteSpace(txt_Name.Text) || string.IsNullOrWhiteSpace(txt_Phone.Text) || string.IsNullOrWhiteSpace(rtxt_Address.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txt_SupplierId.Text, out int supplierId))
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool IsValidInputForDeleting()
        {
            if (string.IsNullOrWhiteSpace(txt_SupplierId.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txt_SupplierId.Text, out int supplierId))
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void AddSupplier()
        {
            if (IsValidInputForAdding())
            {
                Supplier supplier = new Supplier
                {
                    SupplierId = int.Parse(txt_SupplierId.Text),
                    Name = txt_Name.Text,
                    Phone = txt_Phone.Text,
                    Address = rtxt_Address.Text
                };
                try
                {
                    bool result = _bllSupplier.AddSupplier(supplier);
                    if (result)
                    {
                        MessageBox.Show("Thêm nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhà cung cấp thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    LoadDataGridView();
                }


            }
        }

        private void UpdateSupplier()
        {
            if (IsValidInputForUpdating())
            {
                Supplier supplier = new Supplier
                {
                    SupplierId = int.Parse(txt_SupplierId.Text),
                    Name = txt_Name.Text,
                    Phone = txt_Phone.Text,
                    Address = rtxt_Address.Text
                };
                try
                {
                    bool result = _bllSupplier.UpdateSupplier(supplier);
                    if (result)
                    {
                        MessageBox.Show("Cập nhật nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật nhà cung cấp thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteSupplier()
        {
            if (IsValidInputForDeleting())
            {
                int supplierId = int.Parse(txt_SupplierId.Text);
                try
                {
                    bool result = _bllSupplier.DeleteSupplier(supplierId);
                    if (result)
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhà cung cấp thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void SearchSuppliers()
        {
            string searchTerm = txt_SearchTerm.Text;
            string searchOption = cbb_SearchOptions.SelectedItem.ToString();
            DataTable dt = null;
            switch (searchOption)
            {
                case "Tên":
                    dt = _bllSupplier.SearchSuppliersByName(searchTerm);
                    break;
                case "Số điện thoại":
                    dt = _bllSupplier.SearchSuppliersByPhone(searchTerm);
                    break;
                case "Địa chỉ":
                    dt = _bllSupplier.SearchSuppliersByAddress(searchTerm);
                    break;
                case "Mã nhà cung cấp":
                    if (int.TryParse(searchTerm, out int supplierId))
                    {
                        dt = _bllSupplier.GetSupplierById(supplierId);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập mã nhà cung cấp hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
                case "Chung":
                    dt = _bllSupplier.SearchSuppliers(searchTerm);
                    break;
            }
            dgv_Suppliers.DataSource = dt;

        }

    }
}
