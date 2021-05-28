using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PansiyonKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-7RQ7VJ29\SQLEXPRESS;Initial Catalog=Pansiyon;Integrated Security=True");


        private void verileriGoster()
        {
            listView1.Items.Clear();
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From kayitlar", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = reader["id"].ToString();
                add.SubItems.Add(reader["ad"].ToString());
                add.SubItems.Add(reader["soyad"].ToString());
                add.SubItems.Add(reader["oda_no"].ToString());
                add.SubItems.Add(reader["Gtarih"].ToString());
                add.SubItems.Add(reader["telefon"].ToString());
                add.SubItems.Add(reader["hesap"].ToString());
                add.SubItems.Add(reader["Ctarih"].ToString());
                listView1.Items.Add(add);
            }
            connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into kayitlar (id,ad,soyad,oda_no,Gtarih,telefon,hesap,Ctarih) values(@id,@ad,@soyad,@oda_no,@Gtarih,@telefon,@hesap,@Ctarih)",connection);
            command.Parameters.AddWithValue("@id", textBox1.Text.ToString());
            command.Parameters.AddWithValue("@ad", textBox2.Text.ToString());
            command.Parameters.AddWithValue("@soyad", textBox3.Text.ToString());
            command.Parameters.AddWithValue("@oda_no", textBox4.Text.ToString());
            command.Parameters.AddWithValue("@telefon", textBox5.Text.ToString());
            command.Parameters.AddWithValue("@hesap", textBox6.Text.ToString());
            command.Parameters.AddWithValue("@Ctarih", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Gtarih", dateTimePicker1.Value.ToString("yyyy-MM-dd"));

            command.ExecuteNonQuery();
            connection.Close();
            verileriGoster();

        }
        int id = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete From kayitlar where id = (" + id + ")", connection);
            command.ExecuteNonQuery();
            connection.Close();
            verileriGoster();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[7].Text;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            String sorgu = "Update kayitlar Set id = '" + textBox1.Text + "',ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "',oda_no='" + textBox4.Text + "',Gtarih='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',telefon='" + textBox5.Text + "',hesap='" + textBox6.Text + "',Ctarih='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' where id="+id+"";
            SqlCommand sqlCommand = new SqlCommand(sorgu, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            verileriGoster();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From kayitlar where ad like '%"+textBox7.Text+"%'", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = reader["id"].ToString();
                add.SubItems.Add(reader["ad"].ToString());
                add.SubItems.Add(reader["soyad"].ToString());
                add.SubItems.Add(reader["oda_no"].ToString());
                add.SubItems.Add(reader["Gtarih"].ToString());
                add.SubItems.Add(reader["telefon"].ToString());
                add.SubItems.Add(reader["hesap"].ToString());
                add.SubItems.Add(reader["Ctarih"].ToString());
                listView1.Items.Add(add);
            }
            connection.Close();
        }
    }
}