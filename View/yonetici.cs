using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using WindowsFormsApplication4.View;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class yonetici : DevExpress.XtraBars.Ribbon.RibbonForm 
    {
        public yonetici()
        {
            InitializeComponent();
        }
        UrunListeForm urf;
        musteriListeForm1 mlf;
        siparisListeleForm1 spl;
        SiparisDetayForm spd;
        UrunEkleForm uef;
        UrunSilForm usf;
        urunGuncelleForm urg;
        

      
        private void yoneticifrm(object sender, EventArgs e)
        {

        }
        
        private void yoneticifrm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnUrunListele_ItemClick(object sender, ItemClickEventArgs e)
        {
  
                urf = new UrunListeForm();
                urf.MdiParent = this;
                urf.Show();
                urf.listele();

        }

        private void btnMusteriListele_ItemClick(object sender, ItemClickEventArgs e)
        {

                mlf = new musteriListeForm1();
                mlf.MdiParent = this;
                mlf.Show();
                mlf.musteriListele();
            

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
  
                spl = new siparisListeleForm1();
                spl.MdiParent = this;
                spl.Show();
                spl.siparisListele();

        }

        private void SpdBtnListele_ItemClick(object sender, ItemClickEventArgs e)
        {

                spd = new SiparisDetayForm();
                spd.MdiParent = this;
                spd.Show();
                spd.spdListele();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            uef = new UrunEkleForm();
            uef.MdiParent = this;
            uef.Show();
            uef.UrunEkle();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            usf = new UrunSilForm();
            usf.MdiParent = this;
            usf.Show();
        }

        private void BtnUrunGuncelle_ItemClick(object sender, ItemClickEventArgs e)
        {
            urg = new urunGuncelleForm();
            urg.MdiParent = this;
            urg.Show();
        }
    }
}