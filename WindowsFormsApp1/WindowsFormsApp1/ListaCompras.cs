using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ListaCompras : UserControl
    {
        public ListaCompras()
        {
            InitializeComponent();
            btnQuantidade.Text = "Aidiconar";
            btnFinzaliar.Text = "Finalizar";
            lblQuantidade.Text = "Quantidade";
            txtQuantity.Text = "0";

            Utils.lista_produtos = new List<Produto>()
            {
                new Produto("Notebook", 500.28, 50),

                new Produto("Caneta", 666, 30) ,

                new Produto("Mouse", 888.66, 20) ,

                new Produto("Teclado", 150.30, 40) ,

                new Produto("Celular", 325.4,  65 ),
            };
            IncluirProdutoLista();
        }

        public void IncluirProdutoLista()
        {
            foreach (var item in Utils.lista_produtos)
            {
                lst_produtos.Items.Add(EscreverLinhasProdutos(item));
            }
        }

        private void btnIniciarCompra_Click(object sender, EventArgs e) // Adicionar 
        {
            AdicionarItemSelecionado();
        }

        private void lst_produtos_DoubleClick(object sender, EventArgs e) // adiconar item a compra double click
        {
            AdicionarItemSelecionado();
        }

        public void AdicionarACompra(Produto p) // adiciona um produto a lista de compras.
        {
            try
            {
                Utils.lista_compras.Add(p);
                int quantity = Convert.ToInt32(txtQuantity.Text);
                p.RemoveQtdeDisponivel(quantity);

                double total = 0.0;
                foreach (var item in Utils.lista_compras)
                {
                    total += item.Preco * quantity;
                }

                lblTotal.Text = $"Valor total:  {total:c}";
                lst_compras.Items.Add(EscreverLinhasCompra(p));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"  {ex.Message}");
            }
        }

        private void btnFinzaliar_Click(object sender, EventArgs e)
        {
            lblTotal.Text = "R$ 00,0";
            txtQuantity.Text = "0";
            Utils.ListBoxPreenchido = lst_compras;
            Utils.ListaCompraFinalizada = Utils.lista_compras;
            lst_compras.Items.Clear();
            lst_produtos.Items.Clear();
            var frm = new FrmCupom();
            frm.ShowDialog();   


        }

        public string EscreverLinhasCompra(Produto p)
        {
            var qtd = Convert.ToInt32(txtQuantity.Text);
            var preco = p.Preco * qtd;

            string qtde = txtQuantity.Text;
            return $"{p.Nome}  {new string(' ', 20 - p.Nome.Length - qtde.Length - preco.ToString().Length)} {qtde}  {preco:c}";
        }   // método auxiliar

        public string EscreverLinhasProdutos(Produto p)
        {
            string preco = $"{p.Preco:c}";
            if (String.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Text = "0";
            }
            var qtdeDisponivel = p.QuantidadeDisponivel;
            return $"{p.Nome}  {new string(' ', 20 - p.Nome.Length - qtdeDisponivel.ToString().Length - preco.Length)} {qtdeDisponivel}      {preco}";
        } // método auxiliar

        void AdicionarItemSelecionado()
        {
            try
            {
                if (txtQuantity.Text == null || string.IsNullOrEmpty(txtQuantity.Text) || Convert.ToInt32(txtQuantity.Text) <= 0)
                {
                    MessageBox.Show("Digite uma quantidade válida");
                }
                else
                {
                    Produto p = Utils.lista_produtos[lst_produtos.SelectedIndex];
                    AdicionarACompra(p);
                    int quantity = Convert.ToInt32(txtQuantity.Text);

                    //atualizar os itens na tela após adicionar na compra.
                    lst_produtos.Items.Clear();
                    foreach (var item in Utils.lista_produtos)
                    {
                        lst_produtos.Items.Add(EscreverLinhasProdutos(item));
                    }
                }
                if (lst_produtos.SelectedIndex == -1) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // método para adicionar um item selecionado na listbox produtos a listbox compras

    }
}



