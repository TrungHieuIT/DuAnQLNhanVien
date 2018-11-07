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
    }
}
