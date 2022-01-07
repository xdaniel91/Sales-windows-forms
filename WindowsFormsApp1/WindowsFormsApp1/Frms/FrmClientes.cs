using Library.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Frms
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
            EscreverUsers();
            lblName.Visible = false;
        }
        public void EscreverUsers()
        {
            Utils.FeedLists();
            foreach (var item in DataBase.lista_users)
            {
                lst_clientes.Items.Add($"Id: {item.Id} |  Nome: {item.Nome}");
            }
        }

        Person GetItem()
        {
            try
            {
                Person p = DataBase.lista_users[lst_clientes.SelectedIndex];
                return p;
            }
            catch (Exception)
            {
                throw;
            }
        }

        void WriteProperties(Person p)
        {
            lblName.Text = p.Nome;
            txtCpf.Text = p.Cpf;
            txtEmail.Text = p.Email;
            txtId.Text = p.Id;
            msktxtData.Text = p.BirthDate.ToString();
        }

        private void lst_clientes_DoubleClick(object sender, EventArgs e)
        {
            var p = GetItem();
            WriteProperties(p);
            lblName.Visible = true;
        }
    }
}
