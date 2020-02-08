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
using AvioKompanija;

namespace Formee
{
    public partial class FrmLet : Form
    {
        Let let = new Let();
        public FrmLet(Let l)
        {
            InitializeComponent();
            let = l;
        }

        private void FrmLet_Load(object sender, EventArgs e)
        {
            comboBox3.DataSource = KontrolerKorisnickogInterfejsa.Instance.VratiAvione();

            textBox1.Text = let.DatumPolaska.ToString("dd.MM.yyyy hh:mm");
            label1.Text = Convert.ToString(let.SifraLet);
            textBox2.Text = let.DestinacijaOD.Naziv;
            textBox3.Text = let.DestinacijaDO.Naziv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Let novi = new Let();
                novi.SifraLet = let.SifraLet;
               
                Avion a = new Avion();
                a = comboBox3.SelectedItem as Avion;
                novi.Avion = a;
               // novi.DatumPolaska = DateTime.ParseExact(textBox1.Text,"dd.MM.yyyy hh:mm",CultureInfo.InvariantCulture);
                bool uspeh = KontrolerKorisnickogInterfejsa.Instance.IzmeniLet(novi);
                if (uspeh)  MessageBox.Show("Izmene uspesno sacuvane!"); 
                else MessageBox.Show("Sistem ne moze da sacuva izmene!");
            }
            catch (FormatException)
            {
                
                MessageBox.Show("Greska!");
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }
    }
}
