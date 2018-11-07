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
using DemoQLNhanVien_BTL_;
namespace DemoQLNhanVien_BTL_
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        
        DataProvider daP;
        public string type;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            daP = new DataProvider();
            {
<<<<<<< HEAD
                //string userName =daP.GetMD5(txtUserName.Text);
                //string password = daP.GetMD5(txtPass.Text);
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPass.Text)) // xét thử rỗng với trống không 
=======
                string userName = daP.GetMD5(txtUserName.Text);
                string password = daP.GetMD5(txtPass.Text);
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) // xét thử rỗng với trống không 
>>>>>>> 95d13f6764b1be0b6680316cc5c8c34ab3be42f1
                {
                    MessageBox.Show("Yêu cầu thông tin chưa đầy đủ ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
<<<<<<< HEAD
                    
                    if (daP.Login(txtUserName.Text, txtPass.Text))
=======

                    if (daP.Login(userName, password))
>>>>>>> 95d13f6764b1be0b6680316cc5c8c34ab3be42f1
                    {
                        FrmLogin frm = new FrmLogin();
                        this.DialogResult = DialogResult.OK;
                        this.Hide();
                        type = daP.type;
                        if (daP.type == "1")
                        {
                            FrmGiamDoc frmGD = new FrmGiamDoc();
                            frmGD.ShowDialog();
                            
                        }
                        if (daP.type == "2")
                        {
                            FrmQuanLy frmQL = new FrmQuanLy();
                            frmQL.ShowDialog();
                        }
                      
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
        public string type;
        private bool Login(string username, string password)
        {
            string cnStr = "Server =TrungHieuIT\\SQLEXPRESS; Database = EE; Integrated security = true";
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
=======
>>>>>>> 08c0d643124baf16838fb8082f2b3a5907edd97c

  


>>>>>>> 95d13f6764b1be0b6680316cc5c8c34ab3be42f1




        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }




<<<<<<< HEAD
=======


>>>>>>> 95d13f6764b1be0b6680316cc5c8c34ab3be42f1
    }
}
