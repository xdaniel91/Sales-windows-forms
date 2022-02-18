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
        LibraryDAO.DaoCustomer daoCustomers = new LibraryDAO.DaoCustomer();
        int rowIndex = -1;

        public FrmChooseUser()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0) return;

            var id = Convert.ToUInt32(dgv_customers.Rows[rowIndex].Cells["id"].Value.ToString());
            var nome = dgv_customers.Rows[rowIndex].Cells["nome"].Value.ToString();
            var cpf = dgv_customers.Rows[rowIndex].Cells["cpf"].Value.ToString();
            var email = dgv_customers.Rows[rowIndex].Cells["email"].Value.ToString();
            var nascimento = dgv_customers.Rows[rowIndex].Cells["nascimento"].Value.ToString();

            var person = new Person(nome, Convert.ToDateTime(nascimento), cpf, email);
            person.Id = id;
            CustomerChosen = person;
            DialogResult = DialogResult.OK;
        }

        private void FrmChooseUser_Load(object sender, EventArgs e)
        {
            AtualizarGridEmBackground();
        }

        private void dgv_products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void AtualizarGridEmBackground()
        {
            BackgroundWorker myBW = new BackgroundWorker();
            myBW.DoWork += (obj, args) => daoCustomers.Select();
            myBW.RunWorkerCompleted += (obj, args) => daoCustomers.AtualizarGrid(dgv_customers);
            myBW.RunWorkerAsync();
        }
    }
}
