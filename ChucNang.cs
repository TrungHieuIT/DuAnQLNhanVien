using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using DemoQLNhanVien_BTL_;

namespace DemoQLNhanVien_BTL_
{
   public class ChucNang
    {
        //public QLNV qlnv = new QLNV();
        public DataTable daT = new DataTable();
        public void Them (DataTable daT, string id , string name , string phone , string address , string position )
        {
             
            DataRow row = daT.NewRow();
            row["MaNV"] = id;
            row["HoTenNV"] = name;
            row["DiaChi"] = address;
            row["SDT"] = phone;
            row["ChucVu"] = position;
            // row["NgayLam"] = txtDay.Text;
            daT.Rows.Add(row);

            //return daT;
        }
        
        public double TienLuong (int soNgayLam,int chon)
        {
            double kq = 0;
           switch(chon)
            {

                case 1:
                    {
                        GiamDoc gd = new GiamDoc();
                        kq = gd.TinhTienLuong(soNgayLam);
                        return kq;
                    }
                case 2:
                    {
                        PhoGiamDoc pgd = new PhoGiamDoc();
                        kq = pgd.TinhTienLuong(soNgayLam);
                        return kq;
                    }
                case 3:
                    {
                        TruongPhong tp = new TruongPhong();
                        kq = tp.TinhTienLuong(soNgayLam);
                        return kq;                       
                    }
                case 4:
                    {
                        NhanVien nv = new NhanVien();
                        kq = nv.TinhTienLuong(soNgayLam);
                        return kq;
                    }
                   
            }
            return kq;
        }
        public void Sua(int n,int []a)
        {
            for (int i = 0; i < n;i++)
            {
                if (a[i]==1)
                {
                    return;
                }
            }
        }
        public void capNhap()
        {

        }
        public void Xoa ()
        {

        }
    }
}
