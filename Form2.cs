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

namespace DemoQLNhanVien_BTL_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
            }
            List<QLNV> list = GetNhanVien();
            dgvDanhSach.DataSource = list;


            dgvDanhSach.DataSource = list;
            txtID.DataBindings.Add("Text", list, "id");
            txtName.DataBindings.Add("Text", list, "name");
            txtAddress.DataBindings.Add("Text", list, "address");
            txtPhone.DataBindings.Add("Text", list, "phone");
            txtPosition.DataBindings.Add("Text", list, "position");
        }
        List<QLNV> GetNhanVien()
        {
            string cnStr = "Server =TrungHieuIT\\SQLEXPRESS ; Database = QLNhanVien ; Integrated security = true;";
            SqlConnection cn = new SqlConnection(cnStr);
            cn.Open();
            string sql = "SELECT * FROM DSNhanVien1 ";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;


            SqlDataReader dr = cmd.ExecuteReader();
            List<QLNV> list = new List<QLNV>();
            string id, name, address, phone, position;

            while (dr.Read())
            {
                id = dr[0].ToString();
                name = dr[1].ToString();
                address = dr[2].ToString();
                phone = dr[3].ToString();
                position = dr[4].ToString();

                QLNV a = new QLNV(id, name, address, phone, position);
                list.Add(a);
            }
            dr.Close();
            cn.Close();
            return list;
        }
    }
        
}
