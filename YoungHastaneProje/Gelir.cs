using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoungHastaneProje
{
    public partial class Gelir : Form
    {
        public Gelir()
        {
            InitializeComponent();
            txtYatan.TextChanged += new EventHandler(txtFiyat_TextChanged);
            txtSponsor.TextChanged += new EventHandler(txtFiyat_TextChanged);
            txtMuane.TextChanged += new EventHandler(txtFiyat_TextChanged);
            txtLabratuar.TextChanged += new EventHandler(txtFiyat_TextChanged);
            txtEkHizmet.TextChanged += new EventHandler(txtFiyat_TextChanged);
            txtAmaliyat.TextChanged += new EventHandler(txtFiyat_TextChanged);
        }

        SqlBaglanti bag = new SqlBaglanti();

        void Temizle()
        {
            txtAmaliyat.Text = "";
            txtYil.Text = "";
            txtEkHizmet.Text = "";
            txtLabratuar.Text = "";
            txtMuane.Text = "";
            txtSponsor.Text = "";
            txtToplam.Text = "";
            txtYatan.Text = "";
            cbAy.Text = "";
        }

        void GelirListele()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.CadetBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter Listele = new SqlDataAdapter("select GelirNo as [Gelir No],Ay,Yil as [Yıl],Amaliyat,YatanHasta as [Yatan Hasta],ExtraHizmet as [Ek Hizmet],Labrotuar,Muane,Toplam from tbl_Gelir", bag.Baglan());
            DataTable dt = new DataTable();
            Listele.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Baglan().Close();
        }

        void GelirEkle()
        {
            try
            {
                SqlCommand Ekle = new SqlCommand("insert into tbl_Gelir (Ay,Yil,Amaliyat,YatanHasta,ExtraHizmet,Labrotuar,Muane,Toplam) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p9)", bag.Baglan());
                Ekle.Parameters.AddWithValue("@p1", cbAy.Text);
                Ekle.Parameters.AddWithValue("@p2", txtYil.Text);
                Ekle.Parameters.AddWithValue("@p3", txtAmaliyat.Text);
                Ekle.Parameters.AddWithValue("@p4", txtYatan.Text);
                Ekle.Parameters.AddWithValue("@p5", txtEkHizmet.Text);
                Ekle.Parameters.AddWithValue("@p6", txtLabratuar.Text);
                Ekle.Parameters.AddWithValue("@p7", txtMuane.Text);
               
                Ekle.Parameters.AddWithValue("@p9", clsFonksiyon.FormatDuzenle(txtToplam.Text));
                Ekle.ExecuteNonQuery();
                MessageBox.Show("Gelir bilgileri sisteme eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bag.Baglan().Close();
                GelirListele();
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

        void GelirGuncelle()
        {
            try
            {
                SqlCommand Guncelle = new SqlCommand("update tbl_Gelir set Ay=@p2,Yil=@p3,Amaliyat=@p4,YatanHasta=@p5,ExtraHizmet=@p6,Labotuar=@p7,Muane=@p8,Toplam=@p10 where GelirNo=@p1", bag.Baglan());
                Guncelle.Parameters.AddWithValue("@p1", txtGelirNo.Text);
                Guncelle.Parameters.AddWithValue("@p2", cbAy.Text);
                Guncelle.Parameters.AddWithValue("@p3", txtYil.Text);
                Guncelle.Parameters.AddWithValue("@p4", txtAmaliyat.Text);
                Guncelle.Parameters.AddWithValue("@p5", txtYatan.Text);
                Guncelle.Parameters.AddWithValue("@p6", txtEkHizmet.Text);
                Guncelle.Parameters.AddWithValue("@p7", txtLabratuar.Text);
                Guncelle.Parameters.AddWithValue("@p8", txtMuane.Text);
                Guncelle.Parameters.AddWithValue("@p10", clsFonksiyon.FormatDuzenle(txtToplam.Text));
                Guncelle.ExecuteNonQuery();
                MessageBox.Show("Gelir bilgileri güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bag.Baglan().Close();
                GelirListele();
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

        void GelirSil()
        {
            try
            {
                DialogResult DR = MessageBox.Show(txtGelirNo.Text + "  nolu gelir bilgisini silmek ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    SqlCommand Sil = new SqlCommand("delete from tbl_Gelir where GrlirNo=@p1", bag.Baglan());
                    Sil.Parameters.AddWithValue("@p1", txtGelirNo.Text);
                    MessageBox.Show("Oda bilgisi silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sil.ExecuteNonQuery();
                    bag.Baglan().Close();
                    GelirListele();
                }
                else
                    GelirListele();
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
            GelirEkle();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GelirGuncelle();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            GelirSil();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGelirNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbAy.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtYil.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtAmaliyat.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtYatan.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtEkHizmet.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtLabratuar.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtMuane.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtToplam.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void Gelir_Load(object sender, EventArgs e)
        {
            GelirListele();
        }

        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {
            double outdouble = 0;
            double Topla;
            double FiyatAmaliyat = double.TryParse(txtAmaliyat.Text, out outdouble) ? double.Parse(txtAmaliyat.Text) : 0;
            double FiyatYatan = double.TryParse(txtYatan.Text, out outdouble) ? double.Parse(txtYatan.Text) : 0;
            double FiyatExtra = double.TryParse(txtEkHizmet.Text, out outdouble) ? double.Parse(txtEkHizmet.Text) : 0;
            double FiyatLabrotuar = double.TryParse(txtLabratuar.Text, out outdouble) ? double.Parse(txtLabratuar.Text) : 0;
            double FiyatMuane = double.TryParse(txtMuane.Text, out outdouble) ? double.Parse(txtMuane.Text) : 0;
            double FiyatSponsor = double.TryParse(txtSponsor.Text, out outdouble) ? double.Parse(txtSponsor.Text) : 0;

            Topla = FiyatAmaliyat + FiyatExtra + FiyatLabrotuar + FiyatMuane + FiyatSponsor + FiyatYatan;
            txtToplam.Text = Topla.ToString("#,##0.#0");
        }

        private void txtAmaliyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtYatan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtYil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEkHizmet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtLabratuar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMuane_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSponsor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
