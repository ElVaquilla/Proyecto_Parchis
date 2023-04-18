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

namespace Demo_Parchis
{
    public partial class Menu : Form
    {
        Socket server;
        public Menu()
        {
            InitializeComponent();
        }
        int logged = 0;
        private void Menu_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 100;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void jugar_Click(object sender, EventArgs e)
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

            if (log_usuario != null && log_contra != null)
            {
                string mensaje_log = "2/" + log_usuario.Text + "/" + log_contra.Text;
                // Enviamos al servidor el nombre el user y la contraseña
                byte[] msg_log = System.Text.Encoding.ASCII.GetBytes(mensaje_log);
                server.Send(msg_log);

                //Recibimos la respuesta del servidor
                string mensaje2;
                byte[] msg2_log = new byte[80];
                server.Receive(msg2_log);
                mensaje2 = Encoding.ASCII.GetString(msg2_log).Split('\0')[0];
                MessageBox.Show(mensaje2);

                string mensaje = "6/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[100];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MuestraConectados(mensaje);
            }
            else if (nuevo_usuario != null && nuevo_contra != null)
            {
                string mensaje_nuevo = "1/" + nuevo_usuario.Text + "/" + nuevo_contra.Text;
                // Enviamos al servidor el nombre el user y la contraseña
                byte[] msg_nuevo = System.Text.Encoding.ASCII.GetBytes(mensaje_nuevo);
                server.Send(msg_nuevo);

                //Recibimos la respuesta del servidor
                byte[] msg2_nuevo = new byte[80];
                server.Receive(msg2_nuevo);
                mensaje_nuevo = Encoding.ASCII.GetString(msg2_nuevo).Split('\0')[0];
                MessageBox.Show(mensaje_nuevo);

                string mensaje = "6/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[100];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MuestraConectados(mensaje);
            }

            Demo demo = new Demo();
            demo.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void MuestraConectados(string conectados)
        {
            int i;
            string[] lista = conectados.Split('/');
            for (i = 0; i < lista.Length - 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = 0;
            }
            for (i = 0; i < lista.Length - 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = lista[i];
            }
        }

        private void Menu_Load_1(object sender, EventArgs e)
        {

        }
    }
}
