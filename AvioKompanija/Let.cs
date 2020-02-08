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
    public class Let : IDomenskiObjekat
    {
        public int SifraLet { get; set; }
        public DateTime DatumPolaska { get; set; }

        public Destinacija DestinacijaOD { get; set; }
        public Destinacija DestinacijaDO { get; set; }
        [Browsable(false)]
        public String Filter1 { get; set; }
        [Browsable(false)]
        public String Filter2 { get; set; }

        public Avion Avion { get; set; }
        [Browsable(false)]
        public string Table => "Let";
        [Browsable(false)]
        public string FullTable => "Let l";
        [Browsable(false)]
        public string InsertValues => $"'{DatumPolaska}',{DestinacijaOD.DestinacijaID},{DestinacijaDO.DestinacijaID},{Avion.SifraAviona}";
        [Browsable(false)]
        public string UpdateValues => $"SifraAviona = {Avion.SifraAviona}";
        [Browsable(false)]
        public string Join => "join Destinacija d on (d.SifraDestinacije = l.SifraDestinacijeOD) join Avion a on (l.SifraAviona = a.SifraAviona) join Destinacija dst on (l.SifraDestinacijeDO = dst.SifraDestinacije)";
        [Browsable(false)]
        public string SearchId => $"where d.Naziv like '%{Filter1}%' and dst.Naziv like '%{Filter2}%'";
        [Browsable(false)]
        public object ColumnId => "";
        [Browsable(false)]
        public object Get => "Select SifraLet,DatumPolaska,SifraDestinacijeOD,SifraDestinacijeDO,l.SifraAviona,d.Naziv,dst.Naziv,NazivAviona from";
        [Browsable(false)]
        public string Kriterijum { get; set; }
        [Browsable(false)]
        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new Let
                {
                    SifraLet = reader.GetInt32(0),
                    DatumPolaska = reader.GetDateTime(1),
                    DestinacijaOD = new Destinacija { DestinacijaID = reader.GetInt32(2), Naziv = reader.GetString(5) },
                    DestinacijaDO = new Destinacija { DestinacijaID = reader.GetInt32(3), Naziv = reader.GetString(6) },
                    Avion = new Avion { SifraAviona = reader.GetInt32(4), NazivAviona = reader.GetString(7) }

                });
            }
            reader.Close();
            return lista;


        }
       
        [Browsable(false)]
        public string Search(string s)
        {
            return "";
        }

        public string SearchKrit(int krit)
        {
            return "";
        }

        [Browsable(false)]
        public string SearchWhere()
        {
            return $"where SifraLet = { SifraLet}";
        }
        [Browsable(false)]
        public override string ToString()
        {
            return DestinacijaOD.Naziv + " -> " + DestinacijaDO.Naziv;
        }
        [Browsable(false)]
        public string Uslov()
        {
            return $"SifraAviona = {Avion.SifraAviona}";
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
