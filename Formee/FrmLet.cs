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
        KKIFrmLet kontroler = new KKIFrmLet();
        public FrmLet(Let l)
        {
            InitializeComponent();
            let = l;
        }

        private void FrmLet_Load(object sender, EventArgs e)
        {
            try
            {
                kontroler.OtvoriLet(textBox1, textBox2, textBox3, comboBox3, let,label1);
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
                kontroler.SacuvajLet(textBox1,textBox2,textBox3,comboBox3,let);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }
    }
}
