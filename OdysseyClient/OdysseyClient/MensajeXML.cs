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

        public void borrarCancion(Object song)
        {

        }

        public XmlDocument cargarCanciones(String orden)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            if (orden.Equals("nombre"))
            {
                XmlElement codigo = doc.CreateElement("Code");
                codigo.AppendChild(doc.CreateTextNode("cargar"));
                datos.AppendChild(codigo);

                XmlElement ordenamiento = doc.CreateElement("Orden");
                ordenamiento.AppendChild(doc.CreateTextNode("nombre"));
                datos.AppendChild(ordenamiento);
            }
            else if (orden.Equals("artista"))
            {
                XmlElement codigo = doc.CreateElement("Code");
                codigo.AppendChild(doc.CreateTextNode("cargar"));
                datos.AppendChild(codigo);

                XmlElement ordenamiento = doc.CreateElement("Orden");
                ordenamiento.AppendChild(doc.CreateTextNode("artista"));
                datos.AppendChild(ordenamiento);
            }
            else if (orden.Equals("album"))
            {
                XmlElement codigo = doc.CreateElement("Code");
                codigo.AppendChild(doc.CreateTextNode("cargar"));
                datos.AppendChild(codigo);

                XmlElement ordenamiento = doc.CreateElement("Orden");
                ordenamiento.AppendChild(doc.CreateTextNode("album"));
                datos.AppendChild(ordenamiento);
            }
            return doc;
        }


    }
}