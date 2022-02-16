using Library.BaseDados;
using Library.Classes;
using LibraryDAO;
using Npgsql;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class FrmUserRegister : UserControl
    {
        int rowIndex = -1;
        BackgroundWorker myBW = new BackgroundWorker();
        public FrmUserRegister()
        {
            InitializeComponent();
            lblCpf.Text = "CPF";
            btnDelete.Text = "Delete";
            lblName.Text = "Nome";
            lblData.Text = "Nascimento";
            btnRegister.Text = "Salvar";
            lblEmail.Text = "Email";
            txtCpf.MaxLength = 11;

            txtNome.MaxLength = 20;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                try
                {
                    Insert();
                    MessageBox.Show("Cliente incluido", "Timeshare Soluções");

                }
                catch (ValidationException vex)
                {
                    MessageBox.Show(" (vex) Não foi possível inserir o cliente. Error: " + vex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" (ex) Não foi possível incluir o cliente. Error: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    MyUpdate();
                    MessageBox.Show("Cliente Atualizado", "Timeshare Soluções");
                }
                catch (ValidationException vex)
                {
                    MessageBox.Show(" (vex) Não foi possível alterar o cliente. Error: " + vex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" (ex) Não foi possível alterar o cliente. Error: " + ex.Message);
                }
            }
        }

        private void FrmUserRegister_Load(object sender, EventArgs e)
        {
            myBW.DoWork += (obj, args) => DaoCustomer.SelectClientes();
            myBW.RunWorkerCompleted += (obj, args) => DaoCustomer.AlimentarDGV(dgv_customers);
            myBW.RunWorkerAsync();
        }

        private Person ReadFrm()
        {
            try
            {
                var cpf = txtCpf.Text;
                var email = txtEmail.Text;
                var nome = txtNome.Text;
                var birth = Convert.ToDateTime(msktxtData.Text);
                var p = new Person(nome, birth, cpf, email);
                return p;
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

        private void Insert()
        {
            try
            {
                var p = ReadFrm();
                DaoCustomer.InsertCustomer(p);
                AtualizarGridEmBackground();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgv_customers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void dgv_customers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                txtNome.Text = dgv_customers.Rows[e.RowIndex].Cells["_nome"].Value.ToString();
                msktxtData.Text = dgv_customers.Rows[e.RowIndex].Cells["_nascimento"].Value.ToString();
                txtCpf.Text = dgv_customers.Rows[e.RowIndex].Cells["_cpf"].Value.ToString();
                txtEmail.Text = dgv_customers.Rows[e.RowIndex].Cells["_email"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0) return;
            if (string.IsNullOrEmpty(txtCpf.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(msktxtData.Text)) return;

            var dialog = MessageBox.Show("DESEJA REALMENTE DELETAR ESSE CLIENTE ?", "Timeshare Soluções", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.Cancel) return;
            try
            {
                MyDelete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível deletar o cliente selecionado: Error: " + ex.Message);
            }
        }

        void MyUpdate()
        {
            try
            {
                var customer = ReadFrm();
                uint.TryParse(dgv_customers.Rows[rowIndex].Cells["_id"].Value.ToString(),  out uint id);
                DaoCustomer.UpdateCustomer(customer.InformacoesTratadasParaEnviarProBanco(), id);
                AtualizarGridEmBackground();
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

        void MyDelete()
        {
            try
            {
                var id = dgv_customers.Rows[rowIndex].Cells["_id"].Value.ToString();
                var result = Person.DeleteCustomer(id);
                AtualizarGridEmBackground();
                if (!result) throw new Exception("Não foi possível deletar o cliente");
            }
            catch (Exception)
            {
                throw;
            }
        }

        void AtualizarGridEmBackground()
        {
            myBW.DoWork += (obj, args) => DaoCustomer.SelectClientes();
            myBW.RunWorkerCompleted += (obj, args) => DaoCustomer.AlimentarDGV(dgv_customers);
            myBW.RunWorkerAsync();
        }
    }
}



