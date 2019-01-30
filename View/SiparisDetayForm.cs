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
using System.Data.SqlClient;

namespace WindowsFormsApplication4.View
{
    public partial class SiparisDetayForm : DevExpress.XtraEditors.XtraForm
    {
        public SiparisDetayForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-31SPU2M\\SQLEXPRESS;Initial Catalog=nesnelogin;Integrated Security=True");

        SiparisDetayForm spd;
        public void spdListele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select s.siparis_id,s.siparis_durum,s.siparis_tarih,m.musteri_ad,m.musteri_soyad,u.urun_ad,u.urun_fiyat,sip.siparis_miktar,o.odeme_turu from  ((siparis s inner join musteri m on s.musteri_id= m.musteri_id )inner join(siparisdetay sip inner join urunler u on sip.urun_id= u.urun_id) on sip.siparis_id=s.siparis_id) inner join(siparisdetay sd inner join odeme o on sd.odeme_id = o.odeme_id) on sip.odeme_id= o.odeme_id  ",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            baglanti.Close();
        }
        private void SiparisDetayForm_Load(object sender, EventArgs e)
        {
            spdListele();
        }
    }
}