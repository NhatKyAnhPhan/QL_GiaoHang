using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;

namespace DoAn.DAL
{
    internal class DangNhap_DAL
    {
        DAL.Connect_DB conn=new DAL.Connect_DB();
        //Kiểm tra đăng nhập
        public string DangNhap(string id, string matKhau)
        {
            try
            {
                conn.open_connect();

                string sql = @"SELECT ROLE_ID 
                       FROM KHACHHANG 
                       WHERE KHACHHANG_ID = @id AND MATKHAU = @pass";

                SqlCommand cmd = new SqlCommand(sql, conn.get_connect());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pass", matKhau);

                object role = cmd.ExecuteScalar();

                conn.close_connect();

                if (role == null)
                    return null;

                return role.ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}
