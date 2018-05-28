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
    public partial class VentanaPerfil : Form
    {
        public VentanaPerfil(string usuario, string nombre, string edad)
        {
            InitializeComponent();
            lblUsuario.Text = usuario;
            lblNombre.Text = nombre;
            lblEdad.Text = edad;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
