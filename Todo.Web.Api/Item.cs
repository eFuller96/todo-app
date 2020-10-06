using System;
using System.ComponentModel.DataAnnotations;

namespace todo_app
{
    public class Item
    {
        public string Name { get; set; }

        public string CompletedTime { get; set; } = null;

        public bool TaskDone { get; set; } = false;
    }
}
