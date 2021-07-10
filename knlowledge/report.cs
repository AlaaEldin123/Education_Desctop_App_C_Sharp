using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//Activating the SQL server library

namespace knlowledge
{
    public partial class report : Form
    {
        //data set for dataGridView and his Variables inside it  datatable
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        DataTable d1 = new DataTable();
        DataTable d2 = new DataTable();
        DataTable d3 = new DataTable();
        DataTable d4 = new DataTable();
        DataTable d5 = new DataTable();
        DataTable d6 = new DataTable();
        DataTable d7 = new DataTable();
        DataTable d8 = new DataTable();
        DataTable d9 = new DataTable();
        DataTable d10 = new DataTable();
        //Create a variable in the sqlconnection class and link the connection to the SQL server with the Visual Studio
        // in order to read the Visual Studio codes and data for the SQL server
        // enter three parameters of the server name and then the database name and then give the correct connection security true
        SqlConnection coon = new SqlConnection(@"Data Source= .\SQLEXPRESS ;Initial catalog= knowledge ;Integrated Security=true");
        public report()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //clear the data before If there is, in order for the report not to be printed more than once
            d2.Clear();
            //print repore student who taken java certificate and fill them in dataAdapter's dataGridView who called da
            da = new SqlDataAdapter("select cert_name,student_name from certificate, student where cert_name = 'java'", coon);
            //fill the data from da to datatable of datagridview in the variable d2
            da.Fill(d2);
            //show the data on datagridview that Found in the variable d2
            dataGridView1.DataSource = d2;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //clear the data before If there is, in order for the report not to be printed more than once
            dtt.Clear();
            //print repore case student studing network and fill them in dataAdapter's dataGridView who called da
            da = new SqlDataAdapter("select cert_name,student_name,status from certificate,student,stud_course where cert_name = 'network'", coon);
            //fill the data from da to datatable of datagridview in the variable dtt
            da.Fill(dtt);
            //show the data on datagridview that Found in the variable dtt
            dataGridView2.DataSource = dtt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clear the data before If there is, in order for the report not to be printed more than once
            d1.Clear();
            //print repore Details about students basil and fill them in dataAdapter's dataGridView who called da
            da = new SqlDataAdapter("select teacher_name,student_name,class_date,course_name from teacher,student,stud_teacher,course  where student_name = 'basil'", coon);
            //fill the data from da to datatable of datagridview in the variable d1
            da.Fill(d1);
            //show the data on datagridview that Found in the variable d1
            dataGridView3.DataSource = d1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //clear the data before If there is, in order for the report not to be printed more than once
            d3.Clear();
            //print repore Students who succeeded in the network and fill them in dataAdapter's dataGridView who called da
            da = new SqlDataAdapter("select cert_name,student_name from certificate,student where cert_name = 'network'", coon);
            //fill the data from da to datatable of datagridview in the variable d3
            da.Fill(d3);
            //show the data on datagridview that Found in the variable d3
            dataGridView4.DataSource = d3;
        }

        private void report_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //clear the data before If there is, in order for the report not to be printed more than once
            d4.Clear();
            //print repore  employe& job and fill them in dataAdapter's dataGridView who called da
            da = new SqlDataAdapter("select emp_id, emp_name from employee, job_position where employee.job_id=job_position.job_id", coon);
            //fill the data from da to datatable of datagridview in the variable d4
            da.Fill(d4);
            //show the data on datagridview that Found in the variable d4
            dataGridView5.DataSource = d4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //clear the data before If there is, in order for the report not to be printed more than once
            d5.Clear();
            //print repore  Students who live in Istanbul and fill them in dataAdapter's dataGridView who called da
            da = new SqlDataAdapter("select student_id, student_name from student where student_address= 'istanbul'", coon);
            //fill the data from da to datatable of datagridview in the variable d5
            da.Fill(d5);
            //show the data on datagridview that Found in the variable d5
            dataGridView6.DataSource = d5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //clear the data before If there is, in order for the report not to be printed more than once
            d6.Clear();
            //print repore The status of each course and student has ended or is still continuing and fill them in dataAdapter's dataGridView who called da
            da = new SqlDataAdapter("select student_id,student_name,course_name,status from student,course,stud_course where student.student_id=stud_course.stud_id and course.course_id = stud_course.course_id", coon);
            //fill the data from da to datatable of datagridview in the variable d6
            da.Fill(d6);
            //show the data on datagridview that Found in the variable d6
            dataGridView7.DataSource = d6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //clear the data before If there is, in order for the report not to be printed more than once
            d7.Clear();
            //print repore student who token java cert and live in istanbul and fill them in dataAdapter's dataGridView who called da
            da = new SqlDataAdapter("select cert_name,student_name,student_address from certificate, student where cert_name= 'java' and student_address =  'istanbul'", coon);
            //fill the data from da to datatable of datagridview in the variable d7
            da.Fill(d7);
            //show the data on datagridview that Found in the variable d7
            dataGridView8.DataSource = d7;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //clear the data before If there is, in order for the report not to be printed more than once
            d8.Clear();
            //print repore The student, his teacher, and the time of the lecturet and live in istanbul and fill them in dataAdapter's dataGridView who called da
            da = new SqlDataAdapter("select teacher_name,student_name,class_date   from teacher,student,stud_teacher", coon);
            //fill the data from da to datatable of datagridview in the variable d8
            da.Fill(d8);
            //show the data on datagridview that Found in the variable d8
            dataGridView9.DataSource = d8;
        }
    }
}
