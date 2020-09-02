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
            int ukupnoSedista = (avion.SelectedItem as Avion).BrojSedista;
            tableLayoutPanel1.ColumnCount = ukupnoSedista / 4;
            tableLayoutPanel1.RowCount = 4;
            for (int i = 0; i < ukupnoSedista / 4; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0)
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                    Button b = new Button();
                    b.Name = "b" + (j * ukupnoSedista / 4 + i + 1);
                    b.Size = new System.Drawing.Size(37, 25);
                    b.TabIndex = 45;
                    //  b.Text = (j).ToString() + "," + (i).ToString();
                    b.Text = (j * ukupnoSedista / 4 + i + 1).ToString();
                    b.UseVisualStyleBackColor = true;
                    b.Click += B_Click;
                    b.BackColor = Color.Green;
                    this.tableLayoutPanel1.Controls.Add(b, i, j);
                }
            }
            sveRez = KontrolerKorisnickogInterfejsa.Instance.UcitajRezervacije();
            int brPovratak = 0;
            if (cbx.Checked)
            {
                foreach (Rezervacija r in sveRez)
                {

                    if (r.Let.DestinacijaOD.Grad == ((doDest.SelectedItem) as Aerodrom).Grad
                        && r.Let.DestinacijaDO.Grad == ((odDest.SelectedItem) as Aerodrom).Grad
                        && r.Let.DatumPolaska == Convert.ToDateTime(datumOdlaska.SelectedItem))
                    {


                        brPovratak = r.Avion.BrojSedista;

                    }
                }
            }

            tableLayoutPanel2.ColumnCount = brPovratak / 4;
            tableLayoutPanel2.RowCount = 4;
            for (int i = 0; i < brPovratak / 4; i++)
            {
                tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0)
                    {
                        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                    Button but = new Button();
                    but.Name = "but" + (j * ukupnoSedista / 4 + i + 1);
                    but.Size = new System.Drawing.Size(37, 25);
                    but.TabIndex = 45;
                    //  b.Text = (j).ToString() + "," + (i).ToString();
                    but.Text = (j * brPovratak / 4 + i + 1).ToString();
                    but.UseVisualStyleBackColor = true;
                    but.Click += B1_Click;
                    but.BackColor = Color.Green;
                    this.tableLayoutPanel2.Controls.Add(but, i, j);
                }
            }


         


                        foreach (Rezervacija r in sveRez){
                foreach (Control c in this.tableLayoutPanel1.Controls)
                {
                    if (r.Let.DestinacijaOD.Grad == ((odDest.SelectedItem) as Aerodrom).Grad
                    && r.Let.DestinacijaDO.Grad == ((doDest.SelectedItem) as Aerodrom).Grad
                    && r.Let.DatumPolaska == Convert.ToDateTime(datumPolaska.SelectedItem))
                    {
                        if (r.Sediste.BrojSedista == Convert.ToInt32(c.Text))
                        {
                            c.BackColor = Color.Red;
                            c.Enabled = false;
                        }
                    }
                }
            }
            if (cbx.Checked)
            {
                foreach (Rezervacija r in sveRez)
                {
                    foreach (Control c in this.tableLayoutPanel2.Controls)
                    {
                        if (r.Let.DestinacijaOD.Grad == ((doDest.SelectedItem) as Aerodrom).Grad
                        && r.Let.DestinacijaDO.Grad == ((odDest.SelectedItem) as Aerodrom).Grad
                        && r.Let.DatumPolaska == Convert.ToDateTime(datumOdlaska.SelectedItem))
                        {
                            if (r.Sediste.BrojSedista == Convert.ToInt32(c.Text))
                            {
                                c.BackColor = Color.Red;
                                c.Enabled = false;
                            }

                        }
                    }
                }
            }


        }

        private void B1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            lblSedistePov.Text = b.Text;
        }

        private void B_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            lblSediste.Text = b.Text;
        }

        private void FormSedista_Load(object sender, EventArgs e)
        {
            sveRez = KontrolerKorisnickogInterfejsa.Instance.UcitajRezervacije();
                      
            if (!cbx.Checked)
            {
                
                lblSedistePov.Visible = false;
                lblPovratno.Visible = false;
                tableLayoutPanel2.Visible = false;
            }
           
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

        private void b9_Click(object sender, EventArgs e)
        {

        }

        private void b2_Click(object sender, EventArgs e)
        {

        }

        private void b8_Click(object sender, EventArgs e)
        {

        }

        private void b3_Click(object sender, EventArgs e)
        {

        }

        private void b7_Click(object sender, EventArgs e)
        {

        }

        private void b4_Click(object sender, EventArgs e)
        {

        }

        private void b5_Click(object sender, EventArgs e)
        {

        }

        private void b6_Click(object sender, EventArgs e)
        {

        }

        private void b10_Click(object sender, EventArgs e)
        {

        }

        private void b1_Click(object sender, EventArgs e)
        {

        }

        private void b11_Click(object sender, EventArgs e)
        {

        }

        private void b12_Click(object sender, EventArgs e)
        {

        }

        private void b21_Click(object sender, EventArgs e)
        {

        }

        private void b14_Click(object sender, EventArgs e)
        {

        }

        private void b20_Click(object sender, EventArgs e)
        {

        }

        private void b15_Click(object sender, EventArgs e)
        {

        }

        private void b19_Click(object sender, EventArgs e)
        {

        }

        private void b16_Click(object sender, EventArgs e)
        {

        }

        private void b17_Click(object sender, EventArgs e)
        {

        }

        private void b18_Click(object sender, EventArgs e)
        {

        }

        private void b22_Click(object sender, EventArgs e)
        {

        }

        private void b13_Click(object sender, EventArgs e)
        {

        }

        private void b23_Click(object sender, EventArgs e)
        {

        }

        private void b24_Click(object sender, EventArgs e)
        {

        }
    }
}
