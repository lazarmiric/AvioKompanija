using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    static class Program
    {
        public static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            FormPrijava frmPrijava = new FormPrijava();
            frmPrijava.ShowDialog();
        }
    }
}
