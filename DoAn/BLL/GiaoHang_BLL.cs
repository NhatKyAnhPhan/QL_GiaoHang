using DoAn.DAL;
using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.BLL
{
    public class GiaoHang_BLL
    {
        private GiaoHang_DAL dal = new GiaoHang_DAL();

        // 1. Lấy danh sách đơn
        public DataTable LoadDanhSachDon(string trangThai, string tuKhoa)
        {
            return dal.LoadDanhSachDon(trangThai, tuKhoa);
        }

        // 2. Lấy chi tiết món ăn
        public DataTable LoadChiTietDon(string donId)
        {
            return dal.LoadChiTietDon(donId);
        }

        // 3. Lấy thông tin khách + nhà hàng
        public DonHangThongTin LoadThongTinDon(string donId)
        {
            DataTable dt = dal.LoadThongTinDon(donId);
            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];

            return new DonHangThongTin
            {
                TenKhach = r["TenKhach"].ToString(),
                SdtKhach = r["SdtKhach"].ToString(),
                DiaChiKhach = r["DiaChiKhach"].ToString(),

                TenNhaHang = r["TenNhaHang"].ToString(),
                DiaChiNhaHang = r["DiaChiNhaHang"].ToString(),
                SdtNhaHang = r["SdtNhaHang"].ToString()
            };
        }

        // 4. Đổi trạng thái đơn hàng
        public int CapNhatTrangThai(string donId, string trangThai)
        {
            return dal.CapNhatTrangThai(donId, trangThai);
        }
        public DonHangThanhToan_DTO LoadTienDonHang(string donId)
        {
            return dal.LoadTienDonHang(donId);
        }

    }
}
