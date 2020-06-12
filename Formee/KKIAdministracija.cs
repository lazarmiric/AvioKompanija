using AvioKompanija;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    public class KKIAdministracija
    {
        public void DodajLet(TextBox txtDatum, ComboBox cmbOD, ComboBox cmbDo,ComboBox cmbAvion,DataGridView dataGridView2)
        {
            try
            {

                Let l = new Let();
                l.DestinacijaOD = cmbOD.SelectedItem as Destinacija;
                l.DestinacijaDO = cmbDo.SelectedItem as Destinacija;
                if (l.DestinacijaDO.Naziv != l.DestinacijaOD.Naziv)
                {
                    l.Avion = cmbAvion.SelectedItem as Avion;
                    l.DatumPolaska = DateTime.ParseExact(txtDatum.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    bool uspesno = KontrolerKorisnickogInterfejsa.Instance.ZapamtiLet(l);
                    if (uspesno) MessageBox.Show("Sistem je zapamtio novi let!");
                    else MessageBox.Show("Sistem ne moze zapamti novi let!");

                    dataGridView2.Refresh();
                }
                else MessageBox.Show("Destinacije moraju biti razlicite!");
            }
            catch (FormatException)
            {

                MessageBox.Show("Nepravilan unos!"); ;
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }

        public void IzmeniLet(DataGridView dataGridView2) 
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                Let l = new Let();
                l = (Let)dataGridView2.SelectedRows[0].DataBoundItem;
                FrmLet let = new FrmLet(l);
                let.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nije selektovan let!");
            }
        }
        public void Pretrazi(TextBox txtPretraziRez, DataGridView dataGridView1)
        {
            try
            {
                List<Rezervacija> filter = new List<Rezervacija>();
                Rezervacija r = new Rezervacija { Filter = txtPretraziRez.Text };
                filter = KontrolerKorisnickogInterfejsa.Instance.PronadjiRezervaciju(r);
                dataGridView1.DataSource = filter;
                if (filter.Count > 0)
                    MessageBox.Show("Sistem je pronasao rezervacije!");
                if (filter.Count == 0) MessageBox.Show("Sistem ne moze da nadje rezervacije na osnovu kriterijuma!");
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }
        public void Otkazi(TextBox txtPretraziRez,DataGridView dataGridView1, List<Rezervacija> rez)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Rezervacija r = new Rezervacija();
                    r = ((Rezervacija)dataGridView1.SelectedRows[0].DataBoundItem);
                    if (r.Odobreno == true)
                    {
                        bool otkazana = KontrolerKorisnickogInterfejsa.Instance.OtkaziRezervaciju(r);
                        if (otkazana)
                        {
                            txtPretraziRez.Text = "";
                            rez = KontrolerKorisnickogInterfejsa.Instance.UcitajRezervacije();
                            dataGridView1.DataSource = rez;
                            MessageBox.Show("Rezervacija uspesno otkazana!");
                        }
                        else { MessageBox.Show("Sistem ne moze da otkaze rezervaciju!"); }
                    }
                    else { MessageBox.Show("Rezervacija je vec otkazana!"); }
                }
                else MessageBox.Show("Rezervacija nije oznacena!");
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }

        public void PretraziLetove(TextBox txtOd, TextBox txtDo,DataGridView dataGridView2)
        {
            try
            {
                if (txtOd.Text == "" && txtDo.Text == "")
                {
                    MessageBox.Show("Morate uneti bar jedan kriterijum");
                    return;
                }
                Let l = new Let { Filter1 = txtOd.Text, Filter2 = txtDo.Text };
                List<Let> filterLet = new List<Let>();
                filterLet = KontrolerKorisnickogInterfejsa.Instance.PronadjiLet(l);
                if (filterLet.Count > 0) MessageBox.Show("Sistem je pronasao letove po zadatom kriterijumom");
                else MessageBox.Show("Sistem ne moze da pronadje letove po zadatom kriterijumom");
                dataGridView2.DataSource = filterLet;
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }
        public void OtvoriAdmin(DataGridView dataGridView1, ComboBox cmbOD, ComboBox cmbDo, ComboBox cmbAvion, List<Rezervacija> rez)
        {
            cmbDo.DataSource = KontrolerKorisnickogInterfejsa.Instance.VratiDestinacije();
            cmbOD.DataSource = KontrolerKorisnickogInterfejsa.Instance.VratiDestinacije();
            cmbAvion.DataSource = KontrolerKorisnickogInterfejsa.Instance.VratiAvione();
            rez = KontrolerKorisnickogInterfejsa.Instance.UcitajRezervacije();
            dataGridView1.DataSource = rez;
        }
    }
}
