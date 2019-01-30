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
    public partial class UrunListeForm : DevExpress.XtraEditors.XtraForm
    {
        public UrunListeForm()
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
           
            
           


        
        private void UrunListeForm_Load(object sender, EventArgs e)
        {
            listele();

            
        }
    }
}