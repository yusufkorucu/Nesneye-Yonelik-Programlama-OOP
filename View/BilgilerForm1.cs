using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WindowsFormsApplication4.View;
using System.Data.SqlClient;
using WindowsFormsApplication4.Model;
using System.Data.Sql;

namespace WindowsFormsApplication4.View
{
    public partial class BilgilerForm1 : DevExpress.XtraEditors.XtraForm
    {
        public BilgilerForm1()
        {
            InitializeComponent();
        }

        Musteri m = new Musteri();
         public Musteri id;


        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-31SPU2M\\SQLEXPRESS;Initial Catalog=nesnelogin;Integrated Security=True");

          public void Goster()
          {

             m.MusteriUser = lblAd.Text;
             baglanti.Open();
             SqlCommand komut = new SqlCommand();
             SqlCommand komut1 = new SqlCommand();
             komut.Connection = baglanti;

             komut.CommandText = "select m.musteri_ad,m.musteri_soyad,m.musteri_adres,k.k_adi,k.k_sifre from musteri m inner join kullanicilogin k on m.k_id = k.k_id inner join siparis on m.musteri_id = siparis.musteri_id ";
             SqlParameter p1 = new SqlParameter("kid",m.Musteriid);
             komut.Parameters.Add(p1); 

             komut.ExecuteNonQuery();
             SqlDataReader dr = komut.ExecuteReader();

             if (dr.Read())
             {
                 lblAd.Text = dr["musteri_ad"].ToString();
                 lblSoyad.Text = dr["musteri_soyad"].ToString();
                 lblAdres.Text = dr["musteri_adres"].ToString();
                 lblkadi.Text = dr["k_adi"].ToString();
                 lblksif.Text = dr["k_sifre"].ToString();
                  }
                 m.MusteriAdi = lblAd.Text;
                 m.MusteriSoyad = lblSoyad.Text;
                 m.MusterAdres = lblAdres.Text;
                 m.MusteriUser = lblkadi.Text;
                 m.MusteriPassword = lblksif.Text;

                  baglanti.Close();

          }



       

        private void BilgilerForm1_Load(object sender, EventArgs e)
        {

        }



         
    }
}


    
    