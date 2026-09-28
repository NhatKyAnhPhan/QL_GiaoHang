using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.DTO
{
    public class KhuyenMai
    {
        private string khuyenMaiId;
        private string khuyenMaiName;
        private int phamTramGiam;
        private DateTime ngayBD;
        private DateTime ngayKT;

        public KhuyenMai() { }
        public KhuyenMai(string khuyenMaiId, string khuyenMaiName, int phamTramGiam, DateTime ngayBD, DateTime ngayKT)
        {
            this.khuyenMaiId = khuyenMaiId;
            this.khuyenMaiName = khuyenMaiName;
            this.phamTramGiam = phamTramGiam;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }

        public string KhuyenMaiId { get {  return khuyenMaiId; } set { khuyenMaiId = value; } }  
        public string KhuyenMaiName
        {
            get { return khuyenMaiName; }
            set { khuyenMaiName = value;}
        }
        public int PhamTramGiam 
        {
            get { return phamTramGiam;}
            set { phamTramGiam = value;}
        }
        public DateTime NgayBD
        {
            get { return ngayBD; }
            set { ngayBD = value; }
        }
        public DateTime NgayKT
        {
            get { return ngayKT; }
            set { ngayKT = value; }
        }
    }
}
