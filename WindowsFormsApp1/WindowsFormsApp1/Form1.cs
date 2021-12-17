using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnListaCompras.Text = "Compras";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new ListaCompras();
            var tb = new TabPage();
            tb.Name = "Lista de compras";
            tb.Text = "Lista de compras";
            tb.Controls.Add(frm);
            tbc_app.Controls.Add(tb);
        }
    }
}
