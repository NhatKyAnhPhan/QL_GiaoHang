using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DAL
{
    public class TaiKhoan_DAL
    {
        private Connect_DB conn = new Connect_DB();

        public bool KiemTraMatKhauCu(string id, string matKhauCu)
        {
            try
            {
                conn.open_connect();
        
                string sql = "SELECT COUNT(*) FROM KHACHHANG WHERE KHACHHANG_ID = @id AND MATKHAU = @pass";

                SqlCommand cmd = new SqlCommand(sql, conn.get_connect());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pass", matKhauCu);

                int ketQua = Convert.ToInt32(cmd.ExecuteScalar());
                conn.close_connect();

                return ketQua > 0; 
            }
            catch
            {
                conn.close_connect();
                return false;
            }
        }

        public bool CapNhatMatKhau(string id, string matKhauMoi)
        {
            try
            {
                conn.open_connect();
                string sql = "UPDATE KHACHHANG SET MATKHAU = @newPass WHERE KHACHHANG_ID = @id";

                SqlCommand cmd = new SqlCommand(sql, conn.get_connect());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@newPass", matKhauMoi);

                int result = cmd.ExecuteNonQuery();
                conn.close_connect();

                return result > 0; 
            }
            catch
            {
                conn.close_connect();
                return false;
            }
        }
    }
}