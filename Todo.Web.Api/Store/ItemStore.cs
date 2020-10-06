using System;
using System.Collections.Generic;

namespace todo_app.Store
{
    public class ItemStore
    {
        public Dictionary<Guid, Item> GetStartingItems()
        {
            return new Dictionary<Guid, Item>()
            {
                [Guid.NewGuid()] = new Item() { Name = "Pay rent"},
                [Guid.NewGuid()] = new Item() { Name = "Food shopping"},
                [Guid.NewGuid()] = new Item()
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
