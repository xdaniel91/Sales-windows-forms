using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Library.BaseDados;

namespace WindowsFormsApp1
{
    public partial class FrmFinalize : Form
    {
        public List<OrderItems> orderItems = new List<OrderItems>();
        uint CustomerId;
        public FrmFinalize(string customer, string status, string total, List<OrderItems> lista, uint id)
        {
            InitializeComponent();
            lblData.Text = $"{DateTime.Now}";
            lblCustomer.Text = customer;
            lblStatus.Text = status;
            lblTotal.Text = total;
            orderItems = lista;
            CustomerId = id;

            RefreshScreen();
        }

        string WriteItemOrderScreen(OrderItems item)
        {
            var nome = item.OrderProduto.Nome;
            var quantidade = item.Quantity;
            var total = item.TotalValue;

            var nomeLength = nome.Length;
            var quantidadeLength = quantidade.ToString().Length;
            var totalLength = total.ToString().Length;
            return $"{nome + new string(' ', 21 - nomeLength)}" + $"{quantidade + new string(' ', 5 - quantidadeLength)}" + $"{total + new string(' ', 10 - totalLength)}";
        }

        void RefreshScreen()
        {
            if (orderItems.Count <= 0) return; ;

            lst_finalize.Items.Clear();

            foreach (var item in orderItems)
            {
                lst_finalize.Items.Add(WriteItemOrderScreen(item));
            }
        }

        public void GetInfos(Order order)
        {
            double total = 0;

            lblCustomer.Text = $"Cliente: {order.Customer}";
            lblStatus.Text = $"Status: {order.Status}";
            foreach (var item in order.Items)
            {
                total = total + item.TotalValue;
            }

            lblTotal.Text = $"Total {total:c}";
        }
    }
}