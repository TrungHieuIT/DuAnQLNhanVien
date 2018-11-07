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
<<<<<<< HEAD

        public SqlConnection cnn;
        public DataTable memberTable;
        public SqlDataAdapter da;
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            string sql = " Select * FROM DSNhanVien1";
            da = new SqlDataAdapter(sql,cnn);
            int number = da.Fill(ds);
            return ds;
        }
=======
        //public QLNV qlnv = new QLNV();
        public DataTable daT = new DataTable();
>>>>>>> 95d13f6764b1be0b6680316cc5c8c34ab3be42f1
        public void Them (DataTable daT, string id , string name , string phone , string address , string position )
        {
             
            DataRow row = daT.NewRow();
            row["MaNV"] = id;
            row["HoTenNV"] = name;
            row["DiaChi"] = address;
            row["SDT"] = phone;
            row["ChucVu"] = position;     
            daT.Rows.Add(row);

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
           
        }
        public void capNhap()
        {

        }
        public void Xoa ()
        {

        }
    }
}
