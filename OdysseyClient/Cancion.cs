﻿using System;
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

        public override string ToString()
        {
            return ("Nombre:"+Nombre+"  Artista:"+Artista+"  Album:"+Album+"  Genero:"+Genero);
        }
    }
}