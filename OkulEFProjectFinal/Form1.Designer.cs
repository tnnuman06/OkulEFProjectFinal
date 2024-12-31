namespace OkulEFProjectFinal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDersSecimi = new Button();
            btnGuncelle = new Button();
            btnBul = new Button();
            btnEkle = new Button();
            grpboxOgrenciEkle = new GroupBox();
            btnSil = new Button();
            cmbboxSiniflar = new ComboBox();
            lblDersler = new Label();
            txtNumara = new TextBox();
            lblNumara = new Label();
            txtboxSoyad = new TextBox();
            lblSoyad = new Label();
            txtboxAd = new TextBox();
            lblAd = new Label();
            grpboxSinifEkle = new GroupBox();
            btnSinifEkle = new Button();
            btnSinifSil = new Button();
            btnSinifGuncelle = new Button();
            btnSinifBul = new Button();
            txtboxKontenjan = new TextBox();
            lblKontenjan = new Label();
            txtboxSinifAd = new TextBox();
            lblSinifAd = new Label();
            tabcontrol_Ogrenci = new TabControl();
            tabPageOgrenci = new TabPage();
            tabPageDers = new TabPage();
            grpboxDersEkle = new GroupBox();
            btnDersEkle = new Button();
            btnDersSil = new Button();
            btnDersGuncelle = new Button();
            btnDersBul = new Button();
            txtboxDersKodu = new TextBox();
            label1 = new Label();
            txtboxDersAdi = new TextBox();
            label2 = new Label();
            tabPageSinif = new TabPage();
            grpboxOgrenciEkle.SuspendLayout();
            grpboxSinifEkle.SuspendLayout();
            tabcontrol_Ogrenci.SuspendLayout();
            tabPageOgrenci.SuspendLayout();
            tabPageDers.SuspendLayout();
            grpboxDersEkle.SuspendLayout();
            tabPageSinif.SuspendLayout();
            SuspendLayout();
            // 
            // btnDersSecimi
            // 
            btnDersSecimi.Location = new Point(154, 276);
            btnDersSecimi.Name = "btnDersSecimi";
            btnDersSecimi.Size = new Size(84, 23);
            btnDersSecimi.TabIndex = 12;
            btnDersSecimi.Text = "Ders Seçimi";
            btnDersSecimi.UseVisualStyleBackColor = true;
            btnDersSecimi.Click += btnDersSecimi_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(186, 176);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(84, 23);
            btnGuncelle.TabIndex = 11;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnBul
            // 
            btnBul.Location = new Point(276, 176);
            btnBul.Name = "btnBul";
            btnBul.Size = new Size(84, 23);
            btnBul.TabIndex = 10;
            btnBul.Text = "Bul";
            btnBul.UseVisualStyleBackColor = true;
            btnBul.Click += btnBul_Click;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(6, 176);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(84, 23);
            btnEkle.TabIndex = 9;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // grpboxOgrenciEkle
            // 
            grpboxOgrenciEkle.Controls.Add(btnSil);
            grpboxOgrenciEkle.Controls.Add(cmbboxSiniflar);
            grpboxOgrenciEkle.Controls.Add(btnBul);
            grpboxOgrenciEkle.Controls.Add(btnGuncelle);
            grpboxOgrenciEkle.Controls.Add(btnEkle);
            grpboxOgrenciEkle.Controls.Add(lblDersler);
            grpboxOgrenciEkle.Controls.Add(txtNumara);
            grpboxOgrenciEkle.Controls.Add(lblNumara);
            grpboxOgrenciEkle.Controls.Add(txtboxSoyad);
            grpboxOgrenciEkle.Controls.Add(lblSoyad);
            grpboxOgrenciEkle.Controls.Add(txtboxAd);
            grpboxOgrenciEkle.Controls.Add(lblAd);
            grpboxOgrenciEkle.Location = new Point(6, 6);
            grpboxOgrenciEkle.Name = "grpboxOgrenciEkle";
            grpboxOgrenciEkle.Size = new Size(373, 221);
            grpboxOgrenciEkle.TabIndex = 8;
            grpboxOgrenciEkle.TabStop = false;
            grpboxOgrenciEkle.Text = "Öğrenci Ekleme";
            // 
            // btnSil
            // 
            btnSil.Location = new Point(96, 176);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(84, 23);
            btnSil.TabIndex = 12;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // cmbboxSiniflar
            // 
            cmbboxSiniflar.FormattingEnabled = true;
            cmbboxSiniflar.Location = new Point(132, 128);
            cmbboxSiniflar.Name = "cmbboxSiniflar";
            cmbboxSiniflar.Size = new Size(121, 23);
            cmbboxSiniflar.TabIndex = 8;
            // 
            // lblDersler
            // 
            lblDersler.AutoSize = true;
            lblDersler.Location = new Point(50, 132);
            lblDersler.Name = "lblDersler";
            lblDersler.Size = new Size(54, 15);
            lblDersler.TabIndex = 6;
            lblDersler.Text = "Sınıf Seç:";
            // 
            // txtNumara
            // 
            txtNumara.Location = new Point(132, 99);
            txtNumara.Name = "txtNumara";
            txtNumara.Size = new Size(121, 23);
            txtNumara.TabIndex = 5;
            // 
            // lblNumara
            // 
            lblNumara.AutoSize = true;
            lblNumara.Location = new Point(51, 103);
            lblNumara.Name = "lblNumara";
            lblNumara.Size = new Size(53, 15);
            lblNumara.TabIndex = 4;
            lblNumara.Text = "Numara:";
            // 
            // txtboxSoyad
            // 
            txtboxSoyad.Location = new Point(132, 70);
            txtboxSoyad.Name = "txtboxSoyad";
            txtboxSoyad.Size = new Size(121, 23);
            txtboxSoyad.TabIndex = 3;
            // 
            // lblSoyad
            // 
            lblSoyad.AutoSize = true;
            lblSoyad.Location = new Point(62, 74);
            lblSoyad.Name = "lblSoyad";
            lblSoyad.Size = new Size(42, 15);
            lblSoyad.TabIndex = 2;
            lblSoyad.Text = "Soyad:";
            // 
            // txtboxAd
            // 
            txtboxAd.Location = new Point(132, 37);
            txtboxAd.Name = "txtboxAd";
            txtboxAd.Size = new Size(121, 23);
            txtboxAd.TabIndex = 1;
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Location = new Point(79, 41);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(25, 15);
            lblAd.TabIndex = 0;
            lblAd.Text = "Ad:";
            // 
            // grpboxSinifEkle
            // 
            grpboxSinifEkle.Controls.Add(btnSinifEkle);
            grpboxSinifEkle.Controls.Add(btnSinifSil);
            grpboxSinifEkle.Controls.Add(btnSinifGuncelle);
            grpboxSinifEkle.Controls.Add(btnSinifBul);
            grpboxSinifEkle.Controls.Add(txtboxKontenjan);
            grpboxSinifEkle.Controls.Add(lblKontenjan);
            grpboxSinifEkle.Controls.Add(txtboxSinifAd);
            grpboxSinifEkle.Controls.Add(lblSinifAd);
            grpboxSinifEkle.Location = new Point(6, 3);
            grpboxSinifEkle.Name = "grpboxSinifEkle";
            grpboxSinifEkle.Size = new Size(370, 221);
            grpboxSinifEkle.TabIndex = 13;
            grpboxSinifEkle.TabStop = false;
            grpboxSinifEkle.Text = "Sınıf Ekleme";
            // 
            // btnSinifEkle
            // 
            btnSinifEkle.Location = new Point(5, 179);
            btnSinifEkle.Name = "btnSinifEkle";
            btnSinifEkle.Size = new Size(87, 23);
            btnSinifEkle.TabIndex = 14;
            btnSinifEkle.Text = "Ekle";
            btnSinifEkle.UseVisualStyleBackColor = true;
            btnSinifEkle.Click += btnSinifEkle_Click;
            // 
            // btnSinifSil
            // 
            btnSinifSil.Location = new Point(98, 179);
            btnSinifSil.Name = "btnSinifSil";
            btnSinifSil.Size = new Size(86, 23);
            btnSinifSil.TabIndex = 15;
            btnSinifSil.Text = "Sil";
            btnSinifSil.UseVisualStyleBackColor = true;
            btnSinifSil.Click += btnSinifSil_Click;
            // 
            // btnSinifGuncelle
            // 
            btnSinifGuncelle.Location = new Point(190, 179);
            btnSinifGuncelle.Name = "btnSinifGuncelle";
            btnSinifGuncelle.Size = new Size(83, 23);
            btnSinifGuncelle.TabIndex = 16;
            btnSinifGuncelle.Text = "Güncelle";
            btnSinifGuncelle.UseVisualStyleBackColor = true;
            btnSinifGuncelle.Click += btnSinifGuncelle_Click;
            // 
            // btnSinifBul
            // 
            btnSinifBul.Location = new Point(279, 179);
            btnSinifBul.Name = "btnSinifBul";
            btnSinifBul.Size = new Size(83, 23);
            btnSinifBul.TabIndex = 17;
            btnSinifBul.Text = "Bul";
            btnSinifBul.UseVisualStyleBackColor = true;
            btnSinifBul.Click += btnSinifBul_Click;
            // 
            // txtboxKontenjan
            // 
            txtboxKontenjan.Location = new Point(161, 89);
            txtboxKontenjan.Name = "txtboxKontenjan";
            txtboxKontenjan.Size = new Size(121, 23);
            txtboxKontenjan.TabIndex = 3;
            // 
            // lblKontenjan
            // 
            lblKontenjan.AutoSize = true;
            lblKontenjan.Location = new Point(91, 93);
            lblKontenjan.Name = "lblKontenjan";
            lblKontenjan.Size = new Size(64, 15);
            lblKontenjan.TabIndex = 2;
            lblKontenjan.Text = "Kontenjan:";
            // 
            // txtboxSinifAd
            // 
            txtboxSinifAd.Location = new Point(161, 56);
            txtboxSinifAd.Name = "txtboxSinifAd";
            txtboxSinifAd.Size = new Size(121, 23);
            txtboxSinifAd.TabIndex = 1;
            // 
            // lblSinifAd
            // 
            lblSinifAd.AutoSize = true;
            lblSinifAd.Location = new Point(101, 59);
            lblSinifAd.Name = "lblSinifAd";
            lblSinifAd.Size = new Size(51, 15);
            lblSinifAd.TabIndex = 0;
            lblSinifAd.Text = "Sınıf Ad:";
            // 
            // tabcontrol_Ogrenci
            // 
            tabcontrol_Ogrenci.Controls.Add(tabPageOgrenci);
            tabcontrol_Ogrenci.Controls.Add(tabPageDers);
            tabcontrol_Ogrenci.Controls.Add(tabPageSinif);
            tabcontrol_Ogrenci.Location = new Point(12, 12);
            tabcontrol_Ogrenci.Name = "tabcontrol_Ogrenci";
            tabcontrol_Ogrenci.SelectedIndex = 0;
            tabcontrol_Ogrenci.Size = new Size(390, 258);
            tabcontrol_Ogrenci.TabIndex = 4;
            // 
            // tabPageOgrenci
            // 
            tabPageOgrenci.Controls.Add(grpboxOgrenciEkle);
            tabPageOgrenci.Location = new Point(4, 24);
            tabPageOgrenci.Name = "tabPageOgrenci";
            tabPageOgrenci.Padding = new Padding(3);
            tabPageOgrenci.Size = new Size(382, 230);
            tabPageOgrenci.TabIndex = 0;
            tabPageOgrenci.Text = "Öğrenciler";
            tabPageOgrenci.UseVisualStyleBackColor = true;
            // 
            // tabPageDers
            // 
            tabPageDers.Controls.Add(grpboxDersEkle);
            tabPageDers.Location = new Point(4, 24);
            tabPageDers.Name = "tabPageDers";
            tabPageDers.Padding = new Padding(3);
            tabPageDers.Size = new Size(382, 230);
            tabPageDers.TabIndex = 1;
            tabPageDers.Text = "Dersler";
            tabPageDers.UseVisualStyleBackColor = true;
            // 
            // grpboxDersEkle
            // 
            grpboxDersEkle.Controls.Add(btnDersEkle);
            grpboxDersEkle.Controls.Add(btnDersSil);
            grpboxDersEkle.Controls.Add(btnDersGuncelle);
            grpboxDersEkle.Controls.Add(btnDersBul);
            grpboxDersEkle.Controls.Add(txtboxDersKodu);
            grpboxDersEkle.Controls.Add(label1);
            grpboxDersEkle.Controls.Add(txtboxDersAdi);
            grpboxDersEkle.Controls.Add(label2);
            grpboxDersEkle.Location = new Point(6, 3);
            grpboxDersEkle.Name = "grpboxDersEkle";
            grpboxDersEkle.Size = new Size(370, 224);
            grpboxDersEkle.TabIndex = 14;
            grpboxDersEkle.TabStop = false;
            grpboxDersEkle.Text = "Sınıf Ekleme";
            // 
            // btnDersEkle
            // 
            btnDersEkle.Location = new Point(6, 179);
            btnDersEkle.Name = "btnDersEkle";
            btnDersEkle.Size = new Size(84, 23);
            btnDersEkle.TabIndex = 15;
            btnDersEkle.Text = "Ekle";
            btnDersEkle.UseVisualStyleBackColor = true;
            btnDersEkle.Click += btnDersEkle_Click;
            // 
            // btnDersSil
            // 
            btnDersSil.Location = new Point(96, 179);
            btnDersSil.Name = "btnDersSil";
            btnDersSil.Size = new Size(84, 23);
            btnDersSil.TabIndex = 16;
            btnDersSil.Text = "Sil";
            btnDersSil.UseVisualStyleBackColor = true;
            btnDersSil.Click += btnDersSil_Click;
            // 
            // btnDersGuncelle
            // 
            btnDersGuncelle.Location = new Point(186, 179);
            btnDersGuncelle.Name = "btnDersGuncelle";
            btnDersGuncelle.Size = new Size(84, 23);
            btnDersGuncelle.TabIndex = 17;
            btnDersGuncelle.Text = "Güncelle";
            btnDersGuncelle.UseVisualStyleBackColor = true;
            btnDersGuncelle.Click += btnDersGuncelle_Click;
            // 
            // btnDersBul
            // 
            btnDersBul.Location = new Point(276, 179);
            btnDersBul.Name = "btnDersBul";
            btnDersBul.Size = new Size(87, 23);
            btnDersBul.TabIndex = 18;
            btnDersBul.Text = "Bul";
            btnDersBul.UseVisualStyleBackColor = true;
            btnDersBul.Click += btnDersBul_Click;
            // 
            // txtboxDersKodu
            // 
            txtboxDersKodu.Location = new Point(161, 89);
            txtboxDersKodu.Name = "txtboxDersKodu";
            txtboxDersKodu.Size = new Size(121, 23);
            txtboxDersKodu.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 93);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 2;
            label1.Text = "Ders Kod:";
            // 
            // txtboxDersAdi
            // 
            txtboxDersAdi.Location = new Point(161, 56);
            txtboxDersAdi.Name = "txtboxDersAdi";
            txtboxDersAdi.Size = new Size(121, 23);
            txtboxDersAdi.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 60);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 0;
            label2.Text = "Ders Ad:";
            // 
            // tabPageSinif
            // 
            tabPageSinif.Controls.Add(grpboxSinifEkle);
            tabPageSinif.Location = new Point(4, 24);
            tabPageSinif.Name = "tabPageSinif";
            tabPageSinif.Padding = new Padding(3);
            tabPageSinif.Size = new Size(382, 230);
            tabPageSinif.TabIndex = 2;
            tabPageSinif.Text = "Sınıflar";
            tabPageSinif.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 304);
            Controls.Add(tabcontrol_Ogrenci);
            Controls.Add(btnDersSecimi);
            Name = "Form1";
            Text = "Form1";
            grpboxOgrenciEkle.ResumeLayout(false);
            grpboxOgrenciEkle.PerformLayout();
            grpboxSinifEkle.ResumeLayout(false);
            grpboxSinifEkle.PerformLayout();
            tabcontrol_Ogrenci.ResumeLayout(false);
            tabPageOgrenci.ResumeLayout(false);
            tabPageDers.ResumeLayout(false);
            grpboxDersEkle.ResumeLayout(false);
            grpboxDersEkle.PerformLayout();
            tabPageSinif.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnDersSecimi;
        private Button btnGuncelle;
        private Button btnBul;
        private Button btnEkle;
        private GroupBox grpboxOgrenciEkle;
        private ComboBox cmbboxSiniflar;
        private Label lblDersler;
        private TextBox txtNumara;
        private Label lblNumara;
        private TextBox txtboxSoyad;
        private Label lblSoyad;
        private TextBox txtboxAd;
        private Label lblAd;
        private GroupBox grpboxSinifEkle;
        private TextBox txtboxKontenjan;
        private Label lblKontenjan;
        private TextBox txtboxSinifAd;
        private Label lblSinifAd;
        private TabControl tabcontrol_Ogrenci;
        private TabPage tabPageOgrenci;
        private TabPage tabPageDers;
        private TabPage tabPageSinif;
        private GroupBox grpboxDersEkle;
        private TextBox txtboxDersKodu;
        private Label label1;
        private TextBox txtboxDersAdi;
        private Label label2;
        private Button btnSil;
        private Button btnDersEkle;
        private Button btnDersSil;
        private Button btnDersGuncelle;
        private Button btnDersBul;
        private Button btnSinifEkle;
        private Button btnSinifSil;
        private Button btnSinifGuncelle;
        private Button btnSinifBul;
    }
}
