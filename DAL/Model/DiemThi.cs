using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class DiemThi
    {
        public int MaDiem { get; set; }
        public decimal Diem { get; set; }
        public int MSSV { get; set; } 
        public string HocKy { get; set; }
        public int MaMon { get; set; } 
        public string XepLoai { get; set; }
        public int MaGV { get; set; } 
    }

}
