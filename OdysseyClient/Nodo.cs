using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdysseyClient
{
    class Nodo
    {
        private Cancion song;
        private Nodo siguiente;

        public Nodo(Cancion song)
        {
            this.song = song;
            siguiente = null;
        }

        public Cancion getSong()
        {
            return song;
        }

        public Nodo getSiguiente()
        {
            return siguiente;
        }

        public void enlazarSiguiente(Nodo siguiente)
        {
            this.siguiente = siguiente;
        }
    }
}
