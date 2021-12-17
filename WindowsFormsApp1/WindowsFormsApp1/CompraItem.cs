using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CompraItem
    {
        public int Quantity { get; set; }
        public Produto Produto { get; set; }
        public double TotalValue => Quantity * Produto.Preco;


        public CompraItem(Produto p, int qtd)
        {
            Produto = p;
            if (qtd <= 0 || qtd > Produto.QuantidadeDisponivel)
            {
                throw new Exception("Digite uma quantidade válida");
            }
            Quantity = qtd;
           
        }
    }
}
