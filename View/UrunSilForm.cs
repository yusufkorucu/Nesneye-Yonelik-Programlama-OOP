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
using WindowsFormsApplication4.Model;

namespace WindowsFormsApplication4.View
{
    public partial class UrunSilForm : DevExpress.XtraEditors.XtraForm
    {
        public UrunSilForm()
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

     
        private void UrunSilForm_Load(object sender, EventArgs e)
        {
            listele();
            
        }
        int id;
        private void btnSil_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(txtsil.Text);           
             baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from urunler where urun_id=@urunid",baglanti);
            komut.Parameters.AddWithValue("@urunid",id);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme Başarılı");
            
            listele();
          
        }
    }
}