using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmCupom : Form
    {
        public FrmCupom()
        {
            InitializeComponent();
            Adicionar();
            
        }

        void Adicionar()
        {
            foreach (var item in DataBase.lista_compras)
            {
                lstCupom.Items.Add(Escrever(item));
            }
        }

        string Escrever(OrderItems item)
        {
            if (DataBase.lista_compras != null)
            {
                foreach (var i in DataBase.lista_compras)
                {
                    return $"{i.OrderProduto.Nome}  {i.Quantity}   {i.TotalValue}";
                }
            }
            else
            {
                return "";
            }
            return "caiu aqui";
           

           
           
        }
    }
}
