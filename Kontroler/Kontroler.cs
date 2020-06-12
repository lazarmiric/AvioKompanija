using AvioKompanija;
using BrokerBaze;
using Domen;
using SistemskaOperacija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontroler
{
    public class Kontroler
    {
        private Broker broker = new Broker();

        private static Kontroler instance;
        private Kontroler() { }

        public static Kontroler Instance
        { get {
                if (instance == null) { instance = new Kontroler(); }
                return instance;
            }
        }
        public object RegistrijKorisnika(IDomenskiObjekat objekat)
        {
            ZapamtiKorisnika zk = new ZapamtiKorisnika();
            try
            {
                broker.OtvoriKonekciju();
                return (bool)zk.Izvrsi(objekat);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public List<Avion> vratiAvione()
        {
            try
            {
                broker.OtvoriKonekciju();
                return broker.vratiBez(new Avion()).OfType<Avion>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }      

        public bool SacuvajLet(Let l)
        {
            ZapamtiLet zl = new ZapamtiLet();
            try
            {
                broker.OtvoriKonekciju();
                return (bool)zl.Izvrsi(l);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public bool IzmeniLet(Let l)
        {
            IzmeniLet il = new IzmeniLet();
            try
            {
                broker.OtvoriKonekciju();
                return (bool)il.Izvrsi(l);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public Korisnik PrijaviKorisnika(Korisnik k)
        {
            PrijaviKorisnika pk = new PrijaviKorisnika();
            try
            {


                return (Korisnik)pk.Izvrsi(k);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }


        public bool ProveriAdmin(string korisnickoIme, string pass)
        {
            try
            {
                broker.OtvoriKonekciju();
                Administrator a = broker.vratiBez(new Administrator() { KorisnickoIme = korisnickoIme, Sifra = pass }).OfType<Administrator>().ToList().FirstOrDefault();
                if (a != null)
                {
                    if (a.KorisnickoIme == korisnickoIme && a.Sifra == pass)
                    {
                        return true;
                    }
                    else return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }

        }
        public object listaDestinacija()
        {
            try
            {
                broker.OtvoriKonekciju();
                return broker.vratiBez(new Destinacija()).OfType<Destinacija>().ToList();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }

        } 

        public List<Sediste> vratiSedista(int sifra)
        {
            try
            {
                broker.OtvoriKonekciju();
                List<Sediste> sedista = broker.vratiBez(new Sediste()).OfType<Sediste>().ToList();
                List<Sediste> filterSedista = new List<Sediste>();
                foreach(Sediste s in sedista)
                {
                    if(s.Avion.SifraAviona == sifra)
                    {
                        filterSedista.Add(s);
                    }
                }

                return filterSedista;
                    
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

   

        public List<Let> listaLetova()
        {
            UcitajLet ul = new UcitajLet();
            try
            {
                //broker.OtvoriKonekciju();
                //return broker.listaLetova(new Let()).OfType<Let>().ToList();
                return ul.Izvrsi(new Let()) as List<Let>;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }

        }

        public bool sacivajRezervacije(List<Rezervacija> rez)
        {
            SacuvajRezervacije sr = new SacuvajRezervacije();

            try
                {
                  broker.OtvoriKonekciju();
                foreach (Rezervacija r in rez)
                {
                   
                    sr.Izvrsi(r);
                }
                return true;

                }
                catch (Exception e)
                {
                    string s = e.Message;
                     return false;
                    throw;
                }
                finally
                {
                    broker.ZatvoriKonekciju();
                }
            }

        public List<Let> PronadjiLetove(Let l)
        {
            PronadjiLet pl = new PronadjiLet();
            try
            {
                broker.OtvoriKonekciju();
                return (List<Let>)pl.Izvrsi(l);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }


        public List<Rezervacija> vratiRezervacije()
        {

            UcitajRezervacije ur = new UcitajRezervacije();
            try
            {
                broker.OtvoriKonekciju();
                return  ur.Izvrsi(new Rezervacija()) as List<Rezervacija>;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public bool OtkaziRezervaciju(Rezervacija r)
        {
            OtkaziRezervaciju or = new OtkaziRezervaciju();
            try
            {
                broker.OtvoriKonekciju();
                return (bool)or.Izvrsi(r);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public List<Rezervacija> PronadjiRezervacije(Rezervacija r)
        {
            PronadjiRezervaciju po = new PronadjiRezervaciju();
            try
            {
                broker.OtvoriKonekciju();
                return (List<Rezervacija>)po.Izvrsi(r);
             
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }
    }
}
