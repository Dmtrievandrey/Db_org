using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Runtime.Remoting.Messaging;
namespace Db_org
{
    internal class csv
    {

        DB_CONN dB_CONN = new DB_CONN();


        public void csv_export(string file_path, string ds_table)
        {

            StringBuilder csvContent = new StringBuilder();
            DataSet dataSet = new DataSet();
            dataSet = dB_CONN.Getdata();
            DataTable dt = new DataTable();
            dt = dataSet.Tables[ds_table];
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
                File.WriteAllText(file_path + "\\" + ds_table + ".csv", csvContent.ToString(), Encoding.UTF8);
            }
            catch (System.UnauthorizedAccessException e)
            {
                MessageBox.Show("Нет доступа к директории", "Ошибка!",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        public DataTable csv_import(string filePath,string ds_table )
        {
            string fp = filePath;
            DataTable dt = new DataTable();
            StreamReader sr = new StreamReader(fp, Encoding.UTF8);
            {
                string[] colFields = sr.ReadLine().Split(',');
                foreach (string column in colFields)
                {
                    if (column != "")
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        dt.Columns.Add(datecolumn);
                    }
                }
                while (!sr.EndOfStream)
                {
                    string[] fieldData = sr.ReadLine().Split(',');

                    fieldData = fieldData.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                    dt.Rows.Add(fieldData);
                }

                dB_CONN.openconnection();


                SqlBulkCopy s = new SqlBulkCopy(dB_CONN.getconnection());

                s.DestinationTableName = ds_table;
                foreach (var column in dt.Columns)
                    s.ColumnMappings.Add(column.ToString(), column.ToString());
                s.WriteToServer(dt);




                return dt;

            }
        }
    }
}