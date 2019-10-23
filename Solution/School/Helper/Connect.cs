using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.Helper
{
    public static class Connect
    {
        public static SqlConnection ToDatabase()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                string connectionString = "Data Source=.; Initial Catalog=SCHOOL; Integrated Security=true;";
                con = new SqlConnection(connectionString);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return con;
        }

        public static void Close()
        {
            if (ToDatabase().State != ConnectionState.Closed)
            {
                ToDatabase().Close();
            }
        }
    }
}