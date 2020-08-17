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
    public partial class FormSedista : Form
    {
        CheckBox cbx = new CheckBox();
        ComboBox odDest = new ComboBox();
        ComboBox doDest = new ComboBox();
        ListBox datumPolaska = new ListBox();
        ListBox datumOdlaska = new ListBox();
        ComboBox avion = new ComboBox();
        List<Rezervacija> sveRez = new List<Rezervacija>();
        public FormSedista(CheckBox cb, ComboBox cmbDestinacijeOd, ComboBox cmbDestinacijeDo, ListBox lbDatumPolaska, ListBox lbDatumOdl, ComboBox cmbAvion)
        {
            InitializeComponent();
            cbx = cb;
            odDest = cmbDestinacijeOd;
            doDest = cmbDestinacijeDo;
            datumPolaska = lbDatumPolaska;
            datumOdlaska = lbDatumOdl;
            avion = cmbAvion;
            
        }

        private void FormSedista_Load(object sender, EventArgs e)
        {
            sveRez = KontrolerKorisnickogInterfejsa.Instance.UcitajRezervacije();

            b1.BackColor = Color.Green;
            b2.BackColor = Color.Green;
            b3.BackColor = Color.Green;
            b4.BackColor = Color.Green;
            b5.BackColor = Color.Green;
            b6.BackColor = Color.Green;
            b7.BackColor = Color.Green;
            b8.BackColor = Color.Green;
            b9.BackColor = Color.Green;
            b10.BackColor = Color.Green;
            b11.BackColor = Color.Green;
            b12.BackColor = Color.Green;
            b13.BackColor = Color.Green;
            b14.BackColor = Color.Green;
            b15.BackColor = Color.Green;
            b16.BackColor = Color.Green;
            b17.BackColor = Color.Green;
            b18.BackColor = Color.Green;
            b19.BackColor = Color.Green;
            b20.BackColor = Color.Green;
            b21.BackColor = Color.Green;
            b22.BackColor = Color.Green;
            b23.BackColor = Color.Green;
            b24.BackColor = Color.Green;


            bp1.BackColor = Color.Green;
            bp2.BackColor = Color.Green;
            bp3.BackColor = Color.Green;
            bp4.BackColor = Color.Green;
            bp5.BackColor = Color.Green;
            bp6.BackColor = Color.Green;
            bp7.BackColor = Color.Green;
            bp8.BackColor = Color.Green;
            bp9.BackColor = Color.Green;
            bp10.BackColor = Color.Green;
            bp11.BackColor = Color.Green;
            bp12.BackColor = Color.Green;
            bp13.BackColor = Color.Green;
            bp14.BackColor = Color.Green;
            bp15.BackColor = Color.Green;
            bp16.BackColor = Color.Green;
            bp17.BackColor = Color.Green;
            bp18.BackColor = Color.Green;
            bp19.BackColor = Color.Green;
            bp20.BackColor = Color.Green;
            bp21.BackColor = Color.Green;
            bp22.BackColor = Color.Green;
            bp23.BackColor = Color.Green;
            bp24.BackColor = Color.Green;


            if (!cbx.Checked)
            {
                panelPovratna.Visible = false;
                lblSedistePov.Visible = false;
                lblPovratno.Visible = false;
            }
            foreach (Rezervacija r in sveRez)
            {
                if (cbx.Checked)
                {
                    if (r.Let.DestinacijaOD.Grad == ((doDest.SelectedItem) as Aerodrom).Grad
                        && r.Let.DestinacijaDO.Grad == ((odDest.SelectedItem) as Aerodrom).Grad
                        && r.Let.DatumPolaska == Convert.ToDateTime(datumOdlaska.SelectedItem))
                    {
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp1.Text)) { bp1.Enabled = false; bp1.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp2.Text)) { bp2.Enabled = false; bp2.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp3.Text)) { bp3.Enabled = false; bp3.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp4.Text)) { bp4.Enabled = false; bp4.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp5.Text)) { b5.Enabled = false; bp5.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp6.Text)) { bp6.Enabled = false; bp6.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp7.Text)) { bp7.Enabled = false; bp7.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp8.Text)) { bp8.Enabled = false; bp8.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp9.Text)) { bp9.Enabled = false; bp9.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp10.Text)) { bp10.Enabled = false; bp10.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp11.Text)) { bp11.Enabled = false; bp11.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp12.Text)) { bp12.Enabled = false; bp12.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp13.Text)) { bp13.Enabled = false; bp13.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp14.Text)) { bp14.Enabled = false; bp14.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp15.Text)) { bp15.Enabled = false; bp15.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp16.Text)) { bp16.Enabled = false; bp16.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp17.Text)) { bp17.Enabled = false; bp17.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp18.Text)) { bp18.Enabled = false; bp18.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp19.Text)) { bp19.Enabled = false; bp19.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp20.Text)) { bp20.Enabled = false; bp20.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp21.Text)) { bp21.Enabled = false; bp21.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp22.Text)) { bp22.Enabled = false; bp22.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp23.Text)) { bp23.Enabled = false; bp23.BackColor = Color.Red; }
                        if (r.Sediste.BrojSedista == Convert.ToInt32(bp24.Text)) { bp24.Enabled = false; bp24.BackColor = Color.Red; }
                    }
                }


                if (r.Let.DestinacijaOD.Grad == ((odDest.SelectedItem) as Aerodrom).Grad
                    && r.Let.DestinacijaDO.Grad == ((doDest.SelectedItem) as Aerodrom).Grad
                    && r.Let.DatumPolaska == Convert.ToDateTime(datumPolaska.SelectedItem))
                {
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b1.Text)) { b1.Enabled = false; b1.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b2.Text)) { b2.Enabled = false; b2.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b3.Text)) { b3.Enabled = false; b3.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b4.Text)) { b4.Enabled = false; b4.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b5.Text)) { b5.Enabled = false; b5.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b6.Text)) { b6.Enabled = false; b6.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b7.Text)) { b7.Enabled = false; b7.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b8.Text)) { b8.Enabled = false; b8.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b9.Text)) { b9.Enabled = false; b9.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b10.Text)) { b10.Enabled = false; b10.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b11.Text)) { b11.Enabled = false; b11.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b12.Text)) { b12.Enabled = false; b12.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b13.Text)) { b13.Enabled = false; b13.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b14.Text)) { b14.Enabled = false; b14.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b15.Text)) { b15.Enabled = false; b15.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b16.Text)) { b16.Enabled = false; b16.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b17.Text)) { b17.Enabled = false; b17.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b18.Text)) { b18.Enabled = false; b18.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b19.Text)) { b19.Enabled = false; b19.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b20.Text)) { b20.Enabled = false; b20.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b21.Text)) { b21.Enabled = false; b21.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b22.Text)) { b22.Enabled = false; b22.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b23.Text)) { b23.Enabled = false; b23.BackColor = Color.Red; }
                    if (r.Sediste.BrojSedista == Convert.ToInt32(b24.Text)) { b24.Enabled = false; b24.BackColor = Color.Red; }
                }

            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "1";
        }

        private void b2_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "2";
        }

        private void b3_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "3";
        }

        private void b4_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "4";
        }

        private void b5_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "5";
        }

        private void b6_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "6";
        }

        private void b7_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "7";
        }

        private void b8_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "8";
        }

        private void b9_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "9";
        }

        private void b10_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "10";
        }

        private void b11_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "11";
        }

        private void b12_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "12";
        }

        private void b13_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "13";
        }

        private void b14_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "14";
        }

        private void b15_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "15";
        }

        private void b16_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "16";
        }

        private void b17_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "17";
        }

        private void b18_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "18";
        }

        private void b19_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "19";
        }

        private void b20_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "20";
        }

        private void b21_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "21";
        }

        private void b22_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "22";
        }

        private void b23_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "23";
        }

        private void b24_Click(object sender, EventArgs e)
        {
            lblSediste.Text = "24";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {              
                SedisteSesija.Instance.Sediste = Convert.ToInt32(lblSediste.Text);
                if(cbx.Checked) SedisteSesija.Instance.SedistePovratak = Convert.ToInt32(lblSedistePov.Text);
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Morate odabrati sediste!");
            }
        }

        private void bp1_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "1";
        }

        private void bp2_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "2";
        }

        private void bp3_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "3";
        }

        private void bp4_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "4";
        }

        private void bp5_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "5";
        }

        private void bp6_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "6";
        }

        private void bp7_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "7";
        }

        private void bp8_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "8";
        }

        private void bp9_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "9";
        }

        private void bp10_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "10";
        }

        private void bp11_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "11";
        }

        private void bp12_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "12";
        }

        private void bp13_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "13";
        }

        private void bp14_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "14";
        }

        private void bp15_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "15";
        }

        private void bp16_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "16";
        }

        private void bp17_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "17";
        }

        private void bp18_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "18";
        }

        private void bp19_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "19";
        }

        private void bp20_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "20";
        }

        private void bp21_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "21";
        }

        private void bp22_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "22";
        }

        private void bp23_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "23";
        }

        private void bp24_Click(object sender, EventArgs e)
        {
            lblSedistePov.Text = "24";
        }
    }
}
