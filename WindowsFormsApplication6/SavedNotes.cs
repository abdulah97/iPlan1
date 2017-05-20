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
    public partial class SavedNotes : Form
    {
        
        public SavedNotes()
        {
            InitializeComponent();

            pictureBox1.Image = Image.FromFile(@"C:\Users\Nedim\Desktop\iPlan Resources\iPlan.jpg");

            string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                String q1 = "SELECT * FROM newnote ";
                MySqlCommand cmd = new MySqlCommand(q1, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                int i = 0;
                
                //Adds a new button for every note in database and adds a title
                while(reader.Read())
                {

                    Button button = new Button();
                    button.Location = new Point(10, 40 * i + 40);
                    button.Text = reader.GetString(reader.GetOrdinal("Title"));
                    button.Height = 30;
                    button.Width = 130;

                    button.MouseDown += new MouseEventHandler(Button_MouseDown);
                    this.Controls.Add(button);
                    i = i + 1;

                }
                cmd.Cancel();
                cmd.Connection.Close();
                reader.Close();
            }
        }
        //responds to the click on the button
        void Button_MouseDown(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                ContextMenuStrip contexMenuStrip1 = new ContextMenuStrip();
                contexMenuStrip1.Items.Add("Delete ");
                button.ContextMenuStrip = contexMenuStrip1;
                

                //If there is a right click on th button context menu is displayed
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Right)
                {

                    contexMenuStrip1.Show();
                    contexMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler((sender1, e1) =>contexMenuuu_ItemClicked(sender1,e1,button));
                }
                //If there is a left click on the button the note with the title of the button is shown
                else if (me.Button == MouseButtons.Left)
                {
                    this.Hide();
                    NewNote form = new NewNote();
                    form.Show();

                    string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        String q1 = "SELECT * FROM newnote WHERE Title = '" + button.Text + "'  ";
                        MySqlCommand cmd = new MySqlCommand(q1, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        form.SetTextBox(button.Text);
                        reader.Read();
                        form.setRichTextBox(reader.GetString(reader.GetOrdinal("Note")));

                        cmd.Cancel();
                        cmd.Connection.Close();
                        reader.Close();
                    }
                }
            }
        }
        //If the user clicks the delete item from the context menu, button is removed and the selected note is deleted from the database
        void contexMenuuu_ItemClicked(object sender, ToolStripItemClickedEventArgs e,Button button)
        {
            ToolStripItem item = e.ClickedItem;
            this.Controls.Remove(button);

            string connectionString = "server=localhost;uid=root;pwd=;database=Baza";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                String q1 = "DELETE FROM newnote WHERE Title = '" + button.Text + "'  ";
                MySqlCommand cmd = new MySqlCommand(q1, conn);
                cmd.ExecuteNonQuery();
            }
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Notes form = new Notes();
            form.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
