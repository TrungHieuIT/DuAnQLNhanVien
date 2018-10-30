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
using DemoQLNhanVien_BTL_;

namespace DemoQLNhanVien_BTL_
{
    public partial class FrmGiamDoc : Form
    {
        SqlConnection cn;
        DataTable memberTable;
        SqlDataAdapter da;
        public FrmGiamDoc()
        {
            InitializeComponent();
        }

   
        DataSet GetData()
        {
            DataSet ds = new DataSet();
            string sql = " Select * FROM DSNhanVien1";
            da = new SqlDataAdapter(sql, cn);
            int number = da.Fill(ds);
            return ds;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow row = memberTable.NewRow();
            row["MaNV"] = txtID.Text;
            row["HoTenNV"] = txtName.Text;
            row["DiaChi"] = txtAddress.Text;
            row["SDT"] = txtPhone.Text;
            row["ChucVu"] = txtPosition.Text;

            memberTable.Rows.Add(row);
            txtID.Text = txtDay.Text = txtName.Text = txtPhone.Text = txtPosition.Text = "";
            txtID.Focus();

            //for (int i = 0; i < dgvDanhSach.RowCount; i++)
            //{

            //    if (dgvDanhSach.Rows[i].Selected && dgvDanhSach.Rows[i].Cells[0].ToString() == "132451")
            //    {
            //        MessageBox.Show("Trùng Mã Nhân Viên", "error");
            //    }
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(memberTable);
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dgvDanhSach.Columns[col] is DataGridViewButtonColumn && dgvDanhSach.Columns[col].Name == "delete")
            {
               
                if (row >= 0 && row < dgvDanhSach.Rows.Count)
                {
                    memberTable.Rows[row].Delete();
                }
            }
        }

        private void FrmGiamDoc_Load(object sender, EventArgs e)
        {
            string cnStr = "Server =TrungHieuIT\\SQLEXPRESS ; Database = EE; Integrated security = true";
            cn = new SqlConnection(cnStr);
            DataSet ds = GetData();
            memberTable = ds.Tables[0];
            dgvDanhSach.DataSource = memberTable;
        }
        private void FrmGiamDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dgvDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dgvDanhSach.DataSource, "MaNV");

            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text", dgvDanhSach.DataSource, "HoTenNV");

            txtAddress.DataBindings.Clear();
            txtAddress.DataBindings.Add("Text", dgvDanhSach.DataSource, "DiaChi");

            txtPhone.DataBindings.Clear();
            txtPhone.DataBindings.Add("Text", dgvDanhSach.DataSource, "SDT");

            txtPosition.DataBindings.Clear();
            txtPosition.DataBindings.Add("Text", dgvDanhSach.DataSource, "ChucVu");

            if(txtID.Text != "")
            {
                lbSoNgayLam.Visible = true;
                txtDay.Visible = true;
            }
            else
            {
                lbSoNgayLam.Visible = false;
                txtDay.Visible = false;

            }
            //txtDay.DataBindings.Clear();
            //txtDay.DataBindings.Add("Text", dgvDanhSach.DataSource, "NgayLamViec");

            
        }

    }
}
