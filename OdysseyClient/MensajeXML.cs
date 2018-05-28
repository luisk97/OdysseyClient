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

        public XmlDocument borrarCanciones(Object lista)
        {
            ListaCanciones listaElim = (ListaCanciones)lista;
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("eliminar"));
            datos.AppendChild(codigo);

            Cancion temp;

            for (int i = 0; i < listaElim.Size(); i++)
            {
                XmlElement song = doc.CreateElement("Cancion");
                datos.AppendChild(song);

                temp = listaElim.obtener(i).getSong();

                XmlElement nom = doc.CreateElement("Nombre");
                nom.AppendChild(doc.CreateTextNode(temp.Nombre));
                song.AppendChild(nom);

                XmlElement art = doc.CreateElement("Artista");
                art.AppendChild(doc.CreateTextNode(temp.Artista));
                song.AppendChild(art);

                XmlElement album = doc.CreateElement("Album");
                album.AppendChild(doc.CreateTextNode(temp.Album));
                song.AppendChild(album);

                XmlElement gen = doc.CreateElement("Genero");
                gen.AppendChild(doc.CreateTextNode(temp.Genero));
                song.AppendChild(gen);

                datos.AppendChild(song);
            }


            return doc;
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

        public XmlDocument mensajeInicioSesion(string usuario,string contrasenia)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("logIn"));
            datos.AppendChild(codigo);

            XmlElement user = doc.CreateElement("User");
            user.AppendChild(doc.CreateTextNode(usuario));
            datos.AppendChild(user);

            XmlElement pass = doc.CreateElement("Password");
            pass.AppendChild(doc.CreateTextNode(contrasenia));
            datos.AppendChild(pass);

            return doc;
        }

        public XmlDocument mensajeRegistrar(string usuario, string nombre, string edad, string cont)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("signIn"));
            datos.AppendChild(codigo);

            XmlElement user = doc.CreateElement("User");
            user.AppendChild(doc.CreateTextNode(usuario));
            datos.AppendChild(user);

            XmlElement name = doc.CreateElement("FullName");
            name.AppendChild(doc.CreateTextNode(nombre));
            datos.AppendChild(name);

            XmlElement age = doc.CreateElement("Age");
            age.AppendChild(doc.CreateTextNode(edad));
            datos.AppendChild(age);

            XmlElement pass = doc.CreateElement("Password");
            pass.AppendChild(doc.CreateTextNode(cont));
            datos.AppendChild(pass);

            return doc;
        }

        public XmlDocument buscarNombre(string nombre)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);
            
            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("buscar"));
            datos.AppendChild(codigo);

            XmlElement por = doc.CreateElement("Por");
            por.AppendChild(doc.CreateTextNode("nombre"));
            datos.AppendChild(por);

            XmlElement nom = doc.CreateElement("Nombre");
            nom.AppendChild(doc.CreateTextNode(nombre));
            datos.AppendChild(nom);

            return doc;
        }

        public XmlDocument buscarArtista(string artista)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("buscar"));
            datos.AppendChild(codigo);

            XmlElement por = doc.CreateElement("Por");
            por.AppendChild(doc.CreateTextNode("artista"));
            datos.AppendChild(por);

            XmlElement artist = doc.CreateElement("Artista");
            artist.AppendChild(doc.CreateTextNode(artista));
            datos.AppendChild(artist);

            return doc;
        }

        public XmlDocument buscarAlbum(string album)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("buscar"));
            datos.AppendChild(codigo);

            XmlElement por = doc.CreateElement("Por");
            por.AppendChild(doc.CreateTextNode("album"));
            datos.AppendChild(por);

            XmlElement alb = doc.CreateElement("Album");
            alb.AppendChild(doc.CreateTextNode(album));
            datos.AppendChild(alb);

            return doc;
        }

        public XmlDocument xmlReproducir(string nombre)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("play"));
            datos.AppendChild(codigo);

            XmlElement nom = doc.CreateElement("Nombre");
            nom.AppendChild(doc.CreateTextNode(nombre));
            datos.AppendChild(nom);

            return doc;
        }

        public XmlDocument solicitarInfoUsuario(string usuario)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("infoUsuario"));
            datos.AppendChild(codigo);

            XmlElement nom = doc.CreateElement("Usuario");
            nom.AppendChild(doc.CreateTextNode(usuario));
            datos.AppendChild(nom);

            return doc;
        }

        public XmlDocument editarUsuario(string usuarioAnt, string usuario, string nombre, string edad)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("editUsuario"));
            datos.AppendChild(codigo);

            XmlElement userAnt = doc.CreateElement("UsuarioAnt");
            userAnt.AppendChild(doc.CreateTextNode(usuarioAnt));
            datos.AppendChild(userAnt);

            XmlElement user = doc.CreateElement("UsuarioNew");
            user.AppendChild(doc.CreateTextNode(usuario));
            userAnt.AppendChild(user);

            XmlElement nom = doc.CreateElement("Nombre");
            nom.AppendChild(doc.CreateTextNode(nombre));
            userAnt.AppendChild(nom);

            XmlElement ed = doc.CreateElement("Edad");
            ed.AppendChild(doc.CreateTextNode(edad));
            userAnt.AppendChild(ed);

            return doc;
        }
    }
}