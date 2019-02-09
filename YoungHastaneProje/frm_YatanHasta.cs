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
    public partial class frm_YatanHasta : Form
    {
        public frm_YatanHasta()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();

        void HastaEkle()
        {
            try
            {
              
                SqlCommand HastaEkle = new SqlCommand("insert into Tbl_YatanHasta (Ad,Soyad,TC,Tel,Tel2,Cinsiyet,Oda,GT,CT,Ucret,Aciklama) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bag.Baglan());
                HastaEkle.Parameters.AddWithValue("@p1", txtAd.Text);
                HastaEkle.Parameters.AddWithValue("@p2", txtSoyad.Text);
                HastaEkle.Parameters.AddWithValue("@p3", mskTC.Text);
                HastaEkle.Parameters.AddWithValue("@p4", mskTel.Text);
                HastaEkle.Parameters.AddWithValue("@p5", mskTel2.Text);
                if (rbErkek.Checked == true)
                    HastaEkle.Parameters.AddWithValue("@p6", "Erkek");
                else
                    HastaEkle.Parameters.AddWithValue("@p6", "Kadın");
                HastaEkle.Parameters.AddWithValue("@p7", cbOda.Text);
                HastaEkle.Parameters.AddWithValue("@p8",Convert.ToDateTime(dtGT.Text));
                HastaEkle.Parameters.AddWithValue("@p9",Convert.ToDateTime(dtCT.Text));
                HastaEkle.Parameters.AddWithValue("@p10", txtUcret.Text);
                HastaEkle.Parameters.AddWithValue("@p11", rtbAciklama.Text);
                HastaEkle.ExecuteNonQuery();
                MessageBox.Show("Hasta bilgisi eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bag.Baglan().Close();
                HastaListele();
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
            txtUcret.Text = "";
            cbOda.Text = "";
            rtbAciklama.Text = "";
            dtCT.Text = "";
            dtGT.Text = "";
            rbErkek.Checked = false;
            rbKadin.Checked = false;
            mskTC.Text = "";
            mskTel.Text = "";
            mskTel2.Text = "";
        }
        void HastaListele()
        {
            // Yatan hastaları listeleme
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.CadetBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter Listele = new SqlDataAdapter("select Yatanid as [Hasta ID],Ad,Soyad,TC as [T.C],Tel as [Telefon],Tel2 as [2. Telefon],Cinsiyet,Oda,GT as [Giriş T.],CT as [Çıkış T.],Ucret as [Ücret],Aciklama as [Açıklama] from tbl_YatanHasta", bag.Baglan());
            DataTable dt = new DataTable();
            Listele.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Baglan().Close();
        }
        void HastaGüncelle()
        {
            try
            {
                SqlCommand HastaGüncelle = new SqlCommand("Update Tbl_YatanHasta set Ad=@p2,Soyad=@p3,TC=@p4,Tel=@p5,Tel2=@p6,Cinsiyet=@p7,Oda=@p8,GT=@p9, CT=@p10,Ucret=@p11,Aciklama=@p12 where Yatanid=@p1", bag.Baglan());
                HastaGüncelle.Parameters.AddWithValue("@p1", txtid.Text);
                HastaGüncelle.Parameters.AddWithValue("@p2", txtAd.Text);
                HastaGüncelle.Parameters.AddWithValue("@p3", txtSoyad.Text);
                HastaGüncelle.Parameters.AddWithValue("@p4", mskTC.Text);
                HastaGüncelle.Parameters.AddWithValue("@p5", mskTel.Text);
                HastaGüncelle.Parameters.AddWithValue("@p6", mskTel2.Text);
                if (rbErkek.Checked)
                    HastaGüncelle.Parameters.AddWithValue("@p7", "Erkek");
                else
                    HastaGüncelle.Parameters.AddWithValue("@p7", "Kadın");
                HastaGüncelle.Parameters.AddWithValue("@p8", cbOda.Text);
                HastaGüncelle.Parameters.AddWithValue("@p9", dtGT.Text);
                HastaGüncelle.Parameters.AddWithValue("@p10", dtCT.Text);
                HastaGüncelle.Parameters.AddWithValue("@p11", txtUcret.Text);
                HastaGüncelle.Parameters.AddWithValue("@p12", rtbAciklama.Text);
                HastaGüncelle.ExecuteNonQuery();
                MessageBox.Show("Hasta bilgisi Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bag.Baglan().Close();
                HastaListele();
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
        void HastaSil()
        {
            try
            {
                DialogResult DR = MessageBox.Show(txtid.Text+"  nolu hasta bilgisini silmek ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    SqlCommand HastaSil = new SqlCommand("delete from tbl_YatanHasta where Yatanid=@p1", bag.Baglan());
                    HastaSil.Parameters.AddWithValue("@p1", txtid.Text);
                    HastaSil.ExecuteNonQuery();
                    MessageBox.Show("Hasta bilgisi silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bag.Baglan().Close();
                    HastaListele();
                }
                else
                    HastaListele();
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
        void OdaGetir()
        {
            SqlCommand Getir = new SqlCommand("select OdaNo from tbl_Oda where Kapasite!= KisiSayi", bag.Baglan());
            SqlDataReader oku = Getir.ExecuteReader();
            while (oku.Read())
            {
                cbOda.Properties.Items.Add(oku[0].ToString());
            }
            bag.Baglan().Close();
        }
        void HastaYerlestir()
        {
            SqlCommand Yerlestir = new SqlCommand("update tbl_oda set KisiSayi=KisiSayi+1 where OdaNo=@p1", bag.Baglan());
            Yerlestir.Parameters.AddWithValue("@p1", cbOda.Text);
            Yerlestir.ExecuteNonQuery();
            bag.Baglan().Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HastaEkle();
            HastaYerlestir();
        }

        private void frm_YatanHasta_Load(object sender, EventArgs e)
        {
            HastaListele();
            OdaGetir();
            txtAd.Focus();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            HastaGüncelle();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            HastaSil();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            mskTC.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            mskTel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            mskTel2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Erkek")
            {
                rbErkek.Checked = true;
            }
            else
                rbKadin.Checked = false;
            cbOda.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dtGT.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            dtCT.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtUcret.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            rtbAciklama.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
        }

        private void dtCT_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan GunFarki = dtCT.Value.Subtract(dtGT.Value);
            txtUcret.Text = (GunFarki.Days * 100).ToString();
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

