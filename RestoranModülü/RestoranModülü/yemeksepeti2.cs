using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RestoranModülü
{
    class yemeksepeti2
    {
        public static string baglantiyolu = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Merve Özman\Desktop\Yemek Sepeti\YemekSepetim.mdf;Integrated Security=True;Connect Timeout=30";
      
        public static DataSet restorancek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select * from Restoran";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonuc );
            baglanti.Close();
            return sonuc;
        }
         public static DataSet kategoricek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu );
            string sql = "select * from Kategori";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonuc);
            baglanti.Close();
            return sonuc;
         }
        
        
        public static DataSet yemekcek()
        {
            SqlConnection baglanti=new SqlConnection (baglantiyolu);
            string sql="select Yemek.yemekid,Yemek.yemekismi,Yemek.hazirlamasuresi,Yemek.fiyati,Yemek.resim,Yemek.yemekaciklamasi ,Yemek.kategoriid,RestoranYemek.restoranid from Yemek inner join RestoranYemek on Yemek.yemekid=RestoranYemek.yemekid";
            SqlCommand komut =new SqlCommand (sql,baglanti);
            SqlDataAdapter adaptor=new SqlDataAdapter ();
            adaptor .SelectCommand=komut ;
            DataSet sonuc=new DataSet ();
            adaptor .Fill (sonuc);
            return sonuc ;

            
        }
       
        public static void kategoriekle(string adi, string aciklama,int katid,int resid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "insert into Kategori(kategoriadi,kategoriaciklamasi) values (@pad,@pacikla)";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.AddWithValue("@pad",adi);
            komut.Parameters.AddWithValue("@pacikla",aciklama);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            komut.CommandText = "select * from Kategori where kategoriadi='" + adi + "'";
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            int a = Convert.ToInt32(sonuc.Tables[0].Rows[0][0]);
            komut.CommandText = "insert into RestoranKategori(kategoriid,restoranid) values (@pki,@pri)";
            komut.Parameters.AddWithValue("@pki",a);
            komut.Parameters.AddWithValue("@pri",resid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
       
        public static void opsiyonekle(string aciklama,int yemekid,int opsiyonyemid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "insert into YemekOpsiyonu(secenekler) values(@pacik)";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.AddWithValue("@pacik",aciklama);
            komut.Parameters.AddWithValue("@pyid",yemekid);
            //komut.Parameters.Clear();
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            komut.CommandText = "select * from YemekOpsiyonu where secenekler='"+aciklama+"'";
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc );
            komut.CommandText = "insert into OpsiyonYemek(opsiyonyemekid,yemekid) values (@pyid,@pyid)";
            komut.Parameters.AddWithValue("@poyid",opsiyonyemid );
            komut.Parameters.AddWithValue("@pyid",yemekid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();


        }
        
        public static void yemekekle( int katid, string yemismi, int hazirsuresi, int fiyat, byte[] resim, string yemacik, int resid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "insert into Yemek(yemekismi,hazirlamasuresi,fiyati,resim,yemekaciklamasi,kategoriid) values (@pismi,@phs,@pfiy,@pres,@pyemacik,@pkid)";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@pismi", yemismi);
            komut.Parameters.AddWithValue("@phs",hazirsuresi);
            komut.Parameters.AddWithValue("@pfiy",fiyat);
            komut.Parameters.AddWithValue("@pres",resim );
            komut.Parameters.AddWithValue("@pyemacik",yemacik);
            komut.Parameters.AddWithValue("@pkid",katid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            komut.CommandText = "select * from Yemek where yemekismi='"+yemismi+"'";
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            komut.CommandText = "insert into RestoranYemek(restoranid,yemekid) values (@presid,@pyemid)";
            komut.Parameters.Clear();
            int yemekid = Convert.ToInt32(sonuc .Tables[0].Rows[0][0]);
            komut.Parameters.AddWithValue("@presid",resid);
            komut.Parameters.AddWithValue("@pyemid",yemekid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();



        }
        
        public static DataSet bul(string adi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select * from Kategori where kategoriadi like @padi+'%'";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.AddWithValue("@padi",adi );
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucara = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucara);
            baglanti.Close();
            return sonucara;
        }
       

        public static void kategoriduzenle(int katid,string adi, string aciklama)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "update Kategori set kategoriadi=@padi,kategoriaciklamasi=@pacik where kategoriid=@pkid";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@padi",adi);
            komut.Parameters.AddWithValue("@pacik",aciklama);
            komut.Parameters.AddWithValue("@pkid",katid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            
        }
        public static void yemekduzenle(int yemekid, int katid, string ismi, int hazsure, int fiyat, byte[] resim, string acik)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu );
            string sql = "update Yemek set kategoriid=@pkid,yemekismi=@pyemis,hazirlamasuresi=@phazsu,fiyati=@pfiy,resim=@pres,yemekaciklamasi=@pyemacik where yemekid=@pyemid";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@pkid",katid);
            komut.Parameters.AddWithValue("@pyemis",ismi);
            komut.Parameters.AddWithValue("@phazsu",hazsure);
            komut.Parameters.AddWithValue("@pfiy",fiyat );
            komut.Parameters.AddWithValue("@pres",resim );
            komut.Parameters.AddWithValue("@pyemacik",acik);
            komut.Parameters.AddWithValue("@pyemid",yemekid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();


        }
      
        public static void kategorisil(int katid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "delete from Kategori where kategoriid=@pid";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.AddWithValue("@pid",katid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public static void yemeksil(int yemid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu );
            string sql = "delete from Yemek where yemekid=@pyid";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.AddWithValue("@pyid",yemid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            komut.CommandText = "delete from RestoranYemek where yemekid=" + yemid;
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
       

        public static DataSet yemekbul(string ismi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select * from Yemek where yemekismi like @pismi+'%'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pismi", ismi);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonuc);
            baglanti.Close();
            return sonuc;


        }
       
        public static void opsiyonekle(string adi, int fiyati, int yemid, int resid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "insert into YemekOpsiyonu(opsiyonadi,opsiyonfiyati,yemekid,restoranid) values (@padi,@pfiy,@pyid,@presid)";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.AddWithValue("@padi",adi);
            komut.Parameters.AddWithValue("@pfiy",fiyati);
            komut.Parameters.AddWithValue("@pyid",yemid);
            komut.Parameters.AddWithValue("@presid",resid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        
        public static DataSet opsiyoncek1(int yemid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select * from YemekOpsiyonu where yemekid="+yemid;
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            return sonuc;

        }

        public static DataSet opsiyoncek(int yemekid, int yeopid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "select * from YemekOpsiyonu where yemekid="+yemekid +"and yemekopsiyonid="+yeopid;
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            return sonuc;
        }

        public static void opsiyonguncelle(string yemadi, int fiyat, int yeopid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql ="update YemekOpsiyonu set opsiyonadi=@padi,opsiyonfiyati=@pfiy where yemekopsiyonid=@pid";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.AddWithValue("@padi",yemadi);
            komut.Parameters.AddWithValue("@pfiy",fiyat);
            komut.Parameters.AddWithValue("@pid",yeopid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            
        }
        
        public static void opsiyonsil(int opsid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "delete from YemekOpsiyonu where yemekopsiyonid=@pyoid";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@pyoid",opsid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }


    }
}
