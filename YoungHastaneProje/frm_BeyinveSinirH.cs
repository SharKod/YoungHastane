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
    public partial class frm_BeyinveSinirH : Form
    {
        public frm_BeyinveSinirH()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();

        void HastalariListele()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.CadetBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter Listele = new SqlDataAdapter("select Hareketid as [Hasta ID], Ad,Soyad,TC as [T.C],Tel as [Telefon],Sorunu,Depertman,Notlar,Tani as [Tanı],Durum from tbl_Hareketler where Depertman='Beyin ve Sinir Cerrahisi'", bag.Baglan());
            DataTable dt = new DataTable();
            Listele.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Baglan().Close();
        }

        void TaniKaydet()
        {
            try
            {
                if (cbTanik.Checked == false)
                {
                    SqlCommand Guncelle = new SqlCommand("update tbl_Hareketler set Depertman=@p2 Tani=@p3,Durum=@p4 where Hareketid=@p1", bag.Baglan());
                    Guncelle.Parameters.AddWithValue("@p1", txtid.Text);
                    Guncelle.Parameters.AddWithValue("@p2", cbYonlendir.Text);
                    Guncelle.Parameters.AddWithValue("@p3", rtbTanik.Text);
                    Guncelle.Parameters.AddWithValue("@p4", "Tanık Koyulamadı");
                    Guncelle.ExecuteNonQuery();
                    MessageBox.Show("Hasta aktarma işlemi tamamlandı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HastalariListele();
                    bag.Baglan().Close();
                }

                else
                {
                    DialogResult DR = MessageBox.Show(txtid.Text + "  nolu hasta tanık koyulduktan sonra sistemden silinecektir bunu yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (DR == DialogResult.Yes)
                    {
                        SqlCommand Sil = new SqlCommand("delete from tbl_Hareketler where Hareketid=@p1", bag.Baglan());
                        Sil.Parameters.AddWithValue("@p1", txtid.Text);
                        Sil.ExecuteNonQuery();
                        HastalariListele();
                        bag.Baglan().Close();
                    }
                    else
                        HastalariListele();
                }
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
            txtSorun.Text = "";
            txtSoyad.Text = "";
            cbTanik.Checked = false;
            cbYonlendir.Text = "";
            rtbNot.Text = "";
            rtbTanik.Text = "";
            mskTC.Text = "";
            mskTel.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TaniKaydet();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            mskTC.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            mskTel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSorun.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbYonlendir.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            rtbNot.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            rtbTanik.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[9].Value.ToString() == "Tanık Koyulamadı")
            {
                cbTanik.Checked = false;
            }
            else
                cbTanik.Checked = true;
        }

        private void frm_BeyinveSinirH_Load(object sender, EventArgs e)
        {
            HastalariListele();
            txtAd.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void txtSorun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
           && !char.IsSeparator(e.KeyChar);
        }

       
    }
}
