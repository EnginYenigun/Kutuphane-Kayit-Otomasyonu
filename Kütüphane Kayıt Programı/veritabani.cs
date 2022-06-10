using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Kütüphane_Kayıt_Programı
{
    class veritabani
    {
        private OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Properties.Settings.Default.vtyol);
        private OleDbCommand komut;
        private OleDbDataReader oku;

        public bool giris(string kullaniciadi, string sifre)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from giris where kullaniciadi=@kullaniciadi and sifre=@sifre", baglanti);
                komut.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    oku.Close();
                    baglanti.Close();
                    return true;
                }
                else
                {
                    oku.Close();
                    baglanti.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                oku.Close();
                baglanti.Close();
                return false;
            }
        }

        #region ARA
        public void okuyucuara(string aramaturu, string aranacakbilgi, ListView liste)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from okuyuculistesi where " + aramaturu + "='" + aranacakbilgi + "'", baglanti);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["tc"].ToString();
                    ekle.SubItems.Add(oku["ad"].ToString());
                    ekle.SubItems.Add(oku["soyad"].ToString());
                    ekle.SubItems.Add(oku["dogumtarihi"].ToString());
                    ekle.SubItems.Add(oku["telefon"].ToString());
                    ekle.SubItems.Add(oku["eposta"].ToString());
                    ekle.SubItems.Add(oku["uyeliktarihi"].ToString());
                    ekle.SubItems.Add(oku["cinsiyet"].ToString());
                    ekle.SubItems.Add(oku["adres"].ToString());
                    liste.Items.Add(ekle);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void kitapara(string aramaturu, string aranacakbilgi, ListView liste)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from kitaplistesi where " + aramaturu + "='" + aranacakbilgi + "'", baglanti);
                oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["sira"].ToString();
                    ekle.SubItems.Add(oku["ad"].ToString());
                    ekle.SubItems.Add(oku["yazar"].ToString());
                    ekle.SubItems.Add(oku["tur"].ToString());
                    ekle.SubItems.Add(oku["yayinevi"].ToString());
                    ekle.SubItems.Add(oku["stok"].ToString());
                    liste.Items.Add(ekle);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region SİL

        public void teslimalinanlarisil()
        {
            try
            {
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("delete from emanetlistesi where durum='TESLİM EDİLDİ'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Teslim alınan kitaplar başarıyla silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void kitaplistesisil(string barkod)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("delete from kitaplistesi where sira=@barkod", baglanti);
                komut.Parameters.AddWithValue("@barkod", barkod);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Silindi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void okuyucusil(string tc)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("delete from okuyuculistesi where tc=@tc", baglanti);
                komut.Parameters.AddWithValue("@tc", tc);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Silindi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void emanetsil(string kitapad)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("delete from emanetlistesi where kitapad=@kitapad", baglanti);
                komut.Parameters.AddWithValue("@kitapad", kitapad);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Silindi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region GÜNCELLE
        public void girisbilgiguncelle(string kullaniciadi, string sifre)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("update giris set kullaniciadi=@kullaniciadi, sifre=@sifre", baglanti);
                komut.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.ExecuteNonQuery();
                MessageBox.Show("Giriş bilgileri güncellendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void kitaplistesiguncelle(string barkod, string kitapad, string yazar, string tur, string yayinevi, string stoksayisi)
        {
            int barkodint = Convert.ToInt32(barkod);
            int stokint = Convert.ToInt32(stoksayisi);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("update kitaplistesi set ad=@ad,yazar=@yazar,tur=@tur,yayinevi=@yayinevi, stok=@stok where sira=" + barkodint + "", baglanti);
                komut.Parameters.AddWithValue("@ad", kitapad);
                komut.Parameters.AddWithValue("@yazar", yazar);
                komut.Parameters.AddWithValue("@tur", tur);
                komut.Parameters.AddWithValue("@yayinevi", yayinevi);
                komut.Parameters.AddWithValue("@stok", stokint);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Güncellendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void okuyucuguncelle(string tc, string ad, string soyad, string dogumtarihi, string telefon, string eposta, string uyeliktarihi, string cinsiyet, string adres)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("update okuyuculistesi set ad=@ad,soyad=@soyad,dogumtarihi=@dogumtarihi, telefon=@telefon, eposta=@eposta,uyeliktarihi=@uyeliktarihi,cinsiyet=@cinsiyet,adres=@adres where tc='" + tc + "'", baglanti);
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@dogumtarihi", dogumtarihi);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@eposta", eposta);
                komut.Parameters.AddWithValue("@uyeliktarihi", uyeliktarihi);
                komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                komut.Parameters.AddWithValue("@adres", adres);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Güncellendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void emanetguncelle(string adsoyad, string kitapad, string verilistarihi, string teslimtarihi)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("update emanetlistesi set adsoyad=@adsoyad,kitapad=@kitapad,verilistarihi=@verilistarihi,teslimtarihi=@teslimtarihi where adsoyad='" + adsoyad + "'", baglanti);
                komut.Parameters.AddWithValue("@adsoyad", adsoyad);
                komut.Parameters.AddWithValue("@kitapad", kitapad);
                komut.Parameters.AddWithValue("@verilistarihi", verilistarihi);
                komut.Parameters.AddWithValue("@teslimtarihi", teslimtarihi);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Güncellendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region LİSTELE
        public void emanetkitaplistesi(ListView liste)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from emanetlistesi", baglanti);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["adsoyad"].ToString();
                    ekle.SubItems.Add(oku["kitapad"].ToString());
                    ekle.SubItems.Add(oku["verilistarihi"].ToString());
                    ekle.SubItems.Add(oku["teslimtarihi"].ToString());
                    ekle.SubItems.Add(oku["durum"].ToString());
                    liste.Items.Add(ekle);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void gecikenkitaplistesi(ListView liste)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from emanetlistesi where teslimtarihi<@tarih", baglanti);
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToShortDateString());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["adsoyad"].ToString();
                    ekle.SubItems.Add(oku["kitapad"].ToString());
                    ekle.SubItems.Add(oku["verilistarihi"].ToString());
                    ekle.SubItems.Add(oku["teslimtarihi"].ToString());
                    ekle.SubItems.Add(oku["durum"].ToString());
                    liste.Items.Add(ekle);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void kitaplistele(ListView liste)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from kitaplistesi", baglanti);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["sira"].ToString();
                    ekle.SubItems.Add(oku["ad"].ToString());
                    ekle.SubItems.Add(oku["yazar"].ToString());
                    ekle.SubItems.Add(oku["tur"].ToString());
                    ekle.SubItems.Add(oku["yayinevi"].ToString());
                    ekle.SubItems.Add(oku["stok"].ToString());
                    liste.Items.Add(ekle);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void okuyuculistele(ListView liste)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from okuyuculistesi", baglanti);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["tc"].ToString();
                    ekle.SubItems.Add(oku["ad"].ToString());
                    ekle.SubItems.Add(oku["soyad"].ToString());
                    ekle.SubItems.Add(oku["dogumtarihi"].ToString());
                    ekle.SubItems.Add(oku["telefon"].ToString());
                    ekle.SubItems.Add(oku["eposta"].ToString());
                    ekle.SubItems.Add(oku["uyeliktarihi"].ToString());
                    ekle.SubItems.Add(oku["cinsiyet"].ToString());
                    ekle.SubItems.Add(oku["adres"].ToString());
                    liste.Items.Add(ekle);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string girisbilgiduzenlekullaniciadi()
        {
            try
            {
                string sonuc = "";
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from giris kullaniciadi", baglanti);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    sonuc = oku["kullaniciadi"].ToString();
                }
                oku.Close();
                baglanti.Close();
                return sonuc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "KRİTİK HATA";
            }
        }

        public string girisbilgiduzenlesifre()
        {
            try
            {
                string sonuc = "";
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from giris sifre", baglanti);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    sonuc = oku["sifre"].ToString();
                }
                oku.Close();
                baglanti.Close();
                return sonuc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "KRİTİK HATA";
            }
        }

        public int toplamkayitsayisi()
        {
            int kayit = 0;
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select count(*) from emanetlistesi", baglanti);
                kayit += Convert.ToInt32(komut.ExecuteScalar());
                komut = new OleDbCommand("select count(*) from kitaplistesi", baglanti);
                kayit += Convert.ToInt32(komut.ExecuteScalar());
                komut = new OleDbCommand("select count(*) from okuyuculistesi", baglanti);
                kayit += Convert.ToInt32(komut.ExecuteScalar());
                baglanti.Close();
            }
            catch (Exception ex)
            {
                kayit = -1;
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return kayit;
        }
        #endregion
        #region EKLE
        public void kitapekle(string kitapadi, string yazaradi, string kitapturu, string yayinevi, string stoksayisi)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("insert into kitaplistesi (ad,yazar,tur,yayinevi,stok) values (@ad,@yazar,@tur,@yayinevi,@stok)", baglanti);
                komut.Parameters.AddWithValue("@ad", kitapadi);
                komut.Parameters.AddWithValue("@yazar", yazaradi);
                komut.Parameters.AddWithValue("@tur", kitapturu);
                komut.Parameters.AddWithValue("@yayinevi", yayinevi);
                komut.Parameters.AddWithValue("@stok", stoksayisi);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Eklendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void emanetkitapekle(string adsoyad, string kitapad, string emanettarihi, string teslimtarihi)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("insert into emanetlistesi (adsoyad,kitapad,verilistarihi,teslimtarihi) values (@adsoyad,@kitapad,@verilistarihi,@teslimtarihi)", baglanti);
                komut.Parameters.AddWithValue("@adsoyad", adsoyad);
                komut.Parameters.AddWithValue("@kitapad", kitapad);
                komut.Parameters.AddWithValue("@verilistarihi", emanettarihi);
                komut.Parameters.AddWithValue("@teslimtarihi", teslimtarihi);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Eklendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void okuyucuekle(string tc, string ad, string soyad, string dogumtarihi, string telefon, string eposta, string uyeliktarihi, string cinsiyet, string adres)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new OleDbCommand("select * from okuyuculistesi where tc=@tc", baglanti);
                komut.Parameters.AddWithValue("@tc", tc);
                oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Bu TC numarasına ait bir okuyucu zaten sistemde kayıtlı!", "KAYIT MEVCUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    komut = new OleDbCommand("insert into okuyuculistesi (tc,ad,soyad,dogumtarihi,telefon,eposta,uyeliktarihi,cinsiyet,adres) values (@tc,@ad,@soyad,@dogumtarihi,@telefon,@eposta,@uyeliktarihi,@cinsiyet,@adres)", baglanti);
                    komut.Parameters.AddWithValue("@tc", tc);
                    komut.Parameters.AddWithValue("@ad", ad);
                    komut.Parameters.AddWithValue("@soyad", soyad);
                    komut.Parameters.AddWithValue("@dogumtarihi", dogumtarihi);
                    komut.Parameters.AddWithValue("@telefon", telefon);
                    komut.Parameters.AddWithValue("@eposta", eposta);
                    komut.Parameters.AddWithValue("@uyeliktarihi", uyeliktarihi);
                    komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                    komut.Parameters.AddWithValue("@adres", adres);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt Eklendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                baglanti.Close();
                oku.Close();
            }
            catch (Exception ex)
            {
                baglanti.Close();
                oku.Close();
                MessageBox.Show(ex.ToString(), "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}