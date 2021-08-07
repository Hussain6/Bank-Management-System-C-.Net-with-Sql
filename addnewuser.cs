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
    public partial class addnewuser : Form
    {
        public addnewuser()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=bank;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            string user = textBox1.Text;
            string pass = textBox2.Text;
            string accountnumber = textBox3.Text;
            SqlCommand c = new SqlCommand("select * from bankaccounts where accountnumber=@acc", con);
            c.Parameters.AddWithValue("@acc", accountnumber);
            SqlDataAdapter a = new SqlDataAdapter(c);
            DataSet s = new DataSet();
            a.Fill(s);
            con.Close();
            if (s.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Account Already Exist");
            }
            else
            {
                con.Open();
                SqlCommand cc = new SqlCommand("insert into bankaccounts values(@user,@pass,@acc)", con);
                cc.Parameters.AddWithValue("@user", user);
                cc.Parameters.AddWithValue("@pass", pass);
                cc.Parameters.AddWithValue("@acc", accountnumber);
                cc.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand ccc = new SqlCommand("select * from bankaccounts where Username=@user and userpassword=@pass", con);
                ccc.Parameters.AddWithValue("@user", user);
                ccc.Parameters.AddWithValue("@pass", pass);
                SqlDataAdapter aa = new SqlDataAdapter(ccc);
                DataSet ss = new DataSet();
                aa.Fill(ss);
                con.Close();
                if (ss.Tables[0].Rows.Count > 0)
                {
                    DataRow drow = ss.Tables[0].Rows[0];
                    string accountid = drow.ItemArray.GetValue(0).ToString();
                    con.Open();
                    SqlCommand sss = new SqlCommand("Insert into currentammount values (@aid,@ammount)",con);
                    sss.Parameters.AddWithValue("@aid", accountid);
                    sss.Parameters.AddWithValue("@ammount", 0);
                    sss.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Account Created Sucessfully");
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
