using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvioKompanija;

namespace SistemskaOperacija
{
    public class PronadjiRezervaciju : OpstaSistemskaOperacija
    {
        public Rezervacija Rezervacija { get; private set; }
        protected override object IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Rezervacija r = (Rezervacija)objekat;
            Rezervacija = r;
            return broker.Pronadji(objekat).OfType<Rezervacija>().ToList();
        }
        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Rezervacija))
            {
                throw new ArgumentException();
            }
        }
    }
}
