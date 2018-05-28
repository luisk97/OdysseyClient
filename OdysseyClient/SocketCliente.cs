using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OdysseyClient
{
    class SocketCliente
    {
        public string abrirSocket(object o)
        {
            string resp = null;
            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            listen.Connect(direccion);

            byte[] msjEnviar = (byte[])o;
            listen.Send(msjEnviar, 0, msjEnviar.Length, 0);

            int bytesRead = 1;
            while (bytesRead != 0) {
                byte[] buffer = new byte[30000];

                bytesRead = listen.Receive(buffer);
                

                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                resp += response;
            }

            //byte[] bytes = new byte[30000];
            ////recibe datos y devuelve el número de bytes leídos correctamente
            //int count = listen.Receive(bytes);
            ////decodifica bytes a nueva cadena string
            //resp = System.Text.Encoding.ASCII.GetString(bytes, 0, count);

            listen.Close();

            return resp.TrimEnd();
        }
    }
}
