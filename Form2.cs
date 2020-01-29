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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglantiyolu = new SqlConnection("Data Source=TUNERYUSUF\\TUNERYUSUF;Initial Catalog=SinemaApplication;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            baglantiyolu.Open();

            

            SqlDataAdapter da = new SqlDataAdapter(Sorgulama.Text, baglantiyolu); //yazılan sorguyu baglantı yolu yardımı ile alıyoruz
            DataSet data = new DataSet();
            da.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
            baglantiyolu.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantiyolu.Open();

            SqlDataAdapter da = new SqlDataAdapter("select SatısID,Ad as 'Satışı_Yapan_personel',müsteriAd,müsteriSoyad,biletTür,FilmAd,KategoriAd,salonAd,Seans_saat,Tarih from Gişe g inner join Müsteri m on g.mID = m.mID inner join Film f on g.FilmID = f.FilmID inner join Seans s on g.SeansID = s.SeansID inner join Salon k on g.SalonID = k.SalonID inner join Kategori ka on f.KategoriID = ka.KategoriID inner join Bilet b on g.BiletID = b.BiletID inner join Personel p on g.PersonelID = p.PersonelID order by SatısID",baglantiyolu); //yazılan sorguyu baglantı yolu yardımı ile alıyoruz
            DataSet data = new DataSet();                           // veriler datasete eklendi sanal tablo
            da.Fill(data);                                           //Dataadapter içini datasetteki bilgilerle doldurdu
            dataGridView1.DataSource = data.Tables[0];              //datagrid tablosunda veriler listelendi.
            
            baglantiyolu.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantiyolu.Open();

            SqlDataAdapter da = new SqlDataAdapter("select cinsiyet,pozisyon,avg(Maas) as 'Ortalama_Maas' from Personel p inner join Pozisyon po on p.PozisyonID=po.PozisyonID inner join Cinsiyet c on p.CinsiyetID=c.CinsiyetID where cinsiyet='erkek' group by cinsiyet,pozisyon order by pozisyon desc", baglantiyolu); 
            DataSet data = new DataSet();
            da.Fill(data);
            dataGridView1.DataSource = data.Tables[0];

            baglantiyolu.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglantiyolu.Open();

            SqlDataAdapter da = new SqlDataAdapter("select salonAd,FilmAd,KategoriAd,VizyonTarih from Gişe g inner join Film f on g.FilmID=f.FilmID inner join Salon s on g.SalonID=s.SalonID inner join Kategori k on f.KategoriID=k.KategoriID where VizyonTarih between '2016-01-01' and '2017-01-01' order by salonAd", baglantiyolu);
            DataSet data = new DataSet();
            da.Fill(data);
            dataGridView1.DataSource = data.Tables[0];

            baglantiyolu.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglantiyolu.Open();

            SqlDataAdapter da = new SqlDataAdapter("select müsteriAd,müsteriSoyad, count(biletTür)as ToplamAlınanBilet,sum(Fiyat)as ÖdenilenToplamMiktar from Gişe g inner join Müsteri m on g.mID=m.mID inner join Bilet b on g.BiletID=b.BiletID group by müsteriAd,müsteriSoyad", baglantiyolu); 
            DataSet data = new DataSet();
            da.Fill(data);
            dataGridView1.DataSource = data.Tables[0];

            baglantiyolu.Close();
        }

        private void Sorgulama_TextChanged(object sender, EventArgs e)
        {
          

        }
    }
}
