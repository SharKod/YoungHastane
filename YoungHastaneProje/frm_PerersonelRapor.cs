using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoungHastaneProje
{
    public partial class frm_PerersonelRapor : Form
    {
        public frm_PerersonelRapor()
        {
            InitializeComponent();
        }

        private void frm_PerersonelRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbo_YoungHastaneDataSet3.tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.dbo_YoungHastaneDataSet3.tbl_Personel);

            this.reportViewer1.RefreshReport();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
