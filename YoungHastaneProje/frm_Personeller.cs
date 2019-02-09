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
    public partial class frm_Personeller : Form
    {
        public frm_Personeller()
        {
            InitializeComponent();
        }

         SqlBaglanti bag = new SqlBaglanti();

        void PersonelListe()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.CadetBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter Listele = new SqlDataAdapter("select Personelid as [Personel ID],Ad,Soyad,TC,Tel,Mail,Cinsiyet,Yas as [Yaş],Aciklama as [Açıklama] from tbl_Personel", bag.Baglan());
            DataTable dt = new DataTable();
            Listele.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Baglan().Close();
        }
        void PersonelEkle()
        {
            try
            {
                SqlCommand Ekle = new SqlCommand("insert into tbl_Personel (Ad,Soyad,TC,Tel,Mail,Cinsiyet,Yas,Aciklama) values (@p1,@p2,@p3,@p4,@p5,@p8,@p9,@p10)", bag.Baglan());
                Ekle.Parameters.AddWithValue("@p1", txtAd.Text);
                Ekle.Parameters.AddWithValue("@p2", txtSoyad.Text);
                Ekle.Parameters.AddWithValue("@p3", mskTC.Text);
                Ekle.Parameters.AddWithValue("@p4", mskTel.Text);
                Ekle.Parameters.AddWithValue("@p5", txtMail.Text);
                if (rbErkek.Checked == true)
                    Ekle.Parameters.AddWithValue("@p8", "Erkek");
                else
                    Ekle.Parameters.AddWithValue("@p8", "Kadın");
                Ekle.Parameters.AddWithValue("@p9", txtYas.Text);
                Ekle.Parameters.AddWithValue("@p10", rtbAciklama.Text);
                Ekle.ExecuteNonQuery();
                MessageBox.Show("Personel bilgileri sisteme eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PersonelListe();
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
        void Temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtYas.Text = "";
            txtMail.Text = "";
            mskTC.Text = "";
            mskTel.Text = "";
            rtbAciklama.Text = "";
            rbErkek.Checked = false;
            rbKadin.Checked = false;
        }
        void PersonelGuncelle()
        {
            try
            {
                SqlCommand Guncelle = new SqlCommand("update tbl_Personel set Ad=@p2,Soyad=@p3,TC=@p4,Tel=@p5,Mail=@p6,Cinsiyet=@p9,Yas=@p10,Aciklama=@p11 where Personelid=@p1", bag.Baglan());
                Guncelle.Parameters.AddWithValue("@p1", txtid.Text);
                Guncelle.Parameters.AddWithValue("@p2", txtAd.Text);
                Guncelle.Parameters.AddWithValue("@p3", txtSoyad.Text);
                Guncelle.Parameters.AddWithValue("@p4", mskTC.Text);
                Guncelle.Parameters.AddWithValue("@p5", mskTel.Text);
                Guncelle.Parameters.AddWithValue("@p6", txtMail.Text);
               
                if (rbErkek.Checked == true)
                    Guncelle.Parameters.AddWithValue("@p9", "Erkek");
                else
                    Guncelle.Parameters.AddWithValue("@p9", "Kadın");
                Guncelle.Parameters.AddWithValue("@p10", txtYas.Text);
                Guncelle.Parameters.AddWithValue("@p11", rtbAciklama.Text);
                Guncelle.ExecuteNonQuery();
                MessageBox.Show("Personel bilgisi güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PersonelListe();
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
        void PersonelSil()
        {
            try
            {
                DialogResult DR = MessageBox.Show(txtid.Text + "  nolu personel bilgisini silmek ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    SqlCommand Sil = new SqlCommand("delete from tbl_Personel where Personelid=@p1", bag.Baglan());
                    Sil.Parameters.AddWithValue("@p1", txtid.Text);
                    Sil.ExecuteNonQuery();
                    PersonelListe();
                    bag.Baglan().Close();
                }
                else
                    PersonelListe();
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            mskTC.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            mskTel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Erkek")
            {
                rbErkek.Checked = true;
            }
            else
                rbKadin.Checked = true;
            txtYas.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            rtbAciklama.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PersonelEkle();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PersonelGuncelle();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PersonelSil();
        }

        private void frm_Personeller_Load(object sender, EventArgs e)
        {
            PersonelListe();
            txtAd.Focus();
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

        private void txtBrans_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }

        private void txtYas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
