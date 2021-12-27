using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Order
    {
        public List<OrderItems> Items { get; set; }

        public Order()
        {
            Items = new List<OrderItems>();
        }

        public void AddItem(OrderItems item)
        {
            Items.Add(item);

        }
        public void RemoveItem(OrderItems item, int quantity)
        {
            Items.Remove(item);
            
        }
    }
}
