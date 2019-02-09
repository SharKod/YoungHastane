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
    public partial class frm_HastaRapor : Form
    {
        public frm_HastaRapor()
        {
            InitializeComponent();
        }

        private void frm_HastaRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbo_YoungHastaneDataSet.tbl_YatanHasta' table. You can move, or remove it, as needed.
            this.tbl_YatanHastaTableAdapter.Fill(this.dbo_YoungHastaneDataSet.tbl_YatanHasta);
            this.reportViewer1.RefreshReport();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
