using System.Collections.Generic;
using System.Linq;
using Dapper;
using Npgsql;

namespace todo_app.Store
{
    public class ItemStore : IItemStore
    {
        private readonly string _dbConnectionString;

        public ItemStore(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public IDictionary<string, Item> GetItems()
        {
            using (var conn = new NpgsqlConnection(_dbConnectionString))
            {
                var items = conn.Query<Item>("SELECT * FROM items;");
                return items.ToDictionary(item => item.Id.ToString(), item => item);
            }
        }

        public void AddItem(Item item)
        {
            using (var conn = new NpgsqlConnection(_dbConnectionString))
            {
                conn.Execute("INSERT INTO items (id, name) VALUES (@id, @name);", new
                {
                    item.Id,
                    item.Name
                });
            }
        }

        public void UpdateItem(Item item)
        {
            using (var conn = new NpgsqlConnection(_dbConnectionString))
            {
                conn.Execute("UPDATE items SET taskDone = @taskDone, completedTime = @completedTime WHERE id = @id", new
                {
                    taskDone = item.TaskDone,
                    completedTime = item.CompletedTime,
                    id = item.Id
                });
            }
        }

        public void DeleteItem(string id)
        {
            using (var conn = new NpgsqlConnection(_dbConnectionString))
            {
                conn.Execute("DELETE FROM items WHERE id = @id", new
                {
                    id
                });
            }
        }
    }
}
