using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Frms
{
    public partial class FrmListaCompras : UserControl
    {
        public FrmListaCompras()
        {
            InitializeComponent();
            FillLst();
        }

        void FillLst()
        {
            foreach (var order in DataBase.lista_order)
            {
                lst_orders.Items.Add(WriteScreen(order));
            }
        }

        void GetOrder()
        {
            Order o = DataBase.lista_order[lst_orders.SelectedIndex];
            lst_infos.Items.Add(WriteItem(o));
        }

        string WriteScreen(Order order)
        {
            return $"{order.Customer.Nome}   {order.Customer.Id}";
        }

        public string WriteItem(Order order)
        {
            string result = "";
            foreach (var item in order.Items)
            {
                 result = ($"produto: {item.OrderProduto.Nome} | qtd: {item.Quantity} | total: {item.TotalValue}");            
            }
            return result;
        }

        private void DoubleClick(object sender, EventArgs e)
        {
            GetOrder();
        }
    }
}