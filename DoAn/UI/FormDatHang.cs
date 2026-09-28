using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAn.UI
{
    public partial class FormDatHang : Form
    {
        //SqlConnection conn = new SqlConnection(
        //    @"Data Source=LAPTOPHYIEN;Initial Catalog=QL_GIAOHANG;Integrated Security=True");
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-I965QD1N;Initial Catalog=QL_GIAOHANG;Integrated Security=True;");

        DataTable dtGioHang = new DataTable();

        public FormDatHang()
        {
            InitializeComponent();

            dtDS.ReadOnly = true;

            // 2. Bắt buộc chọn cả dòng (Khắc phục lỗi bấm vào mà không thêm giỏ hàng)
            dtDS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 3. Chỉ cho chọn 1 món 1 lúc (Tránh lỗi logic)
            dtDS.MultiSelect = false;

            TaoBangGioHang();
            LoadNhaHang();
            LoadKhachHang();
            LoadKhuyenMai();
        }

        private void TaoBangGioHang()
        {
            dtGioHang.Columns.Add("MONAN_ID");
            dtGioHang.Columns.Add("TENMON");
            dtGioHang.Columns.Add("SOLUONG", typeof(int));
            dtGioHang.Columns.Add("GIA", typeof(long));
            dtGioHang.Columns.Add("THANHTIEN", typeof(long));
            dtGioHang.Columns.Add("GHICHU");

            dtGH.DataSource = dtGioHang;

            dtGH.Columns["MONAN_ID"].HeaderText = "Mã món";
            dtGH.Columns["TENMON"].HeaderText = "Tên món";
            dtGH.Columns["SOLUONG"].HeaderText = "SL";
            dtGH.Columns["GIA"].HeaderText = "Giá";
            dtGH.Columns["THANHTIEN"].HeaderText = "Thành tiền";
            dtGH.Columns["GHICHU"].HeaderText = "Ghi chú";
        }


        private void LoadNhaHang()
        {
            cboNhaHang.DataSource = GetData("SELECT NHAHANG_ID, TEN FROM NHAHANG WHERE TRANGTHAI=N'Mở'");
            cboNhaHang.ValueMember = "NHAHANG_ID";
            cboNhaHang.DisplayMember = "TEN";
        }

        private void LoadDanhMuc(string nhaHangID)
        {
            cboMonAn.DataSource = GetData($"SELECT DANHMUC_ID, TENDM FROM DANHMUC WHERE NHAHANG_ID='{nhaHangID}'");
            cboMonAn.ValueMember = "DANHMUC_ID";
            cboMonAn.DisplayMember = "TENDM";
        }

        private void LoadMonAn(string danhMucID)
        {
            dtDS.DataSource = GetData($@"
                SELECT MONAN_ID, TENMON, GIA, SOLUONG, MOTA 
                FROM MONAN 
                WHERE DANHMUC_ID='{danhMucID}' AND TRANGTHAI=N'Còn'");
        }

        private void LoadKhachHang()
        {
            cboKH.DataSource = GetData("SELECT KHACHHANG_ID, HOTEN FROM KHACHHANG");
            cboKH.ValueMember = "KHACHHANG_ID";
            cboKH.DisplayMember = "HOTEN";
        }

        private void LoadKhuyenMai()
        {
            cboKM.DataSource = GetData("SELECT KHUYENMAI_ID, TENKM, PT_GIAM FROM KHUYENMAI");
            cboKM.ValueMember = "KHUYENMAI_ID";
            cboKM.DisplayMember = "TENKM";
        }

        private void cboNhaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhaHang.SelectedValue != null)
            {
                string maNH = cboNhaHang.SelectedValue.ToString().Trim();
                LoadDanhMuc(maNH);
            }
        }
        private void cboMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonAn.SelectedValue != null)
                LoadMonAn(cboMonAn.SelectedValue.ToString());
        }


        private void dtDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTenMon.Text = dtDS.Rows[e.RowIndex].Cells["TENMON"].Value.ToString();
                txtGia.Text = dtDS.Rows[e.RowIndex].Cells["GIA"].Value.ToString();
                txtSL.Text = "1";
                txtGC.Text = "";
            }
        }

        private void dtDS_DoubleClick(object sender, EventArgs e)
        {
            if (dtDS.SelectedRows.Count == 0) return;

            if (string.IsNullOrWhiteSpace(txtSL.Text) || txtSL.Text == "0")
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            string id = dtDS.SelectedRows[0].Cells["MONAN_ID"].Value.ToString();
            string ten = dtDS.SelectedRows[0].Cells["TENMON"].Value.ToString();
            long gia = long.Parse(dtDS.SelectedRows[0].Cells["GIA"].Value.ToString());
            int sl = int.Parse(txtSL.Text);
            long tt = sl * gia;

            dtGioHang.Rows.Add(id, ten, sl, gia, tt, txtGC.Text);
            TinhTongTien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtGH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa!");
                return;
            }

            dtGH.Rows.RemoveAt(dtGH.SelectedRows[0].Index);
            TinhTongTien();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dtGioHang.Rows.Clear();
            txtTenMon.Clear();
            txtGia.Clear();
            txtSL.Clear();
            txtGC.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }


        private void TinhTongTien()
        {
            long tong = 0;

            foreach (DataRow r in dtGioHang.Rows)
                tong += long.Parse(r["THANHTIEN"].ToString());

            textBox1.Text = tong.ToString();

            long giam = 0;
            if (cboKM.SelectedValue != null)
            {
                DataTable km = GetData($"SELECT PT_GIAM FROM KHUYENMAI WHERE KHUYENMAI_ID='{cboKM.SelectedValue}'");
                if (km.Rows.Count > 0)
                {
                    int pt = int.Parse(km.Rows[0][0].ToString());
                    giam = tong * pt / 100;
                }
            }

            textBox2.Text = giam.ToString();
            textBox3.Text = (tong - giam).ToString();
        }

        private void cboKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!");
                return;
            }

            string dhID = "DH" + DateTime.Now.ToString("yyMMddHHmmss");

            conn.Open();

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO DONHANG VALUES (@id, GETDATE(), 15000, @tong, N'Chờ xác nhận', @kh, @nh, @km)", conn);

            cmd.Parameters.AddWithValue("@id", dhID);
            cmd.Parameters.AddWithValue("@tong", long.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@kh", cboKH.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@nh", cboNhaHang.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@km", cboKM.SelectedValue.ToString());
            cmd.ExecuteNonQuery();

            foreach (DataRow r in dtGioHang.Rows)
            {
                SqlCommand ct = new SqlCommand(
                    "INSERT INTO CT_DONHANG VALUES (@dh, @ma, @sl, @gia, @gc)", conn);

                ct.Parameters.AddWithValue("@dh", dhID);
                ct.Parameters.AddWithValue("@ma", r["MONAN_ID"]);
                ct.Parameters.AddWithValue("@sl", r["SOLUONG"]);
                ct.Parameters.AddWithValue("@gia", r["GIA"]);
                ct.Parameters.AddWithValue("@gc", r["GHICHU"]);

                ct.ExecuteNonQuery();
            }

            conn.Close();
            MessageBox.Show("Đặt hàng thành công!");
        }

        private DataTable GetData(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
