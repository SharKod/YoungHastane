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
    public partial class frm_KullaniciUyeOl : Form
    {
        public frm_KullaniciUyeOl()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();

        void UyeOl()
        {

            try
            {
                if (txtAd.Text == "" || txtCevap.Text == "" || txtSifre.Text == "" || cbGSoru.Text == "")
                {
                    MessageBox.Show("Kullanıcı Ad,Sifre,Gizli Soru,Cevap kısımları boş bırakılamaz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                SqlCommand Uye = new SqlCommand("insert into tbl_KullaniciGiris (KullaniciAd,KullaniciSifre,KullaniciYetki,KullaniciGizliSoru,KullaniciCevap) values (@p1,@p2,@p3,@p4,@p5)", bag.Baglan());
                Uye.Parameters.AddWithValue("@p1", txtAd.Text);
                Uye.Parameters.AddWithValue("@p2", txtSifre.Text);
                Uye.Parameters.AddWithValue("@p3", "Kullanıcı");
                Uye.Parameters.AddWithValue("@p4", cbGSoru.Text);
                Uye.Parameters.AddWithValue("@p5", txtCevap.Text);
                MessageBox.Show("Başarılı bir şekilde üye oldunuz. Giriş yapabilirsiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Uye.ExecuteNonQuery();
                bag.Baglan().Close();
                frm_GirisYap Giris = new frm_GirisYap();
                Giris.Show();
                Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata,  " + ex.Source + "\n" + ex.Message + "lütfen yetkillere bildirin." + MessageBoxButtons.OK + MessageBoxIcon.Error);
            }

            finally
            {
                txtAd.Text = "";
                txtCevap.Text = "";
                txtSifre.Text = "";
                cbGSoru.Text = "";
            }
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            UyeOl();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_KullaniciUyeOl_Load(object sender, EventArgs e)
        {
            txtAd.Focus();
        }
    }
}
