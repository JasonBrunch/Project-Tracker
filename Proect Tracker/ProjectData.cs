using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proect_Tracker
{
    [Serializable]
    public class ProjectData
    {
        public List<Category> categories = new List<Category>();

        public void InitializeProjectData()
        {
            // Planning Category
            var planningTasks = new List<Task>
        {
                new Task { Name = "Choose Product - Gather References", EstimatedTime = 60, Status = TaskStatus.NotStarted },
            new Task { Name = "Requirement Analysis", EstimatedTime = 90, Status = TaskStatus.NotStarted },
            new Task { Name = "Wireframing", EstimatedTime = 120, Status = TaskStatus.NotStarted },
            new Task { Name = "Tech Stack", EstimatedTime = 30, Status = TaskStatus.NotStarted }
        };
            categories.Add(new Category { Name = "Planning", Tasks = planningTasks, Status = TaskStatus.NotStarted });

            // Setup Category
            var setupTasks = new List<Task>
        {
            new Task { Name = "Initialize Project", EstimatedTime = 30, Status = TaskStatus.NotStarted },
            new Task { Name = "Folder Structure", EstimatedTime = 30, Status = TaskStatus.NotStarted },
            new Task { Name = "Git Setup", EstimatedTime = 30, Status = TaskStatus.NotStarted }
        };
            categories.Add(new Category { Name = "Setup", Tasks = setupTasks, Status = TaskStatus.NotStarted });

            // Development Category
            // Back-end Subcategory
            var backendTasks = new List<Task>
            {
                new Task { Name = "Database Setup", EstimatedTime = 90, Status = TaskStatus.NotStarted },
                new Task { Name = "Create Models", EstimatedTime = 60, Status = TaskStatus.NotStarted },
                new Task { Name = "Endpoints", EstimatedTime = 180, Status = TaskStatus.NotStarted },
                new Task { Name = "User Authentication", EstimatedTime = 120, Status = TaskStatus.NotStarted },
                new Task { Name = "Unit Tests", EstimatedTime = 90, Status = TaskStatus.NotStarted },
                new Task { Name = "API Documentation", EstimatedTime = 60, Status = TaskStatus.NotStarted }
            };
            categories.Add(new Category { Name = "Back-end", Tasks = backendTasks, Status = TaskStatus.NotStarted });

            // Front-end Subcategory
            var frontendTasks = new List<Task>
            {
                new Task { Name = "Initialize React App", EstimatedTime = 30, Status = TaskStatus.NotStarted },
                new Task { Name = "Folder Structure", EstimatedTime = 30, Status = TaskStatus.NotStarted },
                // ... Add other Front-end tasks here
            };
            categories.Add(new Category { Name = "Front-end", Tasks = frontendTasks, Status = TaskStatus.NotStarted });

            // Styling Category
            var stylingTasks = new List<Task>
            {
                new Task { Name = "Bootstrap", EstimatedTime = 60, Status = TaskStatus.NotStarted },
                new Task { Name = "CSS", EstimatedTime = 90, Status = TaskStatus.NotStarted }
            };
            categories.Add(new Category { Name = "Styling", Tasks = stylingTasks, Status = TaskStatus.NotStarted });

       
            // Testing Category
            var testingTasks = new List<Task>
            {
                new Task { Name = "UI Tests", EstimatedTime = 60, Status = TaskStatus.NotStarted },
                new Task { Name = "Debug", EstimatedTime = 60, Status = TaskStatus.NotStarted }
            };
            categories.Add(new Category { Name = "Testing", Tasks = testingTasks, Status = TaskStatus.NotStarted });

            // Deployment Category
            var deploymentTasks = new List<Task>
            {
                new Task { Name = "Build", EstimatedTime = 60, Status = TaskStatus.NotStarted },
                new Task { Name = "Hosting", EstimatedTime = 60, Status = TaskStatus.NotStarted },
                new Task { Name = "Custom Domain", EstimatedTime = 30, Status = TaskStatus.NotStarted }
            };
            categories.Add(new Category { Name = "Deployment", Tasks = deploymentTasks, Status = TaskStatus.NotStarted });

            // Post-launch Category
            var postLaunchTasks = new List<Task>
            {
                new Task { Name = "SEO", EstimatedTime = 60, Status = TaskStatus.NotStarted },
                new Task { Name = "Analytics", EstimatedTime = 30, Status = TaskStatus.NotStarted }
            };
            categories.Add(new Category { Name = "Post-launch", Tasks = postLaunchTasks, Status = TaskStatus.NotStarted });
        }
    }
}



