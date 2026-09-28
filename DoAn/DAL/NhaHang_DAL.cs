using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.DTO;

namespace DoAn.DAL
{
    public class NhaHang_DAL
    {
        private Connect_DB db = new Connect_DB();
        public DataTable LayDanhSachKhuVuc()
        {
            DataTable dt = new DataTable();
            string query = "SELECT DISTINCT DIACHI FROM NHAHANG";

            try
            {
                db.open_connect();
                SqlCommand cmd = new SqlCommand(query, db.get_connect());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            finally
            {
                db.close_connect();
            }

            return dt;
        }
        public DataTable LayNhaHangTheoKhuVuc(string khuVuc)
        {
            DataTable dt = new DataTable();
            string query = "SELECT NHAHANG_ID, TEN, DIACHI, EMAIL, SDT FROM NHAHANG WHERE DIACHI = @kv";

            try
            {
                db.open_connect();
                SqlCommand cmd = new SqlCommand(query, db.get_connect());
                cmd.Parameters.AddWithValue("@kv", khuVuc);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {
            }
            finally
            {
                db.close_connect();
            }

            return dt;
        }
        public DataTable LayThongTinNhaHang(string id)
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM NHAHANG WHERE NHAHANG_ID = @id";

            try
            {
                db.open_connect();
                SqlCommand cmd = new SqlCommand(query, db.get_connect());
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            finally
            {
                db.close_connect();
            }

            return dt;
        }
        public DataTable LayMonTheoNhaHang(string nhaHangID)
        {
            DataTable dt = new DataTable();
            string query = @"
SELECT 
    m.MONAN_ID,
    m.URL,
    m.TENMON,
    m.GIA,
    m.SOLUONG,      
    m.MOTA,
    m.TRANGTHAI,
    dm.TENDM
FROM MONAN m
INNER JOIN DANHMUC dm ON m.DANHMUC_ID = dm.DANHMUC_ID
WHERE dm.NHAHANG_ID = @id
ORDER BY dm.TENDM, m.TENMON";

            try
            {
                db.open_connect();
                SqlCommand cmd = new SqlCommand(query, db.get_connect());
                cmd.Parameters.AddWithValue("@id", nhaHangID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL load món ăn: " + ex.Message);
            }
            finally
            {
                db.close_connect();
            }
            return dt;
        }
        public DataTable LayDanhMucTheoNhaHang(string nhaHangID)
        {
            DataTable dt = new DataTable();
            string query = "SELECT DANHMUC_ID, TENDM FROM DANHMUC WHERE NHAHANG_ID = @id";

            try
            {
                db.open_connect();

                SqlCommand cmd = new SqlCommand(query, db.get_connect());
                cmd.Parameters.AddWithValue("@id", nhaHangID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL load danh mục: " + ex.Message);
            }
            finally
            {
                db.close_connect();
            }

            return dt;
        }
        public DataTable LayMonTheoDanhMuc(string danhMucID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT 
    m.MONAN_ID,
    m.TENMON,
    m.GIA,
    m.MOTA,
    m.URL,
    m.TRANGTHAI,
    dm.TENDM
FROM MONAN m
JOIN DANHMUC dm ON m.DANHMUC_ID = dm.DANHMUC_ID
WHERE dm.DANHMUC_ID = @danhMucID";

            try
            {
                db.open_connect();

                SqlCommand cmd = new SqlCommand(query, db.get_connect());
                cmd.Parameters.AddWithValue("@danhMucID", danhMucID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL load món theo danh mục: " + ex.Message);
            }
            finally
            {
                db.close_connect();
            }

            return dt;
        }

        public void TaoDonHang(string donHangID, string khachHangID, string nhaHangID)
        {
            string sql = "usp_TaoDonMoi";

            SqlCommand cmd = new SqlCommand(sql, db.get_connect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DONHANG_ID", donHangID);
            cmd.Parameters.AddWithValue("@KHACHHANG_ID", khachHangID);
            cmd.Parameters.AddWithValue("@NHAHANG_ID", nhaHangID);
            cmd.Parameters.AddWithValue("@TONG_TIEN", 0);
            cmd.Parameters.AddWithValue("@KHUYENMAI_ID", DBNull.Value);

            db.open_connect();
            cmd.ExecuteNonQuery();
            db.close_connect();
        }
        public bool ThemChiTietDonHang(ChiTietDonHang ct)
        {
            string sql = @"
IF EXISTS (
    SELECT 1 FROM CT_DONHANG
    WHERE DONHANG_ID = @DonHangID AND MONAN_ID = @MonAnID
)
BEGIN
    UPDATE CT_DONHANG
    SET SOLUONG = SOLUONG + @SoLuong
    WHERE DONHANG_ID = @DonHangID AND MONAN_ID = @MonAnID
END
ELSE
BEGIN
    INSERT INTO CT_DONHANG (DONHANG_ID, MONAN_ID, SOLUONG, DONGIA, GHICHU)
    VALUES (@DonHangID, @MonAnID, @SoLuong, @DonGia, @GhiChu)
END
";

            try
            {
                db.open_connect();
                SqlCommand cmd = new SqlCommand(sql, db.get_connect());
                cmd.Parameters.AddWithValue("@DonHangID", ct.DonHangId);
                cmd.Parameters.AddWithValue("@MonAnID", ct.MonAnId);
                cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
                cmd.Parameters.AddWithValue("@GhiChu", (object)ct.GhiChu ?? DBNull.Value);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm chi tiết đơn hàng: " + ex.Message);
                return false;
            }
            finally
            {
                db.close_connect();
            }
        }
    }
}


