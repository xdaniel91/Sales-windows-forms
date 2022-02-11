using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Library.BaseDados;
using Newtonsoft.Json;
using Npgsql;

namespace Library.Classes
{

    public class Person
    {
        Database postgre = new Database();
        public uint Id { get; set; }
        // infos pessoais
        [Required(ErrorMessage = "Campo nome obrigatório")]
        [StringLength(50, ErrorMessage = "Campo nome deve ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Cpf obrigatório")]
        public string Cpf { get; set; }

       // [JsonProperty]
        [Required(ErrorMessage = "Campo Email obrigatório")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "Campo data de nascimento obrigatório")]
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                var actualDate = DateTime.Now;
                var age = actualDate.Year - BirthDate.Year;

                if (actualDate.Month < BirthDate.Month)
                    age--;

                return age;
            }
        }

        public Person()
        {
        }

        public Person(string nome, DateTime birth, string cpf, string email)
        {
            Nome = nome;
            BirthDate = birth;
            if (Age > 110 || Age < 13) throw new Exception("Idade inferior a 13 anos ou superior a 110 não permitida. Verifique a data de nascimento");

            Cpf = cpf;
            Email = email;
        }

        public override string ToString()
        {
            return Nome;
        }

        public void ValidaComplemento()
        {
            bool validCpf = Utils.ValidaCpf(this.Cpf);
            bool validEmail = Utils.ValidaEmail(this.Email);

            if (validCpf == false) throw new Exception("CPF inválido");
            if (validEmail == false) throw new Exception("Email inválido");
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

        void InsertCustomer(Person customer)
        {
            customer.ValidaClasse();
            customer.ValidaComplemento();
            var nome = customer.Nome;
            var nascimento = customer.BirthDate.ToString("dd/MM/yyyy").Replace('/', '-');
            var cpf = customer.Cpf;
            var email = customer.Email;

            Database postgre = new Database();
            postgre.connection.Open();
            postgre.sql = $@"select * from clientes_insert('{nome}', '{nascimento}', '{cpf}', '{email}')";
            postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);       
            postgre.connection.Close();
        }

    }
}

