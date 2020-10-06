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
        public IActionResult Update([FromBody] Item updatedItem)
        {
            var indexOfItemToUpdate = _items.FindIndex(i => i.Id == updatedItem.Id);
            if (indexOfItemToUpdate >= 0)
            {
                _items[indexOfItemToUpdate] = updatedItem;
            }
            return new JsonResult(_items);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Item itemToDelete)
        {
            _items.Remove(itemToDelete);
            return new JsonResult(_items);
        }
    }
}
