using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
            button1.Enabled = false;

        }
        Server s;

        private void button2_Click(object sender, EventArgs e)
        {
            s = new Server();
            if (s.PokreniServer())
            {
                label2.Text = "Pokrenut server";
                button2.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (s.ZaustaviServer())
            {
                label2.Text = "Zaustavljen server";
                button2.Enabled = true;
                button1.Enabled= false;
                MessageBox.Show("Server je zaustavljen", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
