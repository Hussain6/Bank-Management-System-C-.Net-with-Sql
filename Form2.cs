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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=bank;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome! " + Form1.username;
            label2.Text = "Account Number : " + Form1.accountnumber;
            con.Open();
            SqlCommand ccc = new SqlCommand("select * from currentammount where AccountID=@id", con);
            ccc.Parameters.AddWithValue("@id", Form1.accountid);
            SqlDataAdapter aa = new SqlDataAdapter(ccc);
            DataSet ss = new DataSet();
            aa.Fill(ss);
            con.Close();
            if (ss.Tables[0].Rows.Count > 0)
            {
                DataRow drow = ss.Tables[0].Rows[0];
                Form1.Totalammount = drow.ItemArray.GetValue(1).ToString();
                label3.Text ="Total Ammount : "+ Form1.Totalammount;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Depsoit d = new Depsoit();
            d.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transfer t = new Transfer();
            t.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transaction t = new Transaction();
            t.Show();
        }
    }
}
