using Library.BaseDados;
using Library.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using LibraryDAO;
using Library.Entities;

namespace WindowsFormsApp1
{
    public partial class FrmOrder : UserControl
    {
        BackgroundWorker myBW = new BackgroundWorker();
        DaoOrderItem daoItem = new DaoOrderItem();
        Person CurrentCustomer = null;
        Order CurrentOrder = null;
        OrderItems myItem = null;
        List<OrderItems> orderItems = new List<OrderItems>();

        int rowIndex = -1;

        public FrmOrder()
        {
            InitializeComponent();
            btnQuantidade.Text = "Aidiconar";
            btnFinzaliar.Text = "Finalizar";
            lblQuantidade.Text = "Quantidade";
            btnSelectUser.Text = "Escolher um cliente";
            txtQuantity.Text = "0";
            lblTotal.Text = $"{0:c}";
            lblCustomer.Visible = false;
            pictureBox1.Visible = false;
            RefreshScreen();
        }

        void RefreshScreen()
        {
            if (orderItems.Count <= 0) return; ;

            lst_itens.Items.Clear();

            foreach (var item in orderItems)
            {
                lst_itens.Items.Add(WriteItemOrderScreen(item));
            }
        }

        private void btnIniciarCompra_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer == null)
            {
                MessageBox.Show("Selecione um cliente para iniciar uma compra.", "Timeshare Soluções");
            }
            else
            {
                try
                {
                    int quantity = Convert.ToInt32(txtQuantity.Text);
                    if (quantity <= 0) return;

                    if (rowIndex < 0)
                    {
                        MessageBox.Show("Por favor selecione um produto", "Timeshare Soluções");
                    }
                    else
                    {
                        var idProduto = Convert.ToUInt32(dgv_products.Rows[rowIndex].Cells["Id"].Value.ToString());
                        var nome = dgv_products.Rows[rowIndex].Cells["Produto"].Value.ToString();
                        var preco = dgv_products.Rows[rowIndex].Cells["Preço"].Value.ToString();
                        var quantidade = dgv_products.Rows[rowIndex].Cells["Quantidade disponivel"].Value.ToString();
                        var produto = new Product(nome, Convert.ToDouble(preco), Convert.ToInt32(quantidade));
                        var orderItem = new OrderItems(produto, quantity);
                        orderItem.ProdutoId = idProduto;

                        var itemBanco = new ItemDataBase(quantity, produto.Preco, idProduto, CurrentCustomer.Id);
                        daoItem.InsertItem(itemBanco);
                        
                        myItem = orderItem;
                        orderItems.Add(orderItem);
                        RefreshScreen();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Produto não adicionado. Erro: " + ex.Message, "Timeshare Soluções");
                }
            }
        }


        private void btnFinzaliar_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer == null || orderItems.Count < 0 || myItem == null)
            {
                MessageBox.Show("Selecione um cliente, ou adicione algum item", "Timeshare Soluções");
            }
            else
            {
                if (CurrentOrder != null)
                {
                    try
                    {
                        CurrentOrder.FinalizeOrder();
                        var itens = orderItems;
                        var customer = CurrentCustomer.Nome.ToString();
                        var status = CurrentOrder.Status.ToString();
                        string total = lblTotal.Text;
                        var frm = new FrmFinalize(customer, status, total, itens, CurrentCustomer.Id);
                        frm.ShowDialog();
                        CurrentOrder = null;
                        CurrentCustomer = null;
                        myItem = null;
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

        }

        string WriteItemOrderScreen(OrderItems item)
        {
            var txt = lblTotal.Text.Remove(0, 2);
            var total = double.Parse(txt);
            total += item.TotalValue;
            lblTotal.Text = $"{total:c}";
            return $"{item.OrderProduto.Nome}" + new string(' ', 20 - item.OrderProduto.Nome.Length) + $"{item.Quantity}" + new string(' ', 4) + $"{item.TotalValue:c}";
        }


        private void FrmOrder_Load(object sender, EventArgs e)
        {
            AtualizarGridEmBackground();
        }

        void AtualizarGridEmBackground()
        {
            myBW.DoWork += (obj, args) => daoItem.Select();
            myBW.RunWorkerCompleted += (obj, args) => daoItem.AtualizarGrid(dgv_products);
            myBW.RunWorkerAsync();
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer != null) return;

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
            }
        }

        private void dgv_products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }
    }


}