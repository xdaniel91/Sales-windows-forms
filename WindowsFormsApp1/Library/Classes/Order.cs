using Library.Classes;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public enum OrderStatus
    {
        InProgress,
        OrderPlaced,
        Processing,
        Delivered
    }

    public class Order
    {
        public List<OrderItems> Items { get; private set; }
        public Customer Customer { get; private set; }
        public OrderStatus Status { get; private set; }


        public Order(Customer customer)
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
        public void FinalizeOrder()
        {
            if (Status != OrderStatus.InProgress) throw new Exception("Só é possível finalizar uma compra em progresso");
            Status = OrderStatus.OrderPlaced;
        }

        public void ProcessingOrder()
        {
            if (Status != OrderStatus.OrderPlaced) throw new Exception("Só é possível processar um pedido realizado");
            Status = OrderStatus.Processing;
        }

        public void DeliveredOrder()
        {
            if (Status != OrderStatus.Processing) throw new Exception("Só é possível enviar um pedido que esteja processando");
            Status = OrderStatus.Delivered;
        }

        public override string ToString()
        {
            return $"{Customer.Nome} // {Status}";
        }


    }
}
