using MinhaAgenda.Models;
using MinhaAgenda.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMinhaAgenda.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Agenda>().Wait();
        }

        public Task<List<Agenda>> GetAll()
        {
            return _conn.Table<Agenda>().ToListAsync();
        }

        public Task<int> Insert(Agenda a)
        {
            return _conn.InsertAsync(a);
        }

        public Task<List<Agenda>>Update(Agenda a)
        {
            string sql = "UPDATE Agenda set Horario = ?, Cliente = ?, Preco = ?, Endereco = ? Where Id = ?";

            return _conn.QueryAsync<Agenda>(sql, a.Horario, a.Cliente, a.Preco, a.Endereco, a.Id);
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Agenda>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Agenda>> Search(string q)
        {
            string sql = "SELECT * FROM Agenda Where Cliente LIKE '%" + q + "%' ";

            return _conn.QueryAsync<Agenda>(sql);
        }

    }

}
