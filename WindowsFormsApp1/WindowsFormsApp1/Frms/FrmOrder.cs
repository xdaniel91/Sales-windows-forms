using Library.Classes;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmOrder : UserControl
    {
        string Connection = "C:\\Users\\xdani\\OneDrive\\Documentos\\FicharioOrders";
        //string Connection = "C:\\Users\\DanielRodriguesCarva\\Documents\\FicharioOrders";
        Person CurrentCustomer = null;
        Order CurrentOrder = null;

        public FrmOrder()
        {
            InitializeComponent();
            btnQuantidade.Text = "Aidiconar";
            btnFinzaliar.Text = "Finalizar";
            lblQuantidade.Text = "Quantidade";
            txtQuantity.Text = "0";
            btnExcluir.Text = "Excluir";
            WriteProductsScreen();
            lblTotal.Text = $"{0:c}";
            lblCustomer.Visible = false;
            pictureBox1.Visible = false;

            if (lst_produtos.SelectedIndex == -1)
            {
                return;
            }
        }

        void WriteProductsScreen()
        {
            try
            {
                foreach (var item in DataBase.lista_produtos)
                {
                    lst_produtos.Items.Add(WriteProductProperties(item));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TimeShare Soluções");
            }
        }

        private void btnIniciarCompra_Click(object sender, EventArgs e) // botão adicionar produto
        {
            if (CurrentCustomer == null || CurrentOrder == null)
            { 
                MessageBox.Show($"Clique em '{btnSelectUser.Text}' para escolher um cliente"); 
            }
            else
            {
                try
                {

                    CurrentOrder.AddItem(GetItem());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TimeShare Soluções");
                }

            }
        }

        private void lst_produtos_DoubleClick(object sender, EventArgs e) // add w/ double click
        {
            if (CurrentOrder == null || CurrentCustomer == null) return;

            try
            {
                CurrentOrder.AddItem(GetItem());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TimeShare Soluções");
            }
        }

        private void btnFinzaliar_Click(object sender, EventArgs e)
        {
            if (CurrentOrder != null)
            {
                CurrentOrder.FinalizeOrder(); // status = orderPlaced
                try
                {
                    CurrentOrder.IncluirFichario(Connection);
                    CurrentOrder.IncluirLista();
                    lst_compras.Items.Clear();
                    lblTotal.Text = $"{0:c}";
                    var frm = new FrmFinalize();
                    frm.ShowDialog(); //abre o "cupom"

                    CurrentOrder = null;
                    CurrentCustomer = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TimeShare Soluções");
                }
               
            }
            else
            {
                MessageBox.Show("Selecione um cliente para inicar uma compra!", "TimeShare Soluções");
            }
        }

        string WriteItemOrderScreen(OrderItems item)
        {
            var txt = lblTotal.Text.Remove(0, 2);
            var total = double.Parse(txt);
            total += item.TotalValue;
            lblTotal.Text = $"{total:c}";
            return $"{item.OrderProduto.Nome}" + new string(' ', 20 - item.OrderProduto.Nome.Length) + $"{item.Quantity}" + new string(' ', 4) + $"{item.TotalValue:c}";
        }

        string WriteProductProperties(Product p)
        {
            try
            {
                var qtdeDisponivel = p.QuantidadeDisponivel;
                return $"{p.Nome}" + new string(' ', 20 - p.Nome.Length) + $"{qtdeDisponivel}" + new string(' ', 7 - qtdeDisponivel.ToString().Length) + $"{p.Preco:c}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível escrever o produto na tela! {ex.Message}");
                return $"Não foi possível escrever o produto na tela! {ex.Message}";
            }
        }

        OrderItems GetItem()
        {

            pictureBox1.Visible = false;
            try
            {
                Product p = DataBase.lista_produtos[lst_produtos.SelectedIndex];
                var quantity = int.Parse(txtQuantity.Text);
                var item = new OrderItems(p, quantity);
                RefreshScreen();
                lst_compras.Items.Add(WriteItemOrderScreen(item));
                return item;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //void RemoveItem()
        //{
        //    try
        //    {
        //        Product p = CurrentOrder.Items.[lst_compras.SelectedIndex];
        //        var item = CurrentOrder.Items.Find(product => product.OrderProduto.Id == p.Id);
        //        CurrentOrder.RemoveItem(item);
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }

        //}

        //void AdicionarItemSelecionado()
        //{

        //    else
        //    {
        //        try
        //        {


        //            RefreshScreen();
        //            lst_compras.Items.Add(EscreverLinhasCompra(item));

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Não foi possível adicionar o produto. {ex.Message}");
        //        }
        //    }
        //}

        void RefreshScreen()
        {
            lst_produtos.Items.Clear();
            foreach (var item in DataBase.lista_produtos)
            {
                lst_produtos.Items.Add(WriteProductProperties(item));
            }
        }

        private void button1_Click_1(object sender, EventArgs e) // botão de criar order / selecionar customer
        {
            var frm = new FrmChooseUser();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                CurrentCustomer = frm.CustomerChosen;

                if (CurrentCustomer != null)
                {
                    var order = new Order(CurrentCustomer); // status = in progress
                    CurrentOrder = order;
                    lblCustomer.Visible = true;
                    pictureBox1.Visible = true;
                    lblCustomer.Text = $"Bem-vindo {CurrentCustomer.Nome}";
                }
                else
                {
                    MessageBox.Show($"Cliente informado vazio (nulo)");
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }
    }
}