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

    
    public partial class certificate : Form
    {
        //Define a variable with the name ID on the public to be seen from the whole and read when called
        string id;
        //data set for combobox and his Variables inside it  datatable
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();

        //Create a variable in the sqlconnection class and link the connection to the SQL server with the Visual Studio
        // in order to read the Visual Studio codes and data for the SQL server
        // enter three parameters of the server name and then the database name and then give the correct connection security true
        SqlConnection coon = new SqlConnection(@"Data Source= .\SQLEXPRESS ;Initial catalog= knowledge ;Integrated Security=true");
        public certificate()
        {
            InitializeComponent();
        }

        private void certificate_Load(object sender, EventArgs e)
        {
            //First, we want to show the last certificate identification number, add one to it, and display it on the Visual Studio interface

            //open coonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named com1 and write name of connection
            SqlCommand com1 = new SqlCommand("select max (cert_id)+1 from certificate", coon);

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

            //Fill the combobox data adapter with a SQL server and write name of connection To fetch data for all certificate

            da = new SqlDataAdapter("select * from certificate", coon);
            //fill the data in datatable called dtt
            da.Fill(dtt);
            comboBox1.DataSource = dtt;
            //Show the table data in the order we want it to appear on the textbox and fill it in the text property

            comboBox1.DisplayMember = ("cert_id");
            textBox5.DataBindings.Add("text", dtt, "cert_name");
            textBox6.DataBindings.Add("text", dtt, "cert_date");
            textBox7.DataBindings.Add("text", dtt, "course_id");
            textBox8.DataBindings.Add("text", dtt, "stud_id");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add new certificate code inside the database

            //open coonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named com1
            SqlCommand com1 = new SqlCommand($"INSERT INTO [certificate]([cert_name],[cert_date],[course_id],[stud_id]) VALUES('{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox9.Text}')", coon);

            //The implementation of the SQL Server code
            com1.ExecuteNonQuery();

            //show message when new certificate add
            MessageBox.Show("A new certificate has been added");

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

        private void button2_Click(object sender, EventArgs e)
        {
            //Cancel the data modification process from the textboxs 2 3 4 9
            textBox2.Text = ("");
            textBox3.Text = ("");
            textBox4.Text = ("");
            textBox9.Text = ("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //open connection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named dd1
            //Here is the code delete certificate from the database
            SqlCommand dd1 = new SqlCommand("delete from certificate where cert_id='" + comboBox1.Text + "'", coon);

            //Code implementation of sql
            dd1.ExecuteNonQuery();

            //show messege when certificate delete

            MessageBox.Show("certificate has been deleted");
            //close connection to sql server
            coon.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //open eonnection to sql server
            coon.Open();
            //Define the code to be executed from within the SQL server and show its result on the Visual Studio 
            //interface and write it within the SQL command Within a variable named dd1
            //Here is the code update certificate from the database
            SqlCommand dd1 = new SqlCommand("UPDATE [certificate] SET [cert_name] = '" + textBox5.Text + "'  ,[cert_date] = '" + textBox6.Text + "' ,[course_id] = '" + textBox7.Text + "',[stud_id] = '" + textBox8.Text + "' WHERE cert_id = '" + comboBox1.Text + "' ", coon);

            //Code implementation
            dd1.ExecuteNonQuery();

            //show messege when certificate updated
            MessageBox.Show("certificate has been updated");
            coon.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Cancel the data modification process from the textbox 5 6 7 8
            textBox5.Text = ("");
            textBox6.Text = ("");
            textBox7.Text = ("");
            textBox8.Text = ("");
        }
    }
}
