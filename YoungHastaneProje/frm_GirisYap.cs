using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YoungHastaneProje
{
    public partial class frm_GirisYap : Form
    {
        public frm_GirisYap()
        {
            InitializeComponent();
        }

        SqlBaglanti baglan = new SqlBaglanti();

        void GirisYap()
        {
            // Sisteme giriş yapmak 

            try
            {
                if (txtAd.Text == "" || txtSifre.Text == "")
                {
                    MessageBox.Show("Kullanıcı Ad veya Sifre boş bırakılamaz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                SqlCommand GirisYap = new SqlCommand("select * from tbl_KullaniciGiris where KullaniciAd=@KullaniciAd and KullaniciSifre=@KullaniciSifre", baglan.Baglan());
                GirisYap.Parameters.AddWithValue("@KullaniciAd", txtAd.Text);
                GirisYap.Parameters.AddWithValue("@KullaniciSifre", txtSifre.Text);
                SqlDataReader VeriOku = GirisYap.ExecuteReader();
                if (VeriOku.HasRows)
                {
                    while (VeriOku.Read())
                    {
                        if (VeriOku["KullaniciYetki"].ToString() == "Yönetici")
                        {
                            frm_Yonetici yonetici = new frm_Yonetici();
                            yonetici.Show();
                            Hide();
                        }

                        else if (VeriOku["KullaniciYetki"].ToString() == "Kullanıcı")
                        {
                            frm_Randevu Randevu = new frm_Randevu();
                            Randevu.Show();
                            Hide();
                        }

                        else if (VeriOku["KullaniciYetki"].ToString() == "Beslenme ve Diyet")
                        {
                            frm_BeslenmeDiyet Diyet = new frm_BeslenmeDiyet();
                            Diyet.Show();
                            Hide();
                        }

                        else if (VeriOku["KullaniciYetki"].ToString() == "Beyin ve Sinir Cerrahisi")
                        {
                            frm_BeyinveSinirH Beyin = new frm_BeyinveSinirH();
                            Beyin.Show();
                            Hide();
                        }

                        else if (VeriOku["KullaniciYetki"].ToString() == "Çocuk Cerrahisi")
                        {
                            frm_Cocuk_Cerrahi Cocuk = new frm_Cocuk_Cerrahi();
                            Cocuk.Show();
                            Hide();
                        }

                        else if (VeriOku["KullaniciYetki"].ToString() == "Odyoloji")
                        {
                            frm_Odyoloji Odyoloji = new frm_Odyoloji();
                            Odyoloji.Show();
                            Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata,  " + ex.Source + "\n" + ex.Message + "lütfen yetkillere bildirin." + MessageBoxButtons.OK + MessageBoxIcon.Error);
            }

        }

        void Sifrelele()
        {
            string metin = txtSifre.Text;
            byte[] veridizi = ASCIIEncoding.ASCII.GetBytes(metin);
            string SifreliVeri = Convert.ToBase64String(veridizi);
            txtSifre.Text = SifreliVeri.ToString();
        }

        void BtnHatırla()
        {
            // Butona yazılacak beni hatırla kodkarı

            Properties.Settings.Default.kad = cbHatirla.Checked ? txtAd.Text : String.Empty;
            Properties.Settings.Default.Save();
        }

        void LoadHatirla()
        {
            //Load Hatırla
            
            txtAd.Text = Properties.Settings.Default["kad"].ToString();
            if (txtAd.Text.Count() > 1)
                cbHatirla.Checked = true;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_GirisYap_Load(object sender, EventArgs e)
        {
            LoadHatirla();
            if (cbHatirla.Checked)
            {
                txtSifre.Focus();
            }
            else
                txtAd.Focus();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            Sifrelele();
            GirisYap();
            BtnHatırla();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            frm_KullaniciUyeOl Uye = new frm_KullaniciUyeOl();
            Uye.Show();
            Hide();
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            frm_sifremiUnuttum Sifre = new frm_sifremiUnuttum();
            Sifre.Show();
            Hide();
        }
    }
}
