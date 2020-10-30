using System.Collections.Generic;

namespace todo_app.Store
{
    public interface IItemStore
    {
        IDictionary<string, Item> GetItems();
    }
}
