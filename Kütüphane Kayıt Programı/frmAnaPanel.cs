using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace Kütüphane_Kayıt_Programı
{
    public partial class frmAnaPanel : Form
    {
        public frmAnaPanel()
        {
            InitializeComponent();
        }

        veritabani vt = new veritabani();

        private void btnGBDGonder_Click(object sender, EventArgs e)
        {
            Thread mailthread = new Thread(mailgonder);
            mailthread.Start();
        }

        void mailgonder()
        {
            try
            {
                btnGBDGonder.Enabled = false;
                btnGBDGonder.Text = "İLETİLİYOR..";
                btnGBDGonder.TextAlign = ContentAlignment.MiddleCenter;
                //SmtpClient sc = new SmtpClient();
                //sc.Port = 587;
                //sc.Host = "smtp.gmail.com";
                //sc.EnableSsl = true;
                //sc.Credentials = new NetworkCredential("mail adresiniz", "şifreniz");
                //MailMessage mail = new MailMessage();
                //mail.From = new MailAddress("mail adresi", "HAKKINDA");
                //mail.To.Add("mail adresi");
                //mail.Subject = "HAKKINDA";
                //mail.Body = txtGBDIletisim.Text;
                //sc.Send(mail);
                txtGBDIletisim.Text += "\r\n\r\nİLETİLDİ";
                btnGBDGonder.Enabled = true;
                btnGBDGonder.Text = "MESAJINIZI GÖNDERİN";
                btnGBDGonder.TextAlign = ContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                btnGBDGonder.Enabled = true;
                btnGBDGonder.TextAlign = ContentAlignment.MiddleRight;
                btnGBDGonder.Text = "MESAJINIZI GÖNDERİN";
                MessageBox.Show("Mesajınız gönderilirken bir hata ile karşılaşıldı!\n\n" + ex, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblKonum.Location = new Point(lblKonum.Location.X, btnKitapListele.Location.Y);
            pnlKitapListele.Visible = true;
            pnlEmanetListele.Visible = false;
            pbAnaSayfa.Visible = false;
            pnlOkuyucuListele.Visible = false;
            pnlGKListele.Visible = false;
            pnlKitapEkle.Visible = false;
            pnlOkuyucuEkle.Visible = false;
            pnlEmanetKitapEkle.Visible = false;
            pnlGBDuzenle.Visible = false;
            Thread thread = new Thread(threadkitaplistele);
            thread.Start();
        }
        void threadkitaplistele()
        {
            lstKitapListele.Items.Clear();
            vt.kitaplistele(lstKitapListele);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblKonum.Location = new Point(lblKonum.Location.X, btnEmanetListele.Location.Y);
            pnlKitapListele.Visible = false;
            pnlEmanetListele.Visible = true;
            pnlOkuyucuListele.Visible = false;
            pnlGKListele.Visible = false;
            pbAnaSayfa.Visible = false;
            pnlKitapEkle.Visible = false;
            pnlOkuyucuEkle.Visible = false;
            pnlEmanetKitapEkle.Visible = false;
            pnlGBDuzenle.Visible = false;
            Thread thread = new Thread(threademanetkitaplistele);
            thread.Start();
        }

        void threademanetkitaplistele()
        {
            lstEmanetListesi.Items.Clear();
            vt.emanetkitaplistesi(lstEmanetListesi);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblKonum.Location = new Point(lblKonum.Location.X, btnOkuyucuListele.Location.Y);
            pnlKitapListele.Visible = false;
            pnlEmanetListele.Visible = false;
            pnlOkuyucuListele.Visible = true;
            pnlGKListele.Visible = false;
            pnlKitapEkle.Visible = false;
            pnlOkuyucuEkle.Visible = false;
            pbAnaSayfa.Visible = false;
            pnlEmanetKitapEkle.Visible = false;
            pnlGBDuzenle.Visible = false;
            Thread thread = new Thread(threadokuyuculistele);
            thread.Start();
        }

        void threadokuyuculistele()
        {
            lstOkuyucuListele.Items.Clear();
            vt.okuyuculistele(lstOkuyucuListele);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblKonum.Location = new Point(lblKonum.Location.X, btnGKListele.Location.Y);
            pnlKitapListele.Visible = false;
            pnlEmanetListele.Visible = false;
            pnlOkuyucuListele.Visible = false;
            pbAnaSayfa.Visible = false;
            pnlGKListele.Visible = true;
            pnlKitapEkle.Visible = false;
            pnlOkuyucuEkle.Visible = false;
            pnlEmanetKitapEkle.Visible = false;
            pnlGBDuzenle.Visible = false;
            Thread thread = new Thread(threadgecikenkitaplistele);
            thread.Start();
        }

        void threadgecikenkitaplistele()
        {
            lstGecikenKitapListesi.Items.Clear();
            vt.gecikenkitaplistesi(lstGecikenKitapListesi);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lblKonum.Location = new Point(lblKonum.Location.X, btnKitapEkle.Location.Y);
            pnlKitapListele.Visible = false;
            pnlEmanetListele.Visible = false;
            pnlOkuyucuListele.Visible = false;
            pnlGKListele.Visible = false;
            pnlKitapEkle.Visible = true;
            pbAnaSayfa.Visible = false;
            pnlOkuyucuEkle.Visible = false;
            pnlEmanetKitapEkle.Visible = false;
            pnlGBDuzenle.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lblKonum.Location = new Point(lblKonum.Location.X, btnOkuyucuEkle.Location.Y);
            pnlKitapListele.Visible = false;
            pnlEmanetListele.Visible = false;
            pnlOkuyucuListele.Visible = false;
            pnlGKListele.Visible = false;
            pnlKitapEkle.Visible = false;
            pbAnaSayfa.Visible = false;
            pnlOkuyucuEkle.Visible = true;
            pnlEmanetKitapEkle.Visible = false;
            pnlGBDuzenle.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lblKonum.Location = new Point(lblKonum.Location.X, btnEmanetEkle.Location.Y);
            pnlKitapListele.Visible = false;
            pnlEmanetListele.Visible = false;
            pnlOkuyucuListele.Visible = false;
            pnlGKListele.Visible = false;
            pnlKitapEkle.Visible = false;
            pnlOkuyucuEkle.Visible = false;
            pbAnaSayfa.Visible = false;
            pnlEmanetKitapEkle.Visible = true;
            pnlGBDuzenle.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lblKonum.Location = new Point(lblKonum.Location.X, btnGirisBilgisiDuzenle.Location.Y);
            pnlKitapListele.Visible = false;
            pnlEmanetListele.Visible = false;
            pnlOkuyucuListele.Visible = false;
            pnlGKListele.Visible = false;
            pnlKitapEkle.Visible = false;
            pbAnaSayfa.Visible = false;
            pnlOkuyucuEkle.Visible = false;
            pnlEmanetKitapEkle.Visible = false;
            pnlGBDuzenle.Visible = true;
            Thread thread = new Thread(threadgirisbilgiduzenle);
            thread.Start();
        }

        void threadgirisbilgiduzenle()
        {
            FileInfo fi = new FileInfo(Properties.Settings.Default.vtyol);
            long boyut = fi.Length;
            int kbboyut = Convert.ToInt32(boyut) / 1024;
            txtKullaniciAdi.Text = vt.girisbilgiduzenlekullaniciadi();
            txtSifre.Text = vt.girisbilgiduzenlesifre();
            lblAyarTK.Text = "Veri Tabanı Toplam Kayıt: " + vt.toplamkayitsayisi().ToString();
            lblVTBoyut.Text = "Veri Tabanı Dosyası Boyutu: " + kbboyut + "KB";
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            DialogResult cikis = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "ÇIKIŞ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void frmAnaPanel_Load(object sender, EventArgs e)
        {
            lblKonum.Location = new Point(lblKonum.Location.X, -200);
            pbAnaSayfa.Visible = true;
            pnlKitapListele.Visible = false;
            pnlEmanetListele.Visible = false;
            pnlOkuyucuListele.Visible = false;
            pnlGKListele.Visible = false;
            pnlKitapEkle.Visible = false;
            pnlOkuyucuEkle.Visible = false;
            pnlEmanetKitapEkle.Visible = false;
            pnlGBDuzenle.Visible = false;
            CheckForIllegalCrossThreadCalls = false;
            txtVTYolu.Text = Properties.Settings.Default.vtyol;
        }

        private void btnGBGuncelle_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(threadgirisguncelle);
            thread.Start();
        }

        void threadgirisguncelle()
        {
            vt.girisbilgiguncelle(txtKullaniciAdi.Text, txtSifre.Text);
        }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            DialogResult secim = ofd.ShowDialog();
            if (secim == DialogResult.OK)
            {
                DialogResult mesaj = MessageBox.Show("Veri tabanı dosyasının yolunu değiştirdiniz. İşlemin geçerli olabilmesi için program yeniden başlatılacak.\nEmin misiniz?", "VERİ TABANI DEĞİŞİMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mesaj == DialogResult.Yes)
                {
                    txtVTYolu.Text = ofd.FileName;
                    Properties.Settings.Default.vtyol = ofd.FileName;
                    Properties.Settings.Default.Save();
                    Process.Start(Application.StartupPath + "\\Kütüphane Kayıt Programı.exe");
                    Application.Exit();
                }
            }
        }
        bool surukle;
        Point nokta;
        private void pnlUstBar_MouseDown(object sender, MouseEventArgs e)
        {
            surukle = true;
            nokta = e.Location;
        }

        private void pnlUstBar_MouseUp(object sender, MouseEventArgs e)
        {
            surukle = false;
        }

        private void pnlUstBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukle)
            {
                Point csp = PointToScreen(e.Location);
                Location = new Point(csp.X - nokta.X, csp.Y - nokta.Y);
            }
        }

        private void lstKitapListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKitapListele.SelectedItems.Count > 0)
            {
                ListViewItem ekle = lstKitapListele.SelectedItems[0];
                txtKitapListeleID.Text = ekle.SubItems[0].Text;
                txtKLKitapAdi.Text = ekle.SubItems[1].Text;
                txtKLYazar.Text = ekle.SubItems[2].Text;
                cbKLTur.Text = ekle.SubItems[3].Text;
                txtKLYayinEvi.Text = ekle.SubItems[4].Text;
                txtKLStokSayisi.Text = ekle.SubItems[5].Text;
                txtKLKitapAdi.Enabled = true;
                txtKLStokSayisi.Enabled = true;
                txtKLYayinEvi.Enabled = true;
                txtKLYazar.Enabled = true;
                cbKLTur.Enabled = true;
                btnKLGuncelle.Enabled = true;
                btnKLKayitSil.Enabled = true;
            }

            if (lstKitapListele.SelectedItems.Count == 0)
            {
                txtKitapListeleID.Clear();
                txtKLKitapAdi.Clear();
                txtKLYazar.Clear();
                cbKLTur.SelectedIndex = -1;
                txtKLYayinEvi.Clear();
                txtKLStokSayisi.Clear();
                txtKLKitapAdi.Enabled = false;
                txtKLStokSayisi.Enabled = false;
                txtKLYayinEvi.Enabled = false;
                txtKLYazar.Enabled = false;
                cbKLTur.Enabled = false;
                btnKLGuncelle.Enabled = false;
                btnKLKayitSil.Enabled = false;
            }
        }

        private void btnKLGuncelle_Click(object sender, EventArgs e)
        {
            vt.kitaplistesiguncelle(txtKitapListeleID.Text, txtKLKitapAdi.Text, txtKLYazar.Text, cbKLTur.Text, txtKLYayinEvi.Text, txtKLStokSayisi.Text);
            threadkitaplistele();
        }

        private void btnKLKayitSil_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show(txtKLKitapAdi.Text + " isimli kitabı silmek istediğinize emin misiniz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sil == DialogResult.Yes)
            {
                vt.kitaplistesisil(txtKitapListeleID.Text);
                threadkitaplistele();
                txtKitapListeleID.Clear();
                txtKLKitapAdi.Clear();
                txtKLYazar.Clear();
                cbKLTur.SelectedIndex = -1;
                txtKLYayinEvi.Clear();
                txtKLStokSayisi.Clear();
                txtKLKitapAdi.Enabled = false;
                txtKLStokSayisi.Enabled = false;
                txtKLYayinEvi.Enabled = false;
                txtKLYazar.Enabled = false;
                cbKLTur.Enabled = false;
                btnKLGuncelle.Enabled = false;
                btnKLKayitSil.Enabled = false;
            }
        }

        private void btnKETemizle_Click(object sender, EventArgs e)
        {
            txtKEKitapAdi.Clear();
            txtKEYayinEvi.Clear();
            txtKEYazarAdi.Clear();
            cbKETur.SelectedIndex = -1;
            nudKEStokSayisi.Value = 0;
        }

        private void btnKEKayitEkle_Click(object sender, EventArgs e)
        {
            if (txtKEKitapAdi.Text == "" || txtKEYayinEvi.Text == "" || txtKEYazarAdi.Text == "" || txtKLYayinEvi.Text == "" || cbKETur.Text == "")
            {
                MessageBox.Show("Lütfen veri girişi yapınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                vt.kitapekle(txtKEKitapAdi.Text, txtKEYazarAdi.Text, cbKETur.Text, txtKEYayinEvi.Text, nudKEStokSayisi.Value.ToString());
            }
        }

        private void btnOEKayitEkle_Click(object sender, EventArgs e)
        {
            if (txtOEAd.Text == "" || txtOEAdres.Text == "" || txtOEEposta.Text == "" || txtOESoyad.Text == "" || txtOETC.Text == "" || txtOETelefon.Text == "(   )    -" || cbOECinsiyet.Text == "")
            {
                MessageBox.Show("Lütfen veri girişi yapınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                vt.okuyucuekle(txtOETC.Text, txtOEAd.Text, txtOESoyad.Text, dtpOEDogumTarihi.Text, txtOETelefon.Text, txtOEEposta.Text, dtpOEUyelikTarihi.Text, cbOECinsiyet.Text, txtOEAdres.Text);
            }
        }

        private void btnOETemizle_Click(object sender, EventArgs e)
        {
            txtOEAd.Clear();
            txtOEAdres.Clear();
            txtOEEposta.Clear();
            txtOESoyad.Clear();
            txtOETC.Clear();
            txtOETelefon.Clear();
            cbOECinsiyet.SelectedIndex = -1;
            dtpOEDogumTarihi.Value = DateTime.Now.Date;
            dtpOEUyelikTarihi.Value = DateTime.Now.Date;
        }

        private void btnOLAra_Click(object sender, EventArgs e)
        {
            lstOkuyucuListele.Items.Clear();
            switch (cbOLAramaTürü.Text)
            {
                case "TC":
                    vt.okuyucuara("tc", txtOLAranacakBilgi.Text, lstOkuyucuListele);
                    break;
                case "AD":
                    vt.okuyucuara("ad", txtOLAranacakBilgi.Text, lstOkuyucuListele);
                    break;
                case "SOYAD":
                    vt.okuyucuara("soyad", txtOLAranacakBilgi.Text, lstOkuyucuListele);
                    break;
                case "TELEFON":
                    vt.okuyucuara("telefon", txtOLAranacakBilgi.Text, lstOkuyucuListele);
                    break;
                case "E-POSTA":
                    vt.okuyucuara("eposta", txtOLAranacakBilgi.Text, lstOkuyucuListele);
                    break;
                case "CİNSİYET":
                    vt.okuyucuara("cinsiyet", txtOLAranacakBilgi.Text, lstOkuyucuListele);
                    break;
                case "ADRES":
                    vt.okuyucuara("adres", txtOLAranacakBilgi.Text, lstOkuyucuListele);
                    break;
            }
        }

        private void btnKLAra_Click(object sender, EventArgs e)
        {
            lstKitapListele.Items.Clear();
            switch (cbKLAramaTürü.Text)
            {
                case "BARKOD":
                    vt.kitapara("sira", txtKitapListeleID.Text, lstKitapListele);
                    break;
                case "KİTAP ADI":
                    vt.kitapara("ad", txtKLKitapAdi.Text, lstKitapListele);
                    break;
                case "YAZAR":
                    vt.kitapara("yazar", txtKLYazar.Text, lstKitapListele);
                    break;
                case "TÜR":
                    vt.kitapara("tur", cbKLTur.Text, lstKitapListele);
                    break;
                case "YAYIN EVİ":
                    vt.kitapara("yayinevi", txtKLYayinEvi.Text, lstKitapListele);
                    break;
                case "STOK SAYISI":
                    vt.kitapara("stok", txtKLStokSayisi.Text, lstKitapListele);
                    break;
            }
        }

        private void lstOkuyucuListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOkuyucuListele.SelectedItems.Count > 0)
            {
                ListViewItem ekle = lstOkuyucuListele.SelectedItems[0];
                txtOLTC.Text = ekle.SubItems[0].Text;
                txtOLAd.Text = ekle.SubItems[1].Text;
                txtOLSoyad.Text = ekle.SubItems[2].Text;
                dtpOLDogumTarihi.Text = ekle.SubItems[3].Text;
                txtOLTelefon.Text = ekle.SubItems[4].Text;
                txtOLEPosta.Text = ekle.SubItems[5].Text;
                dtpOLUyelikTarihi.Text = ekle.SubItems[6].Text;
                cbOLCinsiyet.Text = ekle.SubItems[7].Text;
                txtOLAdres.Text = ekle.SubItems[8].Text;
                dtpOLUyelikTarihi.Enabled = true;
                txtOLAd.Enabled = true;
                txtOLSoyad.Enabled = true;
                dtpOLDogumTarihi.Enabled = true;
                txtOLTelefon.Enabled = true;
                cbOLCinsiyet.Enabled = true;
                txtOLAdres.Enabled = true;
                txtOLEPosta.Enabled = true;
                btnOkuyucuGuncelle.Enabled = true;
                btnOkuyucuSil.Enabled = true;
            }

            if (lstOkuyucuListele.SelectedItems.Count == 0)
            {
                txtOLTC.Clear();
                txtOLAd.Clear();
                txtOLSoyad.Clear();
                dtpOLDogumTarihi.Value = DateTime.Now.Date;
                txtOLTelefon.Clear();
                txtOLEPosta.Clear();
                dtpOLUyelikTarihi.Value = DateTime.Now.Date;
                cbOLCinsiyet.SelectedIndex = -1;
                txtOLAdres.Clear();
                dtpOLUyelikTarihi.Enabled = false;
                txtOLAd.Enabled = false;
                txtOLSoyad.Enabled = false;
                dtpOLDogumTarihi.Enabled = false;
                txtOLTelefon.Enabled = false;
                cbOLCinsiyet.Enabled = false;
                txtOLAdres.Enabled = false;
                txtOLEPosta.Enabled = false;
                btnOkuyucuGuncelle.Enabled = false;
                btnOkuyucuSil.Enabled = false;
            }
        }

        private void btnOkuyucuSil_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show(txtOLAd.Text + " " + txtOLSoyad.Text + " isimli okuyucuyu silmek istediğinize emin misiniz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sil == DialogResult.Yes)
            {
                vt.okuyucusil(txtOLTC.Text);
                threadokuyuculistele();
                txtOLTC.Clear();
                txtOLAd.Clear();
                txtOLSoyad.Clear();
                dtpOLDogumTarihi.Value = DateTime.Now.Date;
                txtOLTelefon.Clear();
                txtOLEPosta.Clear();
                dtpOLUyelikTarihi.Value = DateTime.Now.Date;
                cbOLCinsiyet.SelectedIndex = -1;
                txtOLAdres.Clear();
                dtpOLUyelikTarihi.Enabled = false;
                txtOLAd.Enabled = false;
                txtOLSoyad.Enabled = false;
                dtpOLDogumTarihi.Enabled = false;
                txtOLTelefon.Enabled = false;
                cbOLCinsiyet.Enabled = false;
                txtOLAdres.Enabled = false;
                txtOLEPosta.Enabled = false;
                btnOkuyucuGuncelle.Enabled = false;
                btnOkuyucuSil.Enabled = false;
            }
        }

        private void btnOkuyucuGuncelle_Click(object sender, EventArgs e)
        {
            vt.okuyucuguncelle(txtOLTC.Text, txtOLAd.Text, txtOLSoyad.Text, dtpOLDogumTarihi.Text, txtOLTelefon.Text, txtOLEPosta.Text, dtpOLUyelikTarihi.Text, cbOLCinsiyet.Text, txtOLAdres.Text);
            threadokuyuculistele();
        }

        private void btnEmanetKitapTemizle_Click(object sender, EventArgs e)
        {
            txtEKEAdSoyad.Clear();
            txtEKEKitapAdi.Clear();
            dtpEKEEmanetEdilisTarihi.Value = DateTime.Now.Date;
            dtpEKETeslimTarihi.Value = DateTime.Now.Date;
        }

        private void btnEmanetKitapEkle_Click(object sender, EventArgs e)
        {
            if (dtpEKEEmanetEdilisTarihi.Value > dtpEKETeslimTarihi.Value)
            {
                MessageBox.Show("Teslim tarihi, emanet ediliş tarihinden önce olamaz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtEKEAdSoyad.Text == "" || txtEKEKitapAdi.Text == "")
            {
                MessageBox.Show("Lütfen veri girişi yapınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                vt.emanetkitapekle(txtEKEAdSoyad.Text, txtEKEKitapAdi.Text, dtpEKEEmanetEdilisTarihi.Text, dtpEKETeslimTarihi.Text);
        }

        private void lstGecikenKitapListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGecikenKitapListesi.SelectedItems.Count > 0)
            {
                btnGKLTeslimAlindi.Enabled = true;
                btnGKLTeslimTarihiUzat.Enabled = true;
            }
            if (lstGecikenKitapListesi.SelectedItems.Count == 0)
            {
                btnGKLTeslimAlindi.Enabled = false;
                btnGKLTeslimTarihiUzat.Enabled = false;
            }

            //ListViewItem list = lstGecikenKitapListesi.SelectedItems[0];

            //if (lstGecikenKitapListesi.SelectedItems[4].Text=="TESLİM EDİLDİ")
            //{
            //    btnGKLTeslimAlindi.Enabled = false;
            //    btnGKLTeslimTarihiUzat.Enabled = false;
            //}
            //else
            //{
            //    btnGKLTeslimAlindi.Enabled = true;
            //    btnGKLTeslimTarihiUzat.Enabled = true;
            //}
        }

        private void lstEmanetListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmanetListesi.SelectedItems.Count > 0)
            {
                txtELAdSoyad.Enabled = true;
                txtELKitapAdi.Enabled = true;
                dtpELEmanetTarihi.Enabled = true;
                dtpELTeslimTarihi.Enabled = true;
                btnEmanetListesiGuncelle.Enabled = true;
                btnEmanetListesiSil.Enabled = true;
                cbELDurum.Enabled = true;
                ListViewItem ekle = lstEmanetListesi.SelectedItems[0];
                txtELAdSoyad.Text = ekle.SubItems[0].Text;
                txtELKitapAdi.Text = ekle.SubItems[1].Text;
                dtpELEmanetTarihi.Text = ekle.SubItems[2].Text;
                dtpELTeslimTarihi.Text = ekle.SubItems[3].Text;
                cbELDurum.SelectedItem = ekle.SubItems[4].Text;
            }
            if (lstEmanetListesi.SelectedItems.Count == 0)
            {
                txtELAdSoyad.Enabled = false;
                txtELKitapAdi.Enabled = false;
                dtpELEmanetTarihi.Enabled = false;
                dtpELTeslimTarihi.Enabled = false;
                cbELDurum.Enabled = true;
                btnEmanetListesiGuncelle.Enabled = false;
                btnEmanetListesiSil.Enabled = false;
                txtELAdSoyad.Clear();
                cbELDurum.SelectedIndex = -1;
                txtELKitapAdi.Clear();
                dtpELEmanetTarihi.Value = DateTime.Now.Date;
                dtpELTeslimTarihi.Value = DateTime.Now.Date;
            }
        }

        private void btnEmanetListesiGuncelle_Click_1(object sender, EventArgs e)
        {
            vt.emanetguncelle(txtELAdSoyad.Text, txtELKitapAdi.Text, dtpELEmanetTarihi.Text, dtpELTeslimTarihi.Text);
            threademanetkitaplistele();
        }

        private void btnEmanetListesiSil_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show(txtELKitapAdi.Text + " isimli emaneti silmek istediğinize emin misiniz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sil == DialogResult.Yes)
            {
                vt.emanetsil(txtELKitapAdi.Text);
                threademanetkitaplistele();
                txtELAdSoyad.Enabled = false;
                txtELKitapAdi.Enabled = false;
                cbELDurum.SelectedIndex = -1;
                cbELDurum.Enabled = true;
                dtpELEmanetTarihi.Enabled = false;
                dtpELTeslimTarihi.Enabled = false;
                btnEmanetListesiGuncelle.Enabled = false;
                btnEmanetListesiSil.Enabled = false;
                txtELAdSoyad.Clear();
                txtELKitapAdi.Clear();
                dtpELEmanetTarihi.Value = DateTime.Now.Date;
                dtpELTeslimTarihi.Value = DateTime.Now.Date;
            }
        }

        private void boslukKontrol(object sender, KeyPressEventArgs e)
        {
            textkontrol((TextBox)sender, e);
        }

        void textkontrol(TextBox txt, KeyPressEventArgs e)
        {
            if (txt.Text == "" || txt.Text == null)
            {
                e.Handled = char.IsWhiteSpace(e.KeyChar);
            }
        }

        private void btnGKLTeslimleriSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Teslim alınan kitapların tümü silinsin mi?", "KAYIT SİL?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                vt.teslimalinanlarisil();
                lstGecikenKitapListesi.Items.Clear();
                vt.gecikenkitaplistesi(lstGecikenKitapListesi);
            }
        }

        private void btnGKLRapor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("rapor");
        }
    }
}