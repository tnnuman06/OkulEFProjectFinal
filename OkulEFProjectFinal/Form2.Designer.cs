namespace OkulEFProjectFinal
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDersListeleme = new Label();
            dataGridView_dersler = new DataGridView();
            lblOgrenciBilgileriGelenDeger = new Label();
            btnOgrenciDersKayit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_dersler).BeginInit();
            SuspendLayout();
            // 
            // lblDersListeleme
            // 
            lblDersListeleme.AutoSize = true;
            lblDersListeleme.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDersListeleme.Location = new Point(69, 82);
            lblDersListeleme.Name = "lblDersListeleme";
            lblDersListeleme.Size = new Size(51, 15);
            lblDersListeleme.TabIndex = 5;
            lblDersListeleme.Text = "Dersler:";
            // 
            // dataGridView_dersler
            // 
            dataGridView_dersler.AllowUserToAddRows = false;
            dataGridView_dersler.AllowUserToDeleteRows = false;
            dataGridView_dersler.AllowUserToResizeColumns = false;
            dataGridView_dersler.AllowUserToResizeRows = false;
            dataGridView_dersler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_dersler.BackgroundColor = SystemColors.Window;
            dataGridView_dersler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_dersler.Location = new Point(69, 119);
            dataGridView_dersler.Name = "dataGridView_dersler";
            dataGridView_dersler.ReadOnly = true;
            dataGridView_dersler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_dersler.Size = new Size(662, 249);
            dataGridView_dersler.TabIndex = 4;
            // 
            // lblOgrenciBilgileriGelenDeger
            // 
            lblOgrenciBilgileriGelenDeger.AutoSize = true;
            lblOgrenciBilgileriGelenDeger.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOgrenciBilgileriGelenDeger.Location = new Point(69, 46);
            lblOgrenciBilgileriGelenDeger.Name = "lblOgrenciBilgileriGelenDeger";
            lblOgrenciBilgileriGelenDeger.Size = new Size(201, 15);
            lblOgrenciBilgileriGelenDeger.TabIndex = 3;
            lblOgrenciBilgileriGelenDeger.Text = "Öğrenci  bilgileri bu label e gelecek";
            lblOgrenciBilgileriGelenDeger.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnOgrenciDersKayit
            // 
            btnOgrenciDersKayit.Location = new Point(327, 396);
            btnOgrenciDersKayit.Name = "btnOgrenciDersKayit";
            btnOgrenciDersKayit.Size = new Size(165, 23);
            btnOgrenciDersKayit.TabIndex = 6;
            btnOgrenciDersKayit.Text = "Öğrencinin Derslerini Kaydet";
            btnOgrenciDersKayit.UseVisualStyleBackColor = true;
            btnOgrenciDersKayit.Click += dersleriKaydet;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOgrenciDersKayit);
            Controls.Add(lblDersListeleme);
            Controls.Add(dataGridView_dersler);
            Controls.Add(lblOgrenciBilgileriGelenDeger);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView_dersler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDersListeleme;
        private DataGridView dataGridView_dersler;
        private Label lblOgrenciBilgileriGelenDeger;
        private Button btnOgrenciDersKayit;
    }
}