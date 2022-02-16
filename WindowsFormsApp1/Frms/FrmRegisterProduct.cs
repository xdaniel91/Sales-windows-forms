using Library.BaseDados;
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
        BackgroundWorker myBW = new BackgroundWorker();
        Database postgre = new Database();
        int rowIndex = -1;

        public FrmRegisterProduct()
        {
            InitializeComponent();

            lblName.Text = "Nome";
            lblPrice.Text = "Preço";
            lblQuantity.Text = "Quantidade";
            btnSalvar.Text = "Salvar";
            btnDelete.Text = "Excluir";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           var dialog = MessageBox.Show("TEM CERTEZA QUE DESEJA EXCLUIR ESSE PRODUTO?", "Timeshare Soluções", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.Cancel) return;

            try
            {
                var id = dgv_products.Rows[rowIndex].Cells["_id"].Value.ToString();
                var produto = ReadFrm();
                produto.DeleteProduct(id);
                AtualizarGridEmBackground();
            }
            catch (ValidationException vex)
            {
                MessageBox.Show("Não foi possivel deletar o produto " + vex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Não foi possivel deletar o produto " + ex.Message);
            }
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
            AtualizarGridEmBackground();
        }

        void AtualizarGridEmBackground()
        {
            myBW.DoWork += (obj, args) => MySelect();
            myBW.RunWorkerCompleted += (obj, args) => AtualizarGrid();
            myBW.RunWorkerAsync();
        }

        void AtualizarGrid()
        {
            dgv_products.DataSource = null;
            dgv_products.DataSource = postgre.dt;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
          
            if (String.IsNullOrEmpty(txtMoeda.Text)    ||
                String.IsNullOrEmpty(txtName.Text)     || 
                String.IsNullOrEmpty(txtQuantity.Text) || 
                int.Parse(txtQuantity.Text) <= 0)
                return;

            if (rowIndex < 0)
            {
                try
                {
                    var produto = ReadFrm();
                    produto.InsertProduct();
                    AtualizarGridEmBackground();
                    MessageBox.Show("Produto incluido com sucesso", "Timeshare Soluções");
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
            else 
            {
                try
                {    
                    var id = dgv_products.Rows[rowIndex].Cells["_id"].Value.ToString();
                    var produto = ReadFrm();
                    produto.UpdateProduct(id);
                    AtualizarGridEmBackground();
                    MessageBox.Show("Produto atualizado!", "TimeshareSoluções");

                }
                catch (Exception ex)
                {
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