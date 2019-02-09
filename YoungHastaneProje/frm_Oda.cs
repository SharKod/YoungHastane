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
    public partial class frm_Oda : Form
    {
        public frm_Oda()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();

        void OdaListele()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.CadetBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter Listele = new SqlDataAdapter("select OdaNo as [Oda No],OdaTur,Metrekare,Kapasite,Tv,Klima,Balkon,YatakS,Durumu from tbl_Oda",bag.Baglan());
            DataTable dt = new DataTable();
            Listele.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        void Temizle()
        {
            txtKapasite.Text = "";
            txtMetrekare.Text = "";
            txtOdaNo.Text = "";
            txtOdaTur.Text = "";
           txtYatakS.Text = "";
            cbBalkon.Text = "";
            cbDurum.Text = "";
            cbKlima.Text = "";
            cbTV.Text = "";
        }

        void OdaEkle()
        {
            try
            {
                SqlCommand Ekle = new SqlCommand("insert into tbl_oda (OdaNo,Kapasite,Durumu,TV,Klima,Balkon,YatakS,Metrekare,OdaTur) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",bag.Baglan());
                Ekle.Parameters.AddWithValue("@p1",txtOdaNo.Text);
                Ekle.Parameters.AddWithValue("@p2", txtKapasite.Text);
                Ekle.Parameters.AddWithValue("@p3", cbDurum.Text);
                Ekle.Parameters.AddWithValue("@p4", cbTV.Text);
                Ekle.Parameters.AddWithValue("@p5", cbKlima.Text);
                Ekle.Parameters.AddWithValue("@p6", cbBalkon.Text);
                Ekle.Parameters.AddWithValue("@p7", txtYatakS.Text);
                Ekle.Parameters.AddWithValue("@p8", txtMetrekare.Text);
                Ekle.Parameters.AddWithValue("@p9", txtOdaTur.Text);
                Ekle.ExecuteNonQuery();
                MessageBox.Show("Oda bilgisi eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bag.Baglan().Close();
                OdaListele();

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

        void OdaGuncelle()
        {
            try
            {
                 SqlCommand Guncelle = new SqlCommand("update tbl_Oda set Kapasite=@p2,Durumu=@p3,TV=@p4,Klima=@p5,Balkon=@p6,YatakS=@p7,Metrekare=@p8,OdaTur=@p9 where OdaNo=@p1", bag.Baglan());
            Guncelle.Parameters.AddWithValue("@p1", txtOdaNo.Text);
            Guncelle.Parameters.AddWithValue("@p2", txtKapasite.Text);
            Guncelle.Parameters.AddWithValue("@p3", cbDurum.Text);
            Guncelle.Parameters.AddWithValue("@p4", cbTV.Text);
            Guncelle.Parameters.AddWithValue("@p5", cbKlima.Text);
            Guncelle.Parameters.AddWithValue("@p6", cbBalkon.Text);
            Guncelle.Parameters.AddWithValue("@p7", txtYatakS.Text);
            Guncelle.Parameters.AddWithValue("@p8", txtMetrekare.Text);
            Guncelle.Parameters.AddWithValue("@p9", txtOdaTur.Text);
            Guncelle.ExecuteNonQuery();
            MessageBox.Show("Oda bilgisi günellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bag.Baglan().Close();
            OdaListele();
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

        void OdaSil()
        {
            try
            {
                DialogResult DR = MessageBox.Show(txtOdaNo.Text + "  nolu oda bilgisini silmek ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    SqlCommand Sil = new SqlCommand("delete from tbl_Oda where OdaNo=@p1", bag.Baglan());
                    Sil.Parameters.AddWithValue("@p1", txtOdaNo.Text);
                    MessageBox.Show("Oda bilgisi silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sil.ExecuteNonQuery();
                    bag.Baglan().Close();
                    OdaListele();
                }
                else
                    OdaListele();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OdaEkle();
        }

        private void frm_Oda_Load(object sender, EventArgs e)
        {
            OdaListele();
            txtOdaNo.Focus();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OdaGuncelle();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OdaSil();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOdaNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtOdaTur.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMetrekare.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtKapasite.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbTV.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbKlima.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbBalkon.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtYatakS.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cbDurum.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void txtOdaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMetrekare_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtKapasite_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtYatakS_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtOdaTur_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }
    }
}
