using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TaskKeep.Model
{
    public class Todo
    {
        public int Id {get; set;}
        
        public string TaskName { get; set; }

        public bool IsComplete { get; set; }
        
        
        [JsonConstructor]
        public Todo(int id, string taskName, bool isComplete)
        {
            Id = id;
            TaskName = taskName;
            IsComplete=isComplete;
        }

    }
}