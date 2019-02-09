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
    public partial class frm_GelirGiderGrafigi : Form
    {
        public frm_GelirGiderGrafigi()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();

        int sure = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            sure++;
            if (sure == 1)
            {
                groupControl1.Text = "Amaliyat";
                SqlCommand Grafik1 = new SqlCommand("select Ay,Amaliyat from tbl_Gelir", bag.Baglan());
                SqlDataReader Oku = Grafik1.ExecuteReader();
                while (Oku.Read())
                {
                    this.chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku[0]), int.Parse(Oku[1].ToString()));
                }

                groupControl2.Text = "Doktor Maaş";
                SqlCommand Grafik2 = new SqlCommand("select Ay,DoktorMaas from tbl_Gider", bag.Baglan());
                SqlDataReader Oku2 = Grafik2.ExecuteReader();
                while (Oku2.Read())
                {
                    this.chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku2[0]), int.Parse(Oku2[1].ToString()));
                }

            }

           else if (sure == 5)
            {
                groupControl1.Text = "Yatan Hasta";
                SqlCommand Grafik = new SqlCommand("select Ay,YatanHasta from tbl_Gelir", bag.Baglan());
                SqlDataReader Oku = Grafik.ExecuteReader();
                while (Oku.Read())
                {
                    this.chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku[0]), int.Parse(Oku[1].ToString()));
                }

                groupControl2.Text = "Personel Maaş";
                SqlCommand Grafik2 = new SqlCommand("select Ay,PersonelMaas from tbl_Gider", bag.Baglan());
                SqlDataReader Oku2 = Grafik2.ExecuteReader();
                while (Oku2.Read())
                {
                    this.chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku2[0]), int.Parse(Oku2[1].ToString()));
                }

            }

          else  if (sure == 9)
            {
                groupControl1.Text = "Extra Hizmet";
                SqlCommand Grafik = new SqlCommand("select Ay,ExtraHizmet from tbl_Gelir", bag.Baglan());
                SqlDataReader Oku = Grafik.ExecuteReader();
                while (Oku.Read())
                {
                    this.chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku[0]), int.Parse(Oku[1].ToString()));
                }

                groupControl2.Text = "Yiyecek";
                SqlCommand Grafik2 = new SqlCommand("select Ay,Yiyecek from tbl_Gider", bag.Baglan());
                SqlDataReader Oku2 = Grafik2.ExecuteReader();
                while (Oku2.Read())
                {
                    this.chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku2[0]), int.Parse(Oku2[1].ToString()));
                }

            }

          else  if (sure == 13)
            {
                groupControl1.Text = "Labrotuar";
                SqlCommand Grafik = new SqlCommand("select Ay,Labrotuar from tbl_Gelir", bag.Baglan());
                SqlDataReader Oku = Grafik.ExecuteReader();
                while (Oku.Read())
                {
                    this.chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku[0]), int.Parse(Oku[1].ToString()));
                }

                groupControl2.Text = "Malzeme";
                SqlCommand Grafik2 = new SqlCommand("select Ay,Malzeme from tbl_Gider", bag.Baglan());
                SqlDataReader Oku2 = Grafik2.ExecuteReader();
                while (Oku2.Read())
                {
                    this.chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku2[0]), int.Parse(Oku2[1].ToString()));
                }

            }

           else if (sure == 17)
            {
                groupControl1.Text = "Muane";
                SqlCommand Grafik = new SqlCommand("select Ay,Muane from tbl_Gelir", bag.Baglan());
                SqlDataReader Oku = Grafik.ExecuteReader();
                while (Oku.Read())
                {
                    this.chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku[0]), int.Parse(Oku[1].ToString()));
                }

                groupControl2.Text = "Fatura";
                SqlCommand Grafik2 = new SqlCommand("select Ay,Fatura from tbl_Gider", bag.Baglan());
                SqlDataReader Oku2 = Grafik2.ExecuteReader();
                while (Oku2.Read())
                {
                    this.chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(Oku2[0]), int.Parse(Oku2[1].ToString()));
                }

            }
        }
        private void frm_GELIRGRAFIK_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
