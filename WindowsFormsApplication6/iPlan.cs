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
    public partial class iPlan : Form
    {
        public iPlan()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\Nedim\Desktop\iPlan Resources\iPlan.jpg");

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule form = new Schedule();
            this.Close();
            form.Show();
        }

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form1 form = new Form1();
            this.Close();
            form.Show();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iPlan_Load(object sender, EventArgs e)
        {

        }

        private void averageToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void absentClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeworksExamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeworksExams form = new HomeworksExams();
            form.Show();
            
        }

        private void learningScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudyingSchedule form = new StudyingSchedule();
            form.Show();
        }

        private void importantNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Notes form = new Notes();
            form.Show();
        }

       

        private void iPlan_Load_1(object sender, EventArgs e)
        {

        }
    }
}
