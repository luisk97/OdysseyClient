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
    public partial class VentanaData : Form
    {
        string ruta;

        public VentanaData(object o)
        {
            ruta = (string)o;
            InitializeComponent();
            llenarCampos(ruta);
        }

        string resp;
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

            MessageBox.Show("La cancion se recivio correctamente en el Servidor", "Guardado de Canciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llenarCampos(string ruta)
        {
            Mp3Lib.Mp3File mp3archivo = new Mp3Lib.Mp3File(ruta);

            textBox1.Text = mp3archivo.TagHandler.Title;

            textBox2.Text =  mp3archivo.TagHandler.Artist;

            textBox3.Text = mp3archivo.TagHandler.Album;

            textBox4.Text = mp3archivo.TagHandler.Genre;

            richTextBox1.Text = mp3archivo.TagHandler.Lyrics;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mp3Lib.Mp3File mp3archivo = new Mp3Lib.Mp3File(ruta);

            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);
            //XmlElement raiz = doc.DocumentElement;
            //doc.InsertBefore(declaracion, raiz);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("add"));
            datos.AppendChild(codigo);

            XmlElement metaData = doc.CreateElement("MetaData");
            datos.AppendChild(metaData);

            XmlElement nom = doc.CreateElement("Nombre");
            nom.AppendChild(doc.CreateTextNode(textBox1.Text));
            metaData.AppendChild(nom);
            mp3archivo.TagHandler.Title = textBox1.Text;

            XmlElement art = doc.CreateElement("Artista");
            art.AppendChild(doc.CreateTextNode(textBox2.Text));
            metaData.AppendChild(art);
            mp3archivo.TagHandler.Artist = textBox2.Text;

            XmlElement album = doc.CreateElement("Album");
            album.AppendChild(doc.CreateTextNode(textBox3.Text));
            metaData.AppendChild(album);
            mp3archivo.TagHandler.Album = textBox3.Text;

            XmlElement gen = doc.CreateElement("Genero");
            gen.AppendChild(doc.CreateTextNode(textBox4.Text));
            metaData.AppendChild(gen);
            mp3archivo.TagHandler.Genre = textBox4.Text;

            XmlElement letra = doc.CreateElement("Letra");
            letra.AppendChild(doc.CreateTextNode(richTextBox1.Text));
            metaData.AppendChild(letra);
            mp3archivo.TagHandler.Lyrics = richTextBox1.Text;
            try
            {
                mp3archivo.Update();
            }catch(Exception )
            {
            }

            XmlElement data = doc.CreateElement("Data");
            datos.AppendChild(data);

            XmlElement song = doc.CreateElement("Song");
            byte[] audioBytes = File.ReadAllBytes(ruta);
            string base64String = Convert.ToBase64String(audioBytes);
            song.AppendChild(doc.CreateTextNode(base64String));
            data.AppendChild(song);

            //return doc;


            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            doc.WriteTo(xw);

            string XmlString = sw.ToString();

            MemoryStream ms = new MemoryStream();
            doc.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            Thread hiloSock = new Thread(hiloSocket);
            hiloSock.Start(msjEnviar);

            this.Close();
        }
    }
}
