using AvioKompanija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    public class KKIPretragaLeta
    {

        public void Pretrazi(TextBox txtOd,TextBox txtDo, DataGridView dataGridView1)
        {
            try
            {
                if (txtOd.Text == "" && txtDo.Text == "")
                {
                    MessageBox.Show("Morate uneti bar jedan kriterijum");
                    return;
                }
                Let l = new Let { Filter1 = txtOd.Text, Filter2 = txtDo.Text };
                List<Let> filterLet = new List<Let>();

                filterLet = KontrolerKorisnickogInterfejsa.Instance.PronadjiLet(l);
                if (filterLet.Count == 0) MessageBox.Show("Nema letova po datom kriterijumu!");
                dataGridView1.DataSource = filterLet;
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show("Server je iskljucen!");
                Environment.Exit(0);

            }
        }
    }
}
