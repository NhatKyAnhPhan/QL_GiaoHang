using DoAn.BLL;
using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.UI
{
    public partial class FormKhachHang : Form
    {
            private KhachHang_BLL QLKH = new KhachHang_BLL();
            private DataTable dtDanhSachGoc = new DataTable();
            private readonly string ROLE_KHACHHANG = "R001";
            private readonly string ROLE_NHAHANG = "R002";
            private readonly string ROLE_GIAOHANG = "R005";

            public FormKhachHang()
            {
                InitializeComponent();
                this.CenterToScreen();
                txtMaKhach.ReadOnly = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;
            }

            private void FormKhachHang_Load(object sender, EventArgs e)
            {
                LoadDataAndView();
                LoadRoleComboBox();
            }
            private void LoadDataAndView()
            {
                dtDanhSachGoc = QLKH.HienThiDanhSachNguoiDung();

                dataGridView1.DataSource = dtDanhSachGoc;
                SetDataGridViewHeaders();
            }

            private void LoadRoleComboBox()
            {
                DataTable roles = new DataTable();
                roles.Columns.Add("ID", typeof(string));
                roles.Columns.Add("Name", typeof(string));

                roles.Rows.Add(ROLE_KHACHHANG, "R001 - Người dùng");
                roles.Rows.Add(ROLE_NHAHANG, "R002 - Nhà hàng (NV)");
                roles.Rows.Add(ROLE_GIAOHANG, "R005 - Giao hàng");

                cboVaiTro.DataSource = roles;
                cboVaiTro.DisplayMember = "Name";
                cboVaiTro.ValueMember = "ID";
                cboVaiTro.SelectedIndex = -1;
            }
            private void LoadToTextBox()
            {
                if (dataGridView1.CurrentRow == null) return;
                DataGridViewRow row = dataGridView1.CurrentRow;
                txtMaKhach.Text = row.Cells["MaNV"].Value.ToString();
                txtTenKhach.Text = row.Cells["TenNV"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSdt.Text = row.Cells["SDT"].Value.ToString();

                string currentRoleID = row.Cells["MaNV"].Value.ToString();
                cboVaiTro.SelectedValue = currentRoleID;
            }

            private void SetDataGridViewHeaders()
            {
                if (dataGridView1.Columns.Contains("MaNV")) dataGridView1.Columns["MaNV"].HeaderText = "Mã KH/NV";
                if (dataGridView1.Columns.Contains("TenNV")) dataGridView1.Columns["TenNV"].HeaderText = "Họ Tên";
                if (dataGridView1.Columns.Contains("VaiTro")) dataGridView1.Columns["VaiTro"].HeaderText = "Vai Trò";
                if (dataGridView1.Columns.Contains("DiaChi")) dataGridView1.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                if (dataGridView1.Columns.Contains("SDT")) dataGridView1.Columns["SDT"].HeaderText = "SĐT";
            }
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    LoadToTextBox();
                }
            }

            private void timKhachHang()
            {
                DataView dv = new DataView(dtDanhSachGoc);
                string filter = txtTimKhach.Text.Trim();

                if (!string.IsNullOrEmpty(filter))
                {
                    dv.RowFilter = $"MaNV LIKE '%{filter}%' OR TenNV LIKE '%{filter}%'";
                }
                else
                {
                    dv.RowFilter = ""; 
                }
                dataGridView1.DataSource = dv;
            }

            private void btnTim_Click(object sender, EventArgs e)
            {
                timKhachHang();
            }

            private void txtTimKhach_TextChanged(object sender, EventArgs e)
            {
                timKhachHang();
            }


            private void btnThem_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(txtMaKhach.Text) || string.IsNullOrEmpty(txtTenKhach.Text) || cboVaiTro.SelectedValue == null)
                {
                    MessageBox.Show("Mã KH, Họ tên và Vai trò là bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (QLKH.KT_KhoaChinh_NV(txtMaKhach.Text) != 0)
                {
                    MessageBox.Show("Mã người dùng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Xác nhận thêm người dùng mới?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

  
                TK_KhachHang kh = new TK_KhachHang
                {
                    KhachHangId = txtMaKhach.Text,
                    KhachHangName = txtTenKhach.Text,
                    DiaChi = txtDiaChi.Text,
                    Sdt = txtSdt.Text,
                    RoleId = cboVaiTro.SelectedValue.ToString()
       
                };

                if (QLKH.ThemKhachHang(kh) != 0)
                {
                    LoadDataAndView();
                    MessageBox.Show("Thêm thành công! Mật khẩu mặc định: 123456.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
 
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            private void btnSua_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(txtMaKhach.Text) || QLKH.KT_KhoaChinh_NV(txtMaKhach.Text) == 0)
                {
                    MessageBox.Show("Vui lòng chọn người dùng hợp lệ để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Xác nhận sửa thông tin người dùng?", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                TK_KhachHang kh = new TK_KhachHang
                {
                    KhachHangId = txtMaKhach.Text,
                    KhachHangName = txtTenKhach.Text,
                    DiaChi = txtDiaChi.Text,
                    Sdt = txtSdt.Text,
                    RoleId = cboVaiTro.SelectedValue.ToString()
                };

                if (QLKH.SuaKhachHang(kh) != 0)
                {
                    LoadDataAndView();
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnXoa_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(txtMaKhach.Text) || QLKH.KT_KhoaChinh_NV(txtMaKhach.Text) == 0)
                {
                    MessageBox.Show("Vui lòng chọn người dùng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show($"Xác nhận xóa người dùng {txtMaKhach.Text}?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

                if (QLKH.XoaKhachHang(txtMaKhach.Text) != 0)
                {
                    LoadDataAndView();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa không thành công! (Kiểm tra khóa ngoại)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            private void Thoat_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void FormKhachHang_FormClosing(object sender, FormClosingEventArgs e)
            {
                DialogResult r;
                if (this.Visible == true)
                {
                    r = MessageBox.Show("Bạn có muốn thoát!", "CHƯƠNG TRÌNH THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (r != DialogResult.OK && this.Visible == true)
                        e.Cancel = true;
                }
            }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtMaKhach.Text = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();
                txtTenKhach.Text = dataGridView1.CurrentRow.Cells["TenNV"].Value.ToString();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
    }
}