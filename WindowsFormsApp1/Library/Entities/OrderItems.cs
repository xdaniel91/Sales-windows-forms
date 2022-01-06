using Library.Classes;
using System;

namespace WindowsFormsApp1
{
    public class OrderItems : EntityBase
    {
        public Product OrderProduto { get; set; }
        public int Quantity { get; set; }
        public double TotalValue => OrderProduto.Preco * Quantity;

        public OrderItems(Product product, int quantity)
        {
            OrderProduto = product;
            if (quantity <= 0) throw new Exception("Quantidade inválida");
            if (quantity > OrderProduto.QuantidadeDisponivel) throw new Exception("Quantidade disponível não é o suficiente");
            Quantity = quantity;
            product.RemoveQtdeDisponivel(quantity);
            base.DateHourRegister = DateTime.Now;
        }
    }
}