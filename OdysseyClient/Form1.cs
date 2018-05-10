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

namespace OdysseyClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void hiloSocket(object o)
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

            MessageBox.Show("La cancion se recivio correctamente en el server");
        }

        String resp = "";

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivo mp3(*.mp3)|*.mp3";
            open.Title = "Archivos mp3";
            if (open.ShowDialog() == DialogResult.OK)
            {

                string ruta = open.FileName;
                //MensajeXML msj = new MensajeXML();
                //string textoXml = msj.crearXml("Cancion");
                //Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

                //listen.Connect(direccion);


                MensajeXML msj = new MensajeXML();
                XmlDocument data = msj.crearXml(ruta);

                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                data.WriteTo(xw);

                string XmlString = sw.ToString();

                MemoryStream ms = new MemoryStream();
                data.Save(ms);
                byte[] msjEnviar = ms.ToArray();

                Thread hiloSock = new Thread(hiloSocket);
                hiloSock.Start(msjEnviar);


                //byte[] audioBytes = File.ReadAllBytes("C:\\xml\\applause.mp3");


                //listen.Send(msjEnviar, 0, msjEnviar.Length, 0);
                //byte[] bytes = new byte[256];
                //recibe datos y devuelve el número de bytes leídos correctamente
                //int count = listen.Receive(bytes);
                //decodifica bytes a nueva cadena string
                //string resp = System.Text.Encoding.ASCII.GetString(bytes, 0, count);

                //richTextBox1.Text = resp;
                //richTextBox1.Text = resp;

                //listen.Close();

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
    }
}
