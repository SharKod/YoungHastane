using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoungHastaneProje
{
    public partial class frm_DoktorListe : Form
    {
        public frm_DoktorListe()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();

        void listele()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.CadetBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter Listele = new SqlDataAdapter("select Doktorid as [Doktor ID],Ad,Soyad,TC,Tel,Mail,Cinsiyet,Yas as [Yaş],Aciklama as [Açıklama] from tbl_Doktor", bag.Baglan());
            DataTable dt = new DataTable();
            Listele.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Baglan().Close();
        }

        private void frm_DoktorListe_Load(object sender, EventArgs e)
        {
            listele();
            txtAd.Focus();
        }

        private void txtAd_EditValueChanged(object sender, EventArgs e)
        {
            SqlDataAdapter Ara = new SqlDataAdapter("select Doktorid as [Doktor ID],Ad,Soyad,TC,Tel,Mail,Cinsiyet,Yas as [Yaş],Aciklama as [Açıklama] from tbl_Doktor where Ad like '" + txtAd.Text + "%' ", bag.Baglan());
            DataTable dt = new DataTable();
            Ara.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Baglan().Close();
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
              && !char.IsSeparator(e.KeyChar);
        }
    }
}
