using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Library.BaseDados;
using Newtonsoft.Json;

namespace Library.Classes
{
    public class Customer
    {
        [Required(ErrorMessage = "Id do cliente obrigatório")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "O código do cliente deve ter 4 dígitos")]
        public string Id { get; set; }

        // infos pessoais
        [Required(ErrorMessage = "Campo nome obrigatório")]
        [StringLength(50, ErrorMessage = "Campo nome deve ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo CPF obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Campo CPF deve ter 11 dígitos")]
        public string CPF { get; set; }

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

        public override string ToString()
        {
            return Nome;
        }


        public void ValidaComplemento()
        {
            bool isvalid = Cls_Uteis.Valida(this.CPF);
            if (isvalid == false)
            {
                throw new Exception("CPF inválido");
            }
            if (Age > 110 || Age < 13)
            {
                throw new Exception("Data inválida");
            }

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

        #region "CRUD do Fichario"

        public void IncluirFichario(string Conexao)
        {
            string clienteJson = Customer.SerializerUnit(this);
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

        public Customer BuscarFichario(string id, string conexao)
        {
            Fichario F = new Fichario(conexao);
            if (F.status)
            {
                string clienteJson = F.Buscar(id);
                return Customer.DesSerializerUnit(clienteJson);
            }
            else
            {
                throw new Exception(F.mensagem);
            }
        }

        public void AlterarFichario(string conexao)
        {
            string clienteJson = Customer.SerializerUnit(this);
            Fichario F = new Fichario(conexao);
            if (F.status)
            {
                F.Alterar(this.Id, clienteJson);
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

        public void ApagarFichario(string conexao)
        {

            Fichario F = new Fichario(conexao);
            if (F.status)
            {
                F.Apagar(this.Id);
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

        public List<Customer> BuscarFicharioTodos(string conexao) // retorna uma lista de produtos

        {
            Fichario F = new Fichario(conexao);
            if (F.status)
            {
                _ = new List<string>();
                List<string> List = F.BuscarTodos();
                if (F.status)
                {
                    List<Customer> listaProducts = new List<Customer>();
                    for (int i = 0; i <= List.Count - 1; i++)
                    {
                        Customer C = DesSerializerUnit(List[i]);
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

        //#region CRUD DO FICHARIO DB

        //public void IncluirDB(string conexao)
        //{
        //    string clienteJson = SerializerUnit(this);
        //    var connection = new FicharyDB(conexao);
        //    if (connection.Status == true)
        //    {
        //        connection.IncluirDB(this.Id, clienteJson);
        //        if (connection.Status == false)
        //        {
        //            throw new Exception(connection.Message);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(connection.Message);
        //    }
        //}

        //public Unit BuscarFicharioDB(string id, string conexao)
        //{
        //    var connection = new FicharyDB(conexao);
        //    if (connection.Status == true)
        //    {
        //        var clienteJson = connection.BuscarDB(id);
        //        return User.DesSerializerUnit(clienteJson);
        //    }
        //    else
        //    {
        //        throw new Exception(connection.Message);
        //    }
        //}
        //public void AlterarFicharioDB(string conexao)
        //{
        //    var connection = new FicharyDB(conexao);
        //    var clienteJson = User.SerializerUnit(this);
        //    if (connection.Status == true)
        //    {
        //        connection.AlterarDB(this.Id, clienteJson);
        //        if (connection.Status == true)
        //        {
        //            throw new Exception(connection.Message);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(connection.Message);
        //    }
        //}

        //public void ExcluirDB(string conexao)
        //{

        //    var connection = new FicharyDB(conexao);
        //    if (connection.Status == true)
        //    {
        //        connection.ApagarDB(this.Id);
        //        if (connection.Status == true)
        //        {

        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(connection.Message);
        //    }
        //}

        //public List<List<string>> BuscarFicharioDBTodosDB(string conexao)
        //{
        //    FicharyDB F = new FicharyDB(conexao);
        //    if (F.Status)
        //    {
        //        List<string> List = new List<string>();
        //        List = F.BuscarTodos();
        //        if (F.Status)
        //        {
        //            List<List<string>> ListaBusca = new List<List<string>>();
        //            for (int i = 0; i <= List.Count - 1; i++)
        //            {
        //                User.Unit C = User.DesSerializerUnit(List[i]);
        //                ListaBusca.Add(new List<string> { C.Id, C.Nome });
        //            }
        //            return ListaBusca;
        //        }
        //        else
        //        {
        //            throw new Exception(F.Message);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(F.Message);
        //    }
        //}
        //#endregion

        //#region "CRUD Fichario SQL SERVER Relacional"

        //public void IncludeSQL()
        //{
        //    try
        //    {
        //        string SQL = this.ToInsert();
        //        var db = new SQLServerClass();
        //        db.SQLCommand(SQL);
        //        db.CloseConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Inclusão não permitida. {ex.Message}");
        //    }
        //}

        //public Unit SearchSQL(string Id)
        //{
        //    try
        //    {
        //        string SQL = $"SELECT * FROM [TB_Cliente] WHERE Id = '{Id}'";
        //        var db = new SQLServerClass();
        //        var dt = db.SQLQuery(SQL);
        //        if (dt.Rows.Count == 0)
        //        {
        //            db.CloseConnection();
        //            throw new Exception($"Id não existe, conexão fechada.");
        //        }
        //        else
        //        {
        //            Unit unit = this.DataRowToUnit(dt.Rows[0]);
        //            return unit;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao buscar o conteúdo do Id {Id} || {ex.Message}");
        //    }
        //}

        //public List<List<string>> SearchAllSQL()
        //{
        //    List<List<string>> listaBusca = new List<List<string>>();
        //    try
        //    {
        //        var SQL = $"SELECT * FROM TB_Cliente";
        //        var db = new SQLServerClass();
        //        var dt = db.SQLQuery(SQL);

        //        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //        {
        //            listaBusca.Add(new List<string> { dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Nome"].ToString() });
        //        }
        //        return listaBusca;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Conexão com banco de dados falhou! {ex.Message}");
        //    }
        //}

        //public void ChangeSQL()
        //{
        //    try
        //    {
        //        var SQL = $@"SELECT * FROM [TB_Cliente] WHERE Id = '{Id}'";
        //        var db = new SQLServerClass();
        //        var dt = db.SQLQuery(SQL);

        //        if (dt.Rows.Count == 0)
        //        {
        //            db.CloseConnection();
        //            throw new Exception($"Não foi possível buscar o id {Id}");
        //        }
        //        else
        //        {
        //            SQL = this.ToUpdade(this.Id);
        //            db.SQLCommand(SQL);
        //            db.CloseConnection();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($"Erro ao alterar os dados. {ex.Message}");
        //    }
        //}

        //public void DeleteSQL()
        //{
        //    try
        //    {
        //        var SQL = $@"SELECT * FROM [TB_Cliente] WHERE Id = '{this.Id}'";
        //        var db = new SQLServerClass();
        //        var dt = db.SQLQuery(SQL);
        //        if (dt.Rows.Count == 0)
        //        {
        //            db.CloseConnection();
        //            throw new Exception($"Não foi possível buscar o id {this.Id}");
        //        }
        //        else
        //        {
        //            SQL = $"DELETE * FROM [TB_Cliente] WHERE Id = '{this.Id}'";
        //            db.SQLCommand(SQL);
        //            db.CloseConnection();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($"Erro ao buscar o conteúdo do Id {this.Id} || {ex.Message}");
        //    }
        //}
        //#region "Funções Axiliares"

        //public string ToInsert()
        //{

        //    string SQL;
        //    SQL =
        //        $@"INSERT INTO TO TB_Products
        //        (Id,
        //        Name,
        //        AvaliableQuantity.
        //        Price)                   
        //        VALUES";
        //    SQL += $@"'{this.Id}'";

        //        ;
        //    return SQL;
        //}

        //public string ToUpdade(string id)
        //{
        //    var SQL = "";
        //    return SQL;
        //}

        //public Unit DataRowToUnit(DataRow dr)
        //{
        //    return Unit;
        //}

        //#endregion
        //#endregion


        public static Customer DesSerializerUnit(string vJson)
        {
            return JsonConvert.DeserializeObject<Customer>(vJson);
        }

        public static string SerializerUnit(Customer unit)
        {
            return JsonConvert.SerializeObject(unit);
        }
    }



}

