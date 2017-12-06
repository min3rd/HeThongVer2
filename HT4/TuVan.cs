using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HT4
{
    public partial class TuVan : Form
    {
        public TuVan()
        {
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
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();
            this.Hide();
        }
    }
}
