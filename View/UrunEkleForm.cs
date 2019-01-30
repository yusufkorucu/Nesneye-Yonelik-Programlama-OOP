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
using WindowsFormsApplication4.Model;
using System.Data.SqlClient;

namespace WindowsFormsApplication4.View
{
    public partial class UrunEkleForm : DevExpress.XtraEditors.XtraForm
    {
        public UrunEkleForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-31SPU2M\\SQLEXPRESS;Initial Catalog=nesnelogin;Integrated Security=True");
      
        public void UrunEkle()
        {
            int a;
            urun u = new urun();
            u.UrunAd = txtUrunAd.Text;
            a =Convert.ToInt16 ( txtUrunFiyat.Text); 
            u.Fiyat =a;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into urunler(urun_ad, urun_fiyat) values('"+u.UrunAd+"','"+u.Fiyat+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            UrunEkle();
            MessageBox.Show("Ürün Başarı ile Eklenmiştir");
            txtUrunAd.Clear();
            txtUrunFiyat.Clear();

        }
    }
}