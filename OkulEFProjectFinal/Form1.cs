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
                HataMesaji("T�m alanlar�n doldurulmas� zorunludur");
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
                            MessageBox.Show("��lem ba�ar�yla kay�t edildi");
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
                HataMesaji($"Beklenmeyen bir �ey olu�tu. Hata: {ex.Message}");
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumara.Text, out int numara))
            {
                HataMesaji("Ge�erli bir numara giriniz!");
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
                    HataMesaji("B�yle bir ��renci bulunamad�");
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxAd.Text) ||
                string.IsNullOrWhiteSpace(txtboxSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtNumara.Text))
            {
                HataMesaji("L�tfen t�m alanlar� doldurunuz.");
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

                        MessageBox.Show("��renci ba�ar�yla g�ncellendi.");
                        Temizle();
                    }
                    else
                    {
                        HataMesaji("B�yle bir ��renci bulunamad�.");
                    }
                }
            }
            catch (Exception ex)
            {
                HataMesaji($"Beklenmeyen bir hata olu�tu: {ex.Message}");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumara.Text, out int numara))
            {
                HataMesaji("L�tfen ge�erli bir numara giriniz.");
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
                        MessageBox.Show("��renci ba�ar�l� bir �ekilde silindi.");
                        Temizle();
                    }
                    else
                    {
                        HataMesaji("B�yle bir ��renci bulunamad�.");
                    }
                }
            }
            catch (Exception ex)
            {
                HataMesaji($"Beklenmeyen bir hata olu�tu: {ex.Message}");
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
            //    Console.WriteLine($"Ders Ad�: {ders.DersAd}, Ders Kodu: {ders.DersKod}");
            //}

            //// E�er dersler null veya bo�sa, hatay� burada kontrol edebilirsiniz
            //if (dersler == null || dersler.Count == 0)
            //{
            //    MessageBox.Show("Dersler al�namad�.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                HataMesaji("L�tfen t�m alanlar� doldurdu�unuzdan emin olun.");
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
                        MessageBox.Show("Ders ba�ar�yla eklendi.");
                    }
                    else if (actionType == ActionType.Update && drs != null)
                    {
                        drs.DersAd = dersAdi;
                        ctx.SaveChanges();
                        MessageBox.Show("Ders ba�ar�yla g�ncellendi");
                    }
                    else if (actionType == ActionType.Delete && drs != null)
                    {
                        ctx.Dersler.Remove(drs);
                        ctx.SaveChanges();
                        MessageBox.Show("Ders ba�ar�yla silindi");
                    }
                    else
                    {
                        HataMesaji("Ders bulunamad�.");
                    }
                    Temizle();
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata olu�tu: {ex.Message}");
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
                HataMesaji("L�tfen bir ders kodu giriniz.");
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
                    HataMesaji("B�yle bir ders bulunamad�.");
                }
            }
        }

        private void btnSinifEkle_Click(object sender, EventArgs e)
        {
            string sinifAdi = txtboxSinifAd.Text;
            if (string.IsNullOrWhiteSpace(sinifAdi) || !int.TryParse(txtboxKontenjan.Text, out int kontenjan))
            {
                HataMesaji("L�tfen t�m alanlar� do�ru �ekilde doldurdu�unuzdan emin olun.");
                return;
            }

            var sinif = new Sinif { SinifAd = sinifAdi, Kontenjan = kontenjan };
            using (var ctx = new OgrenciModel())
            {
                try
                {
                    ctx.Siniflar.Add(sinif);
                    ctx.SaveChanges();
                    MessageBox.Show("S�n�f ba�ar�yla eklendi.");
                    Temizle();
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata olu�tu: {ex.Message}");
                }
            }
        }

        private void btnSinifSil_Click(object sender, EventArgs e)
        {
            string sinifAd = txtboxSinifAd.Text;
            if (string.IsNullOrWhiteSpace(sinifAd))
            {
                HataMesaji("L�tfen bir s�n�f ad� giriniz.");
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
                        MessageBox.Show("S�n�f ba�ar�yla silindi");
                        Temizle();
                    }
                    else
                    {
                        HataMesaji("B�yle bir s�n�f bulunamad�");
                    }
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata olu�tu: {ex.Message}");
                }
            }
        }

        private void btnSinifGuncelle_Click(object sender, EventArgs e)
        {
            string sinifAd = txtboxSinifAd.Text;
            if (string.IsNullOrWhiteSpace(sinifAd) || !int.TryParse(txtboxKontenjan.Text, out int kontenjan))
            {
                HataMesaji("L�tfen t�m alanlar� do�ru �ekilde doldurdu�unuzdan emin olun.");
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
                        MessageBox.Show("S�n�f ba�ar�yla g�ncellendi");
                        Temizle();
                    }
                    else
                    {
                        HataMesaji("B�yle bir s�n�f bulunamad�");
                    }
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata olu�tu: {ex.Message}");
                }
            }
        }

        private void btnSinifBul_Click(object sender, EventArgs e)
        {
            string sinifAd = txtboxSinifAd.Text;

            if (string.IsNullOrWhiteSpace(sinifAd))
            {
                HataMesaji("L�tfen bir s�n�f ad� giriniz.");
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
                        HataMesaji("B�yle bir s�n�f bulunamad�");
                    }
                }
                catch (Exception ex)
                {
                    HataMesaji($"Beklenmeyen bir hata olu�tu: {ex.Message}");
                }
            }
        }
    }
}
