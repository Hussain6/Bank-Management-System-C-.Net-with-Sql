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
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=bank;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Form1.Totalammount) > Convert.ToInt32(textBox1.Text))
            {
                con.Open();
                int tammount = Convert.ToInt32(Form1.Totalammount) - Convert.ToInt32(textBox1.Text);
                SqlCommand s = new SqlCommand("insert into Transactioninfo(AccountID,Ammount,Transaction_Type) values(@id,@ammount,@type)", con);
                s.Parameters.AddWithValue("@id", Form1.accountid);
                s.Parameters.AddWithValue("@ammount", textBox1.Text);
                s.Parameters.AddWithValue("@type", "Transfer");
                s.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand a = new SqlCommand("update currentammount set Total_Ammount=@upammount where AccountID=@idd", con);
                a.Parameters.AddWithValue("@upammount", tammount);
                a.Parameters.AddWithValue("@idd", Form1.accountid);
                a.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ammount Have been Transfered");
            }
            else {
                MessageBox.Show("Your Balance is Less to Transfer");
            }
          
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }
    }
}
