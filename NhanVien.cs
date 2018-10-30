using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLNhanVien_BTL_
{
    public class NhanVien : QLNV
    {
        public NhanVien(string id, string name, string address, string phone, string position) : base(id, name, address, phone, position)
        {
        }
        public NhanVien():base()
        {

        }
        public override double TinhTienLuong(int soNgayLam)
        {
            return 1.2 * luong * soNgayLam;
        }
    }
}
