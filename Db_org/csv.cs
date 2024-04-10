using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Db_org
{   
    internal class csv
    {
        
        DB_CONN dB_CONN = new DB_CONN();


        public void csv_export(string file_path)
        {

            StringBuilder csvContent = new StringBuilder();
            DataSet dataSet = new DataSet();
            dataSet = dB_CONN.Getdata();
            DataTable dt = new DataTable();
            dt = dataSet.Tables["ORG_INFO"];
            foreach (DataColumn col in dt.Columns)
            {
                csvContent.Append(col.ColumnName + ',');

            }
            csvContent.AppendLine();
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {


                    csvContent.Append(item.ToString() + ",");
                }
                csvContent.AppendLine();
            }
            try
            {
                File.WriteAllText(file_path+"\\ORG_INFO.csv", csvContent.ToString(), Encoding.UTF8);
            }
            catch (System.UnauthorizedAccessException e) 
                {
                MessageBox.Show("Нет доступа к директории", "Ошибка!",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            
                }
        }
    }
}
