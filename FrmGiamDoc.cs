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
      
        public FrmGiamDoc()
        {
            InitializeComponent();
        }



        ChucNang cn = new ChucNang();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            cn.Them(cn.memberTable, txtID.Text, txtName.Text, txtPhone.Text, txtAddress.Text, cmbPosition.Text);
            dgvDanhSach.DataSource = cn.memberTable;
            txtID.Text = txtDay.Text = txtName.Text = txtAddress.Text = txtPhone.Text = cmbPosition.Text = "";
            txtID.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e) //pass
        {
            
            SqlCommandBuilder builder = new SqlCommandBuilder(cn.da);
            cn.da.Update(cn.memberTable);
            
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e) //pass
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dgvDanhSach.Columns[col] is DataGridViewButtonColumn && dgvDanhSach.Columns[col].Name == "delete")
            {
               
                if (row >= 0 && row < dgvDanhSach.Rows.Count)
                {
                   cn.memberTable.Rows[row].Delete();
                }
            }
        }

        private void FrmGiamDoc_Load(object sender, EventArgs e)//pass
        {
            string cnStr = "Server =TrungHieuIT\\SQLEXPRESS ; Database = EE; Integrated security = true";
            cn.cnn = new SqlConnection(cnStr);
            DataSet ds = cn.GetData();
            cn.memberTable = ds.Tables[0];
            dgvDanhSach.DataSource = cn.memberTable;
        }
        private void FrmGiamDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dgvDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//pass
        {
            int numrow;
            numrow = e.RowIndex;
            txtID.Text = dgvDanhSach.Rows[numrow].Cells[1].Value.ToString();
            txtName.Text = dgvDanhSach.Rows[numrow].Cells[2].Value.ToString();
            txtAddress.Text = dgvDanhSach.Rows[numrow].Cells[3].Value.ToString();
            txtPhone.Text = dgvDanhSach.Rows[numrow].Cells[4].Value.ToString();
            cmbPosition.Text = dgvDanhSach.Rows[numrow].Cells[5].Value.ToString();

            if (txtID.Text != "")
            {
                lbSoNgayLam.Visible = true;
                txtDay.Visible = true;
                btnChange.Enabled = true;
                btnUpdate.Enabled = true;
                btnCalculator.Enabled = true;
            }
            else
            {
                lbSoNgayLam.Visible = false;
                txtDay.Visible = false;
                btnChange.Enabled = false;
                btnUpdate.Enabled = false;
                btnCalculator.Enabled = false;


            }
        }

        private void btnCalculator_Click(object sender, EventArgs e) // pass
        {
            DataRow row = cn.memberTable.NewRow();
            int a = Convert.ToInt32(txtDay.Text);
            double kq = 0;
            if (cmbPosition.Text == "Giám Ðốc")
            {
                GiamDoc gd = new GiamDoc();
                kq = gd.TinhTienLuong(a);
                dgvDanhSach.SelectedRows[0].Cells[7].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells[6].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Phó Giám Đốc")
            {
                PhoGiamDoc nv = new PhoGiamDoc();
                kq = nv.TinhTienLuong(a);
                dgvDanhSach.SelectedRows[0].Cells[7].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells[6].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Trưởng Phòng")
            {
                TruongPhong nv = new TruongPhong();
                kq = nv.TinhTienLuong(a);
                
                dgvDanhSach.SelectedRows[0].Cells[6].Value = kq.ToString();
                dgvDanhSach.SelectedRows[0].Cells[7].Value = txtDay.Text;
            }
            if (cmbPosition.Text == "Nhân Viên")
            {
                NhanVien nv = new NhanVien();
                kq = nv.TinhTienLuong(a);
                dgvDanhSach.SelectedRows[0].Cells[7].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells[6].Value = kq.ToString();
            }
            //txtID.Clear();


        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            
        }
    }
}
