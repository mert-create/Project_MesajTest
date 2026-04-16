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
using System.Data.SqlClient;

namespace Project_MesajTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string numara;
        SqlConnection bgl = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=DbTest;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

        void gelenkutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TBLMESAJLAR WHERE ALICI="+numara, bgl);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }
        void gidenkutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM TBLMESAJLAR WHERE GÖNDEREN=" + numara, bgl);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView3.DataSource = dt1;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            LblNumara.Text= numara;
            gelenkutusu();
            gidenkutusu();

            bgl.Open();
            SqlCommand komut = new SqlCommand("Select Ad,Soyad From TBLKISILER Where numara="+numara,bgl);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0]+ " "+dr[1];
            }
            bgl.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLMESAJLAR (GÖNDEREN,ALICI,BASLIK,ICERIK) VALUES (@p1,@p2,@p3,@p4)", bgl);
            komut.Parameters.AddWithValue("@p1", numara);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox1.Text);
            komut.Parameters.AddWithValue("@p4", richTextBox1.Text);

            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Mesajınız iletildi");
            gidenkutusu();
        }
    }
}
