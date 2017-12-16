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
                                                 "[ma_SV][int] IDENTITY(0, 1) NOT FOR REPLICATION NOT NULL, " +

                                                 "[ten_Sinh_Vien][nvarchar](50) NOT NULL, " +

                                                 "[tuoi][int] NULL, " +

    "[gioi_Tinh][int] NULL, " +

   "[diem_Thi][real] NULL, " +

   "[ma_Tinh][int] NULL, " +

    "[ma_Nganh][varchar](20) NULL, " +
 "CONSTRAINT[PK_SinhVien] PRIMARY KEY CLUSTERED" +
"(" +

    "[ma_SV] ASC" +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]" +
") ON[PRIMARY]", conn);
                SqlCommand sql3 = new SqlCommand("CREATE TABLE [dbo].[Tinh](" +
    "[ma_Tinh][int] NOT NULL, " +

    "[ten_Tinh][nvarchar](50) NULL" +
    ") ON[PRIMARY]", conn);
                SqlCommand sql4 = new SqlCommand("INSERT INTO [dbo].[Tinh]" +
                                                 "([ma_Tinh]" +
                                                 ",[ten_Tinh])" +
                                                 "VALUES" +
                                                 "(1,N'Hà Nội')," +
                                                 "(2,N'Hà Giang')," +
                                                "(4,N'Cao Bằng')," +
                                                "(6,N'Bắc Kạn')," +
                                                "(8,N'Tuyên Quang')," +
                                                "(10,N'Lào Cai')," +
                                                "(11,N'Điện Biên')," +
                                                "(12,N'Lai Châu')," +
                                                "(14,N'Sơn La')," +
                                                "(15,N'Yên Bái')," +
                                                "(17  ,N'Hòa Bình')," +
                                                "(19  ,N'Thái Nguyên')," +
                                                "(20  ,N'Lạng Sơn')," +
                                                "(22  ,N'Quảng Ninh')," +
                                                "(24  ,N'Bắc Giang')," +
                                                "(25  ,N'Phú Thọ')," +
                                                "(26  ,N'Vĩnh Phúc')," +
                                                "(27  ,N'Bắc Ninh')," +
                                                "(30  ,N'Hải Dương')," +
                                                "(31  ,N'Hải Phòng')," +
                                                "(33  ,N'Hưng Yên')," +
                                                "(34  ,N'Thái Bình')," +
                                                "(35  ,N'Hà Nam')," +
                                                "(36  ,N'Nam Định')," +
                                                "(37  ,N'Ninh Bình')," +
                                                "(38  ,N'Thanh Hóa')," +
                                                "(40  ,N'Nghệ An')," +
                                                "(42  ,N'Hà Tĩnh')," +
                                                "(44  ,N'Quảng Bình')," +
                                                "(45  ,N'Quảng Trị')," +
                                                "(46  ,N'Huế')," +
                                                "(48  ,N'Đà Nẵng')," +
                                                "(49  ,N'Quảng Nam')," +
                                                "(51  ,N'Quảng Ngãi')," +
                                                "(52  ,N'Bình Định')," +
                                                "(54  ,N'Phú Yên')," +
                                                "(56  ,N'Khánh Hàa')," +
                                                "(58  ,N'Ninh Thuận')," +
                                                "(60  ,N'Bình Thuận')," +
                                                "(62  ,N'Kon Tum')," +
                                                "(64  ,N'Gia Lai')," +
                                                "(66  ,N'Dak Lak')," +
                                                "(67  ,N'Dak Nông')," +
                                                "(68  ,N'Lâm Đồng')," +
                                                "(70  ,N'Bình Phước')," +
                                                "(72  ,N'Tây Ninh')," +
                                                "(74  ,N'Bình Dương')," +
                                                "(75  ,N'Đồng Nai')," +
                                                "(77  ,N'Bà Rịa - Vũng Tàu')," +
                                                "(79  ,N'Hồ Chi Minh')," +
                                                "(80  ,N'Long An')," +
                                                "(82  ,N'Tiền Giang')," +
                                                "(83  ,N'Bến Tre')," +
                                                "(84  ,N'Trà Vinh')," +
                                                "(86  ,N'Vĩnh Long')," +
                                                "(87  ,N'Đồng Tháp')," +
                                                "(89  ,N'An Giang')," +
                                                "(91  ,N'Kiên Giang')," +
                                                "(92  ,N'Cần Thơ')," +
                                                "(93  ,N'Hậu Giang')," +
                                                "(94  ,N'Sóc Trang')," +
                                                "(95  ,N'Bạc Liêu')," +
                                                "(96  ,N'Cà Mau')", conn);
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
