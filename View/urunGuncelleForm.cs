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
using System.Data.Sql;
using System.Data.SqlClient;
using WindowsFormsApplication4.Model;

namespace WindowsFormsApplication4.View
{
    public partial class urunGuncelleForm : DevExpress.XtraEditors.XtraForm
    {
        public urunGuncelleForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-31SPU2M\\SQLEXPRESS;Initial Catalog=nesnelogin;Integrated Security=True");
      
        
        public void listele()
        {

            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from urunler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            baglanti.Close();
        }


        private void urunGuncelleForm_Load(object sender, EventArgs e)
        {
            listele();

        }
        int id;
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            urun u = new urun();
            u.UrunAd = txtadd.Text;
            u.Fiyat =Convert.ToInt32( txtfiyatt.Text);
           id = Convert.ToInt32(txtid.Text);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update urunler set urun_ad=@urunadi,  urun_fiyat=@urunfiyati where urun_id=@urunid", baglanti);
            komut.Parameters.AddWithValue("@urunid", id);
            komut.Parameters.AddWithValue("@urunadi",u.UrunAd);
            komut.Parameters.AddWithValue("@urunfiyati",u.Fiyat);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Güncellendi");

           listele();
        }
    }
}