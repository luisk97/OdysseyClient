﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdysseyClient
{
    class ListaCanciones
    {
        private Nodo cabeza;
        private Nodo ultimo;
        private int size;

        public ListaCanciones()
        {
            cabeza = null;
            ultimo = null;
            size = 0;
        }

        public Nodo getCabeza()
        {
            return cabeza;
        }

        public void addNodo(Cancion cancion)
        {
            Nodo nuevo = new Nodo(cancion);
            if (cabeza == null)
            {
                cabeza = nuevo;
                ultimo = cabeza;
            }
            else
            {
                Nodo temp = ultimo;
                temp.enlazarSiguiente(nuevo);
                ultimo = nuevo;
            }
            size++;
        }

        public void eliminar(int ind)
        {
            if (ind < size)
            {
                if (ind == 0)
                {
                    cabeza = cabeza.getSiguiente();
                }
                else
                {
                    Nodo temp = cabeza;
                    for (int i = 0; i < (ind - 1); i++)
                    {
                        temp = temp.getSiguiente();
                    }
                    if (ind == size - 1)
                    {
                        temp.enlazarSiguiente(null);
                        ultimo = temp;
                    }
                    else
                    {
                        temp.enlazarSiguiente(temp.getSiguiente().getSiguiente());
                    }
                }
                size--;
            }
            else
            {

            }

        }

        public int Size()
        {
            return size;
        }

        
        public bool estaVacia()
        {
            return size == 0;
        }

        public Nodo getNodo()
        {
            return cabeza;
        }

        public Nodo obtener(int i)
        {
            if (size != 0)
            {
                if (i < size)
                {
                    Nodo temp = cabeza;
                    while (0 < i)
                    {
                        temp = temp.getSiguiente();
                        i--;
                    }
                    return temp;
                }
                else
                {
                }
            }
            else
            {
            }
            return null;
        }

        public void clear()
        {
            cabeza = null;
            ultimo = null;
            size = 0;
        }
    }
}
