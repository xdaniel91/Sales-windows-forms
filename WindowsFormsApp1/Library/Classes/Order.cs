using Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum OrderStatus
    {
        InProgress,
        PendingPayment,
        Processing,
        Shipped,
        Delivered
    }

    public class Order
    {
        public List<OrderItems> Items { get; set; }
        public User.Unit Customer { get; set; }
        public OrderStatus Status { get; set; }


        public Order(User.Unit customer)
        {
            Items = new List<OrderItems>();
            Customer = customer;
            Status = OrderStatus.InProgress;
        }
        public void AddItem(OrderItems item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItems item)
        {
            Items.Remove(item);         
        }

        public override string ToString()
        {

            return $"{Customer.Nome}  / {Status}";
        }
    }
}
