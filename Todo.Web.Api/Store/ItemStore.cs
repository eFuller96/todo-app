using System;
using System.Collections.Generic;

namespace todo_app.Store
{
    public class ItemStore
    {
        private IDictionary<string, Item> Items { get; }
        public IDictionary<string, Item> GetItems()
        {
            return Items;
        }

        public ItemStore()
        {
            Items = PopulateItems();
        }

        private static IDictionary<string, Item> PopulateItems()
        {
            return new Dictionary<string, Item>()
            {
                [Guid.NewGuid().ToString()] = new Item() { Name = "Pay rent"},
                [Guid.NewGuid().ToString()] = new Item() { Name = "Food shopping"},
                [Guid.NewGuid().ToString()] = new Item()
                {
                    Name = "Wash car",
                    CompletedTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm"),
                    TaskDone = true
                }
            };
        }
    }
}
