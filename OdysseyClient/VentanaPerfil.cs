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
            string usua = textBoxUs.Text;
            string nombre = textBoxNom.Text;
            string edad = textBoxEd.Text;
            XmlDocument data;
            XmlNode nodoUser = null;
            if (usua != "")
            {
                if (nombre != "")
                {
                    if (edad != "")
                    {
                        data = msj.editarUsuario(usuario, usua, nombre, edad);
                        nodoUser = aceptar(data);
                    }
                    else
                    {
                        data = msj.editarUsuario(usuario, usua, nombre, lblEdad.Text.ToString());
                        nodoUser = aceptar(data);
                    }

                }
                else if (edad != "")
                {
                    data = msj.editarUsuario(usuario, usua, lblNombre.Text.ToString(), edad);
                    nodoUser = aceptar(data);
                }
                else
                {
                    data = msj.editarUsuario(usuario, usua, lblNombre.Text.ToString(), lblEdad.Text.ToString());
                    nodoUser = aceptar(data);
                }
            }
            else if (nombre != "")
            {
                if (edad != "")
                {
                    data = msj.editarUsuario(usuario, usuario, nombre, edad);
                    nodoUser = aceptar(data);
                }
                else
                {
                    data = msj.editarUsuario(usuario, usuario, nombre, lblEdad.Text.ToString());
                    nodoUser = aceptar(data);
                }
            }
            else if (edad != "")
            {
                data = msj.editarUsuario(usuario, usuario, lblNombre.Text.ToString(), edad);
                nodoUser = aceptar(data);
            }
            if (nodoUser != null)
            {
                usua = nodoUser.SelectSingleNode("usuario").InnerText.ToString();
                nombre = nodoUser.SelectSingleNode("nombre").InnerText.ToString();
                edad = nodoUser.SelectSingleNode("edad").InnerText.ToString();
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

        private XmlNode aceptar(XmlDocument data)
        {
            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            string resp = sock.abrirSocket(msjEnviar);
            XmlDocument xmlUsuario = new XmlDocument();
            xmlUsuario.LoadXml(resp);

            XmlNodeList listUs = xmlUsuario.GetElementsByTagName("User");
            XmlNode nodoUser = listUs.Item(0);
            return nodoUser;
        }

    }
}
