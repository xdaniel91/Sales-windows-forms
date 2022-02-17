using Library.BaseDados;
using Library.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDAO
{
    public class DaoBase
    {
         Database postgre = new Database();
        //void Select(string sql)
        //{
        //    postgre.connection = new NpgsqlConnection(postgre.connectString);
        //    postgre.connection.Open();
        //    postgre.sql = sql;
        //    postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
        //    postgre.dt = new DataTable();
        //    postgre.dt.Load(postgre.sqlCommand.ExecuteReader());
        //    postgre.connection.Close();
        //}

        //public void AtualizarGrid(DataGridView dgv)
        //{
        //    dgv.DataSource = null;
        //    dgv.DataSource = postgre.dt;
        //}


    }

    interface IDaoEntities
    {

        void Insert(object p);
        void Select();
        void Delete(uint id);
        void Update(object[] infos, uint id);
    }
}
