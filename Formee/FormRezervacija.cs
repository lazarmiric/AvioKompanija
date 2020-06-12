using AvioKompanija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formee
{
    public partial class FormRezervacija : Form
    {
        KKIRezervacija kontroler = new KKIRezervacija();
        public FormRezervacija()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                lbDatumOdl.Visible = false;
                label5.Visible = false;

            }
            else
            {
                label5.Visible = true;
                lbDatumOdl.Visible = true;
            }
        }
        List<Destinacija> destinacije = new List<Destinacija>();
        List<Let> letovi = new List<Let>();
        List<Avion> avioni = new List<Avion>();
        //List<Sediste> sedista = new List<Sediste>();

        private void Rezervacija_Load(object sender, EventArgs e)
        {
            destinacije = KontrolerKorisnickogInterfejsa.Instance.VratiDestinacije();
            letovi = KontrolerKorisnickogInterfejsa.Instance.VratiLetove();
            avioni = KontrolerKorisnickogInterfejsa.Instance.VratiAvione();
            try
            {
                kontroler.OtvoriRezervacije(letovi, label5,lbDatumOdl, cmbDestinacijeOd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDestinacijeOd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                kontroler.PromenaDestinacijeOd(letovi, cmbDestinacijeOd, cmbDestinacijeDo, lbDatumPolaska, lbDatumOdl, cmbAvion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }          

        private void cmbDestinacijeDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                kontroler.PromenaDestinacije(letovi, cmbDestinacijeOd, cmbDestinacijeDo, lbDatumPolaska, lbDatumOdl, cmbAvion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                kontroler.SacuvajRezervaciju(rezervacije);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        BindingList<Rezervacija> rezervacije = new BindingList<Rezervacija>();
        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            try
            {
                kontroler.Rezervisi(cmbDestinacijeOd, cmbDestinacijeDo, lbDatumPolaska, lbDatumOdl, cmbAvion,
                    cmbSediste, checkBox1, dataGridView1, rezervacije, avioni, letovi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        private void cmbAvion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                kontroler.PromenaAviona(cmbSediste, cmbAvion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                kontroler.Otkazi(dataGridView1, rezervacije);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            FrmPretragaLeta pl = new FrmPretragaLeta();
            pl.ShowDialog();
        }
    }
}
