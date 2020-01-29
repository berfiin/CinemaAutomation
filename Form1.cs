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

namespace deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglantiyolu = new SqlConnection("Server=TUNERYUSUF\\TUNERYUSUF;Initial Catalog=Kullanıcı;Integrated Security=True");
            baglantiyolu.Open();
            
            string yol= "Select * from Kontrol where Username=@kullanıcı AND Password=@sifre";
            SqlCommand cmd = new SqlCommand(yol,baglantiyolu);
            cmd.Parameters.AddWithValue("@kullanıcı", KullanıcıText.Text);
            cmd.Parameters.AddWithValue("@sifre", SifreText.Text);
            SqlDataReader oku = cmd.ExecuteReader();
            DataTable tablo = new DataTable();
            tablo.Load(oku);


            if (tablo.Rows.Count>0)
            {
                MessageBox.Show("Merhaba!, Başarılı bir şekilde giriş yaptınız.");
                Form2 arama_ekranı = new Form2();
                this.Hide();
                arama_ekranı.Show();
               
            }
            else
            {
                MessageBox.Show("Hata!!, KullanıcıAdı ve Şifrenizi kontrol ediniz..");
                KullanıcıText.Clear();
                SifreText.Clear();
            }
            baglantiyolu.Close();
        }
    }
}
