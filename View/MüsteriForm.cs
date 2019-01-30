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
using WindowsFormsApplication4.Model;


namespace WindowsFormsApplication4.View
{
    public partial class MüsteriForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MüsteriForm()
        {
            InitializeComponent();
        }
        
       
       BilgilerForm1 bl = new BilgilerForm1();
        Giris g = new Giris();
        private void BtnBilgiler_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            bl.MdiParent = this;
            bl.Show();
            bl.Goster();
           
            
        }
        Siparsilerim sp;
        private void BtnSiparislerim_ItemClick(object sender, ItemClickEventArgs e)
        {
            sp = new Siparsilerim();
            sp.MdiParent = this;
            sp.Show();
            sp.siparis();
           
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
       
        private void MüsteriForm_Load(object sender, EventArgs e)
        {

        }
        SiparisVerForm spv;
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            spv = new SiparisVerForm();
            spv.MdiParent = this;
            spv.Show();
            spv.siparisver();

        }
    }
}