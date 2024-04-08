using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Db_org
{
    internal class DB_CONN
    {
        SqlConnection con = new SqlConnection(@"Data source=Gigabyte\MSSQLSERVER01; Initial catalog=DB_org;Integrated security= true;");

        public void openconnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            
            {
                con.Open();
            
            
            }
        }
        public void closeconnection()
        {
            if (con.State == System.Data.ConnectionState.Open)

            {
                con.Close();


            }
        }
        public SqlConnection getconnection()
        {
            return con;
        }

        public DataSet Getdata()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dt = new DataSet();

            SqlCommand sqlCommand = new SqlCommand("select * from ORG_INFO", getconnection());
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dt, "ORG_INFO");
            sqlCommand = new SqlCommand("select * from PERSON_INFO", getconnection());
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dt, "PERSON_INFO");
            return dt; 
        
        }
    }
}
