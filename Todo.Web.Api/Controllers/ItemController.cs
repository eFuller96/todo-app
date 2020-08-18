using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace todo_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly List<Item> _items = new List<Item>()
        {
            new Item() {Name = "Pay rent"},
            new Item() {Name = "Food shopping"},
            new Item() {Name = "Wash car", CompletedTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm"), TaskDone = true}
        };

        [HttpGet]
        public IEnumerable<Item> GetAll()
        {
            return _items;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            _items.Add(item);
            return new JsonResult(_items);
        }
    }
}
