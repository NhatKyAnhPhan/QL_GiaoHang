using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.DTO;

namespace DoAn.DAL
{
    public class KhachHang_DAL
    {
        private Connect_DB db = new Connect_DB();


        public DataTable LayDanhSachNguoiDung()
        {
            DataTable dt = new DataTable();
            string storedProcName = "sp_HienThiDanhSachNguoiDung";

            try
            {
                db.open_connect();
                SqlCommand cmd = new SqlCommand(storedProcName, db.get_connect());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception) {  }
            finally { db.close_connect(); }
            return dt;
        }

   
        public int KT_KhoaChinh_NV(string manv)
        {
            string query = "SELECT COUNT(*) FROM KHACHHANG WHERE KHACHHANG_ID = @MaNV";
            SqlParameter[] parameters = { new SqlParameter("@MaNV", manv) };
            object result = db.ExecuteScalar(query, parameters);
            return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
        }

        public int ThemKhachHang(TK_KhachHang kh)
        {
            string query = "INSERT INTO KHACHHANG (KHACHHANG_ID, HOTEN, CREATE_AT, DIACHI, SDT, MATKHAU, ROLE_ID) VALUES (@ID, @HT, GETDATE(), @DC, @SDT, @MK, @Role)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID", kh.KhachHangId),
                new SqlParameter("@HT", kh.KhachHangName),
                new SqlParameter("@DC", kh.DiaChi ?? (object)DBNull.Value),
                new SqlParameter("@SDT", kh.Sdt ?? (object)DBNull.Value),
                new SqlParameter("@MK", kh.MatKhau),
                new SqlParameter("@Role", kh.RoleId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public int SuaKhachHang(TK_KhachHang kh)
        {
            string query = "UPDATE KHACHHANG SET HOTEN = @HT, DIACHI = @DC, SDT = @SDT WHERE KHACHHANG_ID = @ID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID", kh.KhachHangId),
                new SqlParameter("@HT", kh.KhachHangName),
                new SqlParameter("@DC", kh.DiaChi ?? (object)DBNull.Value),
                new SqlParameter("@SDT", kh.Sdt ?? (object)DBNull.Value)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public int XoaKhachHang(string khachHangID)
        {
            string query = "DELETE FROM KHACHHANG WHERE KHACHHANG_ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", khachHangID) };
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
