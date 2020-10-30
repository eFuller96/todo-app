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
        private readonly IDictionary<string, Item> _items;

        public ItemController(IItemStore itemStore, ILogger logger)
        {
            _logger = logger;
            _items = itemStore.GetItems();
        }

        [HttpGet]
        public IDictionary<string, Item> GetAll()
        {
            return _items;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Item item)
        {
            var newId = Guid.NewGuid().ToString();
            item.Id = newId;
            _items.Add(newId, item);
            return new JsonResult(_items);
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
