using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace todo_app.Controllers
{
    [ApiController]
    [Route("[items]")]
    public class ItemController : ControllerBase
    {
        private readonly Item[] _items =
        {
            new Item() {Name = "Pay rent"},
            new Item() {Name = "Food shopping"},
            new Item() {Name = "Wash car", CompletedTime = DateTime.Now, TaskDone = true}
        };

        [HttpGet]
        public IEnumerable<Item> GetAll()
        {
            return _items;
        }
    }
}
