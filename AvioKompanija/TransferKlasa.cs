using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvioKompanija
{  
    public enum Operacija
    {
        kraj = 1,
        UlogujSe,
        RegistracijaKorisnika,
        VratiDestinacije,
        VratiLetove,
        VratiAvione,
        VratiSedista,
        ZapamtiRrezervacije,
        ProveriAdmin,
        UcitajRezervacije,
        ZapamtiLet,
        OtkaziRezervaciju,
        IzmeniLet,
        PronadjiRezervaciju,
        PronadjiLet,
        ZauzmiSedista,
        VratiAerodrome
    }
    [Serializable]
    public class TransferKlasa
    {
        public Operacija Operacija { get; set; }
        public Object TransferObjekat { get; set; }
    }
}
