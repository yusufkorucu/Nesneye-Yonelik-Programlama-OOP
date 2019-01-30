using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using WindowsFormsApplication4.View;
using WindowsFormsApplication4.Model;



namespace WindowsFormsApplication4
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public int id;
        BilgilerForm1 bf;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-31SPU2M\\SQLEXPRESS;Initial Catalog=nesnelogin;Integrated Security=True");

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.MusteriUser = txtuser.Text;
            m.MusteriPassword = txtpass.Text;

            if (rdby.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut =  new SqlCommand ("select *from login where userr=@kullanici AND password=@sifre", baglanti);
                komut.Parameters.AddWithValue("@kullanici", m.MusteriUser);
                komut.Parameters.AddWithValue("@sifre", m.MusteriPassword);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    yonetici fr = new yonetici();
                    fr.Show();
                    this.Hide();

                }
                baglanti.Close();
                }
            if (rdbm.Checked == true)
            {
               
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from kullanicilogin where k_adi=@kullanici AND k_sifre=@sifre", baglanti);
                komut.Parameters.AddWithValue("@kullanici", m.MusteriUser);
                komut.Parameters.AddWithValue("@sifre", m.MusteriPassword);
                SqlDataReader dr = komut.ExecuteReader();


                if (dr.Read())
                {
                    MüsteriForm mf = new MüsteriForm();
                    mf.Show();
                    this.Hide();
                   

                }
                baglanti.Close();

                
                
            }
            
        }

        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
