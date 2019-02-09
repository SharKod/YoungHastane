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
    public partial class frm_OdaRapor : Form
    {
        public frm_OdaRapor()
        {
            InitializeComponent();
        }

        private void frm_OdaRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbo_YoungHastaneDataSet1.tbl_Oda' table. You can move, or remove it, as needed.
            this.tbl_OdaTableAdapter.Fill(this.dbo_YoungHastaneDataSet1.tbl_Oda);

            this.reportViewer1.RefreshReport();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
