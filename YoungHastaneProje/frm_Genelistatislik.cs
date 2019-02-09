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
    public partial class frm_Genelistatislik : Form
    {
        public frm_Genelistatislik()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();
        int Gelir, Gider, NetKar;

        void istatislikGetir()
        {
            
            SqlCommand hastaS = new SqlCommand("Select count(yatanid) from tbl_yatanhasta", bag.Baglan());
            SqlDataReader HastaOku = hastaS.ExecuteReader();
            while (HastaOku.Read())
            {
                lblHastaS.Text = HastaOku[0].ToString();
            }
            bag.Baglan().Close();
            HastaOku.Close();

            SqlCommand DoktorS = new SqlCommand("Select count(Doktorid) from tbl_Doktor", bag.Baglan());
            SqlDataReader DoktorOku = DoktorS.ExecuteReader();
            while (DoktorOku.Read())
            {
                
                lblDoktorS.Text = DoktorOku[0].ToString();
            }
            bag.Baglan().Close();
            DoktorOku.Close();

            SqlCommand PersonelS = new SqlCommand("Select count(Personelid) from tbl_Personel", bag.Baglan());
            SqlDataReader PersonelOku = PersonelS.ExecuteReader();
            while (PersonelOku.Read())
            {
                
                lblPersonelS.Text = PersonelOku[0].ToString();
            }
            bag.Baglan().Close();
            PersonelOku.Close();

            SqlCommand OdaS = new SqlCommand("Select count(OdaNo) from tbl_Oda", bag.Baglan());
            SqlDataReader OdaOku = OdaS.ExecuteReader();
            while (OdaOku.Read())
            {

                lblOdaS.Text = OdaOku[0].ToString();
            }
            bag.Baglan().Close();
            OdaOku.Close();

            SqlCommand GelirS = new SqlCommand("Select sum(Toplam) from tbl_Gelir", bag.Baglan());
            SqlDataReader GelirOku = GelirS.ExecuteReader();
            while (GelirOku.Read())
            {

                lblToplamParaS.Text = GelirOku[0].ToString();
                Gelir =int.Parse(GelirOku[0].ToString());
            }
            bag.Baglan().Close();
            GelirOku.Close();

            SqlCommand GiderS = new SqlCommand("Select sum(Toplam) from tbl_Gider", bag.Baglan());
            SqlDataReader GiderOku = GiderS.ExecuteReader();
            while (GiderOku.Read())
            {
                Gider = int.Parse(GiderOku[0].ToString());
            }
            bag.Baglan().Close();
            GiderOku.Close();

            NetKar=Gelir - Gider;
            lblNetKar.Text = NetKar.ToString();

            SqlCommand KullaniciS = new SqlCommand("Select count(Kullaniciid) from tbl_KullaniciGiris", bag.Baglan());
            SqlDataReader KullaniciOku = KullaniciS.ExecuteReader();
            while (KullaniciOku.Read())
            {
                 lblKayitS.Text= KullaniciOku[0].ToString();
            }
            bag.Baglan().Close();
            GiderOku.Close();

            SqlCommand OdaVerileri = new SqlCommand("Select count(TV),count(Klima),count(Balkon),count(YatakS) from tbl_Oda", bag.Baglan());
            SqlDataReader OdaVeriOku = OdaVerileri.ExecuteReader();
            while (OdaVeriOku.Read())
            {
                lblTvS.Text = OdaVeriOku[0].ToString();
                lblKlimaS.Text = OdaVeriOku[1].ToString();
                lblBalkonS.Text = OdaVeriOku[2].ToString();
                lblYatakS.Text = OdaVeriOku[3].ToString();
            }
            bag.Baglan().Close();
            OdaVeriOku.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_Genelistatislik_Load(object sender, EventArgs e)
        {
            istatislikGetir();
        }
    }
}
