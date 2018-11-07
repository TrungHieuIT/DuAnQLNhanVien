using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            //string id, name, address, phone, position;
            //id = txtID.Text;
            //name = txtName.Text;
            //address = txtAddress.Text;
            //phone = txtPhone.Text;
            //position = txtPosition.Text;


            DataRow row = memberTable.NewRow();
            row["MaNV"] = txtID.Text;
            row["HoTenNV"] = txtName.Text;
            row["DiaChi"] = txtAddress.Text;
            row["SDT"] = txtPhone.Text;
            row["ChucVu"] = cmbChucVu.Text;
            row["NgayLam"] = txtNgay.Text;

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
            int row = e.RowIndex;
            //if(dgvDanhSach.Columns[col] is DataGridViewButtonColumn && dgvDanhSach.Columns[col].Name == "id")
            //{
            //    txtID.Text = col.ToString();

            //}

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

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            string GD, PGD, TP, NV , day;
            int ngay;
            GD = cmbChucVu.Text = "Giám Đốc";
            PGD = cmbChucVu.Text = "Phó Giám Đốc";
            TP = cmbChucVu.Text = "Trưởng Phòng";
            NV = cmbChucVu.Text = "Nhân Viên";
            day = txtNgay.Text;
            ngay = Convert.ToInt32(day);
            if (cmbChucVu.Text == GD)
            {
                GiamDoc gd = new GiamDoc();

                gd.TinhTienLuong(ngay);
            }
            if (cmbChucVu.Text == PGD)
            {
               PhoGiamDoc pgd = new PhoGiamDoc();

                pgd.TinhTienLuong(ngay);

            }
            if (cmbChucVu.Text == TP)
            {
                TruongPhong tp = new TruongPhong();
                tp.TinhTienLuong(ngay);
            }
            if (cmbChucVu.Text == NV)
            {
                NhanVien nv = new NhanVien();
                nv.TinhTienLuong(ngay);
            }
            DataRow row = memberTable.NewRow();
           // row["TienLuong"] = txtID.Text;

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            
        }

     
    }
}
