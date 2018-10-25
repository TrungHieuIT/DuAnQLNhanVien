using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoQLNhanVien_BTL_
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            FrmLogin frm = new FrmLogin();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
             
                this.Hide();
                if (frm.type == "1") 
                {
                    FrmGiamDoc frmGD = new FrmGiamDoc();
                    frmGD.ShowDialog();

                }
                if (frm.type == "2") 
                {
                    FrmQuanLy frmQL = new FrmQuanLy();
                    frmQL.ShowDialog();
                }
            }
        }
    }
}
