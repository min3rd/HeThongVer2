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
    public partial class Result : Form
    {
        DataTable dt;
        public Result(DataTable t)
        {
            dt = t;
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            if (dt == null)
            {
                MessageBox.Show("Không có kết quả phù hợp");
                this.Hide();
            }else
            {
                dataGridView1.DataSource = dt;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dt = null;
        }
    }
}
