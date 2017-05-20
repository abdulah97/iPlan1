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
    public partial class Administrator : Form
    {
        public Administrator()
        { 
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\xy\Desktop\iPlan Resources\iPlan.jpg");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemoveStudents form = new RemoveStudents();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin form = new AdminLogin();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
