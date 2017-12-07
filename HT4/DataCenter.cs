using HT4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exel = Microsoft.Office.Interop.Excel;

namespace HT4
{
    public partial class DataCenter : Form
    {
        DbConnection db;
        SinhVien currentSV;
        Nganh currentNganh;
        public DataCenter()
        {
            if (db == null)
            {
                db = new DbConnection();
            }
            InitializeComponent();
        }

        private void DataCenter_Load(object sender, EventArgs e)
        {
            btnTuVan.TabStop = false;
            btnTuVan.FlatStyle = FlatStyle.Flat;
            btnTuVan.FlatAppearance.BorderSize = 0;
            btnHuongDan.TabStop = false;
            btnHuongDan.FlatStyle = FlatStyle.Flat;
            btnHuongDan.FlatAppearance.BorderSize = 0;
            btnGoiY.TabStop = false;
            btnGoiY.FlatStyle = FlatStyle.Flat;
            btnGoiY.FlatAppearance.BorderSize = 0;
            btnCaiDat.TabStop = false;
            btnCaiDat.FlatStyle = FlatStyle.Flat;
            btnCaiDat.FlatAppearance.BorderSize = 0;
            btnThoat.TabStop = false;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThem.TabStop = false;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnLamLai.TabStop = false;
            btnLamLai.FlatStyle = FlatStyle.Flat;
            btnLamLai.FlatAppearance.BorderSize = 0;
            btnOpen.TabStop = false;
            btnOpen.FlatStyle = FlatStyle.Flat;
            btnOpen.FlatAppearance.BorderSize = 0;
            btnCapNhat.TabStop = false;
            btnCapNhat.FlatStyle = FlatStyle.Flat;
            btnCapNhat.FlatAppearance.BorderSize = 0;
            btnSua.TabStop = false;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.FlatAppearance.BorderSize = 0;
            btnXoa.TabStop = false;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnLamMoi.TabStop = false;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;




            btnThemNganh.TabStop = false;
            btnThemNganh.FlatStyle = FlatStyle.Flat;
            btnThemNganh.FlatAppearance.BorderSize = 0;
            btnLamLaiNganh.TabStop = false;
            btnLamLaiNganh.FlatStyle = FlatStyle.Flat;
            btnLamLaiNganh.FlatAppearance.BorderSize = 0;
            btnMoNganh.TabStop = false;
            btnMoNganh.FlatStyle = FlatStyle.Flat;
            btnMoNganh.FlatAppearance.BorderSize = 0;
            btnCapNhatNganh.TabStop = false;
            btnCapNhatNganh.FlatStyle = FlatStyle.Flat;
            btnCapNhatNganh.FlatAppearance.BorderSize = 0;
            btnSuaNganh.TabStop = false;
            btnSuaNganh.FlatStyle = FlatStyle.Flat;
            btnSuaNganh.FlatAppearance.BorderSize = 0;
            btnXoaNganh.TabStop = false;
            btnXoaNganh.FlatStyle = FlatStyle.Flat;
            btnXoaNganh.FlatAppearance.BorderSize = 0;
            btnLamMoiNganh.TabStop = false;
            btnLamMoiNganh.FlatStyle = FlatStyle.Flat;
            btnLamMoiNganh.FlatAppearance.BorderSize = 0;
            SqlConnection conn = db.GetConnection();
            try
            {
                conn.Open();

                //Sinh vien
                SqlDataAdapter ap = new SqlDataAdapter("SELECT * FROM SinhVien", conn);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                dataGridView1.DataSource = dt;

                //Nganh
                SqlDataAdapter ap2 = new SqlDataAdapter("SELECT * FROM Nganh", conn);
                DataTable dt2 = new DataTable();
                ap2.Fill(dt2);
                dataGridView2.DataSource = dt2;

                //combobox noi o
                SqlDataAdapter ap3 = new SqlDataAdapter("SELECT * FROM Tinh", conn);
                DataTable dt3 = new DataTable();
                ap3.Fill(dt3);
                cbNoiO.DataSource = dt3;
                cbNoiO.DisplayMember = "ten_Tinh";
                cbNoiO.ValueMember = "ma_Tinh";

                //combobox nganh hoc
                SqlDataAdapter ap4 = new SqlDataAdapter("SELECT * FROM Nganh", conn);
                DataTable dt4 = new DataTable();
                ap4.Fill(dt4);
                cbNganhHoc.DataSource = dt4;
                cbNganhHoc.DisplayMember = "ten_Nganh";
                cbNganhHoc.ValueMember = "ma_Nganh";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtDuongDan.Text.CompareTo("") > 0)
            {
                ImportDataFromExel im = new ImportDataFromExel(txtDuongDan.Text);
                im.Show();
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "(Tất cả các tệp)|*.*|(Các tệp Exel)|*.xlsx";
                ofd.ShowDialog();
                if (ofd.FileName != "")
                {
                    txtDuongDan.Text = ofd.FileName;
                    ImportDataFromExel im = new ImportDataFromExel(ofd.FileName);
                    im.Show();

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn tệp Exel", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tabSV_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataCenter d = new DataCenter();
            d.Show();
            this.Hide();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 0)
            {
                MessageBox.Show("Vui lòng chọn một đối tượng để thực hiện thao tác");
            }
            else
            {
                string s = "DELETE FROM [HT4].[dbo].[SinhVien] WHERE id = " + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
                try
                {
                    SqlConnection conn = db.GetConnection();
                    conn.Open();
                    SqlCommand sql = new SqlCommand(s, conn);
                    sql.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Đã xóa thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();
            this.Hide();
        }

        private void btnTuVan_Click(object sender, EventArgs e)
        {
            TuVan t = new TuVan();
            t.Show();
            this.Hide();
        }

        private void btnLamLaiNganh_Click(object sender, EventArgs e)
        {
            txtMaNganh.Text = "";
            txtTenNganh.Text = "";
            txtYNghia.Text = "";
            currentNganh = null;
        }

        private void btnMoNganh_Click(object sender, EventArgs e)
        {
            if (txtDuongDanNganh.Text.CompareTo("") > 0)
            {
                ImportDataFromExelToNganh ip2 = new ImportDataFromExelToNganh(txtDuongDanNganh.Text);
                ip2.Show();
            }
            else
            {
                OpenFileDialog o = new OpenFileDialog();
                o.Filter = "(Tất cả các tệp)|*.*|(Các tệp Exel)|*.xlsx";
                o.ShowDialog();
                if (o.FileName != "")
                {
                    txtDuongDanNganh.Text = o.FileName;
                    ImportDataFromExelToNganh idn = new ImportDataFromExelToNganh(o.FileName);
                    idn.Show();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một tệp Exel", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtMark.Text = "";
            currentSV = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtAge.Text.Equals("") || txtMark.Text.Equals(""))
            {
                MessageBox.Show("Bạn cần điển đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = db.GetConnection();
                try
                {
                    conn.Open();
                    string s = "INSERT INTO [HT4].[dbo].[SinhVien]([ten_Sinh_Vien] ,[tuoi]  ,[gioi_Tinh] ,[diem_Thi] ,[tinh] ,[nganh_Hoc]) VALUES ('" + txtName.Text + "'," + txtAge.Text + "," + cbGioiTinh.SelectedIndex + "," + txtMark.Text + "," + cbNoiO.SelectedValue + ",'" + cbNganhHoc.SelectedValue + "')";
                    SqlCommand sql = new SqlCommand(s, conn);
                    sql.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm dữ liệu thành công");
                }
                catch
                {
                    MessageBox.Show("Đã xảy ra lỗi không xác định");
                }
            }
        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (currentSV != null)
            {
                currentSV = null;
            }
            else
            {
                if (dataGridView1.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Error");
                }
                string id = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
                string s = "SELECT * FROM SinhVien WHERE id =" + id;
                currentSV = new SinhVien();
                try
                {
                    SqlConnection conn = db.GetConnection();
                    conn.Open();
                    SqlCommand sql = new SqlCommand(s, conn);
                    using (SqlDataReader r = sql.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            currentSV.id = int.Parse(r["id"].ToString());
                            currentSV.ten = r["ten_Sinh_Vien"].ToString();
                            currentSV.tuoi = int.Parse(r["tuoi"].ToString());
                            currentSV.gioitinh = int.Parse(r["gioi_Tinh"].ToString());
                            currentSV.diem = float.Parse(r["diem_Thi"].ToString());
                            currentSV.tinh = int.Parse(r["tinh"].ToString());
                            currentSV.nganhhoc = r["nganh_Hoc"].ToString();
                        }
                    }
                    conn.Close();
                    FillDataToEdit(currentSV);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
        private void FillDataToEdit(SinhVien sv)
        {
            txtName.Text = sv.ten;
            txtAge.Text = sv.tuoi.ToString();
            txtMark.Text = sv.diem.ToString();
            cbGioiTinh.SelectedIndex = sv.gioitinh;
            cbNoiO.SelectedIndex = sv.tinh - 1;
            cbNganhHoc.SelectedValue = sv.nganhhoc;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (currentSV != null)
            {

                currentSV.ten = txtName.Text;
                currentSV.tuoi = int.Parse(txtAge.Text);
                currentSV.diem = float.Parse(txtMark.Text);
                currentSV.gioitinh = cbGioiTinh.SelectedIndex;
                currentSV.tinh = int.Parse(cbNoiO.SelectedValue.ToString());
                currentSV.nganhhoc = cbNganhHoc.SelectedValue.ToString();
                try
                {
                    SqlConnection conn = db.GetConnection();
                    conn.Open();

                    string s = "UPDATE [HT4].[dbo].[SinhVien] SET[ten_Sinh_Vien] = '" + currentSV.ten + "' ,[tuoi] = " + currentSV.tuoi + " ,[gioi_Tinh] = " + currentSV.gioitinh + " ,[diem_Thi] = " + currentSV.diem + "  ,[tinh] = " + currentSV.tinh + " ,[nganh_Hoc] = '" + currentSV.nganhhoc + "' WHERE id = " + currentSV.id + "";
                    MessageBox.Show(s);
                    SqlCommand sql = new SqlCommand(s, conn);
                    sql.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Cập nhật thành công");
                    currentSV = null;
                }
                catch
                {

                }
            }
        }

        private void btnLamMoiNganh_Click(object sender, EventArgs e)
        {
            DataCenter c = new DataCenter();
            c.Show();
            this.Hide();
        }

        private void btnXoaNganh_Click(object sender, EventArgs e)
        {
            string ma = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[0].Value.ToString();
            string s3 = "DELETE FROM [HT4].[dbo].[Nganh] WHERE ma_Nganh='" + ma + "'";
            SqlConnection conn = db.GetConnection();
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand(s3, conn);
                sql.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Đã xóa thành công đối tượng có mã: " + ma);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnThemNganh_Click(object sender, EventArgs e)
        {
            if (txtMaNganh.Text.Equals("") || txtTenNganh.Text.Equals("") || txtYNghia.Text.Equals(""))
            {
                MessageBox.Show("Bạn vui lòng điền đầy đủ thông tin");
            }
            else
            {
                try
                {
                    string s2 = "INSERT INTO [HT4].[dbo].[Nganh] ([ma_Nganh] ,[ten_Nganh] ,[y_Nghia]) VALUES('" + txtMaNganh.Text + "','" + txtTenNganh.Text + "','" + txtYNghia.Text + "')";
                    SqlConnection conn = db.GetConnection();
                    conn.Open();
                    SqlCommand sql = new SqlCommand(s2, conn);
                    sql.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm dữ liệu thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnSuaNganh_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count < 0)
            {
                MessageBox.Show("Bạn cần chọn một dữ liệu để thực thi");
            }
            else
            {
                currentNganh = new Nganh();
                string ma = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[0].Value.ToString();

                try
                {
                    SqlConnection conn = db.GetConnection();
                    conn.Open(); ;
                    SqlCommand sql = new SqlCommand("SELECT [ma_Nganh],[ten_Nganh] ,[y_Nghia] FROM [HT4].[dbo].[Nganh] WHERE ma_Nganh='" + ma + "'", conn);
                    using (SqlDataReader r2 = sql.ExecuteReader())
                    {
                        while (r2.Read())
                        {
                            currentNganh.ma = r2["ma_nganh"].ToString();
                            currentNganh.ten = r2["ten_Nganh"].ToString();
                            currentNganh.ynghia = r2["y_Nghia"].ToString();
                        }
                    }
                    conn.Close();
                    txtMaNganh.Text = currentNganh.ma;
                    txtTenNganh.Text = currentNganh.ten;
                    txtYNghia.Text = currentNganh.ynghia;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnCapNhatNganh_Click(object sender, EventArgs e)
        {
            if(currentNganh == null)
            {
                MessageBox.Show("Bạn chưa chọn sửa bất kỳ đối tượng nào");
            }else
            {
                SqlConnection conn = db.GetConnection();
                try
                {
                    conn.Open();
                    SqlCommand sql = new SqlCommand("UPDATE [HT4].[dbo].[Nganh]SET [ma_Nganh] = '"+txtMaNganh.Text+"' ,[ten_Nganh] = '"+txtTenNganh.Text+"' ,[y_Nghia] = '"+txtYNghia.Text+"'WHERE ma_Nganh='"+currentNganh.ma+"'", conn);
                    sql.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Chỉnh sửa thành công");
                    currentNganh = null;
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
