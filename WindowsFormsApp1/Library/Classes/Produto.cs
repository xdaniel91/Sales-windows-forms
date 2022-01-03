using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Produto
    {


        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int QuantidadeDisponivel { get; set; }

        public Produto(string id, string nome, double preco, int qtdeDisponivel)
        {
            Nome = nome;
            Preco = preco;
            QuantidadeDisponivel = qtdeDisponivel;
        }

        public void AddQtdeDisponivel(int qtde)
        {
            if (qtde <= 0)
            {
                throw new Exception("Digite um número válido");
            }
            QuantidadeDisponivel += qtde;
        }

        public void RemoveQtdeDisponivel(int qtde)
        {
            if (qtde > QuantidadeDisponivel)
            {
                throw new Exception("Quantidade disponível é insuficiente");
            }
            QuantidadeDisponivel = QuantidadeDisponivel - qtde;
        }

        public override string ToString()
        {
            return Nome;
        }
    }


}
