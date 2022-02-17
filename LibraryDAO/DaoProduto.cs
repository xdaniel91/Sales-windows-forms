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
    public class DaoProduto : DaoBase, IDaoEntities
    {
        static Database postgre = new Database();
        public void Delete(uint id)
        {
            
            postgre.connection = new NpgsqlConnection(postgre.connectString);
            postgre.connection.Open();
            postgre.sql = $@"select * from produtos_delete({id});";
            postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
            bool result = (bool)postgre.sqlCommand.ExecuteScalar();
            postgre.connection.Close();
            if (!result) throw new Exception("Delete: false");
        }
        public void AtualizarGrid(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.DataSource = postgre.dt;
        }

        public void Insert(dynamic produto)
        {
            var preco = produto.Preco.ToString().Replace(',', '.');

            postgre.connection = new NpgsqlConnection(postgre.connectString);
            postgre.connection.Open();
            postgre.sql = $"select * from produtos_insert('{produto.Nome}', {preco}, {produto.QuantidadeDisponivel})";
            postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
            bool result = (bool)postgre.sqlCommand.ExecuteScalar();
            postgre.connection.Close();
            if (!result) throw new Exception("Insert: false");
        }

        public void Select()
        {
            postgre.connection = new NpgsqlConnection(postgre.connectString);
            postgre.connection.Open();
            postgre.sql = @"select * from produtos_select()";
            postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
            postgre.dt = new DataTable();
            postgre.dt.Load(postgre.sqlCommand.ExecuteReader());
            postgre.connection.Close();
        }

        public void Update(object[] infos, uint id)
        {
            try
            {
                var nome = infos[0] as string;
                var preco = infos[1] as string;
                var quantidade = infos[2] as int?;

                postgre.connection = new NpgsqlConnection(postgre.connectString);
                postgre.connection.Open();
                postgre.sql = $@"select * from produtos_update({id}, '{nome}', {preco}, {quantidade});";
                postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
                bool result = (bool)postgre.sqlCommand.ExecuteScalar();
                postgre.connection.Close();
                if (!result) throw new Exception("Não foi possível inserir o cliente! by: DaoCustomer");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
