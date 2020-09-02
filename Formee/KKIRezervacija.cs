using AvioKompanija;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    public class KKIRezervacija
    {
        public void SacuvajRezervaciju(BindingList<Rezervacija> rezervacije, List<Rezervacija> pdfRez)
        {
            try
            {
                if (rezervacije.Count > 0)
                {

                    bool uspeh = KontrolerKorisnickogInterfejsa.Instance.ZapamtiRrezervacije(rezervacije.ToList());
                    if (uspeh)
                    {                                               
                        MessageBox.Show("Sistem je zapamtio rezervaciju!");
                        List<Rezervacija> sacuvaneRez = new List<Rezervacija>();
                        int broj = rezervacije.Count;
                        sacuvaneRez = KontrolerKorisnickogInterfejsa.Instance.UcitajRezervacije();
                        int ukupno = sacuvaneRez.Count();
                        for(int i = ukupno - broj; i < ukupno; i++)
                        {
                            pdfRez.Add(sacuvaneRez.ElementAt(i));
                        }
                        rezervacije.Clear();
                        Document doc = new Document();
                        PdfWriter.GetInstance(doc, new FileStream("C:/Users/lazam/Desktop/Karte/karta" + $"{pdfRez.ElementAt(0).RedBr}" + ".pdf", FileMode.Create));
                        doc.Open();
                        for (int i = 0; i < pdfRez.Count; i++)
                        {

                            Paragraph p = new Paragraph($"------------------------------Rezervacija {i+1}------------------------------");
                            Paragraph p1 = new Paragraph($"Rezervacija id: {pdfRez.ElementAt(i).RedBr} \n");
                            Paragraph p11 = new Paragraph($"Rezervisao: {pdfRez.ElementAt(i).Korisnik.Ime} {pdfRez.ElementAt(i).Korisnik.Prezime}");
                            Paragraph p2 = new Paragraph($"Let od: {pdfRez.ElementAt(i).Let.DestinacijaOD.Zemlja.Naziv}" + "-" + $"{pdfRez.ElementAt(i).Let.DestinacijaOD.Grad}");
                            Paragraph p22 = new Paragraph($"      do: {pdfRez.ElementAt(i).Let.DestinacijaDO.Zemlja.Naziv}" + "-" + $"{pdfRez.ElementAt(i).Let.DestinacijaDO.Grad}");
                            Paragraph p3 = new Paragraph($"Sediste: {pdfRez.ElementAt(i).Sediste.BrojSedista}");
                            Paragraph p4 = new Paragraph("-----------------------------------------------------------------------------");
                            Paragraph p5 = new Paragraph($"Datum polaska: { pdfRez.ElementAt(i).Let.DatumPolaska}");
                            Paragraph p6 = new Paragraph(" ");
                            Paragraph psp = new Paragraph(" ");
                            Paragraph psp1 = new Paragraph(" ");
                            doc.Add(p);
                            doc.Add(p1);
                            doc.Add(p11);
                            doc.Add(p2);
                            doc.Add(p22);
                            doc.Add(p3);
                            doc.Add(p5);
                            doc.Add(p4);                            
                            doc.Add(p6);
                            doc.Add(psp);
                            doc.Add(psp1);
                        }
                        doc.Close();
                        MessageBox.Show("Rezervacija je odstampana!");
                    }

                
                    else MessageBox.Show("Nema unete rezervacije");
                }
                else MessageBox.Show("Sistem ne moze da zapamti rezervaciju");


            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }

        public void Rezervisi(ComboBox cmbDestinacijeOd,ComboBox cmbDestinacijeDo,ListBox lbDatumPolaska,
            ListBox lbDatumOdl,ComboBox cmbAvion,CheckBox checkBox1, DataGridView dataGridView1,
            BindingList<Rezervacija> rezervacije, List<Avion> avioni, List<Let> letovi, Label lblSedistePocetak,Label lblSedistePov)
        {
            if (lblSedistePocetak.Text != "-")
            {
                int sifraLeta = 0;
                int sifraPovratka = 0;

                foreach (Let l in letovi)
                {
                    if (l.DestinacijaOD.Grad == (cmbDestinacijeOd.SelectedItem as Aerodrom).Grad &&
                        l.DestinacijaDO.Grad == (cmbDestinacijeDo.SelectedItem as Aerodrom).Grad &&
                        l.DatumPolaska == Convert.ToDateTime(lbDatumPolaska.Text))
                        sifraLeta = l.SifraLet;
                    if (l.DestinacijaDO.Grad == (cmbDestinacijeOd.SelectedItem as Aerodrom).Grad &&
                        l.DestinacijaOD.Grad == (cmbDestinacijeDo.SelectedItem as Aerodrom).Grad &&
                        l.DatumPolaska == Convert.ToDateTime(lbDatumOdl.Text))
                        sifraPovratka = l.SifraLet;
                }

                Let let = new Let();
                Let letPovratak = new Let();

                foreach (Let l in letovi)
                {
                    if (l.SifraLet == sifraLeta)
                    {

                        let = l;
                    }
                    if (l.SifraLet == sifraPovratka)
                    {
                        letPovratak = l;
                    }
                }
                List<Sediste> sedista = new List<Sediste>();
                sedista = KontrolerKorisnickogInterfejsa.Instance.VratiSedista(cmbAvion.SelectedItem as Avion);                
                Avion avion = new Avion();
                foreach (Avion av in avioni)
                {
                    if (letPovratak.Avion != null && av.SifraAviona == letPovratak.Avion.SifraAviona)
                    {
                        avion = av;
                    }

                }
                List<Sediste> sedistaPovratka = new List<Sediste>();
                sedistaPovratka = KontrolerKorisnickogInterfejsa.Instance.VratiSedista(avion);
                Rezervacija r = new Rezervacija();
                r.Let = let;
                r.DatumRezervacije = DateTime.Now;
                r.Odobreno = true;
                Avion a = new Avion();
                a = cmbAvion.SelectedItem as Avion;
                r.Avion = a;
                r.Korisnik = Sesija.Instance.Korisnik;
                Sediste sediste = new Sediste();
                Sediste sedistePov = new Sediste();
                foreach (Sediste s in sedista)
                {
                    if (s.BrojSedista == Convert.ToInt32(lblSedistePocetak.Text))
                    {
                        sediste = s;
                    }
                   
                }     
                foreach(Sediste s in sedistaPovratka)
                {
                    if (lblSedistePov.Text != "-")
                    {
                        if (s.BrojSedista == Convert.ToInt32(lblSedistePov.Text))
                        {
                            sedistePov = s;
                        }
                    }
                }

                r.Sediste = sediste;
                if (rezervacije.Count > 0)
                {
                    foreach (Rezervacija r1 in rezervacije)
                    {
                        if (r.Sediste.BrojSedista == r1.Sediste.BrojSedista && r.Avion.NazivAviona == r1.Avion.NazivAviona && r.Let.DestinacijaOD.Grad == r1.Let.DestinacijaOD.Grad && r.Let.DestinacijaDO.Grad == r1.Let.DestinacijaDO.Grad)
                        {
                            MessageBox.Show("Sediste je zauzeto!");
                            return;
                        }
                    }
                }
                if (checkBox1.Checked && lbDatumOdl.SelectedItem is null)
                {
                    MessageBox.Show("Ne postoji povratna karta za dati let!");
                }
                else if (Convert.ToDateTime(lbDatumOdl.SelectedItem) < Convert.ToDateTime(lbDatumPolaska.SelectedItem) && checkBox1.Checked)
                    MessageBox.Show("Datum povratka mora biti posle datuma polaska!");
                else
                {
                    if(!checkBox1.Checked) rezervacije.Add(r);
                    else if (checkBox1.Checked && lblSedistePov.Text != "-")
                    {
                            rezervacije.Add(r);
                            Rezervacija re = new Rezervacija();
                            re.Korisnik = Sesija.Instance.Korisnik;
                            re.Avion = avion;
                            re.Let = letPovratak;
                            re.DatumRezervacije = DateTime.Now;
                            re.Odobreno = true;
                            re.Sediste = sedistePov;

                            rezervacije.Add(re);
                        
                        
                    }
                    else MessageBox.Show("Morate odabrati sediste za povratni let!");
                   
                }
                dataGridView1.DataSource = rezervacije;
            }
            else { MessageBox.Show("Morate odabrati sediste!"); }
        }

        internal void Sredi(ComboBox cmbDestinacijeOd, ComboBox cmbDestinacijeDo, ComboBox cmbAvion, ListBox lbDatumPolaska)
        {
            Let l = new Let();
            l = LetSesija.Instance.OdabraniLet;
            cmbDestinacijeOd.SelectedIndex = cmbDestinacijeOd.FindStringExact(l.DestinacijaOD.Grad + "-" + l.DestinacijaOD.Zemlja.Naziv);
            cmbDestinacijeDo.SelectedIndex = cmbDestinacijeDo.FindStringExact(l.DestinacijaDO.Grad + "-" + l.DestinacijaDO.Zemlja.Naziv);
            cmbAvion.SelectedIndex = cmbAvion.FindStringExact(l.Avion.NazivAviona);
           // lbDatumPolaska.SelectedIndex = lbDatumPolaska.FindStringExact(l.DatumPolaska.ToString("M/dd/yyyy hh:mm tt"));
           
        }

        public void PromenaDestinacije(List<Let> letovi, ComboBox cmbDestinacijeOd, ComboBox cmbDestinacijeDo,
            ListBox lbDatumPolaska,ListBox lbDatumOdl, ComboBox cmbAvion, Label lblSedistePov, Label lblSedistePocetak)
        {
            lblSedistePov.Text = "-";
            lblSedistePocetak.Text = "-";
            List<DateTime> datumiPolaska = new List<DateTime>();
            List<Avion> avi = new List<Avion>();
            foreach (Let l in letovi)
            {
                if ((cmbDestinacijeOd.SelectedItem as Aerodrom).Grad == l.DestinacijaOD.Grad && (cmbDestinacijeDo.SelectedItem as Aerodrom).Grad == l.DestinacijaDO.Grad)
                {
                    if (avi.Count == 0)
                        avi.Add(l.Avion);
                    else
                    {
                        if (avi.Contains(l.Avion))
                        {
                            avi.Add(l.Avion);
                        }
                    }

                    datumiPolaska.Add(l.DatumPolaska);
                }
            }
            cmbAvion.DataSource = avi;

            lbDatumPolaska.DataSource = datumiPolaska;

            List<DateTime> datumiOdlaska = new List<DateTime>();
            foreach (Let l in letovi)
            {
                if ((cmbDestinacijeOd.SelectedItem as Aerodrom).Grad == l.DestinacijaDO.Grad && (cmbDestinacijeDo.SelectedItem as Aerodrom).Grad == l.DestinacijaOD.Grad)
                {
                    datumiOdlaska.Add(l.DatumPolaska);
                }
               ;
            }
            lbDatumOdl.DataSource = datumiOdlaska;
        }

        public void PromenaDestinacijeOd(List<Let> letovi, ComboBox cmbDestinacijeOd, ComboBox cmbDestinacijeDo,
            ListBox lbDatumPolaska, ListBox lbDatumOdl, ComboBox cmbAvion,List<Rezervacija> sveRez, Label lblSedistePocetak, Label lblSedistePov)
        {
            lblSedistePov.Text = "-";
            lblSedistePocetak.Text = "-";

            List<Aerodrom> destinacijeDo = new List<Aerodrom>();
            foreach (Let l in letovi)
            {
                int k = 0;
                if ((cmbDestinacijeOd.SelectedItem as Aerodrom).Grad == l.DestinacijaOD.Grad)
                {
                    if (destinacijeDo.Count == 0) destinacijeDo.Add(l.DestinacijaDO);
                    else
                    {
                        for (int i = 0; i < destinacijeDo.Count; i++)
                        {
                            if (destinacijeDo.ElementAt(i).Grad == l.DestinacijaDO.Grad)
                                k++;
                        }
                        if (k == 0)
                        {
                            destinacijeDo.Add(l.DestinacijaDO);
                        }
                    }
                    k = 0;
                }
            }

            cmbDestinacijeDo.DataSource = destinacijeDo;
            List<DateTime> datumiPolaska = new List<DateTime>();
            List<Avion> avi = new List<Avion>();
            foreach (Let l in letovi)
            {

                if ((cmbDestinacijeOd.SelectedItem as Aerodrom).Grad == l.DestinacijaOD.Grad && (cmbDestinacijeDo.SelectedItem as Aerodrom).Grad == l.DestinacijaDO.Grad)
                {
                    datumiPolaska.Add(l.DatumPolaska);
                    if (avi.Count == 0)
                        avi.Add(l.Avion);
                    else
                    {
                        if (avi.Contains(l.Avion))
                        {
                            avi.Add(l.Avion);
                        }
                    }
                }
            }
            cmbAvion.DataSource = avi;
            lbDatumPolaska.DataSource = datumiPolaska;

            List<DateTime> datumiOdlaska = new List<DateTime>();
            foreach (Let l in letovi)
            {
                if ((cmbDestinacijeOd.SelectedItem as Aerodrom).Grad == l.DestinacijaDO.Grad && (cmbDestinacijeDo.SelectedItem as Aerodrom).Grad == l.DestinacijaOD.Grad)
                    datumiOdlaska.Add(l.DatumPolaska);

            }
            lbDatumOdl.DataSource = datumiOdlaska;
        
        }
        //public void PromenaAviona(ComboBox cmbSediste,ComboBox cmbAvion)
        //{
        //    List<Sediste> sedista = new List<Sediste>();
        //    sedista = KontrolerKorisnickogInterfejsa.Instance.VratiSedista(cmbAvion.SelectedItem as Avion);
        //    cmbSediste.DataSource = sedista;
        //}
        public void Otkazi(DataGridView dataGridView1, BindingList<Rezervacija> rezervacije)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                rezervacije.Remove((Rezervacija)dataGridView1.SelectedRows[0].DataBoundItem);
            }
            else MessageBox.Show("Rezervacija nije oznacena!");
        }
        public void OtvoriRezervacije(List<Let> letovi, Label label5,ListBox lbDatumOdl,ComboBox cmbDestinacijeOd, Label lblSedistePovratak, Label lblSedistePov)
        {            
            label5.Visible = false;
            lbDatumOdl.Visible = false;
            lblSedistePov.Visible = false;
            lblSedistePovratak.Visible = false;

            List<Aerodrom> destinacijeBez = new List<Aerodrom>();
            foreach (Let l in letovi)
            {
                int k = 0;
                if (destinacijeBez.Count == 0) destinacijeBez.Add(l.DestinacijaOD);
                else
                {
                    for (int i = 0; i < destinacijeBez.Count; i++)
                    {
                        if (destinacijeBez.ElementAt(i).Grad == l.DestinacijaOD.Grad)
                            k++;
                    }
                    if (k == 0)
                    {
                        destinacijeBez.Add(l.DestinacijaOD);
                    }
                }
                k = 0;
            }
            cmbDestinacijeOd.DataSource = destinacijeBez;
        }
    }
}
