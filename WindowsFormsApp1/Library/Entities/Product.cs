using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Library.BaseDados;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public interface IProductContract
    {
        List<Product> GetProducts();
    }
    public class Product : IProductContract
    {
       public static IProductContract Shared = new Product();

        [Required(ErrorMessage = "Campo Id obrigatório")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "O id do produto deve ter 4 dígitos")]
        public string Id { get; private set; }

        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [StringLength(20, ErrorMessage = "O nome do produto deve ter no máximo 20 caracteres")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "Campo preço obrigatório")]
        public double Preco { get; private set; }

        [Required(ErrorMessage = "Campo Quantidade obrigatório")]
        public int QuantidadeDisponivel { get; private set; }

        public Product(string id, string nome, double preco, int quantidadeDisponivel)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            QuantidadeDisponivel = quantidadeDisponivel;
        }
        private Product()
        {
        }
        public void ValidaClasse()
        {
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid == false)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                throw new ValidationException(sbrErrors.ToString());
            }
        }

        protected internal void RemoveQtdeDisponivel(int qtde)
        {
            if (qtde > QuantidadeDisponivel || qtde <= 0)
            {
                throw new Exception("Valor inválido");
            }
            QuantidadeDisponivel -= qtde;
        }

        public override string ToString()
        {
            return Nome;
        }

        #region "CRUD do Fichario"

        public void IncluirFichario(string Conexao)
        {
            string clienteJson = Product.SerializedClassUnit(this);
            Fichario F = new Fichario(Conexao);
            if (F.status)
            {
                F.Incluir(this.Id, clienteJson);
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

        //public Product BuscarFichario(string id, string conexao)
        //{
        //    Fichario F = new Fichario(conexao);
        //    if (F.status)
        //    {
        //        string clienteJson = F.Buscar(id);
        //        return Product.DesSerializedClassUnit(clienteJson);
        //    }
        //    else
        //    {
        //        throw new Exception(F.mensagem);
        //    }
        //}

        //public void AlterarFichario(string conexao)
        //{
        //    string clienteJson = Product.SerializedClassUnit(this);
        //    Fichario F = new Fichario(conexao);
        //    if (F.status)
        //    {
        //        F.Alterar(this.Id, clienteJson);
        //        if (!(F.status))
        //        {
        //            throw new Exception(F.mensagem);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(F.mensagem);
        //    }
        //}

        //public void ApagarFichario(string conexao)
        //{

        //    Fichario F = new Fichario(conexao);
        //    if (F.status)
        //    {
        //        F.Apagar(this.Id);
        //        if (!(F.status))
        //        {
        //            throw new Exception(F.mensagem);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(F.mensagem);
        //    }

        //}

        public List<Product> BuscarFicharioTodos(string conexao) // retorna uma lista de produtos

        {
            Fichario F = new Fichario(conexao);
            if (F.status)
            {
                _ = new List<string>();
                List<string> List = F.BuscarTodos();
                if (F.status)
                {
                    List<Product> listaProducts = new List<Product>();
                    for (int i = 0; i <= List.Count - 1; i++)
                    {
                        Product C = DesSerializedClassUnit(List[i]);
                        listaProducts.Add(C);
                    }

                    return listaProducts;
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

        public static Product DesSerializedClassUnit(string vJson)
        {
            var result = JsonConvert.DeserializeObject<Product>(vJson);
            return result;
        }

        public static string SerializedClassUnit(Product unit)
        {
            return JsonConvert.SerializeObject(unit);
        }

        public List<Product> GetProducts()
        {
            var p = new Product();
            //var result = p.BuscarFicharioTodos("C:\\Users\\DanielRodriguesCarva\\Documents\\FicharioProducts");
            var result = p.BuscarFicharioTodos("C:\\Users\\xdani\\OneDrive\\Documentos\\FicharioProducts");
            return result;
        }
    }
}
