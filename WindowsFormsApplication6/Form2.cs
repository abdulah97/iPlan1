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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\Nedim\Desktop\iPlan Resources\iPlan.jpg");
        }
        //@author Abdulah Pehlić
        //Registration
        //Checks if username is free, if so, records the username and password to database
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                String q1 = "SELECT * FROM login WHERE Username = '" + textBox1.Text + "'";

                MySqlCommand cmd = new MySqlCommand(q1, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    label4.Text = "Username not available!";
                }
                else
                {
                    cmd.Cancel();
                    cmd.Connection.Close();
                    reader.Close();
                    
                    String query = "INSERT INTO login (`ID`, `Username`, `Password`, `Email`) VALUES (null, '" + textBox1.Text
                    + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";

                    MySqlCommand command = new MySqlCommand(query, conn);

                    conn.Open();

                    int msg = command.ExecuteNonQuery();

                    if (msg == 1)
                    {
                        label4.Text = "SIGNED UP SUCCESSFULLY!";

                    }
                    else
                    {
                        label4.Text = "Error!";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
