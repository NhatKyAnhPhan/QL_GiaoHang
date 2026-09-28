using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.BLL;
using DoAn.DTO;

namespace DoAn.UI
{
    public partial class FormGiaoHang : Form
    {
        private GiaoHang_BLL bll = new GiaoHang_BLL();
        public FormGiaoHang()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.ReadOnly = true;
            dgvCT.ReadOnly = true;

            this.Load += FormGiaoHang_Load;
            cbTrangThai.SelectedIndexChanged += cbTrangThai_SelectedIndexChanged;
            btnTim.Click += btnTim_Click;
            dgvDonHang.CellClick += dgvDonHang_CellClick;
            btnNhanDon.Click += btnNhanDon_Click;
            btnDaGiao.Click += btnDaGiao_Click;
            btnHuyDon.Click += btnHuyDon_Click;
        }

        private void FormGiaoHang_Load(object sender, EventArgs e)
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Tất cả");
            cbTrangThai.Items.Add("Chờ xác nhận");
            cbTrangThai.Items.Add("Đã xác nhận");
            cbTrangThai.Items.Add("Đang giao");
            cbTrangThai.SelectedIndex = 0;

            lblChonDon.Text = "Chưa chọn đơn hàng";

            LoadDonHang();
            EnableActionButtons(false);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }
        private void LoadDonHang()
        {
            try
            {
                string trangThai = cbTrangThai.Text;
                if (trangThai == "Tất cả") trangThai = string.Empty;

                string tukhoa = txtTimKiem.Text?.Trim() ?? string.Empty;

                DataTable dt = bll.LoadDanhSachDon(trangThai, tukhoa);
                dgvDonHang.DataSource = dt;

                if (dgvDonHang.Columns.Contains("DONHANG_ID")) dgvDonHang.Columns["DONHANG_ID"].HeaderText = "Mã đơn";
                if (dgvDonHang.Columns.Contains("TenKhach")) dgvDonHang.Columns["TenKhach"].HeaderText = "Khách";
                if (dgvDonHang.Columns.Contains("TenNhaHang")) dgvDonHang.Columns["TenNhaHang"].HeaderText = "Nhà hàng";
                if (dgvDonHang.Columns.Contains("NGAY_TAO")) dgvDonHang.Columns["NGAY_TAO"].HeaderText = "Ngày tạo";
                if (dgvDonHang.Columns.Contains("TONG_TIEN")) dgvDonHang.Columns["TONG_TIEN"].HeaderText = "Tổng tiền";
                if (dgvDonHang.Columns.Contains("TRANGTHAI")) dgvDonHang.Columns["TRANGTHAI"].HeaderText = "Trạng thái";

                dgvCT.DataSource = null;
                ClearInfoBoxes();
                lblChonDon.Text = "Chưa chọn đơn hàng";
                EnableActionButtons(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách đơn:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];
                if (row == null) return;

                string donId = row.Cells["DONHANG_ID"].Value?.ToString();
                if (string.IsNullOrEmpty(donId)) return;

                lblChonDon.Text = $"Đơn: {donId}";

                LoadChiTietDon(donId);
                LoadThongTinDon(donId);
                LoadTienDonHang(donId);

                string trangThai = row.Cells["TRANGTHAI"]?.Value?.ToString() ?? "";
                UpdateActionButtonsByStatus(trangThai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadChiTietDon(string donId)
        {
            try
            {
                DataTable dt = bll.LoadChiTietDon(donId);
                dgvCT.DataSource = dt;

                if (dgvCT.Columns.Contains("TENMON")) dgvCT.Columns["TENMON"].HeaderText = "Món ăn";
                if (dgvCT.Columns.Contains("SOLUONG")) dgvCT.Columns["SOLUONG"].HeaderText = "SL";
                if (dgvCT.Columns.Contains("GHICHU")) dgvCT.Columns["GHICHU"].HeaderText = "Ghi chú";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load chi tiết đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThongTinDon(string donId)
        {
            try
            {
                DonHangThongTin info = bll.LoadThongTinDon(donId);
                if (info == null)
                {
                    ClearInfoBoxes();
                    return;
                }
                // thông tin khách
                txtTenKH.Text = info.TenKhach;
                txtSDTKH.Text = info.SdtKhach;
                txtDiaChiKH.Text = info.DiaChiKhach;

                // thông tin nhà hàng
                txtTenNH.Text = info.TenNhaHang;
                txtSDTNH.Text = info.SdtNhaHang;
                txtDiaChiNH.Text = info.DiaChiNhaHang;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load thông tin đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTienDonHang(string donId)
        {
            var info = bll.LoadTienDonHang(donId);
            if (info == null)
            {
                lblTongTien.Text = "0 đ";
                lblPhiGiao.Text = "0 đ";
                lblKhachCanTra.Text = "0 đ";
                return;
            }

            lblTongTien.Text = "Tổng tiền: " + info.TongTien.ToString("N0") + " vnđ";
            lblPhiGiao.Text = "Phí giao: " + info.PhiGiao.ToString("N0") + " vnđ";
            lblKhachCanTra.Text = "Khách cần trả: " + info.KhachCanTra.ToString("N0") + " vnđ";
            // Thêm hiển thị KM
            if (info.KhuyenMaiId == null || info.KhuyenMaiId == "")
                lblKhuyenMai.Text = "Khuyến mãi: Không có";
            else
                lblKhuyenMai.Text = $"Khuyến mãi: Giảm {info.PhanTramGiam}% ({info.KhuyenMaiId})";

        }

        private void ClearInfoBoxes()
        {
            txtTenKH.Text = "";
            txtSDTKH.Text = "";
            txtDiaChiKH.Text = "";

            txtTenNH.Text = "";
            txtDiaChiNH.Text = "";
            txtSDTNH.Text = "";
        }

        private void EnableActionButtons(bool enabled)
        {
            btnNhanDon.Enabled = enabled;
            btnDaGiao.Enabled = enabled;
            btnHuyDon.Enabled = enabled;
        }

        private void UpdateActionButtonsByStatus(string trangThai)
        {
            // nếu Chờ xác nhận -> có thể Nhận hoặc Hủy
            // nếu Đã xác nhận -> Nhận, Hủy
            // nếu Đang giao -> Đã giao, Hủy
            // nếu Đã giao / Đã hủy -> disable
            btnNhanDon.Enabled = false;
            btnDaGiao.Enabled = false;
            btnHuyDon.Enabled = false;

            if (string.IsNullOrEmpty(trangThai)) return;
            trangThai = trangThai.Trim();

            if (trangThai == "Chờ xác nhận" || trangThai == "Đã xác nhận")
            {
                btnNhanDon.Enabled = true;
                btnHuyDon.Enabled = true;
            }
            else if (trangThai == "Đang giao")
            {
                btnDaGiao.Enabled = true;
                btnHuyDon.Enabled = true;
            }
            else
            {
                // Đã giao, Đã hủy -> hủy tất cả
            }
        }

        private string GetSelectedDonHangId()
        {
            if (dgvDonHang.CurrentRow == null) return null;
            return dgvDonHang.CurrentRow.Cells["DONHANG_ID"]?.Value?.ToString();
        }

        private void btnNhanDon_Click(object sender, EventArgs e)
        {
            string id = GetSelectedDonHangId();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn chắc muốn nhận đơn {id} ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            try
            {
                int r = bll.CapNhatTrangThai(id, "Đang giao");
                if (r > 0)
                {
                    MessageBox.Show("Đã nhận đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDonHang();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhận đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDaGiao_Click(object sender, EventArgs e)
        {
            string id = GetSelectedDonHangId();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận đơn {id} đã giao?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            try
            {
                int r = bll.CapNhatTrangThai(id, "Đã giao");
                if (r > 0)
                {
                    MessageBox.Show("Đã cập nhật trạng thái: Đã giao.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDonHang();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận đã giao: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            string id = GetSelectedDonHangId();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn hủy đơn {id} ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            try
            {
                int r = bll.CapNhatTrangThai(id, "Đã hủy");
                if (r > 0)
                {
                    MessageBox.Show("Đã hủy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDonHang();
                }
                else
                {
                    MessageBox.Show("Hủy thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbTrangThai.SelectedIndex = 0; // chọn lại "Tất cả"
            txtTimKiem.Text = "";
            LoadDonHang();   // load lại list chính
            dgvCT.DataSource = null;
            ClearInfoBoxes();

            lblChonDon.Text = "Chưa chọn đơn hàng";
            lblTongTien.Text = "";
            lblPhiGiao.Text = "";
            lblKhachCanTra.Text = "";
            lblKhuyenMai.Text = "Khuyến mãi: ---";


        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string id = GetSelectedDonHangId();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn một đơn để xem thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadChiTietDon(id);
            LoadThongTinDon(id);

            lblChonDon.Text = $"Đơn: {id}";
        }

        private void FormGiaoHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn thoát màn hình giao hàng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }

}
