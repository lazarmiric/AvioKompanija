using AvioKompanija;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Korisnik : IDomenskiObjekat
    {
    
    

        public int SifraKorisnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }

        public string Table => "Korisnici";

        public string FullTable =>  "Korisnici k";

        public string InsertValues => $"'{Ime}','{Prezime}','{Jmbg}','{DatumRodjenja}','{KorisnickoIme}','{Sifra}'";

        public string UpdateValues => "";

        public string Join => "";

        public string SearchId => "";

        public object ColumnId => "";

        public object Get => "Select * from";

        public string Kriterijum { get ; set ; }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Korisnik korisnik = new Korisnik()
                {
                    SifraKorisnika = reader.GetInt32(0),
                    Ime = reader.GetString(1),
                    Prezime = reader.GetString(2),
                    Jmbg = reader.GetString(3),
                    DatumRodjenja = reader.GetDateTime(4),
                    KorisnickoIme = reader.GetString(5),
                    Sifra = reader.GetString(6)
                };
                lista.Add(korisnik);

            }
            reader.Close();
            return lista;
        }

      

        public string Search(string s)
        {
            return "";
        }

        public string SearchKrit(int krit)
        {
            return "";
        }

        public string SearchWhere()
        {
            return "";
        }

        public override string ToString()
        {
            return Ime+ " " + Prezime;
        }

        public string Uslov()
        {
            return "";
        }

        public string UslovLog(string s1, string s2)
        {
            s1 = KorisnickoIme;
            s2 = Sifra;
            return $"where korisnickoIme ='{s1}' and sifra = '{s2}' ";
        }

        public string UslovSe(int s1, int s2)
        {
            return "";
        }
    }
}
