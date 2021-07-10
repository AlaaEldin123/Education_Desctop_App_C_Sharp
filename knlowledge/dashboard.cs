using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace knlowledge
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            report rep = new report();
            rep.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            student stud = new student();
            stud.Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            teacher tec = new teacher();
            tec.Show();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            certificate cer = new certificate();
            cer.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            course co = new course();
            co.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            exam ex = new exam();
            ex.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            job_position job = new job_position();
            job.Show();
        }
    }
}
