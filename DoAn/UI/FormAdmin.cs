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
    public partial class ChuongTrinh : Form
    {
        private string userRole;
        private string userID; 

        public ChuongTrinh(string userRole, string id)
        {
            InitializeComponent();
            this.userRole = userRole;
            this.userID = id;
        }

        private void CheckUserPermissions()
        {
            NguoiDung.Visible = false;
            NhaHang.Visible = false;
            BaoCao.Visible = false;
            DonHang.Visible = false;
            DatHang.Visible = false;
            if (userRole == "R003") // Admin
            {
                txtTenDN.ForeColor = System.Drawing.Color.Red;
                txtTenDN.Text = "ADMIN: " + userID;
                NguoiDung.Visible = true;
                NhaHang.Visible = true;
                BaoCao.Visible = true;
                DonHang.Visible = true;
                DatHang.Visible = true;
            }
            else if (userRole == "R002") 
            {
                txtTenDN.ForeColor = System.Drawing.Color.DarkBlue;
                txtTenDN.Text = "NHÀ HÀNG: " + userID;
                DonHang.Visible = true;
                NhaHang.Visible = true;
                DatHang.Visible = true;
            }
            else if (userRole == "R001") 
            {
                txtTenDN.Text = "KHÁCH HÀNG: " + userID;
                txtTenDN.ForeColor = System.Drawing.Color.Green;
                DatHang.Visible = true;
            }
            else if (userRole == "R005") 
            {
                txtTenDN.Text = "GIAO HÀNG: " + userID;
                txtTenDN.ForeColor = System.Drawing.Color.Yellow;
                DatHang.Visible = true;
                GiaoHang.Visible = true;
                DonHang.Visible= true;
            }
        }

        private void ChuongTrinh_Load(object sender, EventArgs e)
        {
            CheckUserPermissions();
        }

        private void DoiMatKhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau frmDoiMatKhau = new FormDoiMatKhau(this.userID);
            this.Visible = false;
            frmDoiMatKhau.ShowDialog();
            this.Visible = true;
        }

        private void DangXuat_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            this.Visible = false;
            dn.ShowDialog();
            this.Close();
        }
        private void ChuongTrinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            if (this.Visible == true)
            {
                r = MessageBox.Show("Bạn có muốn thoát chương trình?", "CHƯƠNG TRÌNH THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (r != DialogResult.OK) e.Cancel = true;
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QLNguoiDung_Click(object sender, EventArgs e)
        {
            FormKhachHang formKhachHang = new FormKhachHang();
            this.Visible = false;
            formKhachHang.ShowDialog();
            this.Show();
        }

        private void DatHang_Click(object sender, EventArgs e)
        {
            FormDatHang form=new FormDatHang();
            this.Visible = false;
            form.ShowDialog();
            this.Show();
        }

        private void giaoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGiaoHang form=new FormGiaoHang();
            this.Visible = false;
            form.ShowDialog();
            this.Show();
        }

        private void QLNhaHang_Click(object sender, EventArgs e)
        {
            FormNhaHang form=new FormNhaHang();
            this.Visible = false;
            form.ShowDialog();
            this.Show();
        }
    }
}