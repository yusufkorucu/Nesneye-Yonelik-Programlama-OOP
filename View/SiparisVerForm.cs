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
    public partial class SiparisVerForm : DevExpress.XtraEditors.XtraForm
    {
        public SiparisVerForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-31SPU2M\\SQLEXPRESS;Initial Catalog=nesnelogin;Integrated Security=True");
        public void siparisver()
        {


        }
        public void listele()
        {

            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from urunler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            baglanti.Close();
        }

        private void SiparisVerForm_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from odeme", baglanti);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbodeme.Items.Add(dr["odeme_turu"]);
            }
            baglanti.Close();
            listele();

        }
        int id; DateTime tar;
        private void BtnSiparisVer_Click(object sender, EventArgs e)
        {
            urun u = new urun();
            siparisDetay sd = new siparisDetay();
            siparis s = new siparis();
            id = Convert.ToInt32(txtid.Text);
            SqlCommand asd = new SqlCommand("Select urun_fiyat=@fiyat from urunler  where urun_id=@urunid", baglanti);
            asd.Parameters.AddWithValue("@urunid", id);
            asd.Parameters.AddWithValue("@fiyat",u.Fiyat);
            s.SiparisTarihi = DateTime.Now;
            s.SiparisDurum = "Hazırlanıyor";
            sd.SiparisMiktar =Convert.ToInt32( txtadet.Text);
            sd.SiparisAgirlik = 5;
            sd.SiparisFiyat = sd.SiparisMiktar * u.Fiyat;
            sd.odemeid = cmbodeme.SelectedIndex;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into siparis (musteri_id,siparis_tarih,siparis_durum) values ('"+1+"','"+"02.12.2018"+"','"+s.SiparisDurum+"')", baglanti);
            komut.ExecuteNonQuery();
            SqlCommand kmt = new SqlCommand("insert into siparisdetay (siparis_id,siparis_miktar,siparis_agırlık,siparis_fiyat,urun_id,odeme_id) values ('" + 6 + "','" + sd.SiparisMiktar+ "','" + sd.SiparisAgirlik + "','"+sd.SiparisFiyat+"','"+id+"','"+sd.odemeid+"')", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sipariş Tamamlandı");

            listele();
        }
    }
}