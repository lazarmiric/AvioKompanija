using AvioKompanija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formee
{
    public class LetSesija
    {
        private static LetSesija instance;
        public static LetSesija Instance
        {
            get
            {
                if (instance == null) instance = new LetSesija();
                return instance;
            }
        }
        private LetSesija() { }
       

        public Let OdabraniLet { get; set; }
    }
}
