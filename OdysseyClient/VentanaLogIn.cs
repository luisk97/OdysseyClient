﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OdysseyClient
{
    public partial class VentanaLogIn : Form
    {
        SocketCliente sock = new SocketCliente();

        public VentanaLogIn()
        {
            InitializeComponent();
            this.ActiveControl = textBox2;
            textBox2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            entrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string resp;
            MensajeXML msj = new MensajeXML();
            string usua = textBox3.Text;
            string nombre = textBox4.Text;
            string edad = textBox5.Text;
            string cont = textBox6.Text;
            if (cont != null)
            {
                cont = GetMD5(cont);
                XmlDocument data = msj.mensajeRegistrar(usua, nombre, edad, cont);

                MemoryStream ms = new MemoryStream();
                data.Save(ms);
                byte[] msjEnviar = ms.ToArray();

                resp = sock.abrirSocket(msjEnviar);

                if (resp.Equals("exito"))
                {
                    panel4.Visible = false;
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    MessageBox.Show("Tu cuenta se registro con exito!!", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (resp.Equals("usuario existente"))
                {
                    textBox3.Text = "";
                    MessageBox.Show("El nombre de usuario ya esta registrado", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La contraseña es obligatoria", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("X2"));
            }
            return str.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                entrar();
            }
        }

        private void entrar()
        {
            string resp;
            MensajeXML msj = new MensajeXML();
            string usua = textBox2.Text;
            string cont = GetMD5(textBox1.Text);


            XmlDocument data = msj.mensajeInicioSesion(usua, cont);

            MemoryStream ms = new MemoryStream();
            data.Save(ms);
            byte[] msjEnviar = ms.ToArray();

            resp = sock.abrirSocket(msjEnviar);
            if (resp.Equals("acceso permitido"))
            {
                MessageBox.Show("¡¡¡Bienvenido!!! " + usua + "! :D", "Inicio de Sesion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Principal principal = new Principal(usua);
                principal.Show();
                this.Hide();
            }
            else if (resp.Equals("error pass"))
            {
                MessageBox.Show("Contraseña Incorrecta", "Inicio de Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
            else if (resp.Equals("error user"))
            {
                MessageBox.Show("No existe ese usuario", "Inicio de Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show(resp);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                textBox1.Focus();
            }
        }
    }
}