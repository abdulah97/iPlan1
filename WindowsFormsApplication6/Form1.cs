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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\Nedim\Desktop\iPlan Resources\iPlan.jpg");

        }
        //@author Abdulah Pehlić
        //Student login
        //Checks for the username and password in a database (login status)
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                String query = "SELECT * FROM login WHERE Username = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'";

                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    this.Hide();
                    LoginSuccessful form = new LoginSuccessful();
                    form.Show();
                }
                else
                {
                    label3.Text = "Username and password mismatch!";
                }

                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + " " + reader["username"] + " " + reader["password"]);
                }

                reader.Close();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 Page = new Form2();
            Page.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin form = new AdminLogin();
            form.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

