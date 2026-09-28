using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.DAL;
using DoAn.DTO;
using DoAn.UI;

namespace DoAn.UI
{
    public partial class FormNhaHang : Form
    {
        //private string userRole;
        //private string userID;

        public FormNhaHang(/*string role, string id*/)
        {
            InitializeComponent();
            this.Load += FormNhaHang_Load;
            this.dgvNhaHang.CellClick += DgvNhaHang_CellClick;
            this.btnChon.Click += BtnChon_Click;
            //this.btnThoat.Click += BtnThoat_Click;
            //userRole = role;
            //userID = id;
        }

        //private void BtnThoat_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //    ChuongTrinh admin = new ChuongTrinh(userRole, userID);
        //    admin.Show();
        //}

        private void BtnChon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nhaHangDuocChon))
            {
                MessageBox.Show("Vui lòng chọn nhà hàng!");
                return;
            }

            FormMonAn f = new FormMonAn(nhaHangDuocChon, this);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void DgvNhaHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                nhaHangDuocChon = dgvNhaHang.Rows[e.RowIndex].Cells["NHAHANG_ID"].Value.ToString();
            }
        }

        private void FormNhaHang_Load(object sender, EventArgs e)
        {
            NhaHang_DAL dal = new NhaHang_DAL();
            DataTable dt = dal.LayDanhSachKhuVuc();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu khu vực!");
                return;
            }

            cboKhuVuc.DisplayMember = "DIACHI";
            cboKhuVuc.ValueMember = "DIACHI";
            cboKhuVuc.DataSource = dt;

            cboKhuVuc.SelectedIndex = -1;
        }

        private void cboKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhuVuc.SelectedIndex == -1) return;

            string kv = cboKhuVuc.SelectedValue.ToString();

            NhaHang_DAL dal = new NhaHang_DAL();
            dgvNhaHang.DataSource = dal.LayNhaHangTheoKhuVuc(kv);
        }
        string nhaHangDuocChon = "";

        private void FormNhaHang_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
