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
                lblSedistePov.Visible = false;
                lblSedistePovratak.Visible = false;

            }
            else
            {
                label5.Visible = true;
                lbDatumOdl.Visible = true;
                lblSedistePov.Visible = true;
                lblSedistePovratak.Visible = true;
            }
        }
        List<Destinacija> destinacije = new List<Destinacija>();
        List<Let> letovi = new List<Let>();
        List<Avion> avioni = new List<Avion>();
        List<Aerodrom> aero = new List<Aerodrom>();
        List<Rezervacija> sveRezerv = new List<Rezervacija>();
        //List<Sediste> sedista = new List<Sediste>();

        private void Rezervacija_Load(object sender, EventArgs e)
        {
            destinacije = KontrolerKorisnickogInterfejsa.Instance.VratiDestinacije();
            letovi = KontrolerKorisnickogInterfejsa.Instance.VratiLetove();
            avioni = KontrolerKorisnickogInterfejsa.Instance.VratiAvione();
            aero = KontrolerKorisnickogInterfejsa.Instance.VratiAerodrome();
            sveRezerv = KontrolerKorisnickogInterfejsa.Instance.UcitajRezervacije();
            try
            {
                kontroler.OtvoriRezervacije(letovi, label5, lbDatumOdl, cmbDestinacijeOd, lblSedistePovratak,lblSedistePov); ;
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
                kontroler.PromenaDestinacijeOd(letovi, cmbDestinacijeOd, cmbDestinacijeDo, lbDatumPolaska, lbDatumOdl, cmbAvion,sveRezerv,lblSedistePocetak,lblSedistePov);
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

                kontroler.PromenaDestinacije(letovi, cmbDestinacijeOd, cmbDestinacijeDo, lbDatumPolaska, lbDatumOdl, cmbAvion, lblSedistePov,lblSedistePocetak) ;
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
                    checkBox1, dataGridView1, rezervacije, avioni, letovi,lblSedistePocetak,lblSedistePov) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        //private void cmbAvion_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        kontroler.PromenaAviona(cmbSediste, cmbAvion);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
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
          
            try
            {
                if(LetSesija.Instance.OdabraniLet != null)
                kontroler.Sredi(cmbDestinacijeOd, cmbDestinacijeDo, cmbAvion, lbDatumPolaska);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOdaberiSediste_Click(object sender, EventArgs e)
        {
            FormSedista frmSedista = new FormSedista(checkBox1, cmbDestinacijeOd, cmbDestinacijeDo, lbDatumPolaska, lbDatumOdl, cmbAvion);
            frmSedista.ShowDialog();
            lblSedistePocetak.Text = Convert.ToString(SedisteSesija.Instance.Sediste);
            if (lblSedistePocetak.Text == "0") lblSedistePocetak.Text = "-";
            lblSedistePov.Text = Convert.ToString(SedisteSesija.Instance.SedistePovratak);
            if (lblSedistePov.Text == "0") lblSedistePov.Text = "-";
        }

        private void lbDatumPolaska_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSedistePov.Text = "-";
            lblSedistePocetak.Text = "-";
        }

        private void lbDatumOdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSedistePov.Text = "-";
            lblSedistePocetak.Text = "-";
        }
      
    }
}
