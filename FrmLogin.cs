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
                //string userName =daP.GetMD5(txtUserName.Text);
                //string password = daP.GetMD5(txtPass.Text);
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPass.Text)) // xét thử rỗng với trống không 
                {
                    MessageBox.Show("Yêu cầu thông tin chưa đầy đủ ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    
                    if (daP.Login(txtUserName.Text, txtPass.Text))
                    {
                       FrmLogin frm = new FrmLogin();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        type = daP.type;

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




        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }




    }
}
