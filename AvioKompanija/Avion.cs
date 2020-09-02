using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvioKompanija 
{
    [Serializable]
    public class Avion : IDomenskiObjekat
    {
        public int SifraAviona { get; set; }
        public String NazivAviona { get; set; }

        public int BrojSedista { get; set; }

        public string Table => "Avion";
         
        public string FullTable => "Avion a";

        public string InsertValues => "";

        public string UpdateValues => "";

        public string Join => "";

        public string SearchId => "";

        public object ColumnId => "";

        public object Get => "Select * from";

        public string Kriterijum { get ; set; }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Avion a = new Avion {SifraAviona = reader.GetInt32(0) , NazivAviona = reader.GetString(1) , BrojSedista = reader.GetInt32(2)};                
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

        public override string ToString()
        {
            return NazivAviona;
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
