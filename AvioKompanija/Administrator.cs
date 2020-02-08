using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvioKompanija
{
    [Serializable]
   public class Administrator : IDomenskiObjekat
    {
        public string Sifra { get; set; }
        public int SifraAdmin { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string KorisnickoIme { get; set; }

        public string Table => "Administrator";

        public string FullTable => "Administrator a";

        public string InsertValues => "";

        public string UpdateValues => "";

        public string Join => "";

        public string SearchId => "";

        public object ColumnId => "";

        public object Get => "Select KorisnickoIme,Sifra from";

        public string Kriterijum { get; set ; }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Administrator a = new Administrator()
                {
                    
                    KorisnickoIme = reader.GetString(0),
                    Sifra = reader.GetString(1)
                };
                lista.Add(a);

            }
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

        public string Uslov()
        {
            return "";
        }

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
