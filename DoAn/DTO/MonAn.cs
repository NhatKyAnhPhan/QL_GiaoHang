using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class MonAn
    {
        private string monAnId;
        private string monAnName;
        private long gia;
        private int soLuong;
        private string moTa;
        private string trangThai;
        private string image;
        private string danhMucId;

        public MonAn() { }
        public MonAn(string monAnId, string monAnName, long gia, int soLuong, string moTa, string trangThai, string image, string danhMucId)
        {
            this.monAnId = monAnId;
            this.monAnName = monAnName;
            this.gia = gia;
            this.soLuong = soLuong;
            this.moTa = moTa;
            this.trangThai = trangThai;
            this.image = image;
            this.danhMucId = danhMucId;
        }
        public string MonAnId { get {  return monAnId; } set { monAnId = value; } }
        public string MonAnName { get {  return monAnName; } set {  monAnName = value; } }
        public long Gia { get {  return gia; } set {  gia = value; } }
        public string MoTa { get {  return moTa; } set {  moTa = value; } }
        public string TrangThai { get {  return trangThai; } set {  trangThai = value; } }
        public string Image { get { return image; } set { image = value; } }
        public string DanhMucId { get { return danhMucId; } set { danhMucId = value; } }
        public int SoLuong { get { return soLuong; } set {  soLuong = value; } }
    }
}
