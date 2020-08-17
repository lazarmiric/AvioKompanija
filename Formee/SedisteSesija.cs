using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formee
{
    public class SedisteSesija
    {
        private static SedisteSesija instance;
        public static SedisteSesija Instance
        {
            get
            {
                if (instance == null) instance = new SedisteSesija();
                return instance;
            }
        }
        private SedisteSesija() { }
        public int Sediste { get; set; }

        public int SedistePovratak { get; set; }
    }
}
