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
    public partial class frm_OdaListe : Form
    {
        public frm_OdaListe()
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
            SqlDataAdapter Listele = new SqlDataAdapter("select OdaNo as [Oda No],OdaTur,Metrekare,Kapasite,Tv,Klima,Balkon,YatakS,Durumu from tbl_Oda", bag.Baglan());
            DataTable dt = new DataTable();
            Listele.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void txtAd_EditValueChanged(object sender, EventArgs e)
        {
            SqlDataAdapter Ara = new SqlDataAdapter("select OdaNo as [Oda No],OdaTur,Metrekare,Kapasite,Tv,Klima,Balkon,YatakS,Durumu where OdaNo like '" + txtOdaNo.Text + "%' ", bag.Baglan());
            DataTable dt = new DataTable();
            Ara.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Baglan().Close();
        }

        private void frm_OdaListe_Load(object sender, EventArgs e)
        {
            OdaListele();
        }

        private void txtOdaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
