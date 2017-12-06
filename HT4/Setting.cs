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

namespace HT4
{
    public partial class Setting : Form
    {
        public string server;
        public string data;
        public string user;
        public string password;
        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\config.txt";
        
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

            try
            {
                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    txtServer.Text = lines[0];
                    txtDataName.Text = lines[1];
                    txtUser.Text = lines[2];
                    txtPassword.Text = lines[3];
                }else
                {
                    FileStream fs = File.Create(path);
                    StreamWriter wr = new StreamWriter(fs, Encoding.UTF8);
                    wr.WriteLine("Địa chỉ máy chủ");
                    wr.WriteLine("Tên cở sở dữ liệu");
                    wr.WriteLine("Tài khoản");
                    wr.WriteLine("Mật khẩu");
                    wr.Flush();
                    fs.Close();
                }
            }catch(Exception ex)
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
            }else
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
    }
}
