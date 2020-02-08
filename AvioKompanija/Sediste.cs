using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvioKompanija
{
    [Serializable]
    public class Sediste : IDomenskiObjekat
    {
        public int BrojSedista { get; set; }
        public Avion Avion { get; set; }
        public Klasa Klasa { get; set; }
        public double Cena { get; set; }
        public Boolean Rezervisano { get; set; }

        public string Table => "Sediste";

        public string FullTable => "Sediste s";

        public string InsertValues => "";

        public string UpdateValues => "set Rezervisano = 'false'";

        public string Join => "";

        public string SearchId => "";

        public object ColumnId => "";

        public object Get => "Select * from";

        public string Kriterijum { get; set; }
        //$"Select * from Sediste where SifraAviona = {avion.SifraAviona} and Rezervisano = 0";
        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Sediste s = new Sediste();
                s.Avion = new Avion();
                s.Avion.SifraAviona = reader.GetInt32(0);
                s.BrojSedista = reader.GetInt32(1);
                if (reader.GetString(2) == "Biznis")
                    s.Klasa = Klasa.Biznis;
                else if (reader.GetString(2) == "Prva")
                    s.Klasa = Klasa.Prva;
                else s.Klasa = Klasa.Ekonomska;
                s.Cena = reader.GetDouble(3);
                s.Rezervisano = reader.GetBoolean(4);

                lista.Add(s);
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
            return $"where SifraAviona = {krit} and Rezervisano = 0"; 
        }

        public string SearchWhere()
        {
            return "";
        }

        public override string ToString()
        {
            return Convert.ToString(BrojSedista);
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
            return $"where SifraAviona = {s1} and BrojSedista = {s2}";
        }
    }

    public enum Klasa
    {
        Ekonomska,Biznis,Prva
    }
}
