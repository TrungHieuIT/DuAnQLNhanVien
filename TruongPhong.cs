using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLNhanVien_BTL_
{
    public class TruongPhong : QLNV
    {
        public TruongPhong()
        {
        }

        public TruongPhong(string id, string name, string address, string phone, string position) : base(id, name, address, phone, position)
        {
        }

        public override double TinhTienLuong(int soNgayLam)
        {
            return 1.5 * luong * soNgayLam;
        }
    }
}
