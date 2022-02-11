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
        Database Postgre = new Database();
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
            return $"{item.OrderProduto.Nome}" + new string(' ', 20 - item.OrderProduto.Nome.Length) + $"{item.Quantity}" + new string(' ', 4);
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

        void MySelect()
        {
            //Postgre.connection = new NpgsqlConnection(Postgre.connectString);
            //Postgre.connection.Open();
            //Postgre.sql = @"select cl_nome, oi_quantidade, pd_nome, oi_valortotal from clientes
            //               join compra_item on oi_clienteId = clientes.cl_id
            //               join produtos on produtos.pd_id = compra_item.oi_produtoId";
            //Postgre.sqlCommand = new NpgsqlCommand(Postgre.sql, Postgre.connection);
            //Postgre.dt = new DataTable();
            //Postgre.dt.Load(Postgre.sqlCommand.ExecuteReader());
            //Postgre.connection.Close();
            //dgv_clientexitem.DataSource = null; /* reset datagrid view */
            //dgv_clientexitem.DataSource = Postgre.dt;
        }
    }
}