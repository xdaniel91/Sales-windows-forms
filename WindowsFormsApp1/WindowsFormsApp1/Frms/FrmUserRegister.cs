using Library.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmUserRegister : UserControl
    {
        //string Connection = "C:\\Users\\DanielRodriguesCarva\\Documents\\FicharioCustomers";
        string Connection = "C:\\Users\\xdani\\OneDrive\\Documentos\\FicharioCustomers";

        public FrmUserRegister()
        {
            InitializeComponent();
            lblCpf.Text = "CPF";
            lblId.Text = "ID";
            lblName.Text = "Nome";
            lblData.Text = "Nascimento";
            btnRegister.Text = "Confirmar";
            lblEmail.Text = "Email";
        }

        Person ReadFrm()
        {
            try
            {
                var userName = txtNome.Text;
                var birthdate = Convert.ToDateTime(msktxtData.Text);
                var userCpf = txtCpf.Text;
                var userId = txtId.Text;
                var userEmail = txtEmail.Text;
                var person = new Person(userId, userName, birthdate, userCpf, userEmail);
                return person;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var person = ReadFrm();
                person.ValidaClasse();
                person.ValidaComplemento();
                person.IncluirFichario(Connection);
                Utils.FeedLists();

                MessageBox.Show("Usuário incluido com sucesso!", "TimeShare Soluções");
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var person = ReadFrm();
                person.ValidaClasse();
                person.ValidaComplemento();
                person.IncluirFichario(Connection);

                MessageBox.Show("Usuário incluido com sucesso!", "TimeShare Soluções");
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
    }
}

