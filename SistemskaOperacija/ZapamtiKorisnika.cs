using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvioKompanija;
using Domen;

namespace SistemskaOperacija
{
    public class ZapamtiKorisnika : OpstaSistemskaOperacija
    {
        public Korisnik Korisnik { get; private set; }
        protected override object IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Korisnik k = (Korisnik)objekat;
            Korisnik = k;
            return broker.sacuvaj(objekat);
        }
        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Korisnik))
            {
                throw new ArgumentException();
            }
        }
    }
}
