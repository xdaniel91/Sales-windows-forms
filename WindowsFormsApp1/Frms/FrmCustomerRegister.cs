using Library.BaseDados;
using Library.Classes;
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
        Database postgre = new Database();
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
            postgre.connection = new NpgsqlConnection(postgre.connectString);
            myBW.DoWork += (obj, args) => MySelect();
            myBW.RunWorkerCompleted += (obj, args) => AlimentarDGV();
            myBW.RunWorkerAsync();
        }

        void AlimentarDGV()
        {
            dgv_customers.DataSource = null; /* reset datagrid view */
            dgv_customers.DataSource = postgre.dt;
        }

        private void MySelect()
        {
            try
            {
                postgre.connection = new NpgsqlConnection(postgre.connectString);
                postgre.connection.Open();
                postgre.sql = @"select * from clientes_select()";
                postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
                postgre.dt = new DataTable();
                postgre.dt.Load(postgre.sqlCommand.ExecuteReader());
                postgre.connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
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
                var result = p.InsertCustomer();
                AtualizarGridEmBackground();
                if (!result) throw new Exception("Não foi possível incluir o cliente");
     
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
                customer.ValidaClasse();
                customer.ValidaComplemento();
                var id = dgv_customers.Rows[rowIndex].Cells["_id"].Value.ToString(); 
                var result = customer.UpdateCustomer(id);
                AtualizarGridEmBackground();
                if (!result) throw new Exception("Não foi possivel atualizar o cliente");
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
            myBW.DoWork += (obj, args) => MySelect();
            myBW.RunWorkerCompleted += (obj, args) => AlimentarDGV();
            myBW.RunWorkerAsync();
        }
    }
}



