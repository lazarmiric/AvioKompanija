using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvioKompanija;
using Domen;

namespace Formee
{
    public class KontrolerKorisnickogInterfejsa
    {
        Komunikacija k;
        private KontrolerKorisnickogInterfejsa()
        {
            k = new Komunikacija();
        }
        private static KontrolerKorisnickogInterfejsa instance;
        public static KontrolerKorisnickogInterfejsa Instance
        {
            get
            {
                if (instance == null) instance = new KontrolerKorisnickogInterfejsa();
                return instance;
            }
        }

        internal List<Let> PronadjiLet(Let l)
        {
            return k.PronadjiLet(l);
        }

        public void kraj()
        {
            k.Kraj();
        }
        public bool poveziSeNaServer()
        {
            return k.PoveziSeNaServer();
        }

        internal List<Rezervacija> UcitajRezervacije()
        {
          
            return k.UcitajRezervacije();
        }

        internal Korisnik PrijaviKorisnika(Korisnik kor)
        {
            return k.UlogujSe(kor);
        }

        internal bool RegistracijaKorisnika(Korisnik korisnik)
        {
            return k.RegistrujKorisnika(korisnik);
        }

        internal bool IzmeniLet(Let novi)
        {
            return k.IzmeniLet(novi);
        }

        internal List<Let> VratiLetove()
        {
           return k.VratiLetove();
        }

        internal List<Destinacija> VratiDestinacije()
        {
           return k.VratiDestinacije();
        }

        internal List<Avion> VratiAvione()
        {
            return k.VratiAvione();
        }

        internal List<Aerodrom> VratiAerodrome()
        {
            return k.VratiAerodrome();
        }

        internal List<Sediste> VratiSedista(Avion avion)
        {
            return k.VratiSedista(avion.SifraAviona);
        }

        internal bool ZapamtiLet(Let l)
        {
            return k.ZapamtiLet(l);
        }

        internal bool ProveriAdmin(string user, string pass)
        {
            return k.ProveriAdmin(user,pass);
        }

        internal  bool ZapamtiRrezervacije(List<Rezervacija> rezervacije)
        {
            return k.ZapamtiRezervaciju(rezervacije);
        }

        internal bool OtkaziRezervaciju(Rezervacija r)
        {
            return k.OtkaziRezervaciju(r);
        }

        internal List<Rezervacija> PronadjiRezervaciju(Rezervacija r)
        {
            return k.PronadjiRezervaciju(r);
        }

      
    }
}
