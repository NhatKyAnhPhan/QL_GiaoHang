using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.BLL
{
    public class DangNhap_BLL
    {
        DAL.DangNhap_DAL dal = new DAL.DangNhap_DAL();

        public string DangNhap(string id, string pass)
        {
            return dal.DangNhap(id, pass);
        }
    }
}
