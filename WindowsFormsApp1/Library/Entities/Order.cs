using Library.BaseDados;
using Library.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public interface IOrderContract
    {
        List<Order> GetOrders();
    }

    public enum OrderStatus
    {
        InProgress,
        OrderPlaced,
        Processing,
        Delivered
    }

    public class Order : IOrderContract
    {
        public static IOrderContract Shared = new Order();

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

        public void IncluirLista()
        {
            DataBase.lista_order.Add(this);
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

        #region "CRUD do Fichario"

        public void IncluirFichario(string Conexao)
        {
            string orderJson = Order.SerializedClassUnit(this);
            Fichario F = new Fichario(Conexao);
            if (F.status)
            {
                F.Incluir(orderJson);
                if (!(F.status))
                {
                    throw new Exception(F.mensagem);
                }
            }
            else
            {
                throw new Exception(F.mensagem);
            }
        }
        public List<Order> BuscarFicharioTodos(string conexao) // retorna uma lista de Orders

        {
            Fichario F = new Fichario(conexao);
            if (F.status)
            {
                _ = new List<string>();
                List<string> List = F.BuscarTodos();
                if (F.status)
                {
                    List<Order> listaOrders = new List<Order>();
                    for (int i = 0; i <= List.Count - 1; i++)
                    {
                        Order C = DesSerializedClassUnit(List[i]);
                        listaOrders.Add(C);
                    }

                    return listaOrders;
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }
            else
            {
                throw new Exception(F.mensagem);
            }
        }

        #endregion
        public static Order DesSerializedClassUnit(string vJson)
        {
            return JsonConvert.DeserializeObject<Order>(vJson);
        }

        public static string SerializedClassUnit(Order unit)
        {
            return JsonConvert.SerializeObject(unit);
        }

        public List<Order> GetOrders()
        {
            var o = new Order();
            // var result = o.BuscarFicharioTodos("C:\\Users\\DanielRodriguesCarva\\Documents\\FicharioOrders");
            var result = o.BuscarFicharioTodos("C:\\Users\\xdani\\OneDrive\\Documentos\\FicharioOrders");
            return result;
        }
    }
}
