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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\xy\Desktop\iPlan Resources\iPlan.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
        //Abdulah Pehlić
        //Admin login
        //Checks for the username and password in a database (login status)
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=;database=administrator";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                String query = "SELECT * FROM administrator WHERE Username = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'";

                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    this.Hide();
                    Administrator form = new Administrator();
                    form.Show();
                }
                else
                {
                    label4.Text = "Username and password mismatch!";
                }

                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + " " + reader["username"] + " " + reader["password"]);
                }

                reader.Close();

            }
        }
    }
}
