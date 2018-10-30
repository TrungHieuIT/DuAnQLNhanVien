using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLNhanVien_BTL_
{
    public class GiamDoc : QLNV
    {
        public GiamDoc(string id, string name, string address, string phone, string position) : base(id, name, address, phone, position)
        {

        }
        public GiamDoc():base()
        {

        }
       
        public override double TinhTienLuong(int soNgayLam)
        {
            return 2.5 * luong * soNgayLam;
        }
    }
}
