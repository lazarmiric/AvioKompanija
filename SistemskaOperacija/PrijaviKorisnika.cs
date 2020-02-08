using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvioKompanija;
using Domen;

namespace SistemskaOperacija
{
    public class PrijaviKorisnika : OpstaSistemskaOperacija
    {
    public Korisnik Korisnik { get; private set; }
    protected override object IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
    {
            List<IDomenskiObjekat> korisnici = new List<IDomenskiObjekat>();
            korisnici = broker.vratiBez(objekat);
            Korisnik k = (Korisnik)objekat;
            Korisnik = k;
            //Korisnik korisnik = broker.prijavi(new Korisnik() { KorisnickoIme = k.KorisnickoIme, Sifra = k.Sifra }).OfType<Korisnik>().ToList().FirstOrDefault();
            foreach(Korisnik kor in korisnici)
            {
                if(kor.Sifra == k.Sifra && kor.KorisnickoIme == k.KorisnickoIme)
                {
                    return kor;
                }

                
            }
            return null;
            //if (korisnik != null)
            //{
            //    if (korisnik.KorisnickoIme == k.KorisnickoIme && korisnik.Sifra == k.Sifra)
            //    {
            //        Korisnik = korisnik;
            //        return korisnik;
            //    }
            //    else
            //    {
            //        Korisnik = null;
            //        return null;
            //    }
            //}
            //else
            //{
            //    return null;
            //}


        
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
