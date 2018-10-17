using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLNhanVien_BTL_
{
    class QLNV
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public QLNV(string id, string name, string address, string phone, string position)
        {
            ID = id;
            Name = name;
            Address = address;
            Phone = phone;
            Position = position;
        }
    }
}
