using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DAL
{
    internal class Connect_DB
    {
        SqlConnection conn;
        public Connect_DB()
        {
            conn = new SqlConnection("Data Source=LAPTOP-I965QD1N;Initial Catalog=QL_GIAOHANG;Integrated Security=True;");
        }

        public SqlConnection get_connect()
        {
            return conn;
        }

        public void open_connect()
        {
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
        }

        public void close_connect()
        {
            if (conn.State.ToString() == "Open")
            {
                conn.Close();
            }
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            int result = 0;
            SqlCommand command = new SqlCommand(query, conn);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            try
            {
                open_connect();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                close_connect();
            }
            return result;
        }
        public object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            object result = null;
            SqlCommand command = new SqlCommand(query, conn);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            try
            {
                open_connect();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                result = null;
            }
            finally
            {
                close_connect();
            }
            return result;
        }
        public DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            try
            {
                open_connect();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi GetDataTable: " + ex.Message);
            }
            finally
            {
                close_connect();
            }

            return dt;
        }
    }
}
