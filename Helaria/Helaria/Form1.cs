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

namespace Helaria
{

    public partial class Form1 : Form
    {
        int ID = 0;

        string GetConnectionString()
        {
            return Helaria.Properties.Settings.Default.constr;
        }

        SqlConnection GetConnection()
        {
            string s = GetConnectionString();
            return new SqlConnection(Helaria.Properties.Settings.Default.constr);
        }

        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Title, Venue, Date, Time, Price FROM Helaria", GetConnection());
            da.Fill(dt);
            dgvlist.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txttitle.Text != "" && txtVenue.Text != "")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO  Helaria (Title, Venue, Date, Time, Price)VALUES (@Title, @Venue, @Date, @Time, @Price)", GetConnection());
                cmd.Parameters.AddWithValue("@Title", txttitle.Text);
                cmd.Parameters.AddWithValue("@Venue", txtVenue.Text);
                cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                cmd.Parameters.AddWithValue("@Time", txtTime.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                txttitle.Text = "";
                txtVenue.Text = "";
                txtDate.Text = "";
                txtPrice.Text = "";
                txtTime.Text = "";

                DisplayData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void lblD_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            txtDate.Text = Convert.ToDateTime(dt).ToString("dd MMM yyyy");
        }

        private void lblT_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            txtTime.Text = Convert.ToDateTime(dt).ToString("hh:mm:ss");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txttitle.Text != "" && txtVenue.Text != "")
            {
                SqlCommand cmd = new SqlCommand("UPDATE Helaria SET Title = @Title, Venue = @Venue, Date = @Date, Time = @Time, Price = @Price where id = @id", GetConnection());
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@Title", txttitle.Text);
                cmd.Parameters.AddWithValue("@Venue", txtVenue.Text);
                cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(txtDate.Text).ToString("dd MMM yyyy"));
                cmd.Parameters.AddWithValue("@Time", Convert.ToDateTime(txtTime.Text).ToString("hh:mm:ss"));
            
            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                txttitle.Text = "";
                txtVenue.Text = "";
                txtDate.Text = "";
                txtPrice.Text = "";
                txtTime.Text = "";

                DisplayData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void dgvlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dgvlist.Rows[e.RowIndex].Cells[0].Value.ToString());
            txttitle.Text = dgvlist.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtVenue.Text = dgvlist.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDate.Text = dgvlist.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtTime.Text = Convert.ToDateTime(dgvlist.Rows[e.RowIndex].Cells[4].Value).ToString("hh:mm:ss");
            txtPrice.Text = dgvlist.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                SqlCommand cmd = new SqlCommand("delete Helaria where id=@id", GetConnection());

                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                txttitle.Text = "";
                txtVenue.Text = "";
                txtDate.Text = "";
                txtPrice.Text = "";
                txtTime.Text = "";

                DisplayData();
            }
        }
    }
}
