using System;

namespace todo_app
{
    public class Item
    {
        public string Name { get; set; }

        public DateTime? CompletedTime { get; set; } = null;

        public bool TaskDone { get; set; } = false;
    }
}
