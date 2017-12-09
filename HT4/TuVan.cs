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

namespace HT4
{
    public partial class TuVan : Form
    {
        List<SinhVien> svs;
        DbConnection db;
        List<ThamSo> ts;
        public TuVan()
        {
            if (svs == null)
            {
                svs = new List<SinhVien>();
            }
            if (db == null)
            {
                db = new DbConnection();
            }
            if (ts == null)
            {
                ts = new List<ThamSo>();
            }
            InitializeComponent();
        }

        private void TuVan_Load(object sender, EventArgs e)
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
            btnActionTuVan.TabStop = false;
            btnActionTuVan.FlatStyle = FlatStyle.Flat;
            btnActionTuVan.FlatAppearance.BorderSize = 0;
            btnHuy.TabStop = false;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnTuVan2.TabStop = false;
            btnTuVan2.FlatStyle = FlatStyle.Flat;
            btnTuVan2.FlatAppearance.BorderSize = 0;

            SqlConnection conn = db.GetConnection();
            try
            {
                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM SinhVien", conn);
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SinhVien sv = new SinhVien();
                        sv.id = int.Parse(reader["id"].ToString());
                        sv.ten = reader["ten_Sinh_Vien"].ToString();
                        sv.tuoi = int.Parse(reader["tuoi"].ToString());
                        sv.gioitinh = int.Parse(reader["gioi_Tinh"].ToString());
                        sv.diem = float.Parse(reader["diem_Thi"].ToString());
                        sv.tinh = int.Parse(reader["tinh"].ToString());
                        sv.nganhhoc = reader["nganh_Hoc"].ToString();
                        svs.Add(sv);
                    }
                }
                //combobox noi o
                SqlDataAdapter ap3 = new SqlDataAdapter("SELECT * FROM Tinh", conn);
                DataTable dt3 = new DataTable();
                ap3.Fill(dt3);
                cbTinh.DataSource = dt3;
                cbTinh.DisplayMember = "ten_Tinh";
                cbTinh.ValueMember = "ma_Tinh";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();
            this.Hide();
        }

        private void btnActionTuVan_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtDiem.Text.Equals("") || txtDiem.Text.Equals("") || cbGioiTinh.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin");
            }
            else
            {
                SinhVien sv = new SinhVien();
                sv.id = -1;
                sv.tuoi = int.Parse(txtTuoi.Text);
                sv.gioitinh = cbGioiTinh.SelectedIndex;
                sv.diem = float.Parse(txtDiem.Text);
                sv.tinh = int.Parse(cbTinh.SelectedValue.ToString());
                sv.nganhhoc = "";
                string s = findNganh(sv);
                if (s.Equals(""))
                {
                    MessageBox.Show("Không có kết quả phù hợp");
                }
                else
                {
                    Result r = new Result(s);
                    r.Show();
                }
            }
        }
        private string findNganh(SinhVien sv)
        {
            List<string> nganhUnique = new List<string>();
            foreach (SinhVien s in svs)
            {
                if (nganhUnique.Contains(s.nganhhoc))
                {

                }
                else
                {
                    nganhUnique.Add(s.nganhhoc);
                }
            }
            foreach (string s in nganhUnique)
            {
                ThamSo t = new ThamSo();
                t.ma = s;
                foreach (SinhVien ssv in svs)
                {
                    if (ssv.nganhhoc.Equals(s))
                    {
                        t.list.Add(ssv);
                    }
                }
                ts.Add(t);
            }
            foreach (ThamSo t in ts)
            {
                foreach (SinhVien svt in t.list)
                {
                    t.avgTuoi += svt.tuoi;
                    t.avgGioiTinh += svt.gioitinh;
                    t.avgDiem += svt.diem;
                    t.avgTinh += svt.tinh;
                }
                t.avgTuoi /= t.list.Count;
                t.avgGioiTinh /= t.list.Count;
                t.avgDiem /= t.list.Count;
                t.avgTinh /= t.list.Count;
            }
            float saiso = 100;
            string result = "";
            foreach (ThamSo t in ts)
            {
                float ss = (Math.Abs(t.avgTuoi - sv.tuoi) + Math.Abs(t.avgGioiTinh - sv.gioitinh) + Math.Abs(t.avgDiem - sv.diem) + Math.Abs(t.avgTinh - sv.tinh)) / 4;
                if (ss < saiso)
                {
                    saiso = ss;
                    result = t.ma;
                }
            }
            return result;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtDiem.Text = "";
            txtTuoi.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtDiem.Text.Equals("") || txtDiem.Text.Equals("") || cbGioiTinh.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin");
            }
            else
            {
                SinhVien sv = new SinhVien();
                sv.id = -1;
                sv.tuoi = int.Parse(txtTuoi.Text);
                sv.gioitinh = cbGioiTinh.SelectedIndex;
                sv.diem = float.Parse(txtDiem.Text);
                sv.tinh = int.Parse(cbTinh.SelectedValue.ToString());
                sv.nganhhoc = "";
                List<SinhVien> cq = new List<SinhVien>();
                List<string> uniqueNganh = new List<string>();
                foreach (SinhVien v in svs)
                {
                    if (v.tinh >= sv.tinh - 10 && v.tinh <= sv.tinh + 10)
                    {
                        cq.Add(v);
                        if (uniqueNganh.Contains(v.nganhhoc))
                        {
                        }
                        else
                        {
                            uniqueNganh.Add(v.nganhhoc);
                        }
                    }
                }
                int[] tanso = new int[uniqueNganh.Count];
                foreach (SinhVien v in cq)
                {
                    tanso[uniqueNganh.IndexOf(v.nganhhoc)]++;
                }
                int max = tanso.Max();
                string re = "";
                for (int i = 0; i < tanso.Length; i++)
                {
                    if (tanso[i] == max)
                    {
                        re = uniqueNganh[i];
                    }
                }
                if (re.Equals(""))
                {
                    MessageBox.Show("Không có kết quả tư vấn");
                }
                else
                {
                    Result r = new Result(re);
                    r.Show();
                }
                
            }
        }
    }
}
