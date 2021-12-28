using Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Base_de_dados
{
    public class FicharyDB
    {
        public bool Status;
        public string Message;
        public string Tabela;
        public LocalDB db;
        public FicharyDB(string tabela)
        {
            Status = true;
            try
            {
                Tabela = tabela;
                db = new LocalDB();
                Message = "Conexão com tabela criada!";
            }
            catch (Exception ex)
            {
                Status = false;
                Message = $"Conexão com tabela falhou! - {ex.Message}";
            }



        }

        public string BuscarDB(string id)
        {
            try
            {
                var SQL = $"SELECT Id, JSON FROM {Tabela} WHERE ID = '{id}'";
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count <= 0)
                {
                    Status = false;
                    throw new Exception("Query retornou vazia");
                }
                else
                {
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    Status = true;
                    Message = "Busca realizada";
                    return conteudo;
                }
            }
            catch (Exception ex)
            {
                Status = false;
                return Message = $"Falha! {ex.Message}";
            }
        }


        public List<string> BuscarTodos()
        {
            Status = true;
            List<string> List = new List<string>();
            try
            {
                // SELECT ID, JSON FROM CLIENTE'

                var SQL = "SELECT Id, JSON FROM " + Tabela;
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["JSON"].ToString();
                        List.Add(conteudo);
                    }
                    return List;
                }
                else
                {
                    Status = false;
                    Message = "Não existem clientes na base de dados";
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Message = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return List;
        }

        public void IncluirDB(string id, string jsonUnit)
        {
            Status = true;
            try
            {
                var SQL = "INSERT INTO " + Tabela + " (Id, JSON) VALUES ('" + id + "', '" + jsonUnit + "')";
                db.SQLCommand(SQL);
                Status = true;
                Message = "Inclusão feita";
            }
            catch (Exception ex)
            {
                Status = false;
                Message = $"Erro. {ex.Message}";
            }
        }

        public List<List<string>> BuscarFicharioDBTodosDB(string conexao)
        {
            FicharyDB F = new FicharyDB(conexao);
            if (F.Status)
            {
                List<string> List = new List<string>();
                List = F.BuscarTodos();
                if (F.Status)
                {
                    List<List<string>> ListaBusca = new List<List<string>>();
                    for (int i = 0; i <= List.Count - 1; i++)
                    {
                        User.Unit C = User.DesSerializerUnit(List[i]);
                        ListaBusca.Add(new List<string> { C.Codigo, C.Nome });
                    }
                    return ListaBusca;
                }
                else
                {
                    throw new Exception(F.Message);
                }
            }
            else
            {
                throw new Exception(F.Message);
            }
        }

        public void ApagarDB(string id)
        {
            Status = true;
            try
            {
                var SQL = $"SELECT Id, JSON FROM {Tabela} WHERE ID = '{id}'";
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    SQL = $"DELETE FROM {Tabela} WHERE ID = '{id}'";
                    db.SQLCommand(SQL);
                    Status = true;
                    Message = "Deletado";
                }
                else
                {
                    Status = false;
                    Message = "Falha em deletar";
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Message = $"erro ao bucar o id. {ex.Message}";
            }

        }

        public void AlterarDB(string id, string jsonUnit)
        {
            Status = true;
            try
            {
                var SQL = $"SELECT Id, JSON FROM {Tabela} WHERE ID = '{id}'"; // faz a consulta pra ver se o id existe no db
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    SQL = $"UPDATE {Tabela} SET JSON = '{jsonUnit}' WHERE ID = '{id}'"; // se existir ele executa o update
                    Status = true;
                    Message = "Update feito com sucesso!";
                }
                else
                {
                    Status = false;
                    Message = "Id não foi encontrado";
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Message = $"Erro ao buscar o id {ex.Message}";
            }

        }
    }
}

