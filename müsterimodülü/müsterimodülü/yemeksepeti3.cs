using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace müsterimodülü
{
    
    public class yemeksepeti3
    {
        static string baglantiyolu = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Merve Özman\Desktop\Yemek Sepeti\YemekSepetim.mdf;Integrated Security=True;Connect Timeout=30";
      

        public static bool musterivarmi(string email, int sifre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select * from Musteri where mail=@pmail and sifre=@ps";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.AddWithValue("@pmail",email);
            komut.Parameters.AddWithValue("@ps",sifre);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonuc = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonuc);
            baglanti.Close();

            bool sonuc1 = false;
            if (sonuc.Tables[0].Rows.Count > 0)
                sonuc1 = true;
            return sonuc1;


        }
      
        public static DataSet kategoricek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select kategoriadi,kategoriaciklamasi from Kategori";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            return sonuc;

        }
        public static DataSet restorancek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select * from Restoran";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            return sonuc;

        }
        public static DataSet kategoricekk(int restoranid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select Kategori.kategoriid,Kategori.kategoriadi,Kategori.kategoriaciklamasi from Kategori inner join RestoranKategori on RestoranKategori.kategoriid=Kategori.kategoriid where RestoranKategori.restoranid=" + restoranid;
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            return sonuc;
        }
       
        public static DataSet yemekcek(int resid, int kid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select Yemek.yemekid,Yemek.yemekismi,Yemek.hazirlamasuresi,Yemek.fiyati,Yemek.yemekaciklamasi from Yemek inner join RestoranKategori on RestoranKategori.kategoriid=Yemek.kategoriid where Yemek.kategoriid="+kid+"and RestoranKategori.restoranid="+resid;
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            return sonuc;
        }
      
        public static DataSet opsiyoncek(int yemid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select yemekopsiyonid,opsiyonadi,opsiyonfiyati from YemekOpsiyonu where yemekid="+yemid;
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            return sonuc;
        }
     
        public static void sepetekle(int musid, int resid, int yid, int yemopsid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "insert into Sepet(musteriid,restoranid,yemekid,yemekopsiyonu) values (@pmid,@prid,@pyid,@pyoid)";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.AddWithValue("@pmid",musid);
            komut.Parameters.AddWithValue("@prid",resid);
            komut.Parameters.AddWithValue("@pyid",yid);
            komut.Parameters.AddWithValue("@pyoid",yemopsid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

      
      
    }
}