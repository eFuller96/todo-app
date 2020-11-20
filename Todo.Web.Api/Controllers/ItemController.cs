using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using todo_app.Store;

namespace todo_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemStore _itemStore;

        public ItemController(IItemStore itemStore, ILogger logger)
        {
            _itemStore = itemStore;
            _logger = logger;
        }

        [HttpGet]
        public IDictionary<string, Item> GetAll()
        {
            return _itemStore.GetItems();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Item item)
        {
            var newId = Guid.NewGuid().ToString();
            item.Id = newId;
            _itemStore.AddItem(item);
            return new JsonResult(_itemStore.GetItems());
        }

        [HttpPut]
        public IActionResult Update([FromBody] Item updatedItem)
        {
            _items[updatedItem.Id] = updatedItem;
            return new JsonResult(_items);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]string itemToDeleteKey)
        {
            _items.Remove(itemToDeleteKey);
            return new JsonResult(_items);
        }
    }
}
