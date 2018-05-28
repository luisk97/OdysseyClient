using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OdysseyClient
{
    public partial class VentanaPerfil : Form
    {
        private MensajeXML msj = new MensajeXML();
        private SocketCliente sock = new SocketCliente();
        private string usuario;
        private Principal principal;

        public VentanaPerfil(string usuario, string nombre, string edad, Principal principal)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.principal = principal;
            lblUsuario.Text = usuario;
            lblNombre.Text = nombre;
            lblEdad.Text = edad;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBoxUs.Text = "";
            textBoxNom.Text = "";
            textBoxEd.Text = "";
            panelEdit.Visible = false;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            XmlDocument data = msj.editarUsuario(usuario, textBoxUs.Text.ToString(), textBoxNom.Text.ToString(), textBoxEd.Text.ToString());

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            string resp = sock.abrirSocket(msjEnviar);
            XmlDocument xmlUsuario = new XmlDocument();
            xmlUsuario.LoadXml(resp);

            XmlNodeList listUs = xmlUsuario.GetElementsByTagName("User");
            XmlNode nodoUser = listUs.Item(0);

            string usua = nodoUser.SelectSingleNode("usuario").InnerText.ToString();
            string nombre = nodoUser.SelectSingleNode("nombre").InnerText.ToString();
            string edad = nodoUser.SelectSingleNode("edad").InnerText.ToString();
            this.usuario = usua;

            principal.usuario = usua;

            lblUsuario.Text = usua;
            lblNombre.Text = nombre;
            lblEdad.Text = edad;

            textBoxUs.Text = "";
            textBoxNom.Text = "";
            textBoxEd.Text = "";
            panelEdit.Visible = false;
        }
        
    }
}
