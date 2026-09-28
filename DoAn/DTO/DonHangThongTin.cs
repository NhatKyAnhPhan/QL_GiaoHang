using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class DonHangThongTin
    {
        public string TenKhach { get; set; }
        public string SdtKhach { get; set; }
        public string DiaChiKhach { get; set; }

        public string TenNhaHang { get; set; }
        public string DiaChiNhaHang { get; set; }
        public string SdtNhaHang { get; set; }

        public long TongTien { get; set; }
        public long PhiGiao { get; set; }
        public long KhachCanTra { get; set; }

    }
}
