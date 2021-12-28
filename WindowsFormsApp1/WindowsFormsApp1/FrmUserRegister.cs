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

namespace WindowsFormsApp1
{
    public partial class FrmUserRegister : UserControl
    {
        public FrmUserRegister()
        {
            InitializeComponent();
            lblBairro.Text = "Bairro";
            lblCep.Text = "CEP";
            lblCidade.Text = "Cidade";
            lblCpf.Text = "CPF";
            lblId.Text = "ID";
            lblName.Text = "Nome";
            lblRua.Text = "Rua";
            lblUF.Text = "UF";

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }
        void AssignInfos()
        {
            var user = new User.Unit();
            user.ValidaClasse();
            user.ValidaComplemento();
            user.Id = txtId.Text;
            user.Logradouro = txtRua.Text;
            user.Nome = txtNome.Text;
            user.Telefone = txtTelefone.Text;
            user.CEP = msktxtCep.Text;
            user.Cidade = txtCidade.Text;
            user.CPF = msktxtCpf.Text;
            user.Bairro = txtBairro.Text;
        }
    }
}
