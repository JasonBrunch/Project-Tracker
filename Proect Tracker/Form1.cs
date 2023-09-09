namespace Proect_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Create a box for each categoy in CategoryPnlHldr.
        //Make these boxes match the height of the container and stretch so they are all equal size in the container arranged left to right.


        //Get number of steps in category
        //create a panel for each one in the taskPnl

        //the taskPnl should arrange them in a grid with 3x3 dimensions
        //the panels should know to autosize to fill these grid spaces in the taskPnl



    }

    public enum TaskStatus { NotStarted, InProgress, Completed }

    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Task> Tasks { get; set; }
        // ... some summary stats
    }

    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EstimatedTime { get; set; } // in minutes
        public int ActualTimeSpent { get; set; } // in minutes
        public TaskStatus Status { get; set; }
        // ... other stats
    }
}

