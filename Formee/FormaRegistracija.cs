using Domen;
using Kontroler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{

 
    public partial class FormaRegistracija : Form
    {

        KKIRegistracija kontroler = new KKIRegistracija();
        public FormaRegistracija()
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
        }     

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                kontroler.Registruj(txJmbg, txtIme, txtKorisnickoIme, txtPass, txtPRez,dateTimePicker1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          

        }
        private void FrmClose()
        {
            this.Close();
        }
    }
}
