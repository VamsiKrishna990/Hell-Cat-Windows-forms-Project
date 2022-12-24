using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hell_Cat
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fight\OneDrive\Documents\CATBASE.mdf;Integrated Security=True;Connect Timeout=30");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if(item.GetType().Equals(typeof(TextBox)))
                {
                    TextBox t1=item as TextBox;
                    t1.Text=string.Empty;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //SqlCommand cmd = new SqlCommand();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Designation FROM Employee WHERE Employee_Id='"+ textBox1.Text + "'", con);
                DataSet ds = new DataSet();
                string temp = sda.Fill(ds,"Designation").ToString();
                Debug.Print(textBox1.Text);
                //string temp = sda.ToString();
                Debug.Print("test output "+temp);
                Form2 form2 = new Form2();
                Form1 form1 = new Form1();
                Form3 form3 = new Form3();
                if (textBox1.Text.Equals("123"))
                {
                  
                    form2.Show();
                    this.Hide();
                }
                else if(textBox1.Text.Equals("231"))
                {
                    
                    form1.Show();
                    this.Hide();
                }
                else if(textBox1.Text.Equals("312"))
                {
                      
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Employee");
                }
            }
            catch
            {
                MessageBox.Show("Invalid ID");
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
