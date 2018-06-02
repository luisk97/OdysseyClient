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
        /// <summary>
        /// Recive una lista de canciones a eliminar y crea un XmlDocument con esa lista
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Recibe el orden que se le desea dar a la lista de canciones y crea un XmlDocumnt con la solicitud
        /// </summary>
        /// <param name="orden"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Crea un XmlDocument con el usuario y contraseña ingresados en la ventanaLogin para enviarlo y verificar la informacion
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Crea un XmlDocument con la informacion del usuario que se esta registrando
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="nombre"></param>
        /// <param name="edad"></param>
        /// <param name="cont"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Crea un XmlDocument con el nombre de la cancion que se desea buscar
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Crea un XmlDocument con el artista de la canciones que se desean buscar
        /// </summary>
        /// <param name="artista"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Crea un XmlDocument con el album de las canciones que se desean buscar
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Crea un XmlDocument con el nombre de la cancion que se desea reproducir
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Crea un XmlDocument para solicitar la informacion del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Crea un XmlDocument con la informacion que el usuario desea editar
        /// </summary>
        /// <param name="usuarioAnt"></param>
        /// <param name="usuario"></param>
        /// <param name="nombre"></param>
        /// <param name="edad"></param>
        /// <returns></returns>
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
            datos.AppendChild(user);

            XmlElement nom = doc.CreateElement("Nombre");
            nom.AppendChild(doc.CreateTextNode(nombre));
            datos.AppendChild(nom);

            XmlElement ed = doc.CreateElement("Edad");
            ed.AppendChild(doc.CreateTextNode(edad));
            datos.AppendChild(ed);

            return doc;
        }

        public XmlDocument solicitarListaAmigos(string usuario)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("retornarAmigos"));
            datos.AppendChild(codigo);

            XmlElement user = doc.CreateElement("Usuario");
            user.AppendChild(doc.CreateTextNode(usuario));
            datos.AppendChild(user);
            return doc;
        }

        public XmlDocument buscarAmigo(string usuario)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("buscarAmigo"));
            datos.AppendChild(codigo);

            XmlElement user = doc.CreateElement("Usuario");
            user.AppendChild(doc.CreateTextNode(usuario));
            datos.AppendChild(user);
            return doc;
        }

        public XmlDocument addAmigo(string amigo, string usuario)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaracion);

            XmlElement root = doc.CreateElement("MensajeXML");
            doc.AppendChild(root);

            XmlElement datos = doc.CreateElement("Datos");
            root.AppendChild(datos);

            XmlElement codigo = doc.CreateElement("Code");
            codigo.AppendChild(doc.CreateTextNode("addAmigo"));
            datos.AppendChild(codigo);

            XmlElement user = doc.CreateElement("Usuario");
            user.AppendChild(doc.CreateTextNode(usuario));
            datos.AppendChild(user);

            XmlElement am = doc.CreateElement("Amigo");
            am.AppendChild(doc.CreateTextNode(amigo));
            datos.AppendChild(am);

            return doc;
        }
    }
}