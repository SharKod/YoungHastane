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
    public partial class frm_Yoneticiislem : Form
    {
        public frm_Yoneticiislem()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();

        void YoneticiListele()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.CadetBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter Listele = new SqlDataAdapter("select Yoneticiid as [Yönetici ID],Ad,Soyad,TC as [T.C],Tel as [Telefon],Mail,KulAdi as [Kullanıcı Adı],Sifre as [Şifre],GizliSoru as [Gizli Soru],Cevap,Durum from  tbl_Yonetici", bag.Baglan());
            DataTable dt = new DataTable();
            Listele.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Baglan().Close();
        }

  

        

        void KullaniciEkle()
        {
            SqlCommand KulEkle = new SqlCommand("insert into tbl_KullaniciGiris (KullaniciAd,KullaniciSifre,KullaniciGizliSoru,KullaniciCevap) values (@p1,@p2,@p3,@p4)", bag.Baglan());
            KulEkle.Parameters.AddWithValue("@p1", txtKulAdi.Text);
            KulEkle.Parameters.AddWithValue("@p2", txtSifre.Text);
            KulEkle.Parameters.AddWithValue("@p3", cbGSoru.Text);
            KulEkle.Parameters.AddWithValue("@p4", txtCevap.Text);
            KulEkle.ExecuteNonQuery();
            bag.Baglan().Close();
        }

        void Temizle()
        {
            txtAd.Text = "";
            txtKulAdi.Text = "";
            txtMail.Text = "";
            txtSifre.Text = "";
            txtSoyad.Text = "";
            mskTC.Text = "";
            mskTel.Text = "";
            cbDurum.Text = "";
            txtCevap.Text = "";
            cbGSoru.Text = "";
        }

        void YoneticiGuncelle()
        {
            try
            {
                SqlCommand Guncelle = new SqlCommand("update tbl_Yonetici set Ad=@p2,Soyad=@p3,TC=@p4,Tel=@p5,Mail=@p6,kulAdi=@p7,Sifre=@p8,GizliSoru=@p9,Cevap=@p10,Durum=@p11 where Yoneticiid=@p1", bag.Baglan());
            Guncelle.Parameters.AddWithValue("@p1", txtid.Text);
            Guncelle.Parameters.AddWithValue("@p2", txtAd.Text);
            Guncelle.Parameters.AddWithValue("@p3", txtSoyad.Text);
            Guncelle.Parameters.AddWithValue("@p4", mskTC.Text);
            Guncelle.Parameters.AddWithValue("@p5", mskTel.Text);
            Guncelle.Parameters.AddWithValue("@p6", txtMail.Text);
            Guncelle.Parameters.AddWithValue("@p7", txtKulAdi.Text);
            Guncelle.Parameters.AddWithValue("@p8", txtSifre.Text);
            Guncelle.Parameters.AddWithValue("@p9", cbGSoru.Text);
            Guncelle.Parameters.AddWithValue("@p10", txtCevap.Text);
            Guncelle.Parameters.AddWithValue("@p11", cbDurum.Text);
            Guncelle.ExecuteNonQuery();
            MessageBox.Show("Yönetici bilgileri güncelendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            YoneticiListele();
            bag.Baglan().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata " + ex.Source + "\n" + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Temizle();
            }
        }

        void YoneticiSil()
        {
            try
            {
                DialogResult DR = MessageBox.Show(txtid.Text + "  nolu yönetici bilgisini silmek ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    SqlCommand Sil = new SqlCommand("delete from tbl_Yonetici where Yoneticiid=@p1", bag.Baglan());
                    Sil.Parameters.AddWithValue("@p1", txtid.Text);
                    Sil.ExecuteNonQuery();
                    YoneticiListele();
                    bag.Baglan().Close();
                }
                else
                    YoneticiListele();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata " + ex.Source + "\n" + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Temizle();
            }
        }

        void Sifrelele()
        {
           string metin = txtSifre.Text;
           byte[] veridizi=ASCIIEncoding.ASCII.GetBytes(metin);
           string SifreliVeri = Convert.ToBase64String(veridizi);
           txtSifre.Text = SifreliVeri.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Sifrelele();
            KullaniciEkle();
        }

        private void frm_Yoneticiislem_Load(object sender, EventArgs e)
        {
            YoneticiListele();
            txtAd.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            mskTC.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            mskTel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtKulAdi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtSifre.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cbGSoru.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtCevap.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            cbDurum.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            YoneticiGuncelle();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            YoneticiSil();
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
           && !char.IsSeparator(e.KeyChar);
        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
           && !char.IsSeparator(e.KeyChar);
        }
    }
}
