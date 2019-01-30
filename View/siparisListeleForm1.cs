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
using WindowsFormsApplication4.View;


namespace WindowsFormsApplication4.View
{
    public partial class siparisListeleForm1 : DevExpress.XtraEditors.XtraForm
    {
        public siparisListeleForm1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-31SPU2M\\SQLEXPRESS;Initial Catalog=nesnelogin;Integrated Security=True");

        siparisListeleForm1 spl;

        public void siparisListele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from siparis", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            baglanti.Close();


        }


        private void siparisListeleForm1_Load(object sender, EventArgs e)
        {
            siparisListele();
        }
    }
}