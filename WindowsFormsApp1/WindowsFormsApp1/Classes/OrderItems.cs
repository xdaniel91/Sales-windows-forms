using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class OrderItems
    {
        public Produto OrderProduto { get; set; }
        public int Quantity { get; set; }
        public double TotalValue => OrderProduto.Preco * Quantity;

        public OrderItems(Produto prodcut, int quantity)
        {
            OrderProduto = prodcut;
            Quantity = quantity;
            prodcut.RemoveQtdeDisponivel(quantity);
        }
    }





}