using AvioKompanija;
using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Formee
{
    public class Komunikacija
    {
        TcpClient klijent;
        NetworkStream tok;
        BinaryFormatter formatter;
        public bool PoveziSeNaServer()
        {
            try
            {
                klijent = new TcpClient("127.0.0.1", 20000);
                tok = klijent.GetStream();
                formatter = new BinaryFormatter();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

     

        private TransferKlasa ProcitajOdgovor()
        {
            try
            {
                return (TransferKlasa)formatter.Deserialize(tok);
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>>" + e.Message);
                return null;
            }
        }

        internal List<Rezervacija> UcitajRezervacije()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.UcitajRezervacije;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (List<Rezervacija>)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }
        internal List<Let> PronadjiLet(Let l)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.PronadjiLet;
                transfer.TransferObjekat = l;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (List<Let>)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal bool IzmeniLet(Let novi)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.IzmeniLet;
                transfer.TransferObjekat = novi;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (bool)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal bool RegistrujKorisnika(Korisnik korisnik)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.RegistracijaKorisnika;
                transfer.TransferObjekat = korisnik;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (bool)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal bool ZapamtiLet(Let l)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.ZapamtiLet;
                transfer.TransferObjekat = l;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (bool)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

     

        internal List<Rezervacija> PronadjiRezervaciju(Rezervacija r)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.PronadjiRezervaciju;
                transfer.TransferObjekat = r;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (List<Rezervacija>)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal bool OtkaziRezervaciju(Rezervacija r)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.OtkaziRezervaciju;
                transfer.TransferObjekat = r;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (bool)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal List<Avion> VratiAvione()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.VratiAvione;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (List<Avion>)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal List<Aerodrom> VratiAerodrome()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.VratiAerodrome;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (List<Aerodrom>)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal bool ProveriAdmin(string user, string pass)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.ProveriAdmin;
                Administrator k = new Administrator
                {
                    KorisnickoIme = user,
                    Sifra = pass
                };
                transfer.TransferObjekat = k;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (bool)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal bool ZapamtiRezervaciju(List<Rezervacija> rezervacije)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.ZapamtiRrezervacije;
                transfer.TransferObjekat = rezervacije;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (bool)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal List<Destinacija> VratiDestinacije()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.VratiDestinacije;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (List<Destinacija>)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal List<Sediste> VratiSedista(int sifra)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.VratiSedista;
                transfer.TransferObjekat = sifra;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (List<Sediste>)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal List<Let> VratiLetove()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.VratiLetove;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (List<Let>)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        internal Korisnik UlogujSe(Korisnik k)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacija.UlogujSe;
                transfer.TransferObjekat = k;
                formatter.Serialize(tok, transfer);
                transfer = ProcitajOdgovor();
                return (Korisnik)transfer.TransferObjekat;
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }

        public void Kraj()
        {
            try
            {

                TransferKlasa transfernaKlasa = new TransferKlasa();
                transfernaKlasa.Operacija = Operacija.kraj;
                formatter.Serialize(tok, transfernaKlasa);
            }
            catch (IOException e)
            {

                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }
        }
    }
}
