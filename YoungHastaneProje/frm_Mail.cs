using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;

namespace YoungHastaneProje
{
    public partial class frm_Mail : Form
    {
        public frm_Mail()
        {
            InitializeComponent();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            MailMessage mesaj = new MailMessage();
            SmtpClient istenci = new SmtpClient();
            istenci.Credentials = new System.Net.NetworkCredential("efedenizerkoprulu@outlook.com","2934409829e");
            istenci.Port = 587;
            istenci.Host = "smtp.live.com";
            istenci.EnableSsl = true;
            mesaj.To.Add(txtMail.Text);
            mesaj.From = new MailAddress("efedenizerkoprulu@outlook.com");
            mesaj.Subject=txtKonu.Text;
            mesaj.Body = rtbiçerik.Text;
            istenci.Send(mesaj);
            mesaj.SubjectEncoding = Encoding.UTF8;
            mesaj.BodyEncoding = Encoding.UTF8;
            mesaj.IsBodyHtml = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_Mail_Load(object sender, EventArgs e)
        {
            txtMail.Focus();
        }
    }
}
