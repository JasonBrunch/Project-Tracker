using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proect_Tracker
{
    [Serializable]
    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Task> Tasks { get; set; }
        public TaskStatus Status { get; set; }
        public bool isSelected;

    }
    [Serializable]
    public class Task
    {
        public string Name { get; set; }
        public int EstimatedTime { get; set; } // in minutes
        public int ActualTimeSpent { get; set; } // in minutes
        public TaskStatus Status { get; set; }
        public bool isSelected;
    }
}
