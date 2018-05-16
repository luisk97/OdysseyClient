using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdysseyClient
{
    public class Cancion
    {
        public string Nombre { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string Genero { get; set; }
        public string Letra { get; set; }

        //private string nombre;
        //private string artista;
        //private string album;
        //private string genero;
        //private string letra;

        //public Cancion(string nombre, string artista, string album, string genero, string letra)
        //{
        //    this.nombre = nombre;
        //    this.artista = artista;
        //    this.album = album;
        //    this.genero = genero;
        //    this.letra = letra;
        //}

        public override string ToString()
        {
            return ("Nombre:"+Nombre+"  Artista:"+Artista+"  Album:"+Album+"  Genero:"+Genero);
        }
    }
}
