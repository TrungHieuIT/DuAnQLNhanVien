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
   public class DataProvider
    {
       // SqlConnection cn; 

        public string GetMD5(string chuoi)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }
        public string type;
        public bool Login(string username, string password)
        {
<<<<<<< HEAD
            string user = GetMD5(username);
            string pass = GetMD5(password);
=======
>>>>>>> 86e7dfcd345bbdec4088434cc3f49e0b5a583a6d
            string cnStr = "Server =.; Database =EE; Integrated security = true";
            SqlConnection cn = new SqlConnection(cnStr);
            cn.Open();
            string sql = "SELECT Type FROM Users WHERE Username = '" + username + "' AND Password = '" + password + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            type = (string)cmd.ExecuteScalar();
            cn.Close();

            if (type == "1" || type == "2")
                return true;

            return false;
        }
    }
}
