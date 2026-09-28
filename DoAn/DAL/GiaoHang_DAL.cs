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
    public class GiaoHang_DAL
    {
        private Connect_DB db = new Connect_DB();

        // 1. Lấy danh sách đơn hàng theo trạng thái + tìm kiếm
        public DataTable LoadDanhSachDon(string trangThai, string tuKhoa)
        {
            string query = @"
                SELECT 
                    DH.DONHANG_ID,
                    KH.HOTEN AS TenKhach,
                    NH.TEN AS TenNhaHang,
                    DH.NGAY_TAO,
                    DH.TONG_TIEN,
                    DH.TRANGTHAI
                FROM DONHANG DH
                JOIN KHACHHANG KH ON DH.KHACHHANG_ID = KH.KHACHHANG_ID
                JOIN NHAHANG NH ON DH.NHAHANG_ID = NH.NHAHANG_ID
                WHERE (@TrangThai = '' OR DH.TRANGTHAI = @TrangThai)
                AND (
                   DH.DONHANG_ID LIKE '%' + @TuKhoa + '%' OR
    KH.HOTEN LIKE '%' + @TuKhoa + '%' OR
    KH.SDT LIKE '%' + @TuKhoa + '%' OR
    KH.DIACHI LIKE '%' + @TuKhoa + '%' OR
    NH.TEN LIKE '%' + @TuKhoa + '%' OR
    NH.SDT LIKE '%' + @TuKhoa + '%' OR
    NH.DIACHI LIKE '%' + @TuKhoa + '%' OR
    CONVERT(VARCHAR, DH.NGAY_TAO, 103) LIKE '%' + @TuKhoa + '%' OR
    CONVERT(VARCHAR, DH.TONG_TIEN) LIKE '%' + @TuKhoa + '%'
                )";

            SqlParameter[] pr =
            {
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@TuKhoa", tuKhoa)
            };

            return db.GetDataTable(query, pr);
        }

        // 2. Lấy chi tiết món ăn trong đơn
        public DataTable LoadChiTietDon(string donId)
        {
            string query = @"
                SELECT 
                    M.TENMON AS TenMon,
                    CT.SOLUONG,
                    CT.GHICHU
                FROM CT_DONHANG CT
                JOIN MONAN M ON CT.MONAN_ID = M.MONAN_ID
                WHERE CT.DONHANG_ID = @ID";

            SqlParameter[] pr = { new SqlParameter("@ID", donId) };

            return db.GetDataTable(query, pr);
        }

        // 3. Lấy thông tin khách + nhà hàng
        public DataTable LoadThongTinDon(string donId)
        {
            string query = @"
                SELECT 
                    KH.HOTEN AS TenKhach,
                    KH.SDT AS SdtKhach,
                    KH.DIACHI AS DiaChiKhach,

                    NH.TEN AS TenNhaHang,
                    NH.DIACHI AS DiaChiNhaHang,
                    NH.SDT AS SdtNhaHang
                FROM DONHANG DH
                JOIN KHACHHANG KH ON DH.KHACHHANG_ID = KH.KHACHHANG_ID
                JOIN NHAHANG NH ON DH.NHAHANG_ID = NH.NHAHANG_ID
                WHERE DH.DONHANG_ID = @ID";

            return db.GetDataTable(query,
                new SqlParameter[] { new SqlParameter("@ID", donId) }
            );
        }

        // 4. Cập nhật trạng thái đơn hàng
        public int CapNhatTrangThai(string donId, string trangThai)
        {
            string query = "UPDATE DONHANG SET TRANGTHAI = @TT WHERE DONHANG_ID = @ID";

            SqlParameter[] pr =
            {
                new SqlParameter("@TT", trangThai),
                new SqlParameter("@ID", donId)
            };

            return db.ExecuteNonQuery(query, pr);
        }
        public DonHangThanhToan_DTO LoadTienDonHang(string donId)
        {
            string query = @"
        SELECT 
            DH.TONG_TIEN,
            DH.PHI_GIAO,
            DH.KHUYENMAI_ID,
            KM.PT_GIAM,
            dbo.TinhSoTienSauGiamGia(DH.TONG_TIEN, DH.KHUYENMAI_ID) AS TienSauGiam
        FROM DONHANG DH
        LEFT JOIN KHUYENMAI KM ON DH.KHUYENMAI_ID = KM.KHUYENMAI_ID
        WHERE DH.DONHANG_ID = @ID";

            SqlParameter[] pr = { new SqlParameter("@ID", donId) };
            DataTable dt = db.GetDataTable(query, pr);

            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];

            return new DonHangThanhToan_DTO()
            {
                DonHangID = donId,
                TongTien = Convert.ToInt64(r["TONG_TIEN"]),
                PhiGiao = Convert.ToInt64(r["PHI_GIAO"]),
                TienSauGiam = Convert.ToInt64(r["TienSauGiam"]),
                KhuyenMaiId = r["KHUYENMAI_ID"].ToString(),
                PhanTramGiam = r["PT_GIAM"] == DBNull.Value ? 0 : Convert.ToInt32(r["PT_GIAM"])
            };
        }

    }
}
