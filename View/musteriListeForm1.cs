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
    public partial class musteriListeForm1 : DevExpress.XtraEditors.XtraForm
    {
        public musteriListeForm1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-31SPU2M\\SQLEXPRESS;Initial Catalog=nesnelogin;Integrated Security=True");
        public void musteriListele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from musteri", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            baglanti.Close();
            



        }
         
        private void musteriListeForm1_Load(object sender, EventArgs e)
        {
            musteriListele();

        }
    }
}