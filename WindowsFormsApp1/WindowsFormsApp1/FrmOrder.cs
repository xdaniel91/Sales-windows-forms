using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmOrder : UserControl
    {
    
        public FrmOrder()
        {
            InitializeComponent();
            btnQuantidade.Text = "Aidiconar";
            btnFinzaliar.Text = "Finalizar";
            lblQuantidade.Text = "Quantidade";
            txtQuantity.Text = "0";
            btnExcluir.Text = "Excluir";
            EscreverProdutosNaLst();
            lblTotal.Text = $"{0:c}";

        }

        public void EscreverProdutosNaLst()
        {
            foreach (var item in DataBase.lista_produtos)
            {
                lst_produtos.Items.Add(EscreverLinhasProdutos(item));
            }
        }

        private void btnIniciarCompra_Click(object sender, EventArgs e) // botão adicionar
        {
            AdicionarItemSelecionado();
        }

        private void lst_produtos_DoubleClick(object sender, EventArgs e) // adiconar item a compra double click
        {
            AdicionarItemSelecionado();
        }

        private void btnFinzaliar_Click(object sender, EventArgs e)
        {
            var frm = new FrmCupom();
            frm.Show();
        }

        public string EscreverLinhasCompra(OrderItems item)
        {
            var txt = lblTotal.Text.Remove(0, 2);
            var total = double.Parse(txt);
            total += item.TotalValue;
            lblTotal.Text = $"{total:c}";
            return $"{item.OrderProduto.Nome} " +
           $" {new string(' ', 20 - item.OrderProduto.Nome.Length - item.Quantity.ToString().Length - item.TotalValue.ToString().Length)}" +
           $" {item.Quantity}    {item.TotalValue:c}";
        }

        public string EscreverLinhasProdutos(Produto p)
        {
            if (p.Nome.Length >= 30)
            {
                MessageBox.Show("Digite um nome menor");
            }
            else
            {
                try
                {
                    if (String.IsNullOrEmpty(txtQuantity.Text))
                    {
                        txtQuantity.Text = "0";
                    }
                    var qtdeDisponivel = p.QuantidadeDisponivel;
                    return $"{p.Nome}  {new string(' ', 20 - p.Nome.Length - qtdeDisponivel.ToString().Length - p.Preco.ToString().Length)} {qtdeDisponivel}   {p.Preco:c}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível escrever o produto na tela! {ex.Message}");
                }
            }
            return "";
        }

        void AdicionarItemSelecionado()
        {
            if (lst_produtos.SelectedIndex == -1)
            {
                return;
            }
            else if (txtQuantity.Text == null || string.IsNullOrEmpty(txtQuantity.Text) || Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                MessageBox.Show("Digite uma quantidade válida");
            }
            else
            {
                try
                {
                    Produto p = DataBase.lista_produtos[lst_produtos.SelectedIndex]; // produto selecionado na lst
                    var quantity = int.Parse(txtQuantity.Text); // define qtd
                    var item = new OrderItems(p, quantity); // criar o item
                    var order = new Order(); // criar a order
                    order.AddItem(item);     // adiciona o item à order
                   
                    DataBase.lista_compras = order.Items; // atribui data base a lista de itens 

                    orderAtual = order;

                    RefreshScreen();
                    lst_compras.Items.Add(EscreverLinhasCompra(item));

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível adicionar o produto. {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        void RemoveItem(Order order)
        {
            if (lst_compras.SelectedIndex == - 1)
            {
                return;
            }
            else
            {
                try
                {
                    var item = DataBase.lista_compras[lst_compras.SelectedIndex];
                    order.RemoveItem(item);
                    lst_compras.Items.Remove(item);
                    RefreshScreen2();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }

        }



        void RefreshScreen()
        {
            lst_produtos.Items.Clear();
            foreach (var item in DataBase.lista_produtos)
            {
                lst_produtos.Items.Add(EscreverLinhasProdutos(item));
            }
        }

        void RefreshScreen2()
        {
            lst_compras.Items.Clear();
            foreach (var item in DataBase.lista_compras)
            {
                lst_produtos.Items.Add(EscreverLinhasCompra(item));
            }
        }
    }
}



