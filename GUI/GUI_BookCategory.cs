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
    public partial class GUI_BookCategory : Form
    {
        private BLL_BookCategory _bllBookCategory;
        public GUI_BookCategory()
        {
            InitializeComponent();
            _bllBookCategory = new BLL_BookCategory();
        }

        private void GUI_BookCategory_Load(object sender, EventArgs e)
        {
            LoadDGV();
            LoadSearchOptionsCbb();
        }

        private void LoadDGV()
        {
            DataTable dt = _bllBookCategory.GetAllBookCategories();
            dgv_BookCategory.DataSource = dt;
            dgv_BookCategory.Columns["CategoryID"].HeaderText = "ID";
            dgv_BookCategory.Columns["CategoryName"].HeaderText = "Tên danh mục";
        }

        private void LoadSearchOptionsCbb()
        {
            cbb_SearchOptions.DataSource = new string[] { "ID", "Tên thể loại" };
            cbb_SearchOptions.SelectedIndex = 0;
        }

        private void dgv_BookCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_BookCategory.Rows[e.RowIndex];
                txt_CategoryID.Text = row.Cells["CategoryID"].Value.ToString();
                txt_CategoryName.Text = row.Cells["CategoryName"].Value.ToString();
            }
        }

        private void ClearTextBoxes()
        {
            txt_CategoryID.Clear();
            txt_CategoryName.Clear();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void btn_HuyTimKiem_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            LoadDGV();
        }

        private bool IsValidatedAddCategory()
        {
            if (string.IsNullOrWhiteSpace(txt_CategoryID.Text) || string.IsNullOrWhiteSpace(txt_CategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txt_CategoryID.Text, out _))
            {
                MessageBox.Show("ID phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidatedUpdateCategory()
        {
            if (string.IsNullOrWhiteSpace(txt_CategoryID.Text) || string.IsNullOrWhiteSpace(txt_CategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txt_CategoryID.Text, out _))
            {
                MessageBox.Show("ID phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool IsValidatedDeleteCategory()
        {
            if (string.IsNullOrWhiteSpace(txt_CategoryID.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txt_CategoryID.Text, out _))
            {
                MessageBox.Show("ID phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void AddCategory()
        {
            try
            {
                if (IsValidatedAddCategory())
                {
                    int categoryId = int.Parse(txt_CategoryID.Text);
                    string categoryName = txt_CategoryName.Text;
                    if (_bllBookCategory.AddBookCategory(categoryId, categoryName))
                    {
                        MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm danh mục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadDGV();
                ClearTextBoxes();
            }
        }

        private void UpdateCategory()
        {
            try
            {
                if (IsValidatedUpdateCategory())
                {
                    int categoryId = int.Parse(txt_CategoryID.Text);
                    string categoryName = txt_CategoryName.Text;
                    if (_bllBookCategory.UpdateBookCategory(categoryId, categoryName))
                    {
                        MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật danh mục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadDGV();
                ClearTextBoxes();
            }
        }

        private void DeleteCategory()
        {
            try
            {
                if (IsValidatedDeleteCategory())
                {
                    int categoryId = int.Parse(txt_CategoryID.Text);
                    if (_bllBookCategory.DeleteBookCategory(categoryId))
                    {
                        MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa danh mục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadDGV();
                ClearTextBoxes();
            }
        }


        private void SearchBookCategory()
        {
            try
            {
                if (cbb_SearchOptions.Text == "ID")
                {
                    if (txt_CategoryID.Text.Trim() == "")
                    {
                        MessageBox.Show("Vui lòng nhập ID để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!int.TryParse(txt_CategoryID.Text, out int categoryId))
                    {
                        MessageBox.Show("ID phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dgv_BookCategory.DataSource = _bllBookCategory.SearchBookCategory("ID", txt_CategoryID.Text);
                }

                else if (cbb_SearchOptions.Text == "Tên thể loại")
                {
                    if (txt_CategoryName.Text.Trim() == "")
                    {
                        MessageBox.Show("Vui lòng nhập tên thể loại để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dgv_BookCategory.DataSource = _bllBookCategory.SearchBookCategory("Tên thể loại", txt_CategoryName.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ThucThi_Click(object sender, EventArgs e)
        {
            if (rad_Them.Checked)
            {
                AddCategory();
            }
            else if (rad_Sua.Checked)
            {
                UpdateCategory();
            }
            else if (rad_Xoa.Checked)
            {
                DeleteCategory();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchBookCategory();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chức năng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GUI_BookCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
