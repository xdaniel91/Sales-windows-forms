using Library.BaseDados;
using Library.Classes;
using Npgsql;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmChooseUser : Form
    {
        public Person CustomerChosen { get; set; }
        Database postgre = new Database();
        int rowIndex = -1;

        public FrmChooseUser()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0) return;

            var id = Convert.ToUInt32(dgv_customers.Rows[rowIndex].Cells["_id"].Value.ToString());
            var nome = dgv_customers.Rows[rowIndex].Cells["_nome"].Value.ToString();
            var cpf = dgv_customers.Rows[rowIndex].Cells["_cpf"].Value.ToString();
            var email = dgv_customers.Rows[rowIndex].Cells["_email"].Value.ToString();
            var nascimento = dgv_customers.Rows[rowIndex].Cells["_nascimento"].Value.ToString();

            var person = new Person(nome, Convert.ToDateTime(nascimento), cpf, email);
            person.Id = id;
            CustomerChosen = person;
            DialogResult = DialogResult.OK;
        }
        void MySelect()
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
                MessageBox.Show(ex.Message);
            }
        }

        void AlimentarDGV()
        {
            dgv_customers.DataSource = null; /* reset datagrid view */
            dgv_customers.DataSource = postgre.dt;
        }

        private void FrmChooseUser_Load(object sender, EventArgs e)
        {
            BackgroundWorker myBW = new BackgroundWorker();
            myBW.DoWork += (obj, args) => MySelect();
            myBW.RunWorkerCompleted += (obj, args) => AlimentarDGV();
            myBW.RunWorkerAsync();

        }

        private void dgv_products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }
    }
}
