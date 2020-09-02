using AvioKompanija;
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
    public partial class Administracija : Form
    {
        KKIAdministracija kontroler = new KKIAdministracija();
        public Administracija()
        {
            InitializeComponent();
        }

        private void Administracija_Load(object sender, EventArgs e)
        {
            try
            {
                kontroler.OtvoriAdmin(dataGridView1, cmbOD, cmbDo, cmbAvion, rez);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        List<Rezervacija> rez = new List<Rezervacija>();
        
        private void btnDodajLet_Click(object sender, EventArgs e)
        {

            try
            {
                kontroler.DodajLet(cmbOD,cmbDo,cmbAvion,dataGridView2,dateTimePicker1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnIzmeniLet_Click(object sender, EventArgs e)
        {
            try
            {
                kontroler.IzmeniLet(dataGridView2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            try
            {
                kontroler.Pretrazi(txtPretraziRez,dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        } 

        private void btnOtkaziRez_Click(object sender, EventArgs e)
        {
            try
            {
                kontroler.Otkazi(txtPretraziRez, dataGridView1,rez);
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
                kontroler.PretraziLetove(txtOd,txtDo,dataGridView2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnZameni_Click(object sender, EventArgs e)
        {
            int pom = cmbDo.SelectedIndex;
            cmbDo.SelectedIndex = cmbOD.SelectedIndex;
            cmbOD.SelectedIndex = pom;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pom = txtOd.Text;
            txtOd.Text = txtDo.Text;
            txtDo.Text = pom;
        }
    }
}
