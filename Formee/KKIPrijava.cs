using AvioKompanija;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    public class KKIPrijava
    {
        public event Action FrmClose;
        public void Prijavi(TextBox textBox1, TextBox textBox2,Label label3)
        {
            try
            {
                Korisnik k = new Korisnik();
                Administrator a = new Administrator();
                a.KorisnickoIme = textBox1.Text;
                a.Sifra = textBox2.Text;
                k.KorisnickoIme = textBox1.Text;
                k.Sifra = textBox2.Text;
                if (KontrolerKorisnickogInterfejsa.Instance.poveziSeNaServer())
                {
                    label3.Text = "Connected";

                    if (k.KorisnickoIme == "" || k.Sifra == "") { MessageBox.Show("Morate uneti i korisnicko ime i sifru!"); }
                    else
                    {
                        if (KontrolerKorisnickogInterfejsa.Instance.ProveriAdmin(textBox1.Text, textBox2.Text))
                        {
                            MessageBox.Show("ADMINISTRATOR PRIJAVLJEN!");
                            Administracija frmAdmin = new Administracija();
                            FrmClose();
                            frmAdmin.ShowDialog();
                            


                        }
                        else
                        {
                            Korisnik kor = new Korisnik();
                            kor = KontrolerKorisnickogInterfejsa.Instance.PrijaviKorisnika(k);
                            if (kor != null)
                            {
                                Sesija.Instance.Korisnik = kor;
                                MessageBox.Show("Prijavljen korisnik!");
                                FormRezervacija frmRezervacija = new FormRezervacija();
                                frmRezervacija.ShowDialog();
                                FrmClose();

                            }
                            else MessageBox.Show("Ne postoji korisnik sa tim korisnickim imenom i lozinkom!");
                        }
                    }
                }
                else { MessageBox.Show("Server nije povezan!"); }
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }

        public void Registruj(Label label3)
        {
            if (KontrolerKorisnickogInterfejsa.Instance.poveziSeNaServer())
            {
                label3.Text = "Connected";
                FormaRegistracija frmRegistracija = new FormaRegistracija();
                frmRegistracija.ShowDialog();
            }
            else { MessageBox.Show("Server nije pokrenut!"); }
        }
    }
}
