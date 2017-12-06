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
    public partial class ImportDataFromExel : Form
    {
        DbConnection db;
        public string path;
        public ImportDataFromExel(string s)
        {
            if (db == null)
            {
                db = new DbConnection();
            }
            InitializeComponent();
            this.path = s;
            Exel.Application app = new Exel.Application();
            Exel.Workbook wb = app.Workbooks.Open(path);
            try
            {
                Exel._Worksheet sheet = wb.Sheets[1];
                Exel.Range range = sheet.UsedRange;

                int rows = range.Rows.Count;
                int cols = range.Columns.Count;
                for (int i = 1; i < cols +1; i++)
                {
                    string columnName = range.Cells[1, i].Value.ToString();
                    ColumnHeader col = new ColumnHeader();
                    col.Text = columnName;
                    col.Width = 120;
                    listSV.Columns.Add(col);
                }
                for (int i = 2; i < rows; i++)
                {
                    ListViewItem item = new ListViewItem();
                    for (int j = 1; j < cols+1; j++)
                    {
                        if (j == 1)
                            item.Text = range.Cells[i, j].Value.ToString();
                        else
                            item.SubItems.Add(range.Cells[i, j].Value.ToString());
                    }
                    listSV.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportDataFromExel_Load(object sender, EventArgs e)
        {
            btnThem.TabStop = false;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnHuy.TabStop = false;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = db.GetConnection();

            try
            {
                conn.Open();
                foreach (ListViewItem item in listSV.Items)
                {
                    string s = "INSERT INTO [HT4].[dbo].[SinhVien]([ten_Sinh_Vien] ,[tuoi]  ,[gioi_Tinh] ,[diem_Thi] ,[tinh] ,[nganh_Hoc]) VALUES ('" + item.Text + "'," + item.SubItems[1].Text + "," + item.SubItems[2].Text+ "," + item.SubItems[3].Text + "," + item.SubItems[4].Text + ",'" + item.SubItems[5].Text+"')";
                    SqlCommand sql = new SqlCommand(s,conn);
                    sql.ExecuteNonQuery();
                }
                conn.Close();
                MessageBox.Show("Thêm dữ liệu thành công!");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
