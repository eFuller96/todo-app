using System;
using System.Collections.Generic;

namespace todo_app.Store
{
    public class ItemStore
    {
        private static Dictionary<string, Item> Items { get; set; }
        public Dictionary<string, Item> GetStartingItems()
        {
            return Items;
        }

        public static void PopulateItems()
        {
            Items = new Dictionary<string, Item>()
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
