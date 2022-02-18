using Library.BaseDados;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using Library.Entities;

namespace LibraryDAO
{
    public class DaoOrderItem : DaoBase, IDaoEntities
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

        void RemoveQuantidadeProdutoDataBase(object obj)
        {
            var item = obj as ItemDataBase;
            postgre.connection = new NpgsqlConnection(postgre.connectString);
            postgre.connection.Open();
            postgre.sql = $@"select * from fc_remove_quantidade({item.Quantidade}::INTEGER, {item.ProdutoId}::INTEGER)";
            postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
            postgre.sqlCommand.ExecuteScalar();
            postgre.connection.Close();
        }

        public void Insert(object obj)
        {
            var item = obj as ItemDataBase;
            postgre.connection = new NpgsqlConnection(postgre.connectString);
            postgre.connection.Open();
            postgre.sql = $"insert into compra_item(oi_quantidade, oi_valortotal, oi_datahora, oi_produtoid, oi_clienteid) values ({item.Quantidade}, {item.ValorTotal.ToString().Replace(',', '.')}, now(), {item.ProdutoId}, {item.ClienteId})";
            postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
            postgre.sqlCommand.ExecuteScalar();
            postgre.connection.Close();
            RemoveQuantidadeProdutoDataBase(item);
        }

        public void InsertItem(ItemDataBase item)
        {
            postgre.connection = new NpgsqlConnection(postgre.connectString);
            postgre.connection.Open();
            postgre.sql = $"insert into compra_item(oi_quantidade, oi_valortotal, oi_datahora, oi_produtoid, oi_clienteid) values ({item.Quantidade}, {item.ValorTotal}, now(), {item.ProdutoId}, {item.ClienteId})";
            postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
            postgre.connection.Close();
        }

        public void Select()
        {
            postgre.connection = new NpgsqlConnection(postgre.connectString);
            postgre.connection.Open();
            postgre.sql = @"select pd_id as id, pd_nome as produto, pd_preco as preço, pd_quantidade as ""quantidade disponivel"" from produtos order by(1);";
            postgre.sqlCommand = new NpgsqlCommand(postgre.sql, postgre.connection);
            postgre.dt = new DataTable();
            postgre.dt.Load(postgre.sqlCommand.ExecuteReader());
            postgre.connection.Close();
        }

        public void Update(object[] infos, uint id)
        {
        }

    }
}
