using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class ItemDataBase
    {
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public uint ProdutoId { get; set; }
        public uint ClienteId { get; set; }
        public double ValorTotal { get; private set; }



        public ItemDataBase(int quantidade, double valor, uint id_produto, uint id_cliente)
        {
            Quantidade = quantidade;
            ValorUnitario = valor;
            ProdutoId = id_produto;
            ClienteId = id_cliente;
            ValorTotal = quantidade * valor;
        }

        public object[] RetornoInfosBanco()
        {
            object[] itens = new object[] { Quantidade, ValorTotal, ProdutoId, ClienteId };
            return itens;
        }

    }
}
