using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class DanhMuc
    {
        private string danhMucId;
        private string danhMucName;
        private string moTa;
        private string nhaHangId;

        public DanhMuc()
        { }
        public DanhMuc(string danhMucId, string danhMucName, string moTa, string nhaHangId)
        {
            this.danhMucId = danhMucId;
            this.danhMucName = danhMucName;
            this.moTa = moTa;
            this.nhaHangId = nhaHangId;
        }
        public string DanhMucId { get {  return danhMucId; } set {  danhMucId = value; } }
        public string DanhMucName { get {  return danhMucName; } set { danhMucName = value; } }
        public string MoTa { get {  return moTa; } set {  moTa = value; } } 
        public string NhaHangId { get { return nhaHangId; } set {  nhaHangId = value; } }   
    }
}
