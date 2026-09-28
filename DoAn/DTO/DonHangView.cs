using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class DonHangView
    {
        public string DonHangId { get; set; }
        public string TenKhach { get; set; }
        public string TenNhaHang { get; set; }
        public DateTime NgayTao { get; set; }
        public long TongTien { get; set; }
        public string TrangThai { get; set; }
    }
}
