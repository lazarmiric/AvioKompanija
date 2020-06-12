using AvioKompanija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    public class KKIFrmLet
    {
        public void SacuvajLet(TextBox textBox1, TextBox textBox2, TextBox textBox3, ComboBox comboBox3, Let let)
        {
            try
            {
                Let novi = new Let();
                novi.SifraLet = let.SifraLet;

                Avion a = new Avion();
                a = comboBox3.SelectedItem as Avion;
                novi.Avion = a;
                bool uspeh = KontrolerKorisnickogInterfejsa.Instance.IzmeniLet(novi);
                if (uspeh) MessageBox.Show("Izmene uspesno sacuvane!");
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
        public void OtvoriLet(TextBox textBox1, TextBox textBox2, TextBox textBox3, ComboBox comboBox3, Let let,Label label1)
        {
            comboBox3.DataSource = KontrolerKorisnickogInterfejsa.Instance.VratiAvione();
            textBox1.Text = let.DatumPolaska.ToString("dd.MM.yyyy hh:mm");
            label1.Text = Convert.ToString(let.SifraLet);
            textBox2.Text = let.DestinacijaOD.Naziv;
            textBox3.Text = let.DestinacijaDO.Naziv;
        }
    }
}
