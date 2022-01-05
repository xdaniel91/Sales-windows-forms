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
    public partial class FrmFinalize : Form
    {
        public FrmFinalize()
        {
            InitializeComponent();
            GetInfos(DataBase.lista_order);
            lblData.Text = $"{DateTime.Now}";
        }

        public void GetInfos(List<Order> orders)
        {
            double total = 0;
            foreach (var order in orders)
            {
                lblCustomer.Text = $"Cliente: {order.Customer}";
                lblStatus.Text = $"Status do pedido: {order.Status}";
                foreach (var item in order.Items)
                {                  
                    total =  total + item.TotalValue;
                    
                    lst_principal.Items.Add($"produto: {item.OrderProduto.Nome} | qtd: {item.Quantity} | total: {item.TotalValue}");
                }
            }
            lblTotal.Text = $"Total {total:c}";
        }

        private void lblCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}