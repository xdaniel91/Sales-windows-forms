using Library.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1
{
    public partial class FrmUserRegister : UserControl
    {
        public FrmUserRegister()
        {
            InitializeComponent();
            lblCpf.Text = "CPF";
            lblId.Text = "ID";
            lblName.Text = "Nome";
            lblData.Text = "Data de nascimento";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User.Unit();
                user = AssignInfos();
                user.ValidaClasse();
                user.ValidaComplemento();
                DataBase.lista_users.Add(user);
                MessageBox.Show("Usuário incluido com sucesso!");
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Não foi possível registrar o usuário, verifique os dados! {vex.Message}", "TimeShare Soluções");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Inclusão não permitida. {ex.Message}", "Timeshare Soluções");
            }
        }
        User.Unit AssignInfos()
        {
            var user = new User.Unit();
            try
            {
                user.Nome = txtNome.Text;
                var birthdate = Convert.ToDateTime(msktxtData.Text);
                user.BirthDate = birthdate;
                user.CPF = txtCpf.Text;
                user.Id = txtId.Text;

                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na conversão de txt para propiedades. {ex.Message}", "TimeShare Soluções");
            }
            return user;
        }
    }
}
