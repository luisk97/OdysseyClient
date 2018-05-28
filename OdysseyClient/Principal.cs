using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.Devices;
using System.Media;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace OdysseyClient
{
    public partial class Principal : Form
    {
        public Principal(string usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var device = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            comboBox1.Items.AddRange(device.ToArray());
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        SocketCliente sock = new SocketCliente();
        string usuario = "Nombre de Usuario";

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //private string abrirSocket(object o)
        //{
        //    Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

        //    listen.Connect(direccion);

        //    byte[] msjEnviar = (byte[])o;
        //    listen.Send(msjEnviar, 0, msjEnviar.Length, 0);

        //    byte[] bytes = new byte[30000];
        //    //recibe datos y devuelve el número de bytes leídos correctamente
        //    int count = listen.Receive(bytes);
        //    //decodifica bytes a nueva cadena string
        //    resp = System.Text.Encoding.ASCII.GetString(bytes, 0, count); 

        //    listen.Close();

        //    return resp;
        //}


        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        String resp = "";
        XmlDocument xmlCanciones = new XmlDocument();
        //ListaCanciones lista = new ListaCanciones();
        //List<Cancion> lista = new List<Cancion>();

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;

            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.cargarCanciones("nombre");

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = sock.abrirSocket(msjEnviar);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlCanciones.LoadXml(resp);
            xmlCanciones.WriteTo(xw);

            XmlNodeList listaXml = xmlCanciones.GetElementsByTagName("Cancion");

            actualizarLista(listaXml);

            //string XmlString = sw.ToString();

            //listBox1.Items.Add(XmlString);

            //richTextBox1.Text = XmlString;
        }


        ListaCanciones lista = new ListaCanciones();
        Cancion cancionActual = null;
        private void actualizarLista(XmlNodeList listaXml)
        {
            dataGridView1.Rows.Clear();
            lista = new ListaCanciones();
            XmlNode nodoCancion;
            for (int i = 0; i < listaXml.Count; i++)
            {
                nodoCancion = listaXml.Item(i);
                Cancion cancion = new Cancion();
                cancion.Nombre = nodoCancion.SelectSingleNode("Nombre").InnerText;
                cancion.Artista = nodoCancion.SelectSingleNode("Artista").InnerText;
                cancion.Album = nodoCancion.SelectSingleNode("Album").InnerText;
                cancion.Genero = nodoCancion.SelectSingleNode("Genero").InnerText;
                cancion.Letra = nodoCancion.SelectSingleNode("Letra").InnerText;

                lista.addNodo(cancion);
            }
            for (int ind = 0; ind < lista.Size(); ind++)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1);
                fila.Cells[1].Value = lista.obtener(ind).getSong().Nombre;
                fila.Cells[2].Value = lista.obtener(ind).getSong().Artista;
                fila.Cells[3].Value = lista.obtener(ind).getSong().Album;
                fila.Cells[4].Value = lista.obtener(ind).getSong().Genero;

                dataGridView1.Rows.Add(fila);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            

            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.cargarCanciones("artista");

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = sock.abrirSocket(msjEnviar);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlCanciones.LoadXml(resp);
            xmlCanciones.WriteTo(xw);

            XmlNodeList listaXml = xmlCanciones.GetElementsByTagName("Cancion");

            actualizarLista(listaXml);

            //string XmlString = sw.ToString();

            //listBox1.Items.Add(XmlString);

            //richTextBox1.Text = XmlString+"Ahi esta perro";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;

            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.cargarCanciones("album");

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = sock.abrirSocket(msjEnviar);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlCanciones.LoadXml(resp);
            xmlCanciones.WriteTo(xw);

            XmlNodeList listaXml = xmlCanciones.GetElementsByTagName("Cancion");

            actualizarLista(listaXml);

            //string XmlString = sw.ToString();

            //richTextBox1.Text = XmlString + "Ahi esta perro";
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivo mp3(*.mp3)|*.mp3";
            open.Title = "Archivos mp3";
            if (open.ShowDialog() == DialogResult.OK)
            {

                string ruta = open.FileName;

                VentanaData ventanaAdd = new VentanaData(ruta);
                ventanaAdd.Owner = this;
                ventanaAdd.ShowDialog();

            }
            open.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label5.Text = usuario;
            panel3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel3.Visible = false;
        }

        private Boolean play = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                if (output.PlaybackState == PlaybackState.Playing)
                {
                    output.Pause();
                    button4.Text = ">";
                    play = false;
                }
                else if(output.PlaybackState == PlaybackState.Paused)
                {
                    output.Play();
                    button4.Text = "l l";
                    play = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(64,64,64);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Visible = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //label3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //label4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }


        private void disposeStream()
        {
            if(output != null)
            {
                if(output.PlaybackState == PlaybackState.Playing)
                {
                    output.Stop();
                }
                output.Dispose();
                output = null;
            }
        }


        private void playSong(string nombre)
        {
            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.xmlReproducir(nombre);

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = sock.abrirSocket(msjEnviar);

            //StringWriter sw = new StringWriter();
            //XmlTextWriter xw = new XmlTextWriter(sw);
            XmlDocument xmlSongtoPlay = new XmlDocument();
            xmlSongtoPlay.LoadXml(resp.Replace(Environment.NewLine, ""));
            //xmlSongtoPlay.WriteTo(xw);

            XmlNodeList listaXml = xmlSongtoPlay.GetElementsByTagName("Bytes");
            XmlNode nodoBytes = listaXml.Item(0);
            string base64String = nodoBytes.InnerText;
            //richTextBox1.Text = base64String;

            byte[] mp3bytes = Convert.FromBase64String(base64String);


            Stream msMp3 = new MemoryStream(mp3bytes);



            //using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(msMp3))))
            //{
            //    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
            //    {
            //        waveOut.Init(blockAlignedStream);
            //        waveOut.Play();
            //        while (waveOut.PlaybackState == PlaybackState.Playing)
            //        {
            //            System.Threading.Thread.Sleep(100);
            //        }
            //    }
            //}
            disposeStream();

            mp3Reader = new Mp3FileReader(msMp3);
            //blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(mp3Reader));
            //stream = new BlockAlignReductionStream(blockAlignedStream);
            output = new DirectSoundOut();
            songTrackBar1.Maximum = (int)mp3Reader.TotalTime.TotalSeconds;
            songTrackBar1.Value = 0;
            output.Init(mp3Reader);
            output.Play();
            timer.Start();

            label7.Text = mp3Reader.TotalTime.ToString().Remove(8);
            button4.Text = "l l";
            play = true;
        }


        //private WaveStream blockAlignedStream;
        //private BlockAlignReductionStream stream;
        private DirectSoundOut output;
        private Mp3FileReader mp3Reader;
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!elim)
            {
                button4.Text = ">";
                play = false;

                string nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cancionActual = lista.obtenerPorValor(nombre).getSong();

                playSong(nombre);

                //richTextBox1.Text = resp.Replace(Environment.NewLine, " ");
                label3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                label4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                lblAlb.Text = cancionActual.Album;
                lblArt.Text = cancionActual.Artista;
                lblGen.Text = cancionActual.Genero;
                lblNom.Text = cancionActual.Nombre;

                //MensajeXML msj = new MensajeXML();
                //XmlDocument data = msj.borrarCanciones(listaElim);

                //MemoryStream ms = new MemoryStream();
                //data.Save(ms);
                //byte[] msjEnviar = ms.ToArray();

                //resp = sock.abrirSocket(msjEnviar);
            }
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!elim)
            {
                button4.Text = ">";
                play = false;

                string nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cancionActual = lista.obtenerPorValor(nombre).getSong();

                playSong(nombre);

                label3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                label4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                lblAlb.Text = cancionActual.Album;
                lblArt.Text = cancionActual.Artista;
                lblGen.Text = cancionActual.Genero;
                lblNom.Text = cancionActual.Nombre;
            }
        }


        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                button4.Text = ">";
                play = false;
                cleanLabels();
                output.Stop();
                disposeStream();
            }
        }



        private Boolean elim = false;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (elim)
            {
                button1.Visible = false;
                dataGridView1.Columns[0].Visible = false;
                elim = false;
            }
            else
            {
                button1.Visible = true;
                dataGridView1.Columns[0].Visible = true;
                elim = true;
            }
            

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            panel3.Visible = false;
        }

        private void menuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Visible = false;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Estas seguro?", "Eliminar Canciones", MessageBoxButtons.OKCancel,MessageBoxIcon.Stop);

            if (opcion == DialogResult.OK)
            {
                ListaCanciones listaElim = new ListaCanciones();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        bool isChecked = (bool)dataGridView1.Rows[i].Cells[0].Value;
                        if (isChecked)
                        {
                            Cancion cancion = new Cancion();
                            cancion.Nombre = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            cancion.Artista = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            cancion.Album = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            cancion.Genero = dataGridView1.Rows[i].Cells[4].Value.ToString();

                            listaElim.addNodo(cancion);
                            dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                            i--;
                        }
                    }
                }
                panel3.Visible = false;

                MensajeXML msj = new MensajeXML();
                XmlDocument data = msj.borrarCanciones(listaElim);

                MemoryStream ms = new MemoryStream();
                data.Save(ms);
                byte[] msjEnviar = ms.ToArray();

                resp = sock.abrirSocket(msjEnviar);
                MessageBox.Show(resp, "Eliminacion de Canciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Visible = false;
                dataGridView1.Columns[0].Visible = false;
                elim = false;
            }
        }

        private void artistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string srchArtist = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Artista:", "Buscar Cancion", "", 100, 100);
            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.buscarArtista(srchArtist);

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = sock.abrirSocket(msjEnviar);

            if (resp.Equals("No encontrado"))
            {
                MessageBox.Show("No se encontraron canciones del artista "+ srchArtist, "Busqueda de Canciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                xmlCanciones.LoadXml(resp);
                xmlCanciones.WriteTo(xw);

                XmlNodeList listaXml = xmlCanciones.GetElementsByTagName("Cancion");

                actualizarLista(listaXml);
            }
        }

        private void albumToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string srchAlbum = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Album:", "Buscar Cancion", "", 100, 100);
            if (srchAlbum != null)
            {
                MensajeXML msj = new MensajeXML();
                XmlDocument data = msj.buscarAlbum(srchAlbum);

                MemoryStream ms = new MemoryStream();
                data.Save(ms);
                byte[] msjEnviar = ms.ToArray();

                resp = sock.abrirSocket(msjEnviar);

                if (resp.Equals("No encontrado"))
                {
                    MessageBox.Show("No se encontraron canciones pertenecientes al album " + srchAlbum, "Busqueda de Canciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                xmlCanciones.LoadXml(resp);
                xmlCanciones.WriteTo(xw);

                XmlNodeList listaXml = xmlCanciones.GetElementsByTagName("Cancion");

                actualizarLista(listaXml);
            }
        }

        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string srchSong = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Artista:", "Buscar Cancion", "", 100, 100);
            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.buscarNombre(srchSong);

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = sock.abrirSocket(msjEnviar);

            if (resp.Equals("No encontrado"))
            {
                MessageBox.Show("No se encontro ninguna cancion con el nombre "+ srchSong, "Busqueda de Canciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                xmlCanciones.LoadXml(resp);
                xmlCanciones.WriteTo(xw);

                XmlNodeList listaXml = xmlCanciones.GetElementsByTagName("Cancion");

                actualizarLista(listaXml);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button4.Text = ">";
            play = false;
            if (cancionActual != null)
            {
                Nodo nodoCancionActual = lista.obtenerPorValor(cancionActual.Nombre).getSiguiente();
                if (nodoCancionActual != null)
                {
                    cancionActual = nodoCancionActual.getSong();

                    string nombre = cancionActual.Nombre;

                    playSong(nombre);

                    label3.Text = nombre;
                    label4.Text = cancionActual.Artista;
                    lblAlb.Text = cancionActual.Album;
                    lblArt.Text = cancionActual.Artista;
                    lblGen.Text = cancionActual.Genero;
                    lblNom.Text = cancionActual.Nombre;
                }
                else if (repLista)
                {

                    nodoCancionActual = lista.getCabeza();
                    if (nodoCancionActual != null)
                    {
                        cancionActual = nodoCancionActual.getSong();

                        string nombre = cancionActual.Nombre;

                        playSong(nombre);

                        label3.Text = nombre;
                        label4.Text = cancionActual.Artista;
                        lblAlb.Text = cancionActual.Album;
                        lblArt.Text = cancionActual.Artista;
                        lblGen.Text = cancionActual.Genero;
                        lblNom.Text = cancionActual.Nombre;
                    }

                }
                else
                {
                    disposeStream();
                    cleanLabels();

                }
            }
        }

        private int vol;
        private void timer_Tick(object sender, EventArgs e)
        {
            songTrackBar1.Value = (int)mp3Reader.CurrentTime.TotalSeconds;
            if (mp3Reader.CurrentTime.ToString().Length > 9)
            {
                label6.Text = mp3Reader.CurrentTime.ToString().Remove(8);
                if (label6.Text == label7.Text)
                {
                    button4.Text = ">";
                    play = false;

                    if (repCancion)
                    {
                        string nombre = cancionActual.Nombre;

                        playSong(nombre);
                    }
                    else
                    {
                        Nodo nodoCancionActual = lista.obtenerPorValor(cancionActual.Nombre).getSiguiente();
                        if (nodoCancionActual != null)
                        {
                            cancionActual = nodoCancionActual.getSong();

                            string nombre = cancionActual.Nombre;

                            playSong(nombre);

                            label3.Text = nombre;
                            label4.Text = cancionActual.Artista;
                            lblAlb.Text = cancionActual.Album;
                            lblArt.Text = cancionActual.Artista;
                            lblGen.Text = cancionActual.Genero;
                            lblNom.Text = cancionActual.Nombre;
                        }
                        else if(repLista)
                        {

                            nodoCancionActual = lista.getCabeza();
                            if (nodoCancionActual != null)
                            {
                                cancionActual = nodoCancionActual.getSong();

                                string nombre = cancionActual.Nombre;

                                playSong(nombre);

                                label3.Text = nombre;
                                label4.Text = cancionActual.Artista;
                                lblAlb.Text = cancionActual.Album;
                                lblArt.Text = cancionActual.Artista;
                                lblGen.Text = cancionActual.Genero;
                                lblNom.Text = cancionActual.Nombre;
                            }

                        }
                        else
                        {
                            disposeStream();
                            cleanLabels();

                        }
                    }
                    
                }
                if(comboBox1.SelectedItem != null)
                {
                    var device = (MMDevice)comboBox1.SelectedItem;
                    vol = (int)Math.Round((device.AudioMeterInformation.MasterPeakValue * 100));
                    progressBar1.Value = vol;
                    label1.Text = vol.ToString();
                    if (vol > 5)
                    {
                        bar1.Visible = true;
                        bar2.Visible = false;
                        bar3.Visible = false;
                        bar4.Visible = false;
                        bar5.Visible = false;
                        bar6.Visible = false;
                        bar7.Visible = false;
                        if (vol > 14)
                        {
                            bar2.Visible = true;
                            if (vol > 28)
                            {
                                bar3.Visible = true;
                                if(vol > 42)
                                {
                                    bar4.Visible = true;
                                    if(vol > 56)
                                    {
                                        bar5.Visible = true;
                                        if(vol > 70)
                                        {
                                            bar6.Visible = true;
                                            if(vol > 84)
                                            {
                                                bar7.Visible = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        bar1.Visible = false;
                        bar2.Visible = false;
                        bar3.Visible = false;
                        bar4.Visible = false;
                        bar5.Visible = false;
                        bar6.Visible = false;
                        bar7.Visible = false;
                    }
                }
            }
        }

        private void songTrackBar1_Scroll(object sender, EventArgs e)
        {
            if (mp3Reader != null)
            {
                mp3Reader.CurrentTime = TimeSpan.FromSeconds(songTrackBar1.Value);
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        bool repCancion = false;
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            repCancion = true;
            pictureRepCan1.Visible = false;
            pictureRepCanVer.Visible = true;
        }
        private void pictureRepCanVer_Click(object sender, EventArgs e)
        {
            repCancion = false;
            pictureRepCan1.Visible = true;
            pictureRepCanVer.Visible = false;
        }


        bool repLista = false;
        private void pictureRep1_Click(object sender, EventArgs e)
        {
            repLista = true;
            pictureRep1.Visible = false;
            pictureRepVer.Visible = true;
        }
        private void pictureRepVer_Click(object sender, EventArgs e)
        {
            repLista = false;
            pictureRep1.Visible = true;
            pictureRepVer.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Text = ">";
            play = false;
            if (cancionActual != null)
            {
                Nodo nodoCancionActual = lista.obtenerPorValor(cancionActual.Nombre).getAnterior();
                if (nodoCancionActual != null)
                {
                    cancionActual = nodoCancionActual.getSong();

                    string nombre = cancionActual.Nombre;

                    playSong(nombre);

                    label3.Text = nombre;
                    label4.Text = cancionActual.Artista;
                    lblAlb.Text = cancionActual.Album;
                    lblArt.Text = cancionActual.Artista;
                    lblGen.Text = cancionActual.Genero;
                    lblNom.Text = cancionActual.Nombre;
                }
                else if (repLista)
                {

                    nodoCancionActual = lista.getUltimo();
                    if (nodoCancionActual != null)
                    {
                        cancionActual = nodoCancionActual.getSong();

                        string nombre = cancionActual.Nombre;

                        playSong(nombre);

                        label3.Text = nombre;
                        label4.Text = cancionActual.Artista;
                        lblAlb.Text = cancionActual.Album;
                        lblArt.Text = cancionActual.Artista;
                        lblGen.Text = cancionActual.Genero;
                        lblNom.Text = cancionActual.Nombre;
                    }

                }
                else
                {
                    disposeStream();
                    cleanLabels();

                }
            }
        }

        private void cleanLabels()
        {
            label3.Text = "Nombre de la Cancion";
            label4.Text = "Nombre del Artista";
            lblAlb.Text = "Album";
            lblArt.Text = "Artista";
            lblGen.Text = "Genero";
            lblNom.Text = "Cancion";
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnNotifica_Click(object sender, EventArgs e)
        {

        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            MensajeXML msj = new MensajeXML();
            XmlDocument data = msj.solicitarInfoUsuario(usuario);

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = sock.abrirSocket(msjEnviar);
            XmlDocument xmlUsuario = new XmlDocument();
            xmlUsuario.LoadXml(resp);

            XmlNodeList listUs = xmlUsuario.GetElementsByTagName("User");
            XmlNode nodoUser = listUs.Item(0);

            string nombre = nodoUser.SelectSingleNode("nombre").InnerText;
            string edad = nodoUser.SelectSingleNode("edad").InnerText;

            VentanaPerfil vPerfil = new VentanaPerfil(usuario, nombre, edad);
            vPerfil.Owner = this;
            vPerfil.ShowDialog();
        }
    }
}
