using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HARR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();     
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;

            if (user == "" && password == "")
            {
                label6.Text = "Please enter your credentials";

            }
            else if (user != "admin" || password != "123")
            {
                label6.Text = "Incorrect credentials";
            }
            else if (user == "admin" && password == "123")
            {
                label6.Text = "Welcome";
                profile p=new profile();
                p.Show();
                this.Hide();
                
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
