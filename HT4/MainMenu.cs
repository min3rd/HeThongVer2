using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HT4
{
    public partial class MainMenu : Form
    {
        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\config.txt";
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            btnNhapDuLieu.TabStop = false;
            btnNhapDuLieu.FlatStyle = FlatStyle.Flat;
            btnNhapDuLieu.FlatAppearance.BorderSize = 0;
            btnCaiDat.TabStop = false;
            btnCaiDat.FlatStyle = FlatStyle.Flat;
            btnCaiDat.FlatAppearance.BorderSize = 0;
            btnThoat.TabStop = false;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            //check file config
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    if (lines.Count() < 0)
                    {
                        Setting s = new Setting();
                        s.Show();
                        this.Hide();
                    }
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
                    Setting s = new Setting();
                    s.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTuVan_Click(object sender, EventArgs e)
        {
            TuVan t = new TuVan();
            t.Show();
            this.Hide();
        }

        private void btnNhapDuLieu_Click(object sender, EventArgs e)
        {
            DataCenter d = new DataCenter();
            d.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            Setting s = new Setting();
            s.Show();
            this.Hide();
        }
    }
}
