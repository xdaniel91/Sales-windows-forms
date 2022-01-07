using Library.Classes;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Frms;

namespace WindowsFormsApp1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            btnIniciarCompra.Text = "Iniciar compra";
            BtnRegisterProduct.Text = "Registrar produto";
            btnUserRegister.Text = "Registrar cliente";
            btnListaClientes.Text = "Lista de clientes";
            panel1.Enabled = false;
            panel1.Visible = false;
            Utils.FeedLists();
            btnCompras.Text = "Lista de compras";
        }

        private void btnListaCompras_Click(object sender, EventArgs e)
        {
            var frm = new FrmOrder();
            var tb = new TabPage();
            tb.Name = "Lista de compras";
            tb.Text = "Lista de compras";
            tb.Controls.Add(frm);
            tbc_app.Controls.Add(tb);
            tbc_app.SelectedTab = tb;
        }

        private void btnRegistroProduto_Click(object sender, EventArgs e)
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
            picbox_Menu.Cursor = Cursors.Hand;
        }

        private void btnRegistroCliente_Click(object sender, EventArgs e)
        {
            var frm = new FrmUserRegister();
            var tb = new TabPage();
            tb.Name = "Registro de cliente";
            tb.Text = "Registro de cliente";
            tb.Controls.Add(frm);
            tbc_app.Controls.Add(tb);
            tbc_app.SelectedTab = tb;
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            if (DataBase.lista_order.Count == 0)
            {
                MessageBox.Show("Nenhuma compra foi cadastrada");
            }
            else
            {
                var frm = new FrmListaCompras();
                var tb = new TabPage();
                tb.Name = "Lista de compras";
                tb.Text = "Lista de compras";
                tb.Controls.Add(frm);
                tbc_app.Controls.Add(tb);
                tbc_app.SelectedTab = tb;
            }
        }

        private void btnListaClientes_Click(object sender, EventArgs e)
        {
            var frm = new FrmClientes();
            frm.Show();
        }
    }
}
