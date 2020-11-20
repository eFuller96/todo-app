using System;
using System.Collections.Generic;

namespace todo_app.Store
{
    public class ItemStore : IItemStore
    {
        private IDictionary<string, Item> Items { get; }
        public IDictionary<string, Item> GetItems()
        {
            return Items;
        }

        private readonly string _dbConnectionString;

        public ItemStore(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        private static IDictionary<string, Item> PopulateItems()
        {
            var key1 = Guid.NewGuid().ToString();
            var key2 = Guid.NewGuid().ToString();
            var key3 = Guid.NewGuid().ToString();
            
            return new Dictionary<string, Item>()
            {
                [key1] = new Item() { Id = key1, Name = "Pay rent"},
                [key2] = new Item() { Id = key2, Name = "Food shopping"},
                [key3] = new Item()
                {
                    Id = key3,
                    Name = "Wash car",
                    CompletedTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm"),
                    TaskDone = true
                }
            };
        }
    }
}
