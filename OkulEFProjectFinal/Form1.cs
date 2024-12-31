using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OkulEFProjectFinal
{
    public partial class Form1 : Form
    {
        List<Sinif> SinifListesi;
        public Form1()
        {
            InitializeComponent();
            SiniflariYukle();
        }
        Ogrenci ogrenci;

        private void SiniflariYukle()
        {
            using (var ctx = new OgrenciModel())
            {
                SinifListesi = ctx.Siniflar.ToList();
                cmbboxSiniflar.DataSource = SinifListesi;
                cmbboxSiniflar.DisplayMember = "SinifAd";
                cmbboxSiniflar.ValueMember = "SinifId";
            }
        }

        private void HataMesaji(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Temizle()
        {
            txtboxAd.Clear();
            txtboxSoyad.Clear();
            txtNumara.Clear();
            txtboxDersAdi.Clear();
            txtboxDersKodu.Clear();
            txtboxSinifAd.Clear();
            txtboxKontenjan.Clear();
        }

        private bool AreAllFieldsFilled(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox && string.IsNullOrWhiteSpace(item.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!AreAllFieldsFilled(grpboxOgrenciEkle))
            {
                HataMesaji("Tüm alanlarýn doldurulmasý zorunludur");
                return;
            }

            string ad = txtboxAd.Text;
            string soyad = txtboxSoyad.Text;
            string numara = txtNumara.Text;
            int selectedSinifId = (int)cmbboxSiniflar.SelectedValue;

            var ogr = new Ogrenci { Ad = ad, Soyad = soyad, Numara = numara, SinifId = selectedSinifId };

            try
            {
                using (var ctx = new OgrenciModel())
                {
                    var seciliSinif = ctx.Siniflar.FirstOrDefault(s => s.SinifId == selectedSinifId);
                    if (seciliSinif!=null)
                    {
                        int kontenjan = seciliSinif.Kontenjan;
                        if (ctx.Ogrenciler.Where(o => o.SinifId == selectedSinifId).Count() <= kontenjan)
                        {
                            ctx.Ogrenciler.Add(ogr);
                            ctx.SaveChanges();
                            MessageBox.Show("Ýþlem baþarýyla kayýt edildi");
                            Temizle();
                        }
                        else
                        {
                            MessageBox.Show("Kontenjan DOLUU!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HataMesaji($"Beklenmeyen bir þey oluþtu. Hata: {ex.Message}");
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumara.Text, out int numara))
            {
                HataMesaji("Geçerli bir numara giriniz!");
                return;
            }

            using (var ctx = new OgrenciModel())
            {
                var ogr = ctx.Ogrenciler.FirstOrDefault(o => o.Numara == numara.ToString());
                if (ogr != null)
                {
                    txtboxAd.Text = ogr.Ad;
                    txtboxSoyad.Text = ogr.Soyad;
                    txtNumara.Text = ogr.Numara;
                    cmbboxSiniflar.SelectedValue = ogr.SinifId;
                }
                else
                {
                    HataMesaji("Böyle bir öðrenci bulunamadý");
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxAd.Text) ||
                string.IsNullOrWhiteSpace(txtboxSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtNumara.Text))
            {
                HataMesaji("Lütfen tüm alanlarý doldurunuz.");
                return;
            }

            try
            {
                using (var ctx = new OgrenciModel())
                {
                    var ogr = ctx.Ogrenciler.FirstOrDefault(o => o.Numara == txtNumara.Text.Trim());
                    if (ogr != null)
                    {
                        ogr.Ad = txtboxAd.Text.Trim();
                        ogr.Soyad = txtboxSoyad.Text.Trim();
                        ogr.Numara = txtNumara.Text.Trim();

                        ctx.SaveChanges();

                        MessageBox.Show("Öðrenci baþarýyla güncellendi.");
                        Temizle();
                    }
                    else
                    {
                        HataMesaji("Böyle bir öðrenci bulunamadý.");
                    }
                }
            }
            catch (Exception ex)
            {
                HataMesaji($"Beklenmeyen bir hata oluþtu: {ex.Message}");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumara.Text, out int numara))
            {
                HataMesaji("Lütfen geçerli bir numara giriniz.");
                return;
            }

            try
            {
                using (var ctx = new OgrenciModel())
                {
                    var ogr = ctx.Ogrenciler.FirstOrDefault(o => o.Numara == numara.ToString());
                    if (ogr != null)
                    {
                        ctx.Ogrenciler.Remove(ogr);
                        ctx.SaveChanges();
                        MessageBox.Show("Öðrenci baþarýlý bir þekilde silindi.");
                        Temizle();
                    }
                    else
                    {
                        HataMesaji("Böyle bir öðrenci bulunamadý.");
                    }
                }
            }
            catch (Exception ex)
            {
                HataMesaji($"Beklenmeyen bir hata oluþtu: {ex.Message}");
            }
        }



        private void btnDersSecimi_Click(object sender, EventArgs e)
        {
            Ogrenci ogrenci;
            using (var ctx = new OgrenciModel())
            {
                ogrenci = ctx.Ogrenciler.FirstOrDefault(o => o.Ad == txtboxAd.Text && o.Soyad == txtboxSoyad.Text && o.Numara ==txtNumara.Text);

                if (ogrenci == null)
                {
                    ogrenci = new Ogrenci
                    {
                        Ad = txtboxAd.Text,
                        Soyad = txtboxSoyad.Text,
                        Numara = txtNumara.Text,
                    };

                    ctx.Ogrenciler.Add(ogrenci);
                    ctx.SaveChanges();
                }
            }

            List<Ders> dersler;
            using (var ctx = new OgrenciModel())
            {
                dersler = ctx.Dersler.ToList();
            }

            //Console.WriteLine("Dersler:");
            //foreach (var ders in dersler)
            //{
            //    Console.WriteLine($"Ders Adý: {ders.DersAd}, Ders Kodu: {ders.DersKod}");
            //}

            //// Eðer dersler null veya boþsa, hatayý burada kontrol edebilirsiniz
            //if (dersler == null || dersler.Count == 0)
            //{
            //    MessageBox.Show("Dersler alýnamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //Ders Null kontrol

            //Sinif selectedSinif;
            //using (var ctx = new OgrenciModel())
            //{
            //    selectedSinif = ctx.Siniflar.FirstOrDefault(s => s.SinifId == (int)cmbboxSiniflar.SelectedValue);
            //}

            Form2 frm2 = new Form2(ogrenci, dersler);
            frm2.Show();
            Hide();
        }


        private void HandleDersAction(ActionType actionType)
        {
            string dersKodu = txtboxDersKodu.Text;
            string dersAdi = txtboxDersAdi.Text;

            if (string.IsNullOrWhiteSpace(dersKodu) || string.IsNullOrWhiteSpace(dersAdi))
            {
                HataMesaji("Lütfen tüm alanlarý doldurduðunuzdan emin olun.");
                return;
            }
            using (var ctx = new OgrenciModel())
            {
                try
                {
                    var drs = ctx.Dersler.FirstOrDefault(d => d.DersKod == dersKodu);

                    if (actionType == ActionType.Add)
                    {
                        if (drs != null)
                        {
                            HataMesaji("Bu ders kodu zaten mevcut.");
                            return;
                        }

                        ctx.Dersler.Add(new Ders { DersKod = dersKodu, DersAd = dersAdi });
                        ctx.SaveChanges();
                        MessageBox.Show("Ders baþarýyla eklendi.");
                    }
                    else if (actionType == ActionType.Update && drs != null)
                    {
                        drs.DersAd = dersAdi;
                        ctx.SaveChanges();
                        MessageBox.Show("Ders baþarýyla güncellendi");
                    }
                    else if (actionType == ActionType.Delete && drs != null)
                    {
                        ctx.Dersler.Remove(drs);
                        ctx.SaveChanges();
                        MessageBox.Show("Ders baþarýyla silindi");
                    }
                    else
                    {
                        HataMesaji("Ders bulunamadý.");
                    }
                    Temizle();
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata oluþtu: {ex.Message}");
                }
            }
        }

        private enum ActionType
        {
            Add,
            Update,
            Delete
        }

        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            HandleDersAction(ActionType.Add);
        }

        private void btnDersGuncelle_Click(object sender, EventArgs e)
        {
            HandleDersAction(ActionType.Update);
        }

        private void btnDersSil_Click(object sender, EventArgs e)
        {
            HandleDersAction(ActionType.Delete);
        }

        private void btnDersBul_Click(object sender, EventArgs e)
        {
            string dersKodu = txtboxDersKodu.Text;

            if (string.IsNullOrWhiteSpace(dersKodu))
            {
                HataMesaji("Lütfen bir ders kodu giriniz.");
                return;
            }

            using (var ctx = new OgrenciModel())
            {
                var drs = ctx.Dersler.FirstOrDefault(d => d.DersKod == dersKodu);
                if (drs != null)
                {
                    txtboxDersAdi.Text = drs.DersAd;
                }
                else
                {
                    HataMesaji("Böyle bir ders bulunamadý.");
                }
            }
        }

        private void btnSinifEkle_Click(object sender, EventArgs e)
        {
            string sinifAdi = txtboxSinifAd.Text;
            if (string.IsNullOrWhiteSpace(sinifAdi) || !int.TryParse(txtboxKontenjan.Text, out int kontenjan))
            {
                HataMesaji("Lütfen tüm alanlarý doðru þekilde doldurduðunuzdan emin olun.");
                return;
            }

            var sinif = new Sinif { SinifAd = sinifAdi, Kontenjan = kontenjan };
            using (var ctx = new OgrenciModel())
            {
                try
                {
                    ctx.Siniflar.Add(sinif);
                    ctx.SaveChanges();
                    MessageBox.Show("Sýnýf baþarýyla eklendi.");
                    Temizle();
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata oluþtu: {ex.Message}");
                }
            }
        }

        private void btnSinifSil_Click(object sender, EventArgs e)
        {
            string sinifAd = txtboxSinifAd.Text;
            if (string.IsNullOrWhiteSpace(sinifAd))
            {
                HataMesaji("Lütfen bir sýnýf adý giriniz.");
                return;
            }

            using (var ctx = new OgrenciModel())
            {
                try
                {
                    var sinif = ctx.Siniflar.FirstOrDefault(s => s.SinifAd == sinifAd);
                    if (sinif != null)
                    {
                        ctx.Siniflar.Remove(sinif);
                        ctx.SaveChanges();
                        MessageBox.Show("Sýnýf baþarýyla silindi");
                        Temizle();
                    }
                    else
                    {
                        HataMesaji("Böyle bir sýnýf bulunamadý");
                    }
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata oluþtu: {ex.Message}");
                }
            }
        }

        private void btnSinifGuncelle_Click(object sender, EventArgs e)
        {
            string sinifAd = txtboxSinifAd.Text;
            if (string.IsNullOrWhiteSpace(sinifAd) || !int.TryParse(txtboxKontenjan.Text, out int kontenjan))
            {
                HataMesaji("Lütfen tüm alanlarý doðru þekilde doldurduðunuzdan emin olun.");
                return;
            }

            using (var ctx = new OgrenciModel())
            {
                try
                {
                    var sinif = ctx.Siniflar.FirstOrDefault(s => s.SinifAd == sinifAd);
                    if (sinif != null)
                    {
                        sinif.Kontenjan = kontenjan;
                        ctx.SaveChanges();
                        MessageBox.Show("Sýnýf baþarýyla güncellendi");
                        Temizle();
                    }
                    else
                    {
                        HataMesaji("Böyle bir sýnýf bulunamadý");
                    }
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata oluþtu: {ex.Message}");
                }
            }
        }

        private void btnSinifBul_Click(object sender, EventArgs e)
        {
            string sinifAd = txtboxSinifAd.Text;

            if (string.IsNullOrWhiteSpace(sinifAd))
            {
                HataMesaji("Lütfen bir sýnýf adý giriniz.");
                return;
            }

            using (var ctx = new OgrenciModel())
            {
                try
                {
                    var sinif = ctx.Siniflar.FirstOrDefault(s => s.SinifAd == sinifAd);
                    if (sinif != null)
                    {
                        txtboxSinifAd.Text = sinif.SinifAd;
                        txtboxKontenjan.Text = sinif.Kontenjan.ToString();
                    }
                    else
                    {
                        HataMesaji("Böyle bir sýnýf bulunamadý");
                    }
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata oluþtu: {ex.Message}");
                }
            }
        }
    }
}
