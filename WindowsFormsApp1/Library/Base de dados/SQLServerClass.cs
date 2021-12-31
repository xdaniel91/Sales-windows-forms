using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Configuration.Assemblies;



namespace Library.Base_de_dados
{
    public class SQLServerClass
    {
        public string stringConnection;
        public SqlConnection connectSql;


        public SQLServerClass()
        {
            try
            {
                // stringConnection = "Data Source=DESKTOP-FQCOUVC;Initial Catalog=ByteBank;Persist Security Info=True;User ID=sa;Password=adm";
                stringConnection = ConfigurationManager.ConnectionStrings["Fichario"].ConnectionString;
                connectSql = new SqlConnection(stringConnection);
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

