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
    public partial class frm_Gider : Form
    {
        public frm_Gider()
        {
            InitializeComponent();
            txtPersonelM.TextChanged += new EventHandler(txtFiyat_TextChanged);
            txtFatura.TextChanged += new EventHandler(txtFiyat_TextChanged);
            txtMalzeme.TextChanged += new EventHandler(txtFiyat_TextChanged);
            txtYiyecek.TextChanged += new EventHandler(txtFiyat_TextChanged);
            txtDoktorM.TextChanged += new EventHandler(txtFiyat_TextChanged);
        }

        SqlBaglanti bag = new SqlBaglanti();

        void GiderListele()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.CadetBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter Listele = new SqlDataAdapter("select GiderNo,Ay,Yil as [Yil],DoktorMaas as [Doktor M.],PersonelMaas as [Personel M.],Yiyecek,Malzeme,Fatura,Toplam from tbl_Gider", bag.Baglan());
            DataTable dt = new DataTable();
            Listele.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Baglan().Close();

        }
        void GiderEkle()
        {
            try
            {
                SqlCommand Ekle = new SqlCommand("insert into tbl_Gider (Ay,Yil,DoktorMaas,PersonelMaas,Yiyecek,Malzeme,Fatura,Toplam) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bag.Baglan());
                Ekle.Parameters.AddWithValue("@p1", cbAy.Text);
                Ekle.Parameters.AddWithValue("@p2", txtYil.Text);
                Ekle.Parameters.AddWithValue("@p3", txtDoktorM.Text);
                Ekle.Parameters.AddWithValue("@p4", txtPersonelM.Text);
                Ekle.Parameters.AddWithValue("@p5", txtYiyecek.Text);
                Ekle.Parameters.AddWithValue("@p6", txtMalzeme.Text);
                Ekle.Parameters.AddWithValue("@p7", txtFatura.Text);
                Ekle.Parameters.AddWithValue("@p8", clsFonksiyon.FormatDuzenle(txtToplam.Text));
                Ekle.ExecuteNonQuery();
                MessageBox.Show("Gider bilgisi sisteme eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bag.Baglan().Close();
                GiderListele();
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
            txtToplam.Text = "";
            txtYil.Text = "";
            txtYiyecek.Text = "";
            txtPersonelM.Text = "";
            txtMalzeme.Text = "";
            txtFatura.Text = "";
            txtDoktorM.Text = "";
            cbAy.Text = "";
        }

        void GiderGuncelle()
        {
            try
            {
                SqlCommand Guncelle = new SqlCommand("update tbl_Gider set Ay=@p2,Yil=@p3,DoktorMaas=@p4,PersonelMaas=@p5,Yiyecek=@p6,Malzeme=@p7,Fatura=@p8,Toplam=@p9 where GiderNo=@p1", bag.Baglan());
                Guncelle.Parameters.AddWithValue("@p1", txtGiderNo.Text);
                Guncelle.Parameters.AddWithValue("@p2", cbAy.Text);
                Guncelle.Parameters.AddWithValue("@p3", txtYil.Text);
                Guncelle.Parameters.AddWithValue("@p4", txtDoktorM.Text);
                Guncelle.Parameters.AddWithValue("@p5", txtPersonelM.Text);
                Guncelle.Parameters.AddWithValue("@p6", txtYiyecek.Text);
                Guncelle.Parameters.AddWithValue("@p7", txtMalzeme.Text);
                Guncelle.Parameters.AddWithValue("@p8", txtFatura.Text);
                Guncelle.Parameters.AddWithValue("@p9", clsFonksiyon.FormatDuzenle(txtToplam.Text));
                Guncelle.ExecuteNonQuery();
                MessageBox.Show("Gider bilgisi Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bag.Baglan().Close();
                GiderListele();
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

        void GiderSil()
        {
            try
            {
                DialogResult DR = MessageBox.Show(txtGiderNo.Text + "  nolu gider bilgisini silmek ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    SqlCommand Sil = new SqlCommand("delete from tbl_Gider where GiderNo=@p1", bag.Baglan());
                    Sil.Parameters.AddWithValue("@p1", txtGiderNo.Text);
                    MessageBox.Show("Oda bilgisi silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sil.ExecuteNonQuery();
                    bag.Baglan().Close();
                    GiderListele();
                }
                else
                    GiderListele();
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

        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {
            double outdouble = 0;
            double Topla;
            double FiyatDoktorM = double.TryParse(txtDoktorM.Text, out outdouble) ? double.Parse(txtDoktorM.Text) : 0;
            double FiyatPersonelM = double.TryParse(txtPersonelM.Text, out outdouble) ? double.Parse(txtPersonelM.Text) : 0;
            double FiyatYiyecek = double.TryParse(txtYiyecek.Text, out outdouble) ? double.Parse(txtYiyecek.Text) : 0;
            double FiyatMalzeme= double.TryParse(txtMalzeme.Text, out outdouble) ? double.Parse(txtMalzeme.Text) : 0;
            double FiyatFatura = double.TryParse(txtFatura.Text, out outdouble) ? double.Parse(txtFatura.Text) : 0;

            Topla = FiyatDoktorM + FiyatPersonelM + FiyatMalzeme + FiyatYiyecek + FiyatFatura;
            txtToplam.Text = Topla.ToString("#,##0.#0");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGiderNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbAy.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtYil.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDoktorM.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPersonelM.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtYiyecek.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtMalzeme.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtFatura.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtToplam.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void txtYil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDoktorM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPersonelM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtYiyecek_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMalzeme_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frm_Gider_Load(object sender, EventArgs e)
        {
            GiderListele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GiderEkle();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GiderGuncelle();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            GiderSil();
        }
    }
}
