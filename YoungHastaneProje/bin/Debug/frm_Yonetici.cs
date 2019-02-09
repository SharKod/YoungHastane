using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoungHastaneProje
{
    public partial class frm_Yonetici : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frm_Yonetici()
        {
            InitializeComponent();
        }
   
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form formlar in this.MdiChildren)
            {
                formlar.Close();
            }
        }

        frm_YatanHasta YatanHasta;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (YatanHasta==null)
            {
                YatanHasta = new frm_YatanHasta();
                YatanHasta.MdiParent = this;
                YatanHasta.Show();
            }
        }

        frm_HastaListesi HastaListe;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HastaListe == null)
            {
                HastaListe = new frm_HastaListesi();
                HastaListe.MdiParent = this;
                HastaListe.Show();
            }
        }

        frm_Doktorlar Doktor;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Doktor == null)
            {
                Doktor = new frm_Doktorlar();
                Doktor.MdiParent = this;
                Doktor.Show();
            }
        }

        frm_DoktorListe DoktorListe;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DoktorListe==null)
            {
                DoktorListe = new frm_DoktorListe();
                DoktorListe.MdiParent = this;
                DoktorListe.Show();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Bu proje Efe Denizer Köprülü tarafından eğitim amaçlı yapımıştır herhangi bir maddi gelir umudu yoktur. Kodlar 25.11.2018 tarihinde sıfırdan yazılmaya başlamıştır örnek alınabilir fakat çalınası yasaktır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        frm_Personeller personel;
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (personel==null)
            {
                personel = new frm_Personeller();
                personel.MdiParent = this;
                personel.Show();
            }
        }

        frm_personelListe PersonelListe;
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PersonelListe==null)
            {
                PersonelListe = new frm_personelListe();
                PersonelListe.MdiParent = this;
                PersonelListe.Show();
            }
        }

        frm_Oda Oda;
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Oda==null)
            {
                Oda = new frm_Oda();
                Oda.MdiParent = this;
                Oda.Show();
            }
        }
        frm_OdaListe OdaListe;
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (OdaListe==null)
            {
                OdaListe = new frm_OdaListe();
                OdaListe.MdiParent = this;
                OdaListe.Show();
            }
        }

        Gelir Gelir;
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Gelir== null)
            {
                Gelir = new Gelir();
                Gelir.MdiParent = this;
                Gelir.Show();
            }
        }

        frm_Gider Gider;
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Gider==null)
            {
                Gider = new frm_Gider();
                Gider.MdiParent = this;
                Gider.Show();
            }
        }

        frm_DoktorRapor DoktorRapor;
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DoktorRapor==null)
            {
                DoktorRapor = new frm_DoktorRapor();
                DoktorRapor.Show();
            }
        }

        frm_HastaRapor HastaRapor;
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HastaRapor==null)
            {
                HastaRapor = new frm_HastaRapor();
                HastaRapor.Show();
            }
        }

        frm_PerersonelRapor PersonelRapor;
        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PersonelRapor==null)
            {
                PersonelRapor = new frm_PerersonelRapor();
                PersonelRapor.Show();
            }
        }

        frm_OdaRapor OdaRapor;
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (OdaRapor==null)
            {
                OdaRapor = new frm_OdaRapor();
                OdaRapor.Show();
            }
        }

        frm_Genelistatislik Gistatislik;
        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Gistatislik==null)
            {
                Gistatislik = new frm_Genelistatislik();
                Gistatislik.Show();
            }
        }

        frm_GelirGiderGrafigi GelirGider;

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GelirGider==null)
            {
                GelirGider = new frm_GelirGiderGrafigi();
                GelirGider.MdiParent = this;
                GelirGider.Show();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("http://www.facebook.com/");

        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("http://www.twitter.com/");
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("http://www.instagram.com/");
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://plus.google.com/");
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Process.Start("https://github.com/");
        }

        frm_Mail mail;
        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (mail==null)
            {
                mail = new frm_Mail();
                mail.Show();
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("calc.exe");
        }

        frm_Yoneticiislem Yonetici;
        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Yonetici==null)
            {
                Yonetici = new frm_Yoneticiislem();
                Yonetici.MdiParent = this;
                Yonetici.Show();
            }
        }
    }
}
