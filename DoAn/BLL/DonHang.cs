using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.DAL;
using DoAn.DTO;

namespace DoAn.BLL
{
    public class DonHang
    {
        public void LuuDonHang(    string donHangID,     string khachHangID,    string nhaHangID,    List<ChiTietDonHang> listCT)
        {
            NhaHang_DAL dal = new NhaHang_DAL();
            dal.TaoDonHang(donHangID, khachHangID, nhaHangID);
            foreach (var ct in listCT)
            {
                dal.ThemChiTietDonHang(ct);
            }
        }
    }
}
