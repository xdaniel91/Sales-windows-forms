using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Compra
    {
        public List<CompraItem> Itens { get; set; }

        public Compra()
        {

        }

        public void AddItem(CompraItem orderItem)
        {
            Itens.Add(orderItem);
        }

        public void RemoveItem(CompraItem orderItem)
        {
            Itens.Remove(orderItem);
        }



    }
}
