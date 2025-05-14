using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HARR
{
    public partial class profile : Form
    {
          public profile()
        {
            InitializeComponent();
        }
        string connection = @"Data Source=MURTIZA07\SQLEXPRESS;Initial Catalog=DMPSchool;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        private void profile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dMPSchoolDataSet.teachers' table. You can move, or remove it, as needed.
            this.teachersTableAdapter.Fill(this.dMPSchoolDataSet.teachers);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string query = "insert into teachers values(@password,@name,@class,@email,@phone,@section)";
            using (SqlConnection conn = new SqlConnection(connection)) {
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@class", textBox6.Text);
                    cmd.Parameters.AddWithValue("@email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox7.Text);
                    cmd.Parameters.AddWithValue("@section", textBox8.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teacher added successfully ");
                    conn.Close();
                    button1.PerformClick();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query= "select * from teachers";
            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
            
            string query= "update teachers set teacher_password=@password,teacher_name=@name,teacher_class=@class,teacher_email=@email,teacher_phone=@phone,teacher_section=@section where teacher_id=@id";
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@class", textBox6.Text);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
            cmd.Parameters.AddWithValue("@phone", textBox7.Text);
            cmd.Parameters.AddWithValue("@section", textBox8.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Teacher updated successfully ");
            conn.Close();
            button1.PerformClick();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
