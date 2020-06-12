using AvioKompanija;
using Domen;
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
    public partial class FormPrijava : Form
    {
        KKIPrijava kontroler = new KKIPrijava();
        public FormPrijava()
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
        }
       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                kontroler.Registruj(label3);
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
                kontroler.Prijavi(textBox1, textBox2,label3);
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
