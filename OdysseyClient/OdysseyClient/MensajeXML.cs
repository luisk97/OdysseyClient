using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OdysseyClient
{
    public class MensajeXML
    {
        public XmlDocument crearXml(String ruta)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0","UTF-8",null);
            doc.AppendChild(declaracion);
            //XmlElement raiz = doc.DocumentElement;
            //doc.InsertBefore(declaracion, raiz);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("add"));
            root.AppendChild(codigo);

            XmlElement metaData = doc.CreateElement("MetaData");
            root.AppendChild(metaData);

            XmlElement nom = doc.CreateElement("Nombre");
            nom.AppendChild(doc.CreateTextNode("Psychosocial"));
            metaData.AppendChild(nom);

            XmlElement art = doc.CreateElement("Artista");
            art.AppendChild(doc.CreateTextNode("Slipknot"));
            metaData.AppendChild(art);

            XmlElement album = doc.CreateElement("Album");
            album.AppendChild(doc.CreateTextNode("All Hope is Gone"));
            metaData.AppendChild(album);

            XmlElement data = doc.CreateElement("Data");
            root.AppendChild(data);

            XmlElement song = doc.CreateElement("Song");
            byte[] audioBytes = File.ReadAllBytes(ruta);
            string base64String = Convert.ToBase64String(audioBytes);
            song.AppendChild(doc.CreateTextNode(base64String));
            data.AppendChild(song);




            //doc.Save("C:\\xml\\archivo.xml");

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            doc.WriteTo(xw);
            string XmlString = sw.ToString();

            return doc;
        }

        public void addSong(Object song)
        {

        }

        public void deleteSong(Object song)
        {

        }
    }
}