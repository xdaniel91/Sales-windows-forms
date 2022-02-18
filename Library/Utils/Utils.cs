using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using WindowsFormsApp1;

namespace Library.Classes
{
    public class Utils
    {
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

        public static bool ValidaCpf(string vrCPF)

        {

            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)

                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "12345678909")

                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());
            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {

                if (numeros[9] != 0)

                    return false;

            }

            else if (numeros[9] != 11 - resultado)

                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {

                if (numeros[10] != 0)

                    return false;

            }

            else

                if (numeros[10] != 11 - resultado)

                return false;



            return true;

        }

        /*   public static bool ValidaCpf(string cpf)
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
           } */

        public static bool ValidaEmail(string email)
        {
            email = email.Trim();
            bool IsValid;
            if (string.IsNullOrEmpty(email))
            {
                IsValid = false;
                return IsValid;
            }

            IsValid = Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            return IsValid;
        }

    }
}
