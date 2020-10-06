using System;
using System.Collections.Generic;

namespace todo_app.Store
{
    public class ItemStore
    {
        public Dictionary<string, Item> GetStartingItems()
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

        public ItemStore()
        {

        }
    }

}
