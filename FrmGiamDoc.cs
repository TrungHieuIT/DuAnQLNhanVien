using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DemoQLNhanVien_BTL_;

namespace DemoQLNhanVien_BTL_
{
    public partial class FrmGiamDoc : Form
    {
<<<<<<< HEAD
      
=======
       SqlConnection cnn;
       DataTable memberTable;
       SqlDataAdapter da;
        ChucNang cn = new ChucNang();
>>>>>>> 95d13f6764b1be0b6680316cc5c8c34ab3be42f1
        public FrmGiamDoc()
        {
            InitializeComponent();
        }

<<<<<<< HEAD


        ChucNang cn = new ChucNang();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            cn.Them(cn.memberTable, txtID.Text, txtName.Text, txtPhone.Text, txtAddress.Text, cmbPosition.Text);
            dgvDanhSach.DataSource = cn.memberTable;
=======
   
        DataSet GetData()
        {
            DataSet ds = new DataSet();
            string sql = " Select * FROM DSNhanVien1";
            da = new SqlDataAdapter(sql, cnn);
            int number = da.Fill(ds);
            return ds;
        }
<<<<<<< HEAD
       
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
=======
        private void FrmGiamDoc_Load(object sender, EventArgs e)//pass
        {
            string cnStr = "Server =.; Database = EE; Integrated security = true ;";
            cnn = new SqlConnection(cnStr);
            DataSet ds = GetData();
            memberTable = ds.Tables[0];
            dgvDanhSach.DataSource = memberTable;
>>>>>>> 08c0d643124baf16838fb8082f2b3a5907edd97c
        }
        private void FrmGiamDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //Thêm
        public void btnAdd_Click(object sender, EventArgs e)
        {
            
            ChucNang cng = new ChucNang();
            cng.Them(memberTable, txtID.Text, txtName.Text, txtPhone.Text, txtAddress.Text, cmbPosition.Text);
            dgvDanhSach.DataSource = memberTable;
>>>>>>> 95d13f6764b1be0b6680316cc5c8c34ab3be42f1
            txtID.Text = txtDay.Text = txtName.Text = txtAddress.Text = txtPhone.Text = cmbPosition.Text = "";
            txtID.Focus();
        }
        //Cập nhập
        private void btnUpdate_Click(object sender, EventArgs e) //pass
        {
            
            SqlCommandBuilder builder = new SqlCommandBuilder(cn.da);
            cn.da.Update(cn.memberTable);
            
        }
        //Tính Lương
        private void btnCalculator_Click(object sender, EventArgs e) // pass
        {
            DataRow row = memberTable.NewRow();
            int a = Convert.ToInt32(txtDay.Text);
            int chon;
            double kq = 0;
            if (cmbPosition.Text == "Giám Ðốc")
            {
                chon = 1;
                kq = cn.TienLuong(a, chon);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Phó Giám Đốc")
            {
                chon = 2;
                kq = cn.TienLuong(a, chon);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Trưởng Phòng")
            {
                chon = 3;
                kq = cn.TienLuong(a, chon);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Nhân Viên")
            {
                chon = 4;
                kq = cn.TienLuong(a, chon);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            //txtID.Clear();


        }
        //Sửa
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
        //xóa
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e) //pass
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
<<<<<<< HEAD
            //if(dgvDanhSach.Columns[col] is DataGridViewButtonColumn && dgvDanhSach.Columns[col].Name == "id")
            //{
            //    txtID.Text = col.ToString();

            //}

=======
>>>>>>> 08c0d643124baf16838fb8082f2b3a5907edd97c
            if (dgvDanhSach.Columns[col] is DataGridViewButtonColumn && dgvDanhSach.Columns[col].Name == "delete")
            {
               
                if (row >= 0 && row < dgvDanhSach.Rows.Count)
                {
                   cn.memberTable.Rows[row].Delete();
                }
            }
        }
        private void dgvDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//pass
        {
<<<<<<< HEAD
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

     
=======
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
<<<<<<< HEAD

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
=======
        
>>>>>>> 08c0d643124baf16838fb8082f2b3a5907edd97c
>>>>>>> 95d13f6764b1be0b6680316cc5c8c34ab3be42f1
    }
            
}

