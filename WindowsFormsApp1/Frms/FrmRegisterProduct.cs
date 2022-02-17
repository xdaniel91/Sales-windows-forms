using Library.BaseDados;
using LibraryDAO;
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
        DaoProduto daoProduto = new DaoProduto();
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
                var id = Convert.ToUInt32(dgv_products.Rows[rowIndex].Cells["_id"].Value.ToString());
                daoProduto.Delete(id);
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

        private void FrmRegisterProduct_Load(object sender, EventArgs e)
        {
            AtualizarGridEmBackground();
        }

        void AtualizarGridEmBackground()
        {
            myBW.DoWork += (obj, args) => daoProduto.Select();
            myBW.RunWorkerCompleted += (obj, args) => daoProduto.AtualizarGrid(dgv_products);
            myBW.RunWorkerAsync();
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
                    daoProduto.Insert(produto);
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
                    var id = Convert.ToUInt32(dgv_products.Rows[rowIndex].Cells["_id"].Value.ToString());
                    var produto = ReadFrm();
                    var infos = produto.InformacoesTratadasParaBancoDeDados();
                    daoProduto.Update(infos, id);
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