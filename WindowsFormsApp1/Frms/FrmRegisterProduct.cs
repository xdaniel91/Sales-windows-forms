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
    public partial class FrmRegisterProduct : UserControl
    {
        Database postgre = new Database();
        int rowIndex = -1;
        public FrmRegisterProduct()
        {
            InitializeComponent();

            lblName.Text = "Nome";
            lblPrice.Text = "Preço";
            lblQuantity.Text = "Quantidade";
            btnSalvar.Text = "Salvar";
            btnDelete.Text = "Delte";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        Product ReadFrm()
        {
            try
            {
                var p = new Product(txtName.Text, Convert.ToDouble(txtMoeda.Text), Convert.ToInt32(txtQuantity.Text));
                p.ValidaClasse();
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

        void Insert()
        {
            bool result;
            try
            {
                var p = ReadFrm();

                postgre.connection.Open();
                postgre.sql = $"select * from produtos_insert('{p.Nome}', {p.Preco.ToString().Replace(',', '.')}, {p.QuantidadeDisponivel})";
                postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
                result = (bool)postgre.sqlCommand.ExecuteScalar();
                postgre.connection.Close();
                if (result == true)
                {
                    MessageBox.Show("Produto cadastrado com sucesso", "Timeshare soluções");
                }
                else
                {
                    MessageBox.Show("Insert fail ");
                }
               // MySelect();
                AlimentarDGV();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MySelect()
        {
            try
            {
                postgre.connection = new NpgsqlConnection(postgre.connectString);
                postgre.connection.Open();
                postgre.sql = @"select * from produtos_select()";
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

        private void FrmRegisterProduct_Load(object sender, EventArgs e)
        {
            BackgroundWorker myBW = new BackgroundWorker();
            myBW.DoWork += (obj, args) => MySelect();
            myBW.RunWorkerCompleted += (obj, args) => AlimentarDGV();
            myBW.RunWorkerAsync();
        }

        void AlimentarDGV()
        {
            dgv_products.DataSource = null; /* reset datagrid view */
            dgv_products.DataSource = postgre.dt;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool result;

            if (String.IsNullOrEmpty(txtMoeda.Text) || String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtQuantity.Text) || int.Parse(txtQuantity.Text) <= 0)
                return;

            if (rowIndex < 0)
            {
                try
                {
                    Insert();
                }
                catch (ValidationException vex)
                {
                    MessageBox.Show($"{vex.Message}", "TimeShare Soluções");
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível adicionar o produto! {ex.Message}", "TimeShare Soluções");
                }
            }
            else  /* update */
            {
                try
                {
                    postgre.connection.Open();
                    var id = dgv_products.Rows[rowIndex].Cells["_id"].Value.ToString();
                    var obj = ReadFrm();
                    postgre.sql = $@"select * from produtos_update({id}, '{obj.Nome}', {obj.Preco.ToString().Replace(',','.')}, {obj.QuantidadeDisponivel});";
                    postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
                   
                    postgre.sqlCommand.Parameters.AddWithValue("_nome", txtName.Text);
                    postgre.sqlCommand.Parameters.AddWithValue("_preco", txtMoeda.Text);
                    postgre.sqlCommand.Parameters.AddWithValue("_quantidade", txtQuantity.Text);
                    result = (bool)postgre.sqlCommand.ExecuteScalar();
                    postgre.connection.Close();
                    if (result)
                    {
                        MessageBox.Show("Produto alterado com sucesso", "Timeshare Soluções");
                        MySelect();
                        AlimentarDGV();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível alterar o produto");
                    }

                }
                catch (Exception ex)
                {
                    postgre.connection.Close();
                    MessageBox.Show("Não foi possível alterar o produto. Error: " + ex.Message);
                }
            }

        }

        private void dgv_products_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                txtName.Text = dgv_products.Rows[e.RowIndex].Cells["_nome"].Value.ToString();
                txtMoeda.Text = dgv_products.Rows[e.RowIndex].Cells["_preco"].Value.ToString();
                txtQuantity.Text = dgv_products.Rows[e.RowIndex].Cells["_quantidade"].Value.ToString();
            }
        }

        private void dgv_products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }
    }
}


