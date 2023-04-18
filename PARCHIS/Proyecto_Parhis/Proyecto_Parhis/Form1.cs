using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;


namespace Proyecto_Parhis
{
    public partial class Menu : Form
    {
        Socket server;
        public Menu()
        {
            InitializeComponent();
            log_contraseña.PasswordChar='*';
            log_nombre.MaxLength = 20;
            log_contraseña.MaxLength = 20;

        }
        int logged = 0;
        private void Menu_Load(object sender, EventArgs e)
        {
            TablaConectados.ColumnCount = 1;
            TablaConectados.RowCount = 100;
            TablaConectados.ColumnHeadersVisible = false;
            TablaConectados.RowHeadersVisible = false;
            TablaConectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void alta_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void alta_contraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void log_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void log_contraseña_TextChanged(object sender, EventArgs e)
        {

        }


        private void darse_alta_Click(object sender, EventArgs e)
        {
            if (logged == 0)
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.101");
                IPEndPoint ipep = new IPEndPoint(direc, 9020);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.LightGreen;
                    MessageBox.Show("Conectado");


                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
                logged = 1;
            }
            string mensaje = "1/" + alta_nombre.Text + "/" + alta_contraseña.Text;
            // Enviamos al servidor el nombre el user y la contraseña
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            string mensaje2;
            mensaje2 = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje2);

        }

        private void log_Click(object sender, EventArgs e)
        {
            if (logged == 0)
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.101");
                IPEndPoint ipep = new IPEndPoint(direc, 9020);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.LightGreen;
                    MessageBox.Show("Conectado");


                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
                logged = 1;
            }
            string mensaje = "2/" + log_nombre.Text + "/" + log_contraseña.Text;
            // Enviamos al servidor el nombre el user y la contraseña
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            string mensaje2;
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje2 = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje2);

        }

        private void Consulta1_Click(object sender, EventArgs e)
        {
            string mensaje = "3/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[100];
            server.Receive(msg2);
            string mensaje2;
            mensaje2 = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje2);

        }

        private void Consulta2_Click(object sender, EventArgs e)
        {
            string mensaje ="4/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            string mensaje2;
            mensaje2 = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje2);
        }

        private void TablaConectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void MuestraConectados(string conectados)
        {
            int i;
            string[] lista = conectados.Split('/');
            for (i= 0; i < lista.Length - 1; i++)
            {
                TablaConectados.Rows[i].Cells[0].Value = 0;
            }
            for(i=0; i < lista.Length-1; i++)
            {
                TablaConectados.Rows[i].Cells[0].Value = lista[i+1];
            }
        }

        private void dameconectados_Click(object sender, EventArgs e)
        {
            string mensaje = "5/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            string mensaje2;
            byte[] msg2 = new byte[100];
            server.Receive(msg2);
            mensaje2 = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MuestraConectados(mensaje2);
        }
    }
}
