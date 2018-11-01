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
            
            ChucNang cng = new ChucNang();
            cng.Them(memberTable, txtID.Text, txtName.Text, txtPhone.Text, txtAddress.Text, cmbPosition.Text);
            dgvDanhSach.DataSource = memberTable;
            txtID.Text = txtDay.Text = txtName.Text = txtAddress.Text = txtPhone.Text = cmbPosition.Text = "";
            txtID.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e) //pass
        {
            
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(memberTable);
            
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e) //pass
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

        private void FrmGiamDoc_Load(object sender, EventArgs e)//pass
        {
            string cnStr = "Server =USER-PC\\HUYNHDUC; Database = EE; Integrated security = true ;";
            cn = new SqlConnection(cnStr);
            DataSet ds = GetData();
            memberTable = ds.Tables[0];
            dgvDanhSach.DataSource = memberTable;
        }
        private void FrmGiamDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dgvDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//pass
        {
            int numrow;
            numrow = e.RowIndex;
            txtID.Text = dgvDanhSach.Rows[numrow].Cells["id"].Value.ToString();
            txtName.Text = dgvDanhSach.Rows[numrow].Cells["name"].Value.ToString();
            txtAddress.Text = dgvDanhSach.Rows[numrow].Cells["address"].Value.ToString();
            txtPhone.Text = dgvDanhSach.Rows[numrow].Cells["phone"].Value.ToString();
            cmbPosition.Text = dgvDanhSach.Rows[numrow].Cells["position"].Value.ToString();

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
            DataRow row = memberTable.NewRow();
            int a = Convert.ToInt32(txtDay.Text);
            double kq = 0;
            if (cmbPosition.Text == "Giám Ðốc")
            {
                GiamDoc gd = new GiamDoc();
                kq = gd.TinhTienLuong(a);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Phó Giám Đốc")
            {
                PhoGiamDoc nv = new PhoGiamDoc();
                kq = nv.TinhTienLuong(a);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Trưởng Phòng")
            {
                TruongPhong nv = new TruongPhong();
                kq = nv.TinhTienLuong(a);

                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Nhân Viên")
            {
                NhanVien nv = new NhanVien();
                kq = nv.TinhTienLuong(a);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            //txtID.Clear();


        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
            {
                if (dgvDanhSach.Rows[i].Selected)
                {
                    dgvDanhSach.Rows[i].Cells["id"].Value = txtID.Text;
                    dgvDanhSach.Rows[i].Cells["name"].Value = txtName.Text;
                    dgvDanhSach.Rows[i].Cells["address"].Value = txtAddress.Text;
                    dgvDanhSach.Rows[i].Cells["phone"].Value = txtPhone.Text;
                    dgvDanhSach.Rows[i].Cells["position"].Value = cmbPosition.Text;
                }
            }
        }
            
        }
    }

