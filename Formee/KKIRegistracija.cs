using Domen;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    public class KKIRegistracija
    {
        public event Action FrmClose;
        public void Ocisti(TextBox txJmbg, TextBox txtIme,
            TextBox txtKorisnickoIme, TextBox txtPass, TextBox txtPRez)
        {                     
            txJmbg.Clear();
            txtIme.Clear();
            txtKorisnickoIme.Clear();
            txtPass.Clear();
            txtPRez.Clear();
        }
       

        public void Registruj(TextBox txJmbg, TextBox txtIme, 
            TextBox txtKorisnickoIme, TextBox txtPass, TextBox txtPRez, DateTimePicker dateTimePicker1)
        {
            try
            {
                Korisnik korisnik = new Korisnik();
                korisnik.Ime = txtIme.Text;
                korisnik.Prezime = txtPRez.Text;
                korisnik.Jmbg = txJmbg.Text;
                korisnik.DatumRodjenja = DateTime.ParseExact(dateTimePicker1.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                korisnik.KorisnickoIme = txtKorisnickoIme.Text;
                korisnik.Sifra = Enkripcija.Instance.encrypt(txtPass.Text);


                if (txtIme.Text != "" && txtPRez.Text != "" && txJmbg.Text != "" && txJmbg.Text != "" && txtKorisnickoIme.Text != "" &&
                    txtPass.Text != "")
                {
                    bool registrovan = KontrolerKorisnickogInterfejsa.Instance.RegistracijaKorisnika(korisnik);
                    ;

                    if (registrovan == true)
                    {
                        MessageBox.Show($"Korisnik {korisnik.KorisnickoIme} je uspesno registrovan!");
                        Ocisti( txJmbg, txtIme, txtKorisnickoIme, txtPass, txtPRez);
                        FrmClose();
                    }

                    else
                        MessageBox.Show("Neuspesna registracija!");

                }
                else MessageBox.Show("Morate uneti sve podatke!");
            }
            catch (FormatException fe)
            {

                MessageBox.Show("Nepravilan unos!");
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }
    }
}
