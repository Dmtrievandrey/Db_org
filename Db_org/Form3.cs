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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Db_org
{
    public partial class Form3 : Form
    {
        DB_CONN dB_CONN = new DB_CONN();   
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dB_CONN.openconnection();
            string slq = "";
            string sql = "INSERT INTO PERSON_INFO(SURNAME,NAME_,MIDDLE_NAME,BIRTH_DATE,PASP_SER,PASP_NUMB) VALUES(@SURNAME,@NAME_,@MIDDLE_NAME,@BIRTH_DATE,@PASP_SER,@PASP_NUMB)";
            SqlCommand sqlCommand = new SqlCommand(sql, dB_CONN.getconnection());







            var emptyTextBoxes = Controls.OfType<System.Windows.Forms.TextBox>()
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

                sqlCommand.Parameters.Add("@SURNAME", textBox1.Text);
                sqlCommand.Parameters.Add("@NAME_", textBox2.Text);
                sqlCommand.Parameters.Add("@MIDDLE_NAME", textBox3.Text);
                sqlCommand.Parameters.Add("@PASP_SER", textBox5.Text);
                sqlCommand.Parameters.Add("@PASP_NUMB", textBox6.Text);
                sqlCommand.Parameters.Add("@BIRTH_DATE", dateTimePicker1.Value.Date);

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
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }

}
