using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Db_org
{
    public partial class Form2 : Form
    {
        DB_CONN dB_CONN = new DB_CONN();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB_CONN.openconnection();
            string slq = "";
            string sql = "INSERT INTO ORG_INFO(ORG_NAME,INN,LEGAL_ADDRESS,ACT_ADDRESS) VALUES(@ORG_NAME,@INN,@LEGAL_ADDRESS,@ACT_ADDRESS)";
            SqlCommand sqlCommand = new SqlCommand(sql, dB_CONN.getconnection());
            
            
            
            
           

                
                var emptyTextBoxes = Controls.OfType<TextBox>()
                                             .Where(textBox => string.IsNullOrWhiteSpace(textBox.Text))
                                             .Select(textBox => textBox.Name)
                                             .ToList();

                if (emptyTextBoxes.Any())
                {
                    
                    foreach (var textBoxName in emptyTextBoxes)
                    {
                       MessageBox.Show($"Заполните '{textBoxName}'");
                        
                    }
                }
                else
                {

                sqlCommand.Parameters.Add("@ORG_NAME", textBox1.Text);
                sqlCommand.Parameters.Add("INN", textBox2.Text);
                sqlCommand.Parameters.Add("@LEGAL_ADDRESS", textBox3.Text);
                sqlCommand.Parameters.Add("@ACT_ADDRESS", textBox4.Text);

                    try
                    {
                             sqlCommand.ExecuteNonQuery();
                             MessageBox.Show("Данные добавлены");
                }

                    catch (Exception ex) 
                    {   
                    
                            MessageBox.Show(ex.Message);
                    }

                dB_CONN.closeconnection();
                

            }

          

        }
    }
}
