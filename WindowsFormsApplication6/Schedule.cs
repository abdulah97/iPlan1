using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

    //@author Nedim Husovic
namespace WindowsFormsApplication6
{
    public partial class Schedule : Form
    {
        
        MySqlDataAdapter adap;
        MySqlCommandBuilder cmdbl;
        DataSet ds;
        public Schedule()
        {
            InitializeComponent();
            
            
        }
        //Fills the dataGridView with data from database
        private void Form6_Load(object sender, EventArgs e)
        {
            
            string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                String q1 = "SELECT * FROM schedule";
                adap = new MySqlDataAdapter(q1,conn);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "schedule");
                dataGridView1.DataSource = ds.Tables[0];

                conn.Close();

            }


        }
        //Updates database with data from the grid
        private void update_Click(object sender, EventArgs e)
        {
            cmdbl = new MySqlCommandBuilder(adap);
            adap.Update(ds, "schedule");
            MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            iPlan form = new iPlan();
            form.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }
        //Clears the data from the grid and from the table in database
        private void resetTable_Click(object sender, EventArgs e)
        {
            

            string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                String q1 = "DELETE FROM schedule";
                MySqlCommand cmd = new MySqlCommand(q1, conn);
                cmd.ExecuteNonQuery();

                String q2 = "SELECT * FROM schedule";
                adap = new MySqlDataAdapter(q2, conn);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "schedule");
                dataGridView1.DataSource = ds.Tables[0];

                
            }
        }

       
    }
}
