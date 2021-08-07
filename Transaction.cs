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

    public partial class Transaction : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=bank;Integrated Security=True");
        public Transaction()
        {
            InitializeComponent();
            Viewdata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
        }
        private void Viewdata()
        {
            string id = Form1.accountid;
            con.Open();
            SqlCommand s = new SqlCommand("Exec Trans_proc @id", con);
            s.Parameters.AddWithValue("@id", id);
            SqlDataAdapter a = new SqlDataAdapter(s);
            DataTable d = new DataTable();
            a.Fill(d);
            dataGridView1.DataSource = d;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }
    }
}
