using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDP_Odev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cikisToolStripMenuItem.Click += new EventHandler(cikisToolStripMenuItem_Click);
        }
        //Fontlari ayarladigimiz bir fonksiyon
        public void FontAyari()
        {
            //fontdialog kontrolu olusturup bu kontrolle yazilarimizin fontunu degisebiliriz.
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fontDialog.Font;
        }


        //Dosya acma komutlarinin bulundugu bir fonksiyon
        public void DosyaAcma()
        { 
            //acacagimiz doysayi hafizadan seciyoruz ve eger dogru uzantida dosya sectiysek dosya icerigini richtextboxa aktariyor.
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Dosya seçiniz";
            dialog.Filter = "Metin dosyası(*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(dialog.FileName);
            }
        }


        //Dosya acma stripMenu`nu fonksiyonla kullanma
        private void dosyaAcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaAcma();
        }


        //Dosya kaydetme stripMenu`nu fonksiyonla kullanma
        private void dosyaKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaKaydet();
        }


        //Dosya kaydetme Fonksiyonlari
        public void DosyaKaydet()
        { 
            //SaveFileDialog kontrolunu olusturup doysayi nasil kaydedecegimizi ayarliyorum ve eger dosya kaydolmasi tamamlandiysa ekrana buna uygun bildiri veriyor.
            SaveFileDialog sfd = new SaveFileDialog();
            saveFileDialog1.Title = "Txt olarak kaydetme";
            saveFileDialog1.FileName = "Isim belirleyiniz";
            saveFileDialog1.Filter = "Metin dosyası(*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("Kayıt tamamlandı");
            }
        }


        //Dosya kaydetme butonlarindan  birisi
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DosyaKaydet();
        }


        //Richtextboxun zemin rengini colordialog kontrolu ile degistirmek icin kullandim
        public void ZeminRengi()
        {
            ColorDialog RenkSec = new ColorDialog();
            if (RenkSec.ShowDialog() == DialogResult.OK) // colordialog'tan bir renk seçildiyse işlem yapılacak.
            {
                richTextBox1.BackColor = RenkSec.Color;
            }
        }


        //zemin rengi degisme
        private void zeminRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZeminRengi();
        }


        //yazdigim yazilari color dialog ile rengini degistim(burada fore color kullandim zemin rengindeyse backcolor)
        public void YaziRengi()
        {
            ColorDialog RenkSec = new ColorDialog();
            if (RenkSec.ShowDialog() == DialogResult.OK) // colordialog'tan bir renk seçildiyse işlem yapılacak.
            {
                richTextBox1.ForeColor = RenkSec.Color;
            }
        }

        
        private void yaziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YaziRengi();
        }

        private void yaziCesitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontAyari();
        }

        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Kaydettiğinize emin misiniz?", "Uygulamadan çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Çıkış Yapılıyor...");
                Application.Exit();
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                saveFileDialog1.Title = "Txt olarak kaydetme";
                saveFileDialog1.FileName = "Isim belirleyiniz";
                saveFileDialog1.Filter = "Metin dosyası(*.txt)|*.txt";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Kayıt tamamlandı");
                }
            }
        }

        private void renkToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            YaziRengi();
        }

        //kesme komutlari bulunuyor
        public void Kesme()
        { 
            //eger imlecle sectigim text bos degilse sectigim yaziyi clipboarda ata ve richtextboxtan kaldir
            if (richTextBox1.SelectedText != string.Empty)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.Cut();
            }
        }


        //Yapistir(clipboarda atadigimiz veriyi richtextboxa Yapistir)
        public void Yapistir()
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }


        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontAyari();
        }

        private void kesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kesme();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yapistir();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Kesme();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kesme();
        }
    }
}

