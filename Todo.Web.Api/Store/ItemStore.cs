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
    }
}
