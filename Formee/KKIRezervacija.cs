using AvioKompanija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    public class KKIRezervacija
    {
        public void SacuvajRezervaciju(BindingList<Rezervacija> rezervacije)
        {
            try
            {
                if (rezervacije.Count > 0)
                {

                    bool uspeh = KontrolerKorisnickogInterfejsa.Instance.ZapamtiRrezervacije(rezervacije.ToList());
                    if (uspeh)
                    {


                        MessageBox.Show("Sistem je zapamtio rezervaciju!");
                        rezervacije.Clear();
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
            ListBox lbDatumOdl,ComboBox cmbAvion, ComboBox cmbSediste,CheckBox checkBox1, DataGridView dataGridView1,
            BindingList<Rezervacija> rezervacije, List<Avion> avioni, List<Let> letovi)
        {
            int sifraLeta = 0;
            int sifraPovratka = 0;

            foreach (Let l in letovi)
            {
                if (l.DestinacijaOD.Naziv == (cmbDestinacijeOd.SelectedItem as Destinacija).Naziv &&
                    l.DestinacijaDO.Naziv == (cmbDestinacijeDo.SelectedItem as Destinacija).Naziv &&
                    l.DatumPolaska == Convert.ToDateTime(lbDatumPolaska.Text))
                    sifraLeta = l.SifraLet;
                if (l.DestinacijaDO.Naziv == (cmbDestinacijeOd.SelectedItem as Destinacija).Naziv &&
                    l.DestinacijaOD.Naziv == (cmbDestinacijeDo.SelectedItem as Destinacija).Naziv &&
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

            Avion avion = new Avion();
            foreach (Avion av in avioni)
            {
                if (letPovratak.Avion != null && av.SifraAviona == letPovratak.Avion.SifraAviona)
                {
                    avion = av;
                }

            }
            Rezervacija r = new Rezervacija();
            r.Let = let;
            r.DatumRezervacije = DateTime.Now;
            r.Odobreno = true;
            Avion a = new Avion();
            a = cmbAvion.SelectedItem as Avion;
            r.Avion = a;
            r.Korisnik = Sesija.Instance.Korisnik;
            r.Sediste = cmbSediste.SelectedItem as Sediste;

            if (rezervacije.Count > 0)
            {
                foreach (Rezervacija r1 in rezervacije)
                {
                    if (r.Sediste.BrojSedista == r1.Sediste.BrojSedista && r.Avion.NazivAviona == r1.Avion.NazivAviona && r.Let.DestinacijaOD.Naziv == r1.Let.DestinacijaOD.Naziv && r.Let.DestinacijaDO.Naziv == r1.Let.DestinacijaDO.Naziv)
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
                MessageBox.Show("Nije dobar datum!");
            else
            {
                if (checkBox1.Checked)
                {
                    Rezervacija re = new Rezervacija();
                    re.Korisnik = Sesija.Instance.Korisnik;
                    re.Avion = avion;
                    re.Let = letPovratak;
                    re.DatumRezervacije = DateTime.Now;
                    re.Odobreno = true;
                    re.Sediste = cmbSediste.SelectedItem as Sediste;

                    rezervacije.Add(re);
                }
                rezervacije.Add(r);
            }
            dataGridView1.DataSource = rezervacije;
        }

        public void PromenaDestinacije(List<Let> letovi, ComboBox cmbDestinacijeOd, ComboBox cmbDestinacijeDo,
            ListBox lbDatumPolaska,ListBox lbDatumOdl, ComboBox cmbAvion)
        {
            List<DateTime> datumiPolaska = new List<DateTime>();
            List<Avion> avi = new List<Avion>();
            foreach (Let l in letovi)
            {
                if ((cmbDestinacijeOd.SelectedItem as Destinacija).Naziv == l.DestinacijaOD.Naziv && (cmbDestinacijeDo.SelectedItem as Destinacija).Naziv == l.DestinacijaDO.Naziv)
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
                if ((cmbDestinacijeOd.SelectedItem as Destinacija).Naziv == l.DestinacijaDO.Naziv && (cmbDestinacijeDo.SelectedItem as Destinacija).Naziv == l.DestinacijaOD.Naziv)
                {
                    datumiOdlaska.Add(l.DatumPolaska);
                }
               ;
            }
            lbDatumOdl.DataSource = datumiOdlaska;
        }

        public void PromenaDestinacijeOd(List<Let> letovi, ComboBox cmbDestinacijeOd, ComboBox cmbDestinacijeDo,
            ListBox lbDatumPolaska, ListBox lbDatumOdl, ComboBox cmbAvion)
        {
            List<Destinacija> destinacijeDo = new List<Destinacija>();
            foreach (Let l in letovi)
            {
                int k = 0;
                if ((cmbDestinacijeOd.SelectedItem as Destinacija).Naziv == l.DestinacijaOD.Naziv)
                {
                    if (destinacijeDo.Count == 0) destinacijeDo.Add(l.DestinacijaDO);
                    else
                    {
                        for (int i = 0; i < destinacijeDo.Count; i++)
                        {
                            if (destinacijeDo.ElementAt(i).Naziv == l.DestinacijaDO.Naziv)
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

                if ((cmbDestinacijeOd.SelectedItem as Destinacija).Naziv == l.DestinacijaOD.Naziv && (cmbDestinacijeDo.SelectedItem as Destinacija).Naziv == l.DestinacijaDO.Naziv)
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
                if ((cmbDestinacijeOd.SelectedItem as Destinacija).Naziv == l.DestinacijaDO.Naziv && (cmbDestinacijeDo.SelectedItem as Destinacija).Naziv == l.DestinacijaOD.Naziv)
                    datumiOdlaska.Add(l.DatumPolaska);

            }
            lbDatumOdl.DataSource = datumiOdlaska;
        }
        public void PromenaAviona(ComboBox cmbSediste,ComboBox cmbAvion)
        {
            List<Sediste> sedista = new List<Sediste>();
            sedista = KontrolerKorisnickogInterfejsa.Instance.VratiSedista(cmbAvion.SelectedItem as Avion);
            cmbSediste.DataSource = sedista;
        }
        public void Otkazi(DataGridView dataGridView1, BindingList<Rezervacija> rezervacije)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                rezervacije.Remove((Rezervacija)dataGridView1.SelectedRows[0].DataBoundItem);
            }
            else MessageBox.Show("Rezervacija nije oznacena!");
        }
        public void OtvoriRezervacije(List<Let> letovi, Label label5,ListBox lbDatumOdl,ComboBox cmbDestinacijeOd)
        {            
            label5.Visible = false;
            lbDatumOdl.Visible = false;


            List<Destinacija> destinacijeBez = new List<Destinacija>();
            foreach (Let l in letovi)
            {
                int k = 0;
                if (destinacijeBez.Count == 0) destinacijeBez.Add(l.DestinacijaOD);
                else
                {
                    for (int i = 0; i < destinacijeBez.Count; i++)
                    {
                        if (destinacijeBez.ElementAt(i).Naziv == l.DestinacijaOD.Naziv)
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
