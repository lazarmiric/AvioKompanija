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
    public class Destinacija:IDomenskiObjekat
    {
        public int DestinacijaID { get; set; }
        public String Naziv { get; set; }

        public string Table => "Destinacija";

        public string FullTable => "Destnacija d";

        public string InsertValues => "";

        public string UpdateValues => "";

        public string Join => $"";

        public string SearchId => $"where DestinacijaID = {DestinacijaID}";

        public object ColumnId => "DestinacijaID";

        public object Get => "Select * FROM";

        public string Kriterijum { get; set;}

        public override string ToString()
        {
            return Naziv;
        }

        [Browsable(false)]
        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new Destinacija()
                {
                    DestinacijaID = reader.GetInt32(0),
                    Naziv = reader.GetString(1)
                });
            }
            return lista;
        }

    
  

        public string SearchWhere()
        {
            return "";
        }

        public string Search(string s)
        {
            return "" ;
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

        public string SearchKrit(int krit)
        {
            return "";
        }
    }
}
