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
    public partial class Form1 : Form
    {

        DB_CONN dB_CONN = new DB_CONN();
        public Form1()
        {
            InitializeComponent();
        }



   private void Form1_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = dB_CONN.Getdata() ;
            dataGridView1.DataMember = "ORG_INFO";
            dataGridView2.DataSource = dB_CONN.Getdata();
            dataGridView2.DataMember = "PERSON_INFO";
            
        }





        private void button1_Click(object sender, EventArgs e)
        {   Form2 form2 = new Form2();  
            form2.Show();
            form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
        }

        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {

            dataGridView1.DataSource = dB_CONN.Getdata();
            dataGridView1.DataMember = "ORG_INFO";
            dataGridView2.DataSource = dB_CONN.Getdata();
            dataGridView2.DataMember = "PERSON_INFO";


        }
 
    }
}
