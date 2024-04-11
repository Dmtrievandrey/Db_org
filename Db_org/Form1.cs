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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
     

        private void button5_Click(object sender, EventArgs e)
        {
            string ds_table = "ORG_INFO";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(fbd.SelectedPath);
            }
            csv.csv_export(fbd.SelectedPath,ds_table);



        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;

              
                string ds_table = "ORG_INFO";
               csv.csv_import(filePath,ds_table);
                dataGridView1.DataSource = dB_CONN.Getdata();
                dataGridView1.DataMember = "ORG_INFO";
                MessageBox.Show("Данные успешно импортированны!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string ds_table = "PERSON_INFO";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show( "Данные сохранены в папке:"+fbd.SelectedPath);
            }
            csv.csv_export(fbd.SelectedPath, ds_table);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv";
           
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;

             
                string ds_table = "PERSON_INFO";
                csv.csv_import(filePath, ds_table);
                dataGridView2.DataSource = dB_CONN.Getdata();
                dataGridView2.DataMember = "PERSON_INFO";
                MessageBox.Show("Данные успешно импортированны!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form3 form3 = new Form3();
            form3.Show();
            form3.FormClosed += new FormClosedEventHandler(form3_FormClosed);
        }
    }
}
