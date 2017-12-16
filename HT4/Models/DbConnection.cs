using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HT4
{
    class DbConnection
    {
        public string server;
        public string data;
        public string user;
        public string password;
        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\config.txt";
        string connetionString = null;
        string connectionString2 = null;
        SqlConnection cnn;

        public DbConnection()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                server = lines[0];
                data = lines[1];
                user = lines[2];
                password = lines[3];
                if (user.Equals("sa"))
                {
                    connetionString = @"Data Source=" + server + ";Initial Catalog=" + data + ";Persist Security Info=True;User ID=" + user + ";Password=" + password + "";
                    cnn = new SqlConnection();
                    cnn.ConnectionString = connetionString;
                }else
                {
                    connectionString2 = @"Data Source="+server+";Initial Catalog="+data+";Integrated Security=True";
                    cnn = new SqlConnection();
                    cnn.ConnectionString = connectionString2;
                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public SqlConnection GetConnection()
        {
            if(cnn == null)
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    server = lines[0];
                    data = lines[1];
                    user = lines[2];
                    password = lines[3];
                    if (user.Equals("sa"))
                    {
                        connetionString = @"Data Source=" + server + ";Initial Catalog=" + data + ";Persist Security Info=True;User ID=" + user + ";Password=" + password + "";
                        cnn = new SqlConnection();
                        cnn.ConnectionString = connetionString;
                    }
                    else
                    {
                        connectionString2 = @"Data Source=" + server + ";Initial Catalog=" + data + ";Integrated Security=True";
                        cnn = new SqlConnection();
                        cnn.ConnectionString = connectionString2;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return cnn;
        }
    }
}
