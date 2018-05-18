using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdysseyClient
{
    public partial class VentanaLogIn : Form
    {
        public VentanaLogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }
    }
}
