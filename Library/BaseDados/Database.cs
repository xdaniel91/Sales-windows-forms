using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Npgsql;

namespace Library.BaseDados
{
    public class Database
    {
       public string connectString = String.Format("User ID=postgres;" +
       "Password=adm;" +
       "Host=localhost;" +
       "Port=5432;" +
       "Database=SystemOrder;" +
       "Connection Lifetime=0;");

        public NpgsqlConnection connection;
        public string sql;
        public NpgsqlCommand sqlCommand;
        public DataTable dt;
        public Database()
        {

        }
    }
}
