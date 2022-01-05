using System.IO;
using System.Net;
using System.Text;
using WindowsFormsApp1;

namespace Library.Classes
{
    public class Utils
    {

        //public static bool ValidaSenhaLogin(string senha)
        //{
        //    if (senha == "curso")
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public static string GeraJSONCEP(string CEP)
        {
            System.Net.HttpWebRequest requisicao = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + CEP + "/json/");
            HttpWebResponse resposta = (HttpWebResponse)requisicao.GetResponse();

            int cont;
            byte[] buffer = new byte[1000];
            StringBuilder sb = new StringBuilder();
            string temp;
            Stream stream = resposta.GetResponseStream();
            do
            {
                cont = stream.Read(buffer, 0, buffer.Length);
                temp = Encoding.UTF8.GetString(buffer, 0, cont).Trim();
                sb.Append(temp);

            } while (cont > 0);
            return sb.ToString();
        }

        public static bool Valida(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static void FeedLists()
        {
            string connectionProduct = "C:\\Users\\DanielRodriguesCarva\\Documents\\FicharioProducts";
            string connectionCustomer = "C:\\Users\\DanielRodriguesCarva\\Documents\\FicharioCustomers";
            string connectionOrders = "C:\\Users\\DanielRodriguesCarva\\Documents\\FicharioOrders";
            //string Connection = "C:\\Users\\xdani\\OneDrive\\Documentos\\FicharioProducts";
            var p = new Product("", "", 0, 0);
            var c = new Person();
            var o = new Order(c);
            DataBase.lista_order = o.BuscarFicharioTodos(connectionOrders);
            DataBase.lista_produtos = p.BuscarFicharioTodos(connectionProduct);
            DataBase.lista_users = c.BuscarFicharioTodos(connectionCustomer);
        }

    }
}
