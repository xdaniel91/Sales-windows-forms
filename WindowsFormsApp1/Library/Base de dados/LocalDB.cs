using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Base_de_dados
{
    public class LocalDB
    {
        public string connectionString;
        public SqlConnection connectSql;

        public LocalDB()
        {
            try
            {
                connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database\\Fichario.mdf;Integrated Security=True";
                connectSql = new SqlConnection(connectionString);
                connectSql.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // metodo de consulta que retorna dados.
        public DataTable SQLQuery(string SQL)
        {
            var dt = new DataTable();
            try
            {
                var myCommand = new SqlCommand(SQL, connectSql);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();

                dt.Load(myReader);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return dt;
        }

        // método de comandos que retorna uma mensagem.
        public string SQLCommand(string SQL)
        {
            try
            {
                var myCommand = new SqlCommand(SQL, connectSql);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();

                return "";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // método para fechar a conexão
        public void CloseConnection()
        {
            connectSql.Close();
        }
    }
}


