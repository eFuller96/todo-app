using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Serilog;
using todo_app.Store;

namespace todo_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly Dictionary<string, Item> _items;

        public ItemController(ItemStore itemStore, ILogger logger)
        {
            _logger = logger;
            _items = itemStore.GetStartingItems();
        }


        [HttpGet]
        public Dictionary<string, Item> GetAll()
        {
            return _items;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Item item)
        {
            _items.Add(Guid.NewGuid().ToString(), item);
            return new JsonResult(_items);
        }

        [HttpPut]
        public IActionResult Update([FromBody] IDictionary<string, Item> updatedItemList)
        {
            var (key, value) = updatedItemList.First();
            _items[key] = value;
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
