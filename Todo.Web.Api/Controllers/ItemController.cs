using System;
using System.Collections.Generic;
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
        private readonly Dictionary<Guid, Item> _items;

        public ItemController(ItemStore itemStore, ILogger logger)
        {
            _logger = logger;
            _items = itemStore.GetStartingItems();
        }


        [HttpGet]
        public Dictionary<Guid, Item> GetAll()
        {
            return _items;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Item item)
        {
            _items.Add(Guid.NewGuid(), item);
            return new JsonResult(_items);
        }

        [HttpPut]
        public IActionResult Update([FromBody] KeyValuePair<Guid, Item> updatedItem)
        {
            _items[updatedItem.Key] = updatedItem.Value;
            return new JsonResult(_items);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] KeyValuePair<Guid, Item> itemToDelete)
        {
            _items.Remove(itemToDelete.Key);
            return new JsonResult(_items);
        }
    }
}
