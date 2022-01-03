using Library.Classes;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1
{
    public partial class FrmOrder : UserControl
    {
        User.Unit Customer = null;


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
            lst_produtos.Enabled = false;
            btnFinzaliar.Enabled = false;
            btnQuantidade.Enabled = false;
        }

        public void EscreverProdutosNaLst()
        {
            foreach (var item in DataBase.lista_produtos)
            {
                lst_produtos.Items.Add(EscreverLinhasProdutos(item));
            }
        }

        //public void EscreverUsers()
        //{
        //    foreach (var item in DataBase.lista_users)
        //    {
        //        lst_cliente.Items.Add(item);
        //    }
        //}

        //public void AddUser()
        //{
        //    if (lst_cliente.SelectedIndex == -1)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            User.Unit user = DataBase.lista_users[lst_cliente.SelectedIndex]; // usuario selecionado na lst
        //            Customer = user;
        //            if (user != null)
        //            {
        //                lst_produtos.Enabled = true;
        //                btnFinzaliar.Enabled = true;
        //                btnQuantidade.Enabled = true;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"{ex.Message}");
        //        }
        //    }
        //}

        private void btnIniciarCompra_Click(object sender, EventArgs e) // botão adicionar
        {
            AdicionarItemSelecionado();
        }

        private void lst_produtos_DoubleClick(object sender, EventArgs e) // add w/ double click
        {
            AdicionarItemSelecionado();
        }

        private void btnFinzaliar_Click(object sender, EventArgs e)
        {
            var frm = new FrmFinalize();
            frm.ShowDialog();
            frm.LabelCustomer.Text = Customer.Nome;
            double total = 0.0;
           foreach (var item in DataBase.lista_itens)
            {
                total += item.TotalValue;
            }
            frm.LabelTotal.Text = total.ToString();
            foreach (var item in DataBase.lista_itens)
            {
                frm.lst_principal.Items.Add(EscreverLinhasCompra(item));
            }

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
                    if (Customer != null)
                    {
                        var order = new Order(Customer); // criar a order 
                        order.AddItem(item);     // adiciona o item à order

                        DataBase.lista_itens = order.Items; // atribui data base a lista de itens 

                        RefreshScreen();
                        lst_compras.Items.Add(EscreverLinhasCompra(item));
                    }
                    else
                    {
                        MessageBox.Show("Cliente nulo", "TimeShare Soluções");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível adicionar o produto. {ex.Message}");
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            var frm = new FrmChooseUser();
            frm.ShowDialog();
            Customer = frm.CustomerChosen;
            lst_produtos.Enabled = true;
            btnFinzaliar.Enabled = true;
            btnQuantidade.Enabled = true;

        }
    }
}