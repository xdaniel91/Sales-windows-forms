using Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    public static class DataBase
    {
              
        public static List<Produto> lista_produtos = new List<Produto>();
        
        public static List<OrderItems> lista_itens = new List<OrderItems>();

        public static List<Order> lista_order = new List<Order>();

        public static List<User.Unit> lista_users = new List<User.Unit>();
                               
    }
}
