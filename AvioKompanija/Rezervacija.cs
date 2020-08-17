using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvioKompanija
{
    [Serializable]
    public class Rezervacija : IDomenskiObjekat

    {
        [Browsable(false)]
        public int RedBr { get; set; }
        public DateTime DatumRezervacije { get; set; }
       
        public Boolean Odobreno{ get; set; }
        public Korisnik  Korisnik { get; set; }
        [Browsable(false)]
        public Administrator Administrator{ get; set; }

        public Avion Avion { get; set; }

        public Sediste Sediste{ get; set; }

        public Let Let { get; set; }



        [Browsable(false)]
        public String Filter { get; set; }
        [Browsable(false)]
        public string Table => "Rezervacija";
        [Browsable(false)]
        public string FullTable => "Rezervacija r";
        [Browsable(false)]
        public string InsertValues => $"'{DatumRezervacije}','{Odobreno}',{Korisnik.SifraKorisnika},1,{Avion.SifraAviona},{Sediste.BrojSedista},{Let.SifraLet}";

        //  $"Insert into {objekat.Table} values {objekat.InsertValues}";
        [Browsable(false)]
        public string UpdateValues => "set Odobreno = 'false'";
        [Browsable(false)]
        public string Join => "join Let l on(r.SifraLet = l.SifraLet) join Aerodrom aer on (aer.AerodromID = l.SifraDestinacijeDO) join Aerodrom aero on(aero.AerodromID = l.SifraDestinacijeOD) join Korisnici k on(k.SifraKorisnika = r.SifraKorisnika) join Avion a on(a.SifraAviona = r.SifraAviona) join Destinacija dst on (dst.SifraDestinacije = aer.ZemljaID) join Destinacija ds on(ds.SifraDestinacije = aero.ZemljaID)";
        [Browsable(false)]
        public string SearchId => $"where dst.Naziv like '%{Filter}%'";
        [Browsable(false)]
        public object ColumnId => $"where RedBr = {RedBr}";
        [Browsable(false)]
        public object Get => "Select * from";
        [Browsable(false)]
        public string Kriterijum { get ; set; }
        [Browsable(false)]
        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();

            while (reader.Read())
            {
                Rezervacija r = new Rezervacija();
                r.RedBr = reader.GetInt32(0);
                r.DatumRezervacije = reader.GetDateTime(1);
                r.Odobreno = reader.GetBoolean(2);
                Korisnik k = new Korisnik();
                k.SifraKorisnika = reader.GetInt32(3);
                k.Ime = reader.GetString(20);
                k.Prezime = reader.GetString(21);
                r.Korisnik = k;
                Administrator a = new Administrator();
                a.SifraAdmin = reader.GetInt32(4);
                r.Administrator = a;
                Let l = new Let();
                l.SifraLet = reader.GetInt32(7);
                l.DatumPolaska = reader.GetDateTime(9);
                r.Let = l;
                Aerodrom od = new Aerodrom();
                Aerodrom dod = new Aerodrom();
                od.AerodromID = reader.GetInt32(16);
                od.Grad = reader.GetString(17);
                Destinacija dstod = new Destinacija();
                dstod.DestinacijaID = reader.GetInt32(30);
                dstod.Naziv = reader.GetString(31);
                Destinacija dstdo = new Destinacija();
                dstdo.DestinacijaID = reader.GetInt32(28);
                dstdo.Naziv = reader.GetString(29);
                od.Zemlja = dstod;
                dod.Zemlja = dstdo;
                dod.AerodromID = reader.GetInt32(13);
                dod.Grad = reader.GetString(14);
                l.DestinacijaDO = dod;
                l.DestinacijaOD = od;
                Sediste s = new Sediste();
                Avion av = new Avion();
                av.SifraAviona = reader.GetInt32(5);
                av.NazivAviona = reader.GetString(25);
                r.Avion = av;
                s.BrojSedista = reader.GetInt32(6);
                r.Sediste = s;

                lista.Add(r);
            }
            reader.Close();
            return lista;
        }
        [Browsable(false)]
        public string insertObject(Object o)
        {
            Rezervacija r = new Rezervacija();
            r = (Rezervacija)o;
           return $"'{r.DatumRezervacije}','{r.Odobreno}',{r.Korisnik.SifraKorisnika},{r.Administrator.SifraAdmin},{r.Avion.SifraAviona},{r.Sediste.BrojSedista},{r.Let.SifraLet}";
        }




        [Browsable(false)]
        public string Search( string s)
        {
            return $"where de.Naziv like '%{s}%'";
        }

        public string SearchKrit(int krit)
        {
            return "";
        }

        [Browsable(false)]
        public string SearchWhere()
        {
            return "";
        }
        [Browsable(false)]
        public string Uslov()
        {
            return "";
        }
        [Browsable(false)]
        public string UslovLog(string s1, string s2)
        {
            return "";
        }

        public string UslovSe(int s1, int s2)
        {
            return "";
        }
    }
}
