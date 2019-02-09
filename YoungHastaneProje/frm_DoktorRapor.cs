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
    public partial class frm_DoktorRapor : Form
    {
        public frm_DoktorRapor()
        {
            InitializeComponent();
        }

        private void frm_DoktorRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbo_YoungHastaneDataSet2.tbl_Doktor' table. You can move, or remove it, as needed.
            this.tbl_DoktorTableAdapter.Fill(this.dbo_YoungHastaneDataSet2.tbl_Doktor);

            this.reportViewer1.RefreshReport();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
