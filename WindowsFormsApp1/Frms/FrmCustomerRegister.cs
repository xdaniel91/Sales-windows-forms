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
                Insert();
            }
            else 
            {
                try
                {
                    MyUpdate();
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
            catch (Exception ex)
            {
                MessageBox.Show("aqui "+ ex.Message);
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
                p.ValidaClasse();
                p.ValidaComplemento();
                var result = p.InsertCustomer();
                if (result)
                {
                    MessageBox.Show("Cliente inserido com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não foi possível inserir o cliente!");
                }
                

                //postgre.connection.Open();
                //postgre.sql = $@"select * from clientes_insert('{p.Nome}', '{p.BirthDate.ToString("dd/MM/yyyy").Replace('/', '-')}', '{p.Cpf}', '{p.Email}')";
                //postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
                //result = (bool)postgre.sqlCommand.ExecuteScalar();
                //postgre.connection.Close();
                //postgre.dt = new DataTable();
                //postgre.dt.Load(postgre.sqlCommand.ExecuteReader());
                //myBW.DoWork += (obj, args) => MySelect();
                //myBW.RunWorkerCompleted += (obj, args) => AlimentarDGV();
                //myBW.RunWorkerAsync();

                //if (result)
                //{
                //    MessageBox.Show("Cliente cadastrado com sucesso", "Timeshare soluções");
                //}
                //else
                //{
                //    MessageBox.Show("Insert fail");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert fail. Error: " + ex.Message, "Timeshare Soluções");
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
                bool result;
                var customer = ReadFrm();
                customer.ValidaClasse();
                customer.ValidaComplemento();
                var id = dgv_customers.Rows[rowIndex].Cells["_id"].Value.ToString();
                var data = customer.BirthDate.ToString("yyyy/MM/dd").Replace('/', '-');
              
                postgre.connection.Open(); 
                postgre.sql = $@"select * from clientes_update({id}, '{customer.Nome}', '{data}', '{customer.Cpf}', '{customer.Email}');";
                postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
                postgre.sqlCommand.Parameters.AddWithValue("_nome", txtNome.Text);
                postgre.sqlCommand.Parameters.AddWithValue("_data", msktxtData.Text);
                postgre.sqlCommand.Parameters.AddWithValue("_cpf", txtCpf.Text);
                postgre.sqlCommand.Parameters.AddWithValue("_email", txtEmail.Text);
                result = (bool)postgre.sqlCommand.ExecuteScalar();
                postgre.connection.Close();
                myBW.DoWork += (obj, args) => MySelect();
                myBW.RunWorkerCompleted += (obj, args) => AlimentarDGV();
                myBW.RunWorkerAsync();

                if (result)
                {
                    MessageBox.Show("Cliente alterado com sucesso", "Timeshare Soluções");

                }
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
                bool result;
                var id = dgv_customers.Rows[rowIndex].Cells["_id"].Value.ToString();

                postgre.connection.Open();
                postgre.sql = $@"select * from clientes_delete({id})";
                postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
                result = (bool)postgre.sqlCommand.ExecuteScalar();
                postgre.dt = new DataTable();
                postgre.dt.Load(postgre.sqlCommand.ExecuteReader());
                AlimentarDGV();
                postgre.connection.Close();

                if (result)
                {
                    MessageBox.Show("Cliente deletado com sucesso.", "Timeshare soluções");
                    
                }
                else
                {
                    MessageBox.Show("Não foi possível deletar o cliente.", "Timeshare soluções");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}



