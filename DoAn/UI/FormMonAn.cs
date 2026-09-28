using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.DAL;
using DoAn.DTO;

namespace DoAn.UI
{
    public partial class FormMonAn : Form
    {
        private string nhaHangID;
        private FormNhaHang formNhaHang;
        public FormMonAn(string id, FormNhaHang f)
        {
            nhaHangID = id;
            formNhaHang = f;
            InitializeComponent();
            this.Load += FormMonAn_Load;
            dgvMonAn.CellFormatting += DgvMonAn_CellFormatting;
            cboLoai.SelectedIndexChanged += CboLoai_SelectedIndexChanged;
            btnChon.Click += BtnChon_Click;
            dgvMonDaChon.CellClick += DgvMonDaChon_CellClick;
            btnXoa.Click += BtnXoa_Click;
            btnSua.Click += BtnSua_Click;
            dgvMonAn.CellDoubleClick += DgvMonAn_CellDoubleClick;
            btnThem.Click += BtnThem_Click;
            btnChon.Enabled = false;
            btnQuayLai.Click += BtnQuayLai_Click;
            btnDatHang.Click += BtnDatHang_Click;
        }

        private void BtnDatHang_Click(object sender, EventArgs e)
        {
            if (dgvMonDaChon.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn món nào!");
                return;
            }


            string khachHangID = UserSession.TaiKhoan.KhachHangId;
            string donHangID = "DH" + DateTime.Now.Ticks;//lấy thời gian hiện tại làm mã đơn

            NhaHang_DAL dal = new NhaHang_DAL();

            try
            {

                dal.TaoDonHang(donHangID, khachHangID, nhaHangID);


                foreach (DataGridViewRow row in dgvMonDaChon.Rows)
                {
                    ChiTietDonHang ct = new ChiTietDonHang()
                    {
                        DonHangId = donHangID,
                        MonAnId = row.Cells["MaMon2"].Value.ToString(),
                        SoLuong = Convert.ToInt32(row.Cells["SoLuong2"].Value),
                        DonGia = Convert.ToInt64(row.Cells["Gia2"].Value),
                        GhiChu = null
                    };

                    dal.ThemChiTietDonHang(ct);
                }

                MessageBox.Show("🎉 Đặt hàng thành công!");

                dgvMonDaChon.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đặt hàng: " + ex.Message);
            }
        }

        private void BtnQuayLai_Click(object sender, EventArgs e)
        {
            formNhaHang.Show();
            this.Close();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            btnChon.Enabled = true;
        }

        private void DgvMonAn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rowEdit < 0) return;

            DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];

            string ten = row.Cells["TenMon"].Value.ToString();
            long gia = Convert.ToInt64(row.Cells["Gia"].Value);
            string fileName = row.Cells["HinhAnh"].Value?.ToString();
            Image img = GetImageFromResource(fileName);
            dgvMonDaChon.Rows[rowEdit].Cells["HinhAnh2"].Value = img;
            dgvMonDaChon.Rows[rowEdit].Cells["HinhAnh2"].Value = img;

            dgvMonDaChon.Rows[rowEdit].Cells["TenMon2"].Value = ten;
            dgvMonDaChon.Rows[rowEdit].Cells["Gia2"].Value = gia;

            int sl = Convert.ToInt32(dgvMonDaChon.Rows[rowEdit].Cells["SoLuong2"].Value);
            dgvMonDaChon.Rows[rowEdit].Cells["ThanhTien2"].Value = sl * gia;

            rowEdit = -1;
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvMonDaChon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn món cần đổi bên danh sách đã chọn");
                return;
            }

            rowEdit = dgvMonDaChon.SelectedRows[0].Index;

            MessageBox.Show("Hãy chọn món mới bên danh sách món ăn");
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMonDaChon.SelectedRows.Count > 0)
            {
                dgvMonDaChon.Rows.RemoveAt(dgvMonDaChon.SelectedRows[0].Index);
            }
        }
        private int rowEdit = -1;

        private void DgvMonDaChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Nút tăng
            if (dgvMonDaChon.Columns[e.ColumnIndex].Name == "Tang")
            {
                int sl = Convert.ToInt32(dgvMonDaChon.Rows[e.RowIndex].Cells["SoLuong2"].Value);
                sl++;
                dgvMonDaChon.Rows[e.RowIndex].Cells["SoLuong2"].Value = sl;

                long gia = Convert.ToInt64(dgvMonDaChon.Rows[e.RowIndex].Cells["Gia2"].Value);
                dgvMonDaChon.Rows[e.RowIndex].Cells["ThanhTien2"].Value = sl * gia;
            }

            // Nút giảm
            if (dgvMonDaChon.Columns[e.ColumnIndex].Name == "Giam")
            {
                int sl = Convert.ToInt32(dgvMonDaChon.Rows[e.RowIndex].Cells["SoLuong2"].Value);
                if (sl > 1) sl--;

                dgvMonDaChon.Rows[e.RowIndex].Cells["SoLuong2"].Value = sl;

                long gia = Convert.ToInt64(dgvMonDaChon.Rows[e.RowIndex].Cells["Gia2"].Value);
                dgvMonDaChon.Rows[e.RowIndex].Cells["ThanhTien2"].Value = sl * gia;
            }
        }

        private void BtnChon_Click(object sender, EventArgs e)
        {
            if (dgvMonAn.SelectedRows.Count == 0) return;

            DataGridViewRow rSrc = dgvMonAn.SelectedRows[0];

            string maMon = rSrc.Cells["MaMon"].Value.ToString();
            string ten = rSrc.Cells["TenMon"].Value.ToString();
            long gia = Convert.ToInt64(rSrc.Cells["Gia"].Value);

            string fileName = rSrc.Cells["HinhAnh"].Value?.ToString();
            Image img = GetImageFromResource(fileName);

            // ===== ĐANG Ở CHẾ ĐỘ ĐỔI MÓN =====
            if (rowEdit >= 0)
            {
                DataGridViewRow rowDangSua = dgvMonDaChon.Rows[rowEdit];
                int slDangSua = Convert.ToInt32(rowDangSua.Cells["SoLuong2"].Value);

                // TÌM MÓN TRÙNG (KHÁC DÒNG ĐANG SỬA)
                foreach (DataGridViewRow row in dgvMonDaChon.Rows)
                {
                    if (row.Index == rowEdit) continue;

                    if (row.Cells["MaMon2"].Value?.ToString() == maMon)
                    {
                        // GỘP SỐ LƯỢNG
                        int sl = Convert.ToInt32(row.Cells["SoLuong2"].Value);
                        sl += slDangSua;

                        row.Cells["SoLuong2"].Value = sl;
                        row.Cells["ThanhTien2"].Value = sl * gia;

                        // XÓA DÒNG ĐANG SỬA
                        dgvMonDaChon.Rows.RemoveAt(rowEdit);

                        rowEdit = -1;
                        return;
                    }
                }

                // KHÔNG TRÙNG THÌ THAY THẾ BÌNH THƯỜNG
                rowDangSua.Cells["MaMon2"].Value = maMon;
                rowDangSua.Cells["HinhAnh2"].Value = img;
                rowDangSua.Cells["TenMon2"].Value = ten;
                rowDangSua.Cells["Gia2"].Value = gia;
                rowDangSua.Cells["ThanhTien2"].Value = slDangSua * gia;

                rowEdit = -1;
                return;
            }

            // CHẾ ĐỘ THÊM BÌNH THƯỜNG
            foreach (DataGridViewRow row in dgvMonDaChon.Rows)
            {
                if (row.Cells["MaMon2"].Value?.ToString() == maMon)
                {
                    int sl = Convert.ToInt32(row.Cells["SoLuong2"].Value);
                    sl++;
                    row.Cells["SoLuong2"].Value = sl;
                    row.Cells["ThanhTien2"].Value = sl * gia;
                    return;
                }
            }

            // THÊM DÒNG MỚI 
            int idx = dgvMonDaChon.Rows.Add();
            DataGridViewRow r = dgvMonDaChon.Rows[idx];

            r.Cells["MaMon2"].Value = maMon;
            r.Cells["HinhAnh2"].Value = img;
            r.Cells["TenMon2"].Value = ten;
            r.Cells["SoLuong2"].Value = 1;
            r.Cells["Gia2"].Value = gia;
            r.Cells["ThanhTien2"].Value = gia;
            r.Cells["Tang"].Value = "+";
            r.Cells["Giam"].Value = "-";
        }

        private void CboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoai.SelectedValue == null) return;

            string dmID = cboLoai.SelectedValue.ToString();
            NhaHang_DAL dal = new NhaHang_DAL();
            DataTable dt = dal.LayMonTheoDanhMuc(dmID);

            var list = dt.AsEnumerable()
                .Select(r => new
                {
                    MaMon = r.Field<string>("MONAN_ID"),
                    TenMon = r.Field<string>("TENMON"),
                    TrangThai = r.Field<string>("TRANGTHAI"),
                    Gia = r.Field<long>("GIA"),
                    MoTa = r.Field<string>("MOTA"),
                    HinhAnh = r.Field<string>("URL"),
                    DanhMuc = r.Field<string>("TENDM")
                })
                .ToList();

            dgvMonAn.DataSource = list;
        }

        private void DgvMonAn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMonAn.Columns[e.ColumnIndex].Name == "HinhAnh" && e.Value != null)
            {
                string fileName = e.Value.ToString();
                e.Value = GetImageFromResource(fileName);
                e.FormattingApplied = true;
            }
        }

        private void FormMonAn_Load(object sender, EventArgs e)
        {
            //Cố định cột
            dgvMonAn.AutoGenerateColumns = false;
            dgvMonDaChon.AutoGenerateColumns = false;

            dgvMonAn.AllowUserToAddRows = false;
            dgvMonDaChon.AllowUserToAddRows = false;

            //cố định ảnh
            DataGridViewImageColumn imgCol =
                (DataGridViewImageColumn)dgvMonAn.Columns["HinhAnh"];

            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgCol.Width = 80;
            imgCol.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            //Cấu hình ảnh
            DataGridViewImageColumn imgCol2 =
                (DataGridViewImageColumn)dgvMonDaChon.Columns["HinhAnh2"];

            imgCol2.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgCol2.Width = 60;
            imgCol2.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            //Set kích thước
            dgvMonAn.DataBindingComplete += DgvMonAn_DataBindingComplete;

            //Load
            LoadThongTinNhaHang();
            LoadDanhMuc();
            LoadDanhSachMonAn();

        }

        private void DgvMonAn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMonAn.Rows)
            {
                row.Height = 60;
            }
        }

        private void LoadDanhMuc()
        {
            NhaHang_DAL dal = new NhaHang_DAL();
            DataTable dt = dal.LayDanhMucTheoNhaHang(nhaHangID);

            cboLoai.DataSource = dt;
            cboLoai.DisplayMember = "TENDM";
            cboLoai.ValueMember = "DANHMUC_ID";
        }

        private void LoadThongTinNhaHang()
        {
            NhaHang_DAL dal = new NhaHang_DAL();
            DataTable dt = dal.LayThongTinNhaHang(nhaHangID);

            if (dt.Rows.Count > 0)
            {
                txtNhaHang.Text = dt.Rows[0]["TEN"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhà hàng có ID = " + nhaHangID);
            }
        }
        private void LoadDanhSachMonAn()
        {
            NhaHang_DAL dal = new NhaHang_DAL();
            DataTable dt = dal.LayMonTheoNhaHang(nhaHangID);

            var list = dt.AsEnumerable()
                .Where(r => r.Field<int>("SOLUONG") > 0)
                .Select(r => new
                {
                    HinhAnh = r.Field<string>("URL"),
                    MaMon = r.Field<string>("MONAN_ID"),
                    TenMon = r.Field<string>("TENMON"),
                    TrangThai = r.Field<string>("TRANGTHAI"),
                    Gia = r.Field<long>("GIA"),
                    MoTa = r.Field<string>("MOTA"),
                    DanhMuc = r.Field<string>("TENDM"),
                    SoLuong = r.Field<int>("SOLUONG")
                })
                .ToList();

            dgvMonAn.DataSource = list;
        }
        private Image GetImageFromResource(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return Properties.Resources.h1; // ảnh mặc định

            switch (fileName.ToLower())
            {
                case "h1.jpg": return Properties.Resources.h1;
                case "h2.jpg": return Properties.Resources.h2;
                case "h3.jpg": return Properties.Resources.h3;
                case "h4.jpg": return Properties.Resources.h4;
                case "h5.jpg": return Properties.Resources.h5;
                default: return Properties.Resources.h1;
            }
        }

    }
}
