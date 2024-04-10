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
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace Db_org
{
    public partial class Form1 : Form
    {
        csv csv = new csv();   
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
        private void form3_FormClosed(object sender, FormClosedEventArgs e)
        {

            dataGridView1.DataSource = dB_CONN.Getdata();
            dataGridView1.DataMember = "ORG_INFO";
            dataGridView2.DataSource = dB_CONN.Getdata();
            dataGridView2.DataMember = "PERSON_INFO";


        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            form3.FormClosed += new FormClosedEventHandler(form3_FormClosed);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                // shows the path to the selected folder in the folder dialog
                MessageBox.Show(fbd.SelectedPath);

            csv.csv_export(fbd.SelectedPath);



        }
    }
}
