using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_Parchis
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void Demo_Load(object sender, EventArgs e)
        {

        }

        private void dado_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int d1 = rand.Next(1, 7);
            MessageBox.Show("Dado=" + d1);
        }
    }
}
