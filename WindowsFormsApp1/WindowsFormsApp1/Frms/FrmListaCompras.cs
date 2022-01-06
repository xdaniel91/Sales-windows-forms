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
        Order OrderSelect;
        public FrmListaCompras()
        {
            InitializeComponent();
            FillLst();
        }

        void FillLst()
        {
            foreach (var order in DataBase.lista_order)
            {
                lst_orders.Items.Add(WriteOrder(order));
            }
        }

        void GetOrder()
        {
            Order o = DataBase.lista_order[lst_orders.SelectedIndex];
            OrderSelect = o;
        }

        string WriteOrder(Order order)
        {
            return $"Cliente: {order.Customer.Nome} | Id: {order.Customer.Id}";
        }

        public void GetInfos(Order order)
        {
            
            foreach (var item in order.Items)
            {
                 lst_infos.Items.Add($"produto: {item.OrderProduto.Nome} |  qtd: {item.Quantity} |  quantidade: {item.Quantity} |  Total {item.TotalValue:c}");            
            }
            
        }

        private void DoubleClick(object sender, EventArgs e)
        {
            lst_infos.Items.Clear();
            GetOrder();
            GetInfos(OrderSelect);
        }
    }
}