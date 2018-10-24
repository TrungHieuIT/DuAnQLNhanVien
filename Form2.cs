﻿using System;
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
        SqlConnection cn;
        DataTable memberTable;
        SqlDataAdapter da;
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
            string cnStr = "Server =TrungHieuIT\\SQLEXPRESS ; Database = QLNhanVien; Integrated security = true";
            cn = new SqlConnection(cnStr);
            DataSet ds = GetData();
            memberTable = ds.Tables[0];
            dgvDanhSach.DataSource = memberTable;
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
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(memberTable);
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;

            if (dgvDanhSach.Columns[col] is DataGridViewButtonColumn && dgvDanhSach.Columns[col].Name == "delete")
            {
                int row = e.RowIndex;
                if (row >= 0 && row < dgvDanhSach.Rows.Count)
                {
                    memberTable.Rows[row].Delete();
                }
            }
        }

     
    }
}
