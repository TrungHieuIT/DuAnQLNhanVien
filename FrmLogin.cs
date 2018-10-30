using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace DemoQLNhanVien_BTL_
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                string userName = GetMD5(txtUserName.Text);
                string password = GetMD5(txtPass.Text);
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) // xét thử rỗng với trống không 
                {
                    MessageBox.Show("Yêu cầu thông tin chưa đầy đủ ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Login(userName, password))
                    {
                       FrmLogin frm = new FrmLogin();
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("UserName hoặc Password không đúng !", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        if (result == DialogResult.Cancel)
                        {
                            Application.Exit();
                        }
                        else
                        {
                            txtUserName.Focus();
                        }
                    }
                }
            }
        }
        public string type;
        private bool Login(string username, string password)
        {
            string cnStr = "Server =TrungHieuIT\\SQLEXPRESS; Database = QLNhanVien; Integrated security = true";
            SqlConnection cn = new SqlConnection(cnStr);
            cn.Open();
           
            string sql = "SELECT Type FROM Users WHERE Username = '" + username + "' AND password = '" + password + "'";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        
    }
}
