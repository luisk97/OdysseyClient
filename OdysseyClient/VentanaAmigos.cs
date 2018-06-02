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
    public partial class VentanaAmigos : Form
    {
        SocketCliente sock = new SocketCliente();
        private MensajeXML msj = new MensajeXML();
        XmlNodeList listUs;
        string user = "";
        public VentanaAmigos(XmlNodeList listUs, string user)
        {
            InitializeComponent();
            this.listUs = listUs;
            this.user = user;
            if(listUs != null)
            {
                actualizarLista(listUs);
            }
            else
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridViewAmigos);
                fila.Cells[0].Value = "En este momento";
                fila.Cells[1].Value = "no tienes amigos en tu lista de amigos";
                dataGridViewAmigos.Rows.Add(fila);
            }
        }

        private void btnAmigos_Click(object sender, EventArgs e)
        {
            string usuario = textBoxBuscarA.Text;
            XmlDocument data = msj.buscarAmigo(usuario);

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            string resp = sock.abrirSocket(msjEnviar);

            if(resp.Equals("No existe"))
            {
                MessageBox.Show("No se encontro ningun usuario", "Buscar Amigos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resp.Equals("Existe"))
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Quieres añadir al usuario " + usuario + " como amigo?", "Buscar Amigos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {

                    usuario = textBoxBuscarA.Text;
                    data = msj.addAmigo(usuario,user);

                    ms = new MemoryStream();
                    data.Save(ms);
                    msjEnviar = ms.ToArray();

                    resp = sock.abrirSocket(msjEnviar);
                    XmlDocument xmlUsuario = new XmlDocument();
                    xmlUsuario.LoadXml(resp);
                    XmlNodeList listaXml = xmlUsuario.GetElementsByTagName("Usuario");
                    XmlNode nodoAmigo = listaXml.Item(0);
                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dataGridViewAmigos);
                    fila.Cells[0].Value = nodoAmigo.SelectSingleNode("usuario").InnerText;
                    fila.Cells[1].Value = nodoAmigo.SelectSingleNode("nombre").InnerText;
                    dataGridViewAmigos.Rows.Add(fila);

                    data = msj.addAmigo(usuario,user);
                    data.Save(ms);
                    msjEnviar = ms.ToArray();

                    resp = sock.abrirSocket(msjEnviar);

                    MessageBox.Show("("+resp+") el usuario se agrego con exito a tu lista de amigos", "Buscar Amigos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewAmigos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void actualizarLista(XmlNodeList listaXml)
        {
            dataGridViewAmigos.Rows.Clear();

            XmlNode nodoAmigo;
            for (int i = 0; i < listaXml.Count; i++)
            {
                nodoAmigo = listaXml.Item(i);
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridViewAmigos);
                fila.Cells[0].Value = nodoAmigo.SelectSingleNode("usuario").InnerText;
                fila.Cells[1].Value = nodoAmigo.SelectSingleNode("nombre").InnerText;
                dataGridViewAmigos.Rows.Add(fila);
            }
            
        }
    }
}
