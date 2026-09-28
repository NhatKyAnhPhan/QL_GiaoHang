using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class DonHangThanhToan_DTO
    {
        public string DonHangID { get; set; }
        public long TongTien { get; set; }
        public long PhiGiao { get; set; }
        public long TienSauGiam { get; set; }
        public string KhuyenMaiId { get; set; }
        public int PhanTramGiam { get; set; }

        public long KhachCanTra => TienSauGiam + PhiGiao;
    }
}
