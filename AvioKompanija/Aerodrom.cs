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
    public class Aerodrom : IDomenskiObjekat
    {
        public int AerodromID { get; set; }
        public String Grad { get; set; }

        public Destinacija Zemlja { get; set; }

        [Browsable(false)]
        public string Table => "Aerodrom";
        [Browsable(false)]
        public string FullTable => "Aerodrom a";
        [Browsable(false)]
        public string InsertValues => throw new NotImplementedException();
        [Browsable(false)]
        public string UpdateValues => throw new NotImplementedException();
        [Browsable(false)]
        public string Join => "join Destinacija d on (d.SifraDestinacije = a.ZemljaID)";
        [Browsable(false)]
        public string SearchId => throw new NotImplementedException();
        [Browsable(false)]
        public object ColumnId => "AerodromID";
        [Browsable(false)]
        public object Get => "Select * from";
        [Browsable(false)]
        public string Kriterijum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Browsable(false)]
        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Aerodrom a = new Aerodrom();
                a.AerodromID = reader.GetInt32(0);
                a.Grad = reader.GetString(1);
                Destinacija d = new Destinacija();
                d.DestinacijaID = reader.GetInt32(2);
                d.Naziv = reader.GetString(4);
                a.Zemlja = d;
                lista.Add(a);
            }
            return lista;
        }
        [Browsable(false)]
        public string Search(string s)
        {
            throw new NotImplementedException();
        }
        [Browsable(false)]
        public string SearchKrit(int krit)
        {
            throw new NotImplementedException();
        }
        [Browsable(false)]
        public string SearchWhere()
        {
            throw new NotImplementedException();
        }
        [Browsable(false)]
        public string Uslov()
        {
            throw new NotImplementedException();
        }
        [Browsable(false)]
        public string UslovLog(string s1, string s2)
        {
            throw new NotImplementedException();
        }
        [Browsable(false)]
        public string UslovSe(int s1, int s2)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Grad + "-" + Zemlja.Naziv;
        }
    }
}
