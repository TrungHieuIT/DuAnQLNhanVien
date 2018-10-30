using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLNhanVien_BTL_
{
   public abstract class QLNV
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public QLNV()
        {

        }
        public QLNV(string id, string name, string address, string phone, string position)
        {
            ID = id;
            Name = name;
            Address = address;
            Phone = phone;
            Position = position;
        }
        public const int luong = 200000;
        public abstract double TinhTienLuong(int soNgayLam);
    }
}
