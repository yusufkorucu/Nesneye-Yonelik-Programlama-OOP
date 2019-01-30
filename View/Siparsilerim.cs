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


namespace WindowsFormsApplication4.View
{
    public partial class Siparsilerim : DevExpress.XtraEditors.XtraForm
    {
        public Siparsilerim()
        {
            InitializeComponent();
        }
        Siparsilerim sp;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-31SPU2M\\SQLEXPRESS;Initial Catalog=nesnelogin;Integrated Security=True");
        public void siparis()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select KL.k_id,M.musteri_ad,M.musteri_soyad,M.musteri_adres,S.siparis_tarih,S.siparis_durum,Sd.siparis_fiyat,Sd.siparis_miktar,Sd.siparis_agırlık,u.urun_ad,u.urun_fiyat from kullanicilogin KL inner join musteri M on KL.k_id=M.k_id inner join siparis S on S.musteri_id=m.musteri_id inner join siparisdetay Sd on Sd.siparis_id = s.siparis_id inner join urunler u on Sd.urun_id = u.urun_id   where KL.k_id =1", baglanti);
            DataTable dt = new DataTable();

            da.Fill(dt);
            gridControl1.DataSource = dt;





            baglanti.Close();

        }

        private void Siparsilerim_Load(object sender, EventArgs e)
        {
            siparis();
        }
    }
}