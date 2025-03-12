using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class GiangVien
    {
        public int MaGV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public int MaDangNhap { get; set; } 
        public int MaMon { get; set; } 
        public int MaLop { get; set; } 
    }

}
