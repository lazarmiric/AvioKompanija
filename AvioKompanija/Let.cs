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

        public Aerodrom DestinacijaOD { get; set; }
        public Aerodrom DestinacijaDO { get; set; }
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
        public string InsertValues => $"'{DatumPolaska}',{DestinacijaOD.AerodromID},{DestinacijaDO.AerodromID},{Avion.SifraAviona}";
        [Browsable(false)]
        public string UpdateValues => $"SifraAviona = {Avion.SifraAviona}";
        [Browsable(false)]
        public string Join => "join Aerodrom ae on (ae.AerodromID = l.SifraDestinacijeOD) join Avion a on (l.SifraAviona = a.SifraAviona) join Aerodrom aer on (l.SifraDestinacijeDO = aer.AerodromID) join Destinacija d on(d.SifraDestinacije = ae.ZemljaID) join Destinacija ds on(ds.SifraDestinacije = aer.ZemljaID)";
        [Browsable(false)]
        public string SearchId => $"where d.Naziv like '%{Filter1}%' and ds.Naziv like '%{Filter2}%'";
        [Browsable(false)]
        public object ColumnId => "";
        [Browsable(false)]
        public object Get => "Select SifraLet,DatumPolaska,SifraDestinacijeOD,SifraDestinacijeDO,l.SifraAviona,ae.Grad,ae.ZemljaID,d.Naziv,d.SifraDestinacije,aer.Grad,aer.ZemljaID,ds.Naziv,ds.SifraDestinacije,NazivAviona,BrojSedista from";
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
                    DestinacijaOD = new Aerodrom { AerodromID = reader.GetInt32(2), Grad = reader.GetString(5),Zemlja = new Destinacija { DestinacijaID = reader.GetInt32(6),Naziv = reader.GetString(7)}  },
                    DestinacijaDO = new Aerodrom { AerodromID = reader.GetInt32(3), Grad = reader.GetString(9),Zemlja = new Destinacija { DestinacijaID = reader.GetInt32(10),Naziv = reader.GetString(11)} },
                    Avion = new Avion { SifraAviona = reader.GetInt32(4), NazivAviona = reader.GetString(13) , BrojSedista = reader.GetInt32(14)}

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
            return DestinacijaOD.Grad + " -> " + DestinacijaDO.Grad;
        }
        [Browsable(false)]
        public string Uslov()
        {
            return $"SifraAviona = {Avion.SifraAviona} , DatumPolaska = '{DatumPolaska}'";
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
