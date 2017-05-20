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
    public partial class Notes : Form
    {
        //Nedim Husovic
        //Notes Form
        public Notes()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\Nedim\Desktop\iPlan Resources\iPlan.jpg");
        }

      

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewNote Page = new NewNote();
            Page.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SavedNotes Page = new SavedNotes();
            Page.Show();

        }

       

       


        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            iPlan form = new iPlan();
            form.Show();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
