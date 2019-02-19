using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace YöneticiModülü
{

    class yemeksepeti
    {
        static string baglantiyolu = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Merve Özman\Desktop\Yemek Sepeti\YemekSepetim.mdf;Integrated Security=True;Connect Timeout=30";

         public static DataSet yoneticigiris(string kullaniciadi, int sifre)
        {

            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select * from Yonetici where kullaniciadi=@ykuladi and kullanicisifre=@ykulsif ";
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = sql;
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@ykuladi",kullaniciadi);
            komut.Parameters.AddWithValue("@ykulsif", sifre);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucds = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucds);
            baglanti.Close();
            
            return sonucds;

        }
         
        public static void restoranveriekle(string rismi,string rturu,string radres,int rtel,byte[] resim)
        {
            SqlConnection baglanti=new SqlConnection (baglantiyolu);
            string sql="insert into Restoran(restoranismi,restoranturu,adres,telefon,resim) values (@pismi,@pturu,@padr,@ptel,@pres)";
            SqlCommand komut=new SqlCommand (sql,baglanti);
            komut .Parameters.Clear ();
            komut.Parameters.AddWithValue(@"pismi",rismi);
            komut.Parameters.AddWithValue(@"pturu",rturu);
            komut .Parameters.AddWithValue(@"padr",radres);
            komut.Parameters.AddWithValue(@"ptel",rtel);
            komut.Parameters .AddWithValue(@"pres",resim );
           // komut.Parameters.Clear();
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
         
         public static DataSet bul(string isim)
         {
             SqlConnection baglanti = new SqlConnection(baglantiyolu);
             string sql = "select * from Restoran where restoranismi like @padi+ '%'";
             SqlCommand komut = new SqlCommand(sql,baglanti );
             komut.Parameters.AddWithValue("@padi", isim);
             SqlDataAdapter adaptor = new SqlDataAdapter();
             adaptor.SelectCommand = komut;
             DataSet sonucara = new DataSet();
             baglanti.Open();
             adaptor.Fill(sonucara);
             baglanti.Close();
             return sonucara;

         }

         public static void düzenle(int resid, string isim, string restoranturu, string adres, int tel, byte[] resim)
         {
             SqlConnection baglanti = new SqlConnection(baglantiyolu);
             string sql = "update Restoran set restoranismi=@pisim,restoranturu=@pturu,adres=@padr,telefon=@ptel,resim=@pres where restoranid=@pid";
             SqlCommand komut = new SqlCommand(sql,baglanti);
             komut.Parameters.AddWithValue("@pisim",isim);
             komut.Parameters.AddWithValue("@pturu",restoranturu);
             komut.Parameters.AddWithValue("@padr",adres);
             komut.Parameters.AddWithValue("@ptel",tel);
             komut.Parameters.AddWithValue("@pres",resim);
             komut.Parameters.AddWithValue("@pid",resid);
             baglanti.Open();
             komut.ExecuteNonQuery();
             baglanti.Close();
         }
         public static void sil(int restoranid)
         {
             SqlConnection baglanti = new SqlConnection(baglantiyolu);
             string sql = "delete from Restoran where restoranid=@pid";
             SqlCommand komut = new SqlCommand(sql,baglanti);
             komut.Parameters.AddWithValue("@pid",restoranid);
             baglanti.Open();
             komut.ExecuteNonQuery();
             baglanti.Close();
         }
         public static DataSet vericek()
         {
             SqlConnection baglanti = new SqlConnection(baglantiyolu );
             string sql = "select * from Restoran";
             SqlCommand komut = new SqlCommand(sql,baglanti);
             SqlDataAdapter adaptor = new SqlDataAdapter();
             adaptor.SelectCommand = komut;
             DataSet tablo = new DataSet();
             adaptor.Fill(tablo);
             return tablo;
             

             
         }
    }
    
}
