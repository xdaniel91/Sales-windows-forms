using Library.BaseDados;
using Library.Classes;
using Newtonsoft.Json;
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
        public Person Customer { get; private set; }
        public OrderStatus Status { get; private set; }

        private Order()
        {
        }

        public Order(Person customer)
        {
            Items = new List<OrderItems>();
            Customer = customer;
            Status = OrderStatus.InProgress;
        }
        public void AddItem(OrderItems item)
        {
            if (this.Status != OrderStatus.InProgress)
            {
                throw new Exception($"Só é possível adicionar itens a uma compra InProgress. {this.Status}");
            }
            Items.Add(item);
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
    }
}
