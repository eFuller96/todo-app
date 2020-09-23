using System;
using System.Collections.Generic;

namespace todo_app.Store
{
    public class ItemStore
    {
        public List<Item> GetStartingItems()
        {
            return new List<Item>()
            {
                new Item() {Id = Guid.NewGuid(), Name = "Pay rent"},
                new Item() {Id = Guid.NewGuid(), Name = "Food shopping"},
                new Item()
                {
                    Id = Guid.NewGuid(), Name = "Wash car", CompletedTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm"),
                    TaskDone = true
                }
            };
        }

        public ItemStore()
        {

        }
    }

}
