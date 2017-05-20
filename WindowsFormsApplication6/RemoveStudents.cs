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
    public partial class RemoveStudents : Form
    {
        public RemoveStudents()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\Nedim\Desktop\iPlan Resources\iPlan.jpg");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //Abdulah Pehlić
        //Searches for a user to be removed
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                String query = "SELECT * FROM `login` WHERE `Username` LIKE '" + textBox1.Text + "'";

                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    button2.Show();
                    label3.Text = "User found, if you want to remove him, click on the button below.";
                }
                else
                {
                    label3.Text = "User not found, please try again!";
                    button2.Hide();
                }

                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + " " + reader["username"] + " " + reader["password"]);
                }

                reader.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Administrator form = new Administrator();
            this.Hide();
            form.Show();
        }
        //Abdulah Pehlić
        //Removes a user that has been searched previously
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                String query = "DELETE FROM `login` WHERE `login`.`Username` = '" + textBox1.Text + "'";

                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    label3.Text = "Something went wrong...";
                }
                else
                {
                    label3.Text = "User deleted successfully!";
                }

                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + " " + reader["username"] + " " + reader["password"]);
                }

                reader.Close();

            }
        }

        private void RemoveStudents_Load(object sender, EventArgs e)
        {

        }
    }
}
