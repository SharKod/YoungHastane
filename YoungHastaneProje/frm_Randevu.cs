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
    public partial class frm_Randevu : Form
    {
        public frm_Randevu()
        {
            InitializeComponent();
        }
    
        SqlBaglanti bag = new SqlBaglanti();

        void Temizle()
        {
            txtAd.Text = "";
            txtSorun.Text = "";
            txtSoyad.Text = "";
            cbDepartman.Text = "";
            rtbNot.Text = "";
            mskTel.Text = "";
            mskTC.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                 SqlCommand RandevuAl = new SqlCommand("insert into tbl_Hareketler (Ad,Soyad,TC,Tel,Soru<nu,Depertman,Notlar) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bag.Baglan());
            RandevuAl.Parameters.AddWithValue("@p1", txtAd.Text);
            RandevuAl.Parameters.AddWithValue("@p2", txtSoyad.Text);
            RandevuAl.Parameters.AddWithValue("@p3", mskTC.Text);
            RandevuAl.Parameters.AddWithValue("@p4", mskTel.Text);
            RandevuAl.Parameters.AddWithValue("@p5", txtSorun.Text);
            RandevuAl.Parameters.AddWithValue("@p6", cbDepartman.Text);
            RandevuAl.Parameters.AddWithValue("@p7", rtbNot.Text);
            RandevuAl.ExecuteNonQuery();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frm_GirisYap GY = new frm_GirisYap();
            GY.Show();
            this.Hide();
        }

        private void frm_Randevu_Load(object sender, EventArgs e)
        {
            txtAd.Focus();
        }
    }
}
