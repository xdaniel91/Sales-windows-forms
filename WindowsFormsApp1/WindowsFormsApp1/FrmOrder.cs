using Library.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1
{
    public partial class FrmOrder : UserControl
    {
        Customer CurrentCustomer = null;
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
            lst_produtos.Enabled = false;
            btnFinzaliar.Enabled = false;
            btnQuantidade.Enabled = false;
            lblCustomer.Visible = false;
           
            if (lst_produtos.SelectedIndex == -1)
            {
                return;
            }
        }

        public void WriteProductsScreen()
        {
            foreach (var item in DataBase.lista_produtos)
            {
                lst_produtos.Items.Add(WriteProductProperties(item));
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
            try
            {
                CurrentOrder.AddItem(GetItem());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TimeShare Soluções");
            }
        }

        private void lst_produtos_DoubleClick(object sender, EventArgs e) // add w/ double click
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

        private void btnFinzaliar_Click(object sender, EventArgs e)
        {
            if (CurrentOrder != null)
            {
                CurrentOrder.FinalizeOrder();
                DataBase.lista_order.Add(CurrentOrder);
                CurrentOrder = null;
            }
            else
            {
                MessageBox.Show("Order global null");
            }
            var frm = new FrmFinalize();
            frm.ShowDialog();

        }

        public string WriteItemOrderScreen(OrderItems item)
        {
            var txt = lblTotal.Text.Remove(0, 2);
            var total = double.Parse(txt);
            total += item.TotalValue;
            lblTotal.Text = $"{total:c}";
            return $"{item.OrderProduto.Nome} " +
           $" {new string(' ', 20 - item.OrderProduto.Nome.Length - item.Quantity.ToString().Length - item.TotalValue.ToString().Length)}" +
           $" {item.Quantity}    {item.TotalValue:c}";
        }

        public string WriteProductProperties(Product p)
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

        OrderItems GetItem()
        {
            if (txtQuantity.Text == null || string.IsNullOrEmpty(txtQuantity.Text) || Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                MessageBox.Show("Digite uma quantidade válida");
            }
            Product p = DataBase.lista_produtos[lst_produtos.SelectedIndex];
            var quantity = int.Parse(txtQuantity.Text);
            var item = new OrderItems(p, quantity);
            RefreshScreen();
            lst_compras.Items.Add(WriteItemOrderScreen(item));
            return item;
        }

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            var frm = new FrmChooseUser();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                CurrentCustomer = frm.CustomerChosen;
                lst_produtos.Enabled = true;
                btnFinzaliar.Enabled = true;
                btnQuantidade.Enabled = true;
                if (CurrentCustomer != null)
                {
                    var order = new Order(CurrentCustomer);
                    CurrentOrder = order;
                    lblCustomer.Visible = true;
                    lblCustomer.Text = $"Bem-vindo {CurrentCustomer.Nome}";
                }
                else
                {
                    MessageBox.Show("Customer null");
                }
            }
        }
    }
}