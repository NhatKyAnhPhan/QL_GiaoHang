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

using DoAn.BLL;
using DoAn.DAL;
using DoAn.DTO; 

namespace DoAn.UI
{
    public partial class FormDoiMatKhau : Form
    {
        TaiKhoan_BLL bll = new TaiKhoan_BLL();
        string currentUserID; 

        public FormDoiMatKhau()
        {
            InitializeComponent();
        }
        public FormDoiMatKhau(string id) : this()
        {
            currentUserID = id;
            txt_TaiKhoan.Text = currentUserID; 
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            txt_TaiKhoan.Enabled = false;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (txt_MKCu.Text == "" || txt_MKMoi.Text == "" || txt_ReMKMoi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }
            if (txt_MKMoi.Text != txt_ReMKMoi.Text)
            {
                MessageBox.Show("Mật khẩu mới nhập lại không khớp!", "Lỗi");
                return;
            }

            if (bll.CheckMatKhauCu(currentUserID, txt_MKCu.Text) == false)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi");
                return;
            }
            if (bll.DoiMatKhau(currentUserID, txt_MKMoi.Text))
            {
                MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại.", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, không thể đổi mật khẩu.", "Lỗi");
            }
        }
        private void FormDoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            if (this.Visible == true)
            {
                r = MessageBox.Show("Bạn có muốn thoát ?", "CHƯƠNG TRÌNH THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (r != DialogResult.OK && this.Visible == true)
                    e.Cancel = true;
                else
                {
                    this.Hide();
                }
            }
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}