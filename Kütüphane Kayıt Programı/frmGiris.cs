using System;
using System.Windows.Forms;
namespace Kütüphane_Kayıt_Programı
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        veritabani vt = new veritabani();
        private void GirisKontrol(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (vt.giris(txtKullaniciAdi.Text, txtSifre.Text)==true)
            {
                frmAnaPanel kp = new frmAnaPanel();
                kp.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Hatalı giriş! Lütfen bilgilerin doğruluğunu kontrol edin!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}