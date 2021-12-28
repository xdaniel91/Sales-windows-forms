using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            btnListaCompras.Text = "Compras";
            BtnRegisterProduct.Text = "Registrar produto";
            panel1.Enabled = false;
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new FrmOrder();
            var tb = new TabPage();
            tb.Name = "Lista de compras";
            tb.Text = "Lista de compras";
            tb.Controls.Add(frm);
            tbc_app.Controls.Add(tb);
            tbc_app.SelectedTab = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new FrmRegisterProduct();
            var tb = new TabPage();
            tb.Name = "Registro de produtos";
            tb.Text = "Registro de produtoss";
            tb.Controls.Add(frm);
            tbc_app.Controls.Add(tb);
            tbc_app.SelectedTab = tb;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            tbc_app.Controls.Remove(tbc_app.SelectedTab);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Enabled == true && panel1.Visible == true)

            {
                panel1.Enabled = false;
                panel1.Visible = false;
            }
            else
            {
                panel1.Enabled = true;
                panel1.Visible = true;
            }


        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var frm = new FrmUserRegister();
            var tb = new TabPage();
            tb.Name = "Registro de usuários";
            tb.Text = "Registro de usuários";
            tb.Controls.Add(frm);
            tbc_app.Controls.Add(tb);
            tbc_app.SelectedTab = tb;
        }
    }


}
