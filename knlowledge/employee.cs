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
    public partial class employee : Form
    {
        //Define a variable with the name ID on the year to be seen from the whole and read when called
        string id;
        //data set for combobox and his Variables inside it  datatable
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();

        //Create a variable in the sqlconnection class and link the connection to the SQL server with the Visual Studio
        // in order to read the Visual Studio codes and data for the SQL server
        // enter three parameters of the server name and then the database name and then give the correct connection security true
        SqlConnection coon = new SqlConnection(@"Data Source= DESKTOP-OG8KV71\SQLEXPRESS ;Initial catalog= knowledge ;Integrated Security=true");
        public employee()
        {
            InitializeComponent();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            //First, we want to show the last employee identification number, add one to it, and display it on the Visual Studio interface

            //open coonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL comman Within a variable named com1 and write name of connection
            SqlCommand com1 = new SqlCommand("select max (emp_id)+1 from employee", coon);

            //Now we implement or set the results as a variable called reader
            SqlDataReader reader = com1.ExecuteReader();

            //Then we read the results inside the reader
            reader.Read();
            //Put the data that was taken from the reader variable and put it in the boxes starting with the number 0 and convert it to string
            id = reader[0].ToString();
            //Put the identification number inside textBox1
            textBox1.Text = id;
            //Now close the connection to SQL Server
            coon.Close();
            //Fill the combobox data adapter with a SQL server and write name of connection To fetch data for all employee
            da = new SqlDataAdapter("select * from employee", coon);
            //fill the data in datatable called dtt
            da.Fill(dtt);
            //Show the table data in the order we want it to appear on the textbox and fill it in the text property
            comboBox1.DataSource = dtt;
            comboBox1.DisplayMember = ("emp_id");
            textBox5.DataBindings.Add("text", dtt, "emp_name");
            textBox6.DataBindings.Add("text", dtt, "emp_address");
            textBox7.DataBindings.Add("text", dtt, "emp_phone");
            textBox8.DataBindings.Add("text", dtt, "job_id");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add new employee code inside the database

            //open coonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named com1
            SqlCommand com1 = new SqlCommand("INSERT INTO [employee]([emp_name],[emp_address],[emp_phone],[job_id]) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+textBox9.Text+"')", coon);
            //The implementation of the SQL Server code
            com1.ExecuteNonQuery();
            //show message when new employee add
            MessageBox.Show("A new employee has been added");
            //clear the data from the boxs 2 3 4 9
            textBox2.Text = ("");
            textBox3.Text = ("");
            textBox4.Text = ("");
            textBox9.Text = ("");
            //Identification Conversion Code from String to Integrator to add to it 1 And put it inside a variable named id2
            int id2 = int.Parse(id);
            //Convert the definition code from int to string and display it on a window
            textBox1.Text = (id2 + 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = ("");
            textBox3.Text = ("");
            textBox4.Text = ("");
            textBox9.Text = ("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand dd1 = new SqlCommand("delete from student where student_id='" + comboBox1.Text + "'", coon);
            dd1.ExecuteNonQuery();
            MessageBox.Show("Student has been deleted");
            coon.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand dd1 = new SqlCommand("UPDATE [student] SET [student_name] = '" + textBox5.Text + "'  ,[student_address] = '" + textBox6.Text + "' ,[student_phone] = '" + textBox7.Text + "' WHERE student_id = '" + comboBox1.Text + "' ", coon);
            dd1.ExecuteNonQuery();
            MessageBox.Show("Student has been updated");
            coon.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = ("");
            textBox6.Text = ("");
            textBox7.Text = ("");
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Add new employee code inside the database

            //open coonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named com1
            SqlCommand com1 = new SqlCommand($"INSERT INTO [employee]([emp_name],[emp_address],[emp_phone],[job_id]) VALUES('{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox9.Text}')", coon);
            //The implementation of the SQL Server code
            com1.ExecuteNonQuery();
            //show message when new employee add
            MessageBox.Show("A new employee has been added");
            //clear the data from the boxs 2 3 4 9
            textBox2.Text = ("");
            textBox3.Text = ("");
            textBox4.Text = ("");
            textBox9.Text = ("");
            //Identification Conversion Code from String to Integrator to add to it 1 And put it inside a variable named id2
            int id2 = int.Parse(id);
            //Convert the definition code from int to string and display it on a window
            textBox1.Text = (id2 + 1).ToString();


            coon.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Cancel the data modification process from the textboxs 2 3 4 9
            textBox2.Text = ("");
            textBox3.Text = ("");
            textBox4.Text = ("");
            textBox9.Text = ("");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //open connection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named dd1
            //Here is the code delete employee from the database
            SqlCommand dd1 = new SqlCommand("delete from employee where emp_id='" + comboBox1.Text + "'", coon);
            //Code implementation of sql
            dd1.ExecuteNonQuery();
            //show messege when employee delete
            MessageBox.Show("employee has been deleted");
            //close connection to sql server
            coon.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            //open eonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named dd1
            //Here is the code update employee from the database
            SqlCommand dd1 = new SqlCommand("UPDATE [employee] SET [emp_name] = '" + textBox5.Text + "'  ,[emp_address] = '" + textBox6.Text + "' ,[emp_phone] = '" + textBox7.Text + "',[job_id] = '" + textBox8.Text + "' WHERE emp_id = '" + comboBox1.Text + "' ", coon);
            //Code implementation of sql
            dd1.ExecuteNonQuery();
            //show messege when employee updated
            MessageBox.Show("employee has been updated");
            coon.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //Cancel the data modification process from the textbox 5 6 7 8
            textBox5.Text = ("");
            textBox6.Text = ("");
            textBox7.Text = ("");
            textBox8.Text = ("");
        }
    }
}
