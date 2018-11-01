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
    }
}
