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
    public partial class Result : Form
    {
        String result;
        DbConnection db;
        Nganh nganh;
        public Result(string s)
        {
            if(db == null)
            {
                db = new DbConnection();
            }
            
            result = s;
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            SqlConnection conn = db.GetConnection();
            try
            {
                conn.Open();
                string s = "SELECT * FROM Nganh WHERE ma_Nganh='"+result+"'";
                SqlDataAdapter ad = new SqlDataAdapter(s, conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                conn.Close();
                dataGridView1.DataSource = dt;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = "";
            this.Hide();
        }
    }
}
