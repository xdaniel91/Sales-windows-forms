using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmFinalize : Form
    {
        public FrmFinalize()
        {
            InitializeComponent();
            var lastIndex = DataBase.lista_order.Count;
            GetInfos(DataBase.lista_order[lastIndex - 1]);
            lblData.Text = $"{DateTime.Now}";
        }

        public void GetInfos(Order order)
        {
            double total = 0;

            lblCustomer.Text = $"Cliente: {order.Customer}";
            lblStatus.Text = $"Status: {order.Status}";
            foreach (var item in order.Items)
            {
                total = total + item.TotalValue;

                lst_principal.Items.Add($"Produto: {item.OrderProduto.Nome}  |  Quantidade: {item.Quantity} |  Total: {item.TotalValue}");
            }

            lblTotal.Text = $"Total {total:c}";
        }

        private void lblCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}