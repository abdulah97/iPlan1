using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class AddHomework : Form
    {
        public AddHomework()
        {
            InitializeComponent();
        }
        
        //Abdulah Pehlić
        //Adds a new homework to the database
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                String query = "INSERT INTO hw (`Subject`, `Date`, `Homework`) VALUES ('" +
                    textBox1.Text + "','" + dateTimePicker1.Text + "','" + richTextBox1.Text + "')";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                

                int msg = cmd.ExecuteNonQuery();

                if (msg == 1)
                {
                    label4.Text = "Added successfully!";
                    button2.Show();
                }
                else
                {
                    label4.Text = "Error!";
                }



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            iPlan form = new iPlan();
            form.Show();
        }
    }
}
