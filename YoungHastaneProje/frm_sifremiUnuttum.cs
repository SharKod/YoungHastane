using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YoungHastaneProje
{
    public partial class frm_sifremiUnuttum : Form
    {
        public frm_sifremiUnuttum()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();

        void SifreGetir()
        {
            SqlCommand Getir = new SqlCommand("sekect * from tbl_KullaniciGiris where KullaniciGizliSoru=@p1 and KullaniciCevap=@p2", bag.Baglan());
            Getir.Parameters.AddWithValue("@o1", cbGSoru.Text);
            Getir.Parameters.AddWithValue("@p2", txtCevap.Text);
            
                panel2.Visible = true;
                SqlDataReader dr = Getir.ExecuteReader();
                while (dr.Read())
                {
                    lblSifre.Text = dr["Sifre"].ToString();
                }
                bag.Baglan().Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SifreGetir();
        }
    }
}
