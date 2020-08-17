using AvioKompanija;
using Domen;
using Kontroler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class NitKlijenta
    {
        private NetworkStream tok;
        private BinaryFormatter formatter;
        public List<Thread> nitiKlijenata = new List<Thread>();     

        public NitKlijenta(NetworkStream tok)
        {
            this.tok = tok;
            formatter = new BinaryFormatter();
            ThreadStart obrada = Obradi;
            new Thread(obrada).Start();
            nitiKlijenata.Add(new Thread(obrada));
        }
        public void Obradi()
        {
            try
            {
                int operacija = 0;
                while (operacija != (int)Operacija.kraj)
                {
                    TransferKlasa transfer = formatter.Deserialize(tok) as TransferKlasa;
                    switch (transfer.Operacija)
                    {
                        case Operacija.kraj:
                            operacija = 1;
                            break;
                        case Operacija.UlogujSe:
                            Korisnik k = (Korisnik)transfer.TransferObjekat;
                              transfer.TransferObjekat = Kontroler.Kontroler.Instance.PrijaviKorisnika((Korisnik)transfer.TransferObjekat);
                            formatter.Serialize(tok, transfer);                            
                            break;
                        case Operacija.RegistracijaKorisnika:
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.RegistrijKorisnika((Korisnik)transfer.TransferObjekat);
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiDestinacije:                           
                             transfer.TransferObjekat =  Kontroler.Kontroler.Instance.listaDestinacija();
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiLetove:
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.listaLetova();
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiAvione:                         
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.vratiAvione();
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiSedista:                            
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.vratiSedista((int)transfer.TransferObjekat);
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.ZapamtiRrezervacije:
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.sacivajRezervacije((List<Rezervacija>)transfer.TransferObjekat);
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.ProveriAdmin:
                            Administrator a = (Administrator)transfer.TransferObjekat;
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.ProveriAdmin(a.KorisnickoIme, a.Sifra);
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.UcitajRezervacije:                           
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.vratiRezervacije();
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.ZapamtiLet:
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.SacuvajLet((Let)transfer.TransferObjekat);
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.OtkaziRezervaciju:
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.OtkaziRezervaciju((Rezervacija)transfer.TransferObjekat);
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.IzmeniLet:
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.IzmeniLet((Let)transfer.TransferObjekat);
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.PronadjiRezervaciju:
                            List<Rezervacija> filter = new List<Rezervacija>();
                            filter = Kontroler.Kontroler.Instance.PronadjiRezervacije((Rezervacija)transfer.TransferObjekat);
                            transfer.TransferObjekat = filter;
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.PronadjiLet:
                            List<Let> filterLet = new List<Let>();
                            filterLet = Kontroler.Kontroler.Instance.PronadjiLetove((Let)transfer.TransferObjekat);
                            transfer.TransferObjekat = filterLet;
                            formatter.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiAerodrome:
                            transfer.TransferObjekat = Kontroler.Kontroler.Instance.vratiAerodrome();
                            formatter.Serialize(tok, transfer);
                            break;

                    }
                }
            }
            catch (Exception) {  }
        }
    }
                    
}
