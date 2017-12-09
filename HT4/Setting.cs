using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace HT4
{
    public partial class Setting : Form
    {
        public string server;
        public string data;
        public string user;
        public string password;
        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\config.txt";

        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
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
            btnLuu.TabStop = false;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnHuy.TabStop = false;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnThem.TabStop = false;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;

            try
            {
                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    txtServer.Text = lines[0];
                    txtDataName.Text = lines[1];
                    txtUser.Text = lines[2];
                    txtPassword.Text = lines[3];
                }
                else
                {
                    FileStream fs = File.Create(path);
                    StreamWriter wr = new StreamWriter(fs, Encoding.UTF8);
                    wr.WriteLine("Địa chỉ máy chủ");
                    wr.WriteLine("Tên cở sở dữ liệu");
                    wr.WriteLine("Tài khoản");
                    wr.WriteLine("Mật khẩu");
                    wr.Flush();
                    fs.Close();
                    string[] lines = System.IO.File.ReadAllLines(path);
                    txtServer.Text = lines[0];
                    txtDataName.Text = lines[1];
                    txtUser.Text = lines[2];
                    txtPassword.Text = lines[3];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();
            this.Hide();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                WriteData();
            }
            else
            {
                WriteData();
            }
        }
        private void WriteData()
        {
            FileStream fs = File.Create(path);
            StreamWriter wr = new StreamWriter(fs, Encoding.UTF8);
            wr.WriteLine(txtServer.Text);
            wr.WriteLine(txtDataName.Text);
            wr.WriteLine(txtUser.Text);
            wr.WriteLine(txtPassword.Text);
            wr.Flush();
            fs.Close();
            MessageBox.Show("Đã lưu chỉnh sửu");
        }

        private void btnTuVan_Click(object sender, EventArgs e)
        {
            TuVan t = new TuVan();
            t.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=" + txtServer.Text + ";Integrated security=SSPI;database=master");
            str = "CREATE DATABASE " + txtDataName.Text + " ON PRIMARY " +
        "(NAME = " + txtDataName.Text + "_Data, " +
        "FILENAME = 'C:\\" + txtDataName.Text + "Data.mdf', " +
        "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
        "LOG ON (NAME = " + txtDataName.Text + "_Log, " +
        "FILENAME = 'C:\\" + txtDataName.Text + "Log.ldf', " +
        "SIZE = 1MB, " +
        "MAXSIZE = 5MB, " +
        "FILEGROWTH = 10%)";
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
                string connetionString = @"Data Source=" + txtServer.Text + ";Initial Catalog=" + txtDataName.Text + ";Persist Security Info=True;User ID=" + txtUser.Text + ";Password=" + txtPassword.Text + "";
                SqlConnection conn = new SqlConnection(connetionString);
                conn.Open();
                SqlCommand sql1 = new SqlCommand("CREATE TABLE[dbo].[Nganh](" +

                                                "[ma_Nganh][varchar](20) NOT NULL," +

                                                "[ten_Nganh][nvarchar](1000) NULL," +

                                                "[y_Nghia][nvarchar](1000) NULL" +
                                                ") ON[PRIMARY]", conn);
                SqlCommand sql2 = new SqlCommand("CREATE TABLE [dbo].[SinhVien](" +
                                                 "[id][int] IDENTITY(0, 1) NOT FOR REPLICATION NOT NULL, " +

                                                 "[ten_Sinh_Vien][nvarchar](50) NOT NULL, " +

                                                 "[tuoi][int] NULL, " +

    "[gioi_Tinh][int] NULL, " +

   "[diem_Thi][real] NULL, " +

   "[tinh][int] NULL, " +

    "[nganh_Hoc][varchar](20) NULL, " +
 "CONSTRAINT[PK_SinhVien] PRIMARY KEY CLUSTERED" +
"(" +

    "[id] ASC" +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]" +
") ON[PRIMARY]", conn);
                SqlCommand sql3 = new SqlCommand("CREATE TABLE [dbo].[Tinh](" +
    "[ma_Tinh][int] NOT NULL, " +

    "[ten_Tinh][varchar](50) NULL" +
    ") ON[PRIMARY]", conn);
                SqlCommand sql4 = new SqlCommand("INSERT INTO [dbo].[Tinh]" +
                                                 "([ma_Tinh]" +
                                                 ",[ten_Tinh])" +
                                                 "VALUES" +
                                                 "(1,'Ha Noi')," +
                                                 "(2,'Ha Giang')," +
                                                "(4,'Cao Bang')," +
                                                "(6,'Bac Kan')," +
                                                "(8,'Tuyen Quang')," +
                                                "(10,'Lao Cai')," +
                                                "(11,'Dien Bien')," +
                                                "(12,'Lai Chau')," +
                                                "(14,'Son La')," +
                                                "(15,'Yen Bai')," +
                                                "(17  ,'Hoa Binh')," +
                                                "(19  ,'Thai Nguyen')," +
                                                "(20  ,'Lang Son')," +
                                                "(22  ,'Quang Ninh')," +
                                                "(24  ,'Bac Giang')," +
                                                "(25  ,'Phu Tho')," +
                                                "(26  ,'Vinh Phuc')," +
                                                "(27  ,'Bac Ninh')," +
                                                "(30  ,'Hai Duong')," +
                                                "(31  ,'Hai Phong')," +
                                                "(33  ,'Hung Yen')," +
                                                "(34  ,'Thai Binh')," +
                                                "(35  ,'Ha Nam')," +
                                                "(36  ,'Nam Dinh')," +
                                                "(37  ,'Ninh Binh')," +
                                                "(38  ,'Thanh Hoa')," +
                                                "(40  ,'Nghe An')," +
                                                "(42  ,'Ha Tinh')," +
                                                "(44  ,'Quang Binh')," +
                                                "(45  ,'Quang Tri')," +
                                                "(46  ,'Hue')," +
                                                "(48  ,'Da Nang')," +
                                                "(49  ,'Quang Nam')," +
                                                "(51  ,'Quang Ngai')," +
                                                "(52  ,'Binh Dinh')," +
                                                "(54  ,'Phu Yen')," +
                                                "(56  ,'Khanh Hoa')," +
                                                "(58  ,'Ninh Thuan')," +
                                                "(60  ,'Binh Thuan')," +
                                                "(62  ,'Kon Tum')," +
                                                "(64  ,'Gia Lai')," +
                                                "(66  ,'Dak Lak')," +
                                                "(67  ,'Dak Nong')," +
                                                "(68  ,'Lam Dong')," +
                                                "(70  ,'Binh Phuoc')," +
                                                "(72  ,'Tay Ninh')," +
                                                "(74  ,'Binh Duong')," +
                                                "(75  ,'Dong Nai')," +
                                                "(77  ,'Ba Ria - Vung Tau')," +
                                                "(79  ,'Ho CHi Minh')," +
                                                "(80  ,'Long An')," +
                                                "(82  ,'Tien Giang')," +
                                                "(83  ,'Ben Tre')," +
                                                "(84  ,'Tra Vinh')," +
                                                "(86  ,'Vinh Long')," +
                                                "(87  ,'Dong Thap')," +
                                                "(89  ,'An Giang')," +
                                                "(91  ,'Kien Giang')," +
                                                "(92  ,'Can Tho')," +
                                                "(93  ,'Hau Giang')," +
                                                "(94  ,'Soc Trang')," +
                                                "(95  ,'Bac Lieu')," +
                                                "(96  ,'Ca Mau')", conn);
                sql1.ExecuteNonQuery();
                sql2.ExecuteNonQuery();
                sql3.ExecuteNonQuery();
                sql4.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Tạo thành công");
                if (File.Exists(path))
                {
                    File.Delete(path);
                    WriteData();
                }
                else
                {
                    WriteData();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private void btnHuy_Click(object sender, EventArgs e)
        {

        }
    }
}
