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
    public partial class FrmQuanLy : Form
    {
        public FrmQuanLy()
        {
            InitializeComponent();
        }

        private void FrmQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void FrmQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();  
        }   
    }
}
