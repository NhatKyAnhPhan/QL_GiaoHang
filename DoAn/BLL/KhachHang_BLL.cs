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
    public class KhachHang_BLL
    {
        private KhachHang_DAL dal = new KhachHang_DAL();

        public DataTable HienThiDanhSachNguoiDung()
        {
            return dal.LayDanhSachNguoiDung();
        }

        public int ThemKhachHang(TK_KhachHang kh)
        {
            if (string.IsNullOrEmpty(kh.RoleId))
            {
                kh.RoleId = "R002";
            }
            if (string.IsNullOrEmpty(kh.MatKhau))
            {
                kh.MatKhau = "123456"; 
            }
            return dal.ThemKhachHang(kh);
        }
        public int SuaKhachHang(TK_KhachHang kh)
        {
            return dal.SuaKhachHang(kh);
        }

        public int XoaKhachHang(string khachHangID)
        {
            return dal.XoaKhachHang(khachHangID);
        }

        public int KT_KhoaChinh_NV(string manv)
        {
            return dal.KT_KhoaChinh_NV(manv);
        }
    }
}
