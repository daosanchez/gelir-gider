using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gelir_gider_1313
{
    public partial class Form1 : Form
    {
        BindingList<Islem> islemler = new BindingList<Islem>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string tanım = txtTanim.Text;
            string tur = cmbTur.Text;
            DateTime KayitTarih = DateTime.Now;
            string miktar = numMiktar.Text;
            bool gelir = cbGelir.Checked;

            Islem islem = new Islem(id, tanım, tur, KayitTarih, miktar, gelir);

            islemler.Add(islem);



            txtId.Clear();
            txtTanim.Clear();
            cmbTur.Items.Clear();
            cbGelir.Checked = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Islem islem1 = new Islem(1, "Maaş", "Su", new DateTime(2023, 11, 05), "800", false);
            Islem islem2 = new Islem(2, "Fatura", "Hastane", new DateTime(2023, 10, 05), "500", true);
            Islem islem3 = new Islem(3, "Ek Gelir", "Elektrik", new DateTime(2023, 11, 15), "400", false);
            Islem islem4 = new Islem(4, "Kira", "Ekim", new DateTime(2023, 09, 05), "3000", true);
            Islem islem5 = new Islem(5, "Kira", "Mesai", new DateTime(2023, 10, 15), "900", false);



            islemler.Add(islem1);
            islemler.Add(islem2);
            islemler.Add(islem3);
            islemler.Add(islem4);
            islemler.Add(islem5);

            dtvİsimler.DataSource = islemler;

        }

       
            
        

        

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dtvİsimler.SelectedRows.Count > 0)
            {
                Islem islem = (Islem)dtvİsimler.SelectedRows[0].DataBoundItem;


                DialogResult sonuc = MessageBox.Show(islem.Gelir + " Silinsin mi?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {

                    islemler.Remove(islem);

                }


            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtvİsimler_SelectionChanged(object sender, EventArgs e)
        {
            if (dtvİsimler.SelectedRows.Count > 0)
            {
                Islem islem = (Islem)dtvİsimler.SelectedRows[0].DataBoundItem;

                txtId.Text = islem.Id.ToString();
                txtTanim.Text = islem.Tanim;
                cmbTur.Text = islem.Tur;
                dtTarih.Value = islem.Tarih;
                numMiktar.Text = islem.Miktar;
                cbGelir.Checked = islem.Gelir;

            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dtvİsimler.SelectedRows.Count > 0)
            {
                Islem islem = (Islem)dtvİsimler.SelectedRows[0].DataBoundItem;


                islem.Tanim = txtTanim.Text;
                islem.Tur = cmbTur.SelectedText;
                islem.Tarih = dtTarih.Value;
                islem.Miktar = numMiktar.Text;
                islem.Gelir = cbGelir.Checked;


                dtvİsimler.Refresh();
            }
        }
    }
}
