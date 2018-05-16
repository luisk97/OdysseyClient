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
    public partial class Form3 : Form
    {
        string ruta;
        public Form3(object o)
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

            MessageBox.Show("La cancion se recivio correctamente en el server");
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
            String[] artist = new String[] { textBox3.Text };
            String[] genere = new String[] { textBox4.Text };
            TagLib.File tagger = TagLib.File.Create(ruta);

            tagger.Tag.Title = textBox1.Text;
            tagger.Tag.AlbumArtists = artist;
            tagger.Tag.Album = textBox3.Text;
            tagger.Tag.Genres = genere;

            tagger.Save();
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

            XmlElement art = doc.CreateElement("Artista");
            art.AppendChild(doc.CreateTextNode(textBox2.Text));
            metaData.AppendChild(art);

            XmlElement album = doc.CreateElement("Album");
            album.AppendChild(doc.CreateTextNode(textBox3.Text));
            metaData.AppendChild(album);

            XmlElement gen = doc.CreateElement("Genero");
            gen.AppendChild(doc.CreateTextNode(textBox4.Text));
            metaData.AppendChild(gen);

            XmlElement letra = doc.CreateElement("Letra");
            letra.AppendChild(doc.CreateTextNode(richTextBox1.Text));
            metaData.AppendChild(letra);

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

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
