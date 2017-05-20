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
    public partial class NewNote : Form
    {
        //Nedim Husovic
        
        public NewNote()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void SetTextBox(String text)
        {
            textBox1.Text = text;
        }

        public void setRichTextBox(String text)
        {
            richTextBox1.Text = text;
        }

        private void NewNote_Load(object sender, EventArgs e)
        {

        }
        //Adds a new note to database
        private void button1_Click(object sender, EventArgs e)
        {

             string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
             using (MySqlConnection conn = new MySqlConnection(connectionString))
             {
                 

                 String query = "INSERT INTO newnote (`Title`, `Note`) VALUES ( '" + textBox1.Text
                    + "', '" + richTextBox1.Text + "')";

                 MySqlCommand cmd = new MySqlCommand(query, conn);
                 conn.Open();

                 
                 cmd.ExecuteNonQuery();
                
             }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Notes form = new Notes();
            form.Show();
        }
    }
}
