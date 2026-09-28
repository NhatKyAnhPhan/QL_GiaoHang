using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.DAL;
using DoAn.DTO;

namespace DoAn.BLL
{
    public class TaiKhoan_BLL
    {
        private TaiKhoan_DAL dal = new TaiKhoan_DAL();

        public bool CheckMatKhauCu(string id, string mkCu)
        {
            return dal.KiemTraMatKhauCu(id, mkCu);
        }

        public bool DoiMatKhau(string id, string mkMoi)
        {
            return dal.CapNhatMatKhau(id, mkMoi);
        }
    }
}