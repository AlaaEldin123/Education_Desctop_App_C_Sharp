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
    public partial class course : Form
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
        SqlConnection coon = new SqlConnection(@"Data Source= .\SQLEXPRESS ;Initial catalog= knowledge ;Integrated Security=true");
        public course()
        {
            InitializeComponent();
        }

        private void course_Load(object sender, EventArgs e)
        {
            //First, we want to show the last course identification number, add one to it, and display it on the Visual Studio interface

            //open coonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL comman Within a variable named com1 and write name of connection
            SqlCommand com1 = new SqlCommand("select max (course_id)+1 from course", coon);

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
            //Fill the combobox data adapter with a SQL server and write name of connection To fetch data for all course
            da = new SqlDataAdapter("select * from course", coon);
            //fill the data in datatable called dtt
            da.Fill(dtt);
            comboBox1.DataSource = dtt;
            //Show the table data in the order we want it to appear on the textbox and fill it in the text property
            comboBox1.DisplayMember = ("course_id");
            textBox5.DataBindings.Add("text", dtt, "course_name");
            textBox6.DataBindings.Add("text", dtt, "course_length");
            textBox7.DataBindings.Add("text", dtt, "course_cost");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add new student code inside the database

            //open coonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named com1

            SqlCommand com1 = new SqlCommand("INSERT INTO [course]([course_name],[course_length],[course_cost]) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", coon);
            //The implementation of the SQL Server code
            com1.ExecuteNonQuery();

            //show message when new course add
            MessageBox.Show("A new course has been added");

            //clear the data from the boxs 2 3 4
            textBox2.Text = ("");
            textBox3.Text = ("");
            textBox4.Text = ("");
            //Identification Conversion Code from String to Integrator to add to it 1 And put it inside a variable named id2
            int id2 = int.Parse(id);
            //Convert the definition code from int to string and display it on a window
            textBox1.Text = (id2 + 1).ToString();

            coon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cancel the data modification process from the textboxs 2 3 4
            textBox2.Text = ("");
            textBox3.Text = ("");
            textBox4.Text = ("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //open connection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named dd1
            //Here is the code delete course from the database
            SqlCommand dd1 = new SqlCommand("delete from course where course_id='" + comboBox1.Text + "'", coon);

            //Code implementation of sql
            dd1.ExecuteNonQuery();
            //show messege when course delete
            MessageBox.Show("one course has been deleted");
            //close connection
            coon.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //open eonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named dd1
            //Here is the code update course from the database
            SqlCommand dd1 = new SqlCommand("UPDATE [course] SET [course_name] = '" + textBox5.Text + "'  ,[course_length] = '" + textBox6.Text + "' ,[course_cost] = '" + textBox7.Text + "' WHERE course_id = '" + comboBox1.Text + "' ", coon);
            //Code implementation
            dd1.ExecuteNonQuery();
            //show messege when course updated
            MessageBox.Show("course has been updated");
            coon.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Cancel the data modification process from the textbox 5 6 7
            textBox5.Text = ("");
            textBox6.Text = ("");
            textBox7.Text = ("");
        }
    }
}
