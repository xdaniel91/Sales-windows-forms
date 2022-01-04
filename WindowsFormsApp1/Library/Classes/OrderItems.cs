namespace WindowsFormsApp1
{
    public class OrderItems
    {
        public Product OrderProduto { get; set; }
        public int Quantity { get; set; }
        public double TotalValue => OrderProduto.Preco * Quantity;

        public OrderItems(Product prodcut, int quantity)
        {
            OrderProduto = prodcut;
            Quantity = quantity;
            prodcut.RemoveQtdeDisponivel(quantity);
        }

        public override string ToString()
        {
            return $"{OrderProduto.Nome} // {Quantity} // {TotalValue}";
        }
    }
}