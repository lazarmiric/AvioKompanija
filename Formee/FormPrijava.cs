using AvioKompanija;
using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Formee
{
    public partial class FormPrijava : Form
    {
        public FormPrijava()
        {
            InitializeComponent();
        }

        //Kontroler.Kontroler kontroler = new Kontroler.Kontroler();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (KontrolerKorisnickogInterfejsa.Instance.poveziSeNaServer())
            {
                label3.Text = "Connected";
                FormaRegistracija frmRegistracija = new FormaRegistracija();
                frmRegistracija.ShowDialog();
            }
            else { MessageBox.Show("Server nije pokrenut!");}



        }

        private void button1_Click(object sender, EventArgs e)
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
                            frmAdmin.ShowDialog();
                            Close();


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
                                Close();

                            }
                            else MessageBox.Show("Ne postoji korisnik sa tim korisnickim imenom i lozinkom!");
                        }
                    }
                }
                else { MessageBox.Show("Server nije povezan!");}
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }

      
    }
}
