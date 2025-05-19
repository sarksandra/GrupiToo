using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Mihkel
{
    public class TodoItem
    {
        public string Description { get; }
        public bool IsCompleted { get; set; }

        public TodoItem(string description)
        {
            Description = description;
            IsCompleted = false;
        }
    }
}
