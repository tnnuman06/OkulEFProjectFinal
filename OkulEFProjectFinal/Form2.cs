using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulEFProjectFinal
{
    public partial class Form2 : Form
    {
        private Ogrenci ogrenci;
        private List<Ders> dersler;

        public Form2(Ogrenci ogrenci, List<Ders> dersler)
        {
            InitializeComponent();

            // Öğrenci ve dersleri al
            this.ogrenci = ogrenci ?? throw new ArgumentNullException(nameof(ogrenci));
            this.dersler = dersler ?? throw new ArgumentNullException(nameof(dersler));

            if (this.dersler == null || !this.dersler.Any())
            {
                MessageBox.Show("Dersler listesi boş veya null.");
                return;
            }
            dataGridView_dersler.MultiSelect = true;
            lblOgrenciBilgileriGelenDeger.Text = $"Öğrenci: {ogrenci.Ad} {ogrenci.Soyad} {ogrenci.Numara}";

            dataGridView_dersler.DataSource = dersler;
            dataGridView_dersler.Columns["OgrenciDersler"].Visible = false;
            dataGridView_dersler.Columns["DersId"].Visible = false;
        }

        void dersleriKaydet(object sender,EventArgs e)
        {
            using (var ctx=new OgrenciModel()) 
            {
                var satirList = dataGridView_dersler.SelectedRows;
                foreach (DataGridViewRow row in satirList)
                {
                    if (row != null)
                    {
                        Ders ders = row.DataBoundItem as Ders;
                        if (ders != null)
                        {
                            OgrenciDers dersKaydi = new OgrenciDers
                            {
                                OgrenciId = ogrenci.Id,
                                DersId = ders.DersId
                            };
                            ctx.OgrenciDersler.Add(dersKaydi);
                        }
                    }
                }
                ctx.SaveChanges();
                var denemeList=ctx.OgrenciDersler.ToList();
            }  
             
        }
    }
}
