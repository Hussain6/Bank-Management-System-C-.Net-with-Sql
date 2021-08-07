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

namespace WindowsFormsApp1
{
 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=bank;Integrated Security=True");
        public static string accountid = "";
        public static string username = "";
        public static string accountnumber = "";
        public static string Totalammount = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string user = textBox1.Text;
            string pass = textBox2.Text;
            SqlCommand c = new SqlCommand("select * from bankaccounts where Username=@user and userpassword=@pass",con);
            c.Parameters.AddWithValue("@user", user);
            c.Parameters.AddWithValue("@pass", pass);
            SqlDataAdapter a = new SqlDataAdapter(c);
            DataSet s = new DataSet();
            a.Fill(s);
       
            if (s.Tables[0].Rows.Count > 0)
            {
                DataRow drow = s.Tables[0].Rows[0];
                accountid = drow.ItemArray.GetValue(0).ToString();
                username= drow.ItemArray.GetValue(1).ToString();
                accountnumber = drow.ItemArray.GetValue(3).ToString();
                this.Hide();
                Form2 f = new Form2();
                f.Show();
            }
            else {
                MessageBox.Show("Invalid Username or password");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addnewuser a = new addnewuser();
            this.Hide();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
