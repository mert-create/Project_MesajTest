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
namespace Project_MesajTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection bgl = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=DbTest;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"); 
        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select*From TBLKISILER WHERE NUMARA=@P1 AND SIFRE=@P2",bgl);
            komut.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 fr = new Form2();
                fr.numara = maskedTextBox1.Text;
                fr.Show();
                
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi");
            }
            bgl.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
