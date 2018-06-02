using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OdysseyClient
{
    /// <summary>
    /// Esta clase establecera la comunicacion con la aplicacion servidor
    /// </summary>
    class SocketCliente
    {
        /// <summary>
        /// Este metodo recibe un objeto y lo transforma en un Array de bytes para enviarlo al servidor y 
        /// retorna el string que nos devuelve el servidor
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string abrirSocket(object o)
        {
            string resp = null;
            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            listen.Connect(direccion);

            byte[] msjEnviar = (byte[])o;
            listen.Send(msjEnviar, 0, msjEnviar.Length, 0);

            int bytesRead = 1;
            // Ciclo que lee la totalidad del mensaje enviado por el servidor
            while (bytesRead != 0) {
                byte[] buffer = new byte[30000];

                bytesRead = listen.Receive(buffer);
                

                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                resp += response;
            }

            listen.Close();

            return resp.TrimEnd();
        }
    }
}
