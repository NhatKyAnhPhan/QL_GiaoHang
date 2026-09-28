using DoAn.BLL;
using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.UI
{
    public partial class DangNhap : Form
    {
        DangNhap_BLL bll = new DangNhap_BLL();

        public DangNhap()
        {
            InitializeComponent();
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.User != "")
            {
                txt_TaiKhoan.Text = Properties.Settings.Default.User;
                txt_MatKhau.Text = Properties.Settings.Default.Pass;
                cbGhiNhoTK.Checked = true; 
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_TaiKhoan.Text) || string.IsNullOrEmpty(txt_MatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string id = txt_TaiKhoan.Text;
            string matKhau = txt_MatKhau.Text;

            // Kiểm tra đăng nhập
            string role = bll.DangNhap(id, matKhau);

            if (role != null)
            {
                TK_KhachHang kh = new TK_KhachHang();
                kh.KhachHangId = id;
                kh.RoleId = role;
                UserSession.TaiKhoan = kh;
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                if (cbGhiNhoTK.Checked == true)
                {
                    Properties.Settings.Default.User = txt_TaiKhoan.Text;
                    Properties.Settings.Default.Pass = txt_MatKhau.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.User = "";
                    Properties.Settings.Default.Pass = "";
                    Properties.Settings.Default.Save();
                }
                ChuongTrinh frm = new ChuongTrinh(role, id);

                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi");
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) Application.Exit();
        }
        private void cbGhiNhoTK_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}