using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;

namespace OdysseyClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private string abrirSocket(object o)
        {
            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            listen.Connect(direccion);

            byte[] msjEnviar = (byte[])o;
            listen.Send(msjEnviar, 0, msjEnviar.Length, 0);

            byte[] bytes = new byte[30000];
            //recibe datos y devuelve el número de bytes leídos correctamente
            int count = listen.Receive(bytes);
            //decodifica bytes a nueva cadena string
            resp = System.Text.Encoding.ASCII.GetString(bytes, 0, count); 

            listen.Close();

            return resp;
        }


        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        String resp = "";
        XmlDocument xmlCanciones = new XmlDocument();
        ListaCanciones lista = new ListaCanciones();
        //List<Cancion> lista = new List<Cancion>();

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;

            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.cargarCanciones("nombre");

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = abrirSocket(msjEnviar);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlCanciones.LoadXml(resp);
            xmlCanciones.WriteTo(xw);

            XmlNodeList listaXml = xmlCanciones.SelectNodes("Cancion");
            actualizarLista(listaXml);

            string XmlString = sw.ToString();

            listBox1.Items.Add(XmlString);

            richTextBox1.Text = XmlString + "Lo logramos perro Wuuuuuuuuuuhhhhhooooohhhh!!!!!! XD";
        }

        private void actualizarLista(XmlNodeList listaXml)
        {
            //lista.Clear();
            //lista.clear();
            XmlNode nodoCancion;
            for (int i = 0; i < listaXml.Count; i++)
            {
                nodoCancion = listaXml.Item(i);
                Cancion cancion = new Cancion();
                cancion.Nombre = nodoCancion.SelectSingleNode("Nombre").InnerText;
                cancion.Artista = nodoCancion.SelectSingleNode("Artista").InnerText;
                cancion.Album = nodoCancion.SelectSingleNode("Album").InnerText;
                cancion.Genero = nodoCancion.SelectSingleNode("Genero").InnerText;
                cancion.Letra = nodoCancion.SelectSingleNode("Letra").InnerText;

                lista.addNodo(cancion);
                //lista.Add(cancion);
            }
            for (int ind = 0; ind < lista.Size(); ind++)
            {
                listBox1.Items.Add(lista.obtener(ind).getSong().ToString());
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;

            listBox1.Items.Add("Me cago");

            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.cargarCanciones("artista");

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = abrirSocket(msjEnviar);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlCanciones.LoadXml(resp);
            xmlCanciones.WriteTo(xw);

            string XmlString = sw.ToString();

            listBox1.Items.Add(XmlString);

            richTextBox1.Text = XmlString+"Ahi esta perro";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;

            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.cargarCanciones("album");

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = abrirSocket(msjEnviar);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlCanciones.LoadXml(resp);
            xmlCanciones.WriteTo(xw);

            string XmlString = sw.ToString();

            listBox1.Items.Add(XmlString);

            richTextBox1.Text = XmlString + "Ahi esta perro";
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivo mp3(*.mp3)|*.mp3";
            open.Title = "Archivos mp3";
            if (open.ShowDialog() == DialogResult.OK)
            {

                string ruta = open.FileName;

                Form3 ventanaAdd = new Form3(ruta);
                ventanaAdd.Owner = this;
                ventanaAdd.ShowDialog();

            }
            open.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel3.Visible = false;
        }

        private Boolean play = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if (play)
            {
                button4.Text = ">";
                play = false;
            }
            else
            {
                button4.Text = "l l";
                play = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
