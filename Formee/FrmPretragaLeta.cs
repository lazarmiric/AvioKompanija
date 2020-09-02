using AvioKompanija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    public partial class FrmPretragaLeta : Form
    {
        KKIPretragaLeta kontroler = new KKIPretragaLeta();
        public FrmPretragaLeta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                kontroler.Pretrazi(txtOd, txtDo, dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = txtOd.Text;
            txtOd.Text = txtDo.Text;
            txtDo.Text = s;
        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            try
            {
                kontroler.Odaberi(dataGridView1);
                if(LetSesija.Instance.OdabraniLet != null)
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
