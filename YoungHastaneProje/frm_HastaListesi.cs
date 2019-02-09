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
    public partial class frm_HastaListesi : Form
    {
        public frm_HastaListesi()
        {
            InitializeComponent();
        }

        SqlBaglanti bag = new SqlBaglanti();

        void Listele()
        {
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

        private void frm_HastaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void txtAd_EditValueChanged(object sender, EventArgs e)
        {
            SqlDataAdapter Ara = new SqlDataAdapter("select Yatanid as [Hasta ID],Ad,Soyad,TC as [T.C],Tel as [Telefon],Tel2 as [2. Telefon],Cinsiyet,Oda,GT as [Giriş T.],CT as [Çıkış T.],Ucret as [Ücret],Aciklama as [Açıklama] from tbl_YatanHasta where Ad like '" + txtAd.Text + "%' ", bag.Baglan());
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
