using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvioKompanija
{

    public interface IDomenskiObjekat
    {
        string Table { get; }
        string FullTable { get; }
        string InsertValues { get; }
        string UpdateValues { get; }
        string Join { get; }
        string SearchWhere();
        string SearchKrit(int krit);
        string Uslov();
        string Search(string s);
        string UslovLog(string s1, string s2);
        string UslovSe(int s1, int s2);
        string SearchId { get; }
        object ColumnId { get; }
        object Get { get; }
        string Kriterijum { get; set; }
        List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader);
      
       
    }
}
