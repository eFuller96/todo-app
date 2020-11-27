using System.Collections.Generic;

namespace todo_app.Store
{
    public interface IItemStore
    {
        IDictionary<string, Item> GetItems();
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(string id);
    }
}
