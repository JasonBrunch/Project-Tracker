using System.Diagnostics;

namespace Proect_Tracker
{
    public partial class Form1 : Form
    {
        private readonly Color colorBackground = Color.FromArgb(240, 240, 240);
        private readonly Color colorButtonNotCompleted = Color.FromArgb(255, 102, 102);
        private readonly Color colorButtonCompleted = Color.FromArgb(102, 255, 102);
        private readonly Color colorButtonSelected = Color.FromArgb(255, 255, 102);

        Task currentSelectedTask = null;
        private int tickCounter = 0;
        System.Windows.Forms.Timer timer1;


        public Form1()
        {
            InitializeComponent();
            ProjectData projectData = new ProjectData();
            projectData.InitializeProjectData();

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(this.timer1_Tick);  // Attach the tick event
            timer1.Interval = 1000; // Fires every 1 second (1000 ms)


            CreateCategories(projectData.categories);
            SetUpProject(projectData);
        }
        private void SetUpProject(ProjectData projectData)
        {
            totalHrsLbl.Text = "Estimated Hours: " + GetTotalHours(projectData.categories).ToString();
        }
        private float GetTotalHours(List<Category> categories)
        {
            int totalHours = 0;
            foreach (Category category in categories)
            {
                int totalCategoryMinutes = 0;
                for (int i = 0; i < category.Tasks.Count; i++)
                {
                    int TaskMinutes = category.Tasks[i].EstimatedTime;
                    totalCategoryMinutes += TaskMinutes;
                }
                totalHours += totalCategoryMinutes;
            }

            return totalHours / 60;


        }
        private void CreateCategories(List<Category> categories)
        {
            int totalWidth = CategoryPnlHldr.Width;
            int panelWidth = totalWidth / categories.Count;
            int remainingWidth = totalWidth - (panelWidth * categories.Count);

            foreach (Category category in categories)
            {
                int thisPanelWidth = panelWidth;
                // Subtract pixels to make it fit
                thisPanelWidth -= 7;
                if (remainingWidth > 0)
                {
                    thisPanelWidth++;
                    remainingWidth--;
                }

                // Create Panel
                Panel panel = new Panel
                {
                    Width = thisPanelWidth,
                    Height = CategoryPnlHldr.Height - 7,
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                    Tag = category  // Save category object in panel's Tag for later retrieval
                };

                // Set the color right here
                SetPanelColor(panel, category.Status, category.isSelected);

                panel.Click += new EventHandler(CategoryPanel_Click);  // Attach Click event

                // Create Label
                Label label = new Label
                {
                    Text = category.Name,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    AutoSize = false
                };

                label.Click += new EventHandler(CategoryPanel_Click);  // Attach Click event to the label too


                // Add Label to Panel
                panel.Controls.Add(label);

                // Add Panel to FlowLayoutPanel
                CategoryPnlHldr.Controls.Add(panel);
            }
        }
        private void CategoryPanel_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Click");

            Category clickedCategory = null;

            // Step 1: Reset isSelected for all categories
            foreach (Control control in CategoryPnlHldr.Controls)
            {
                if (control is Panel panel && panel.Tag is Category category)
                {
                    category.isSelected = false;
                }
            }

            // Find the clicked category and set isSelected = true
            if (sender is Panel clickedPanel)
            {
                clickedCategory = clickedPanel.Tag as Category;
            }
            else if (sender is Label clickedLabel && clickedLabel.Parent is Panel parentPanel)
            {
                clickedCategory = parentPanel.Tag as Category;
            }

            // Step 2: Update isSelected for the clicked category
            if (clickedCategory != null)
            {
                clickedCategory.isSelected = true;
                Debug.WriteLine("Creating Task List");
                CreateTaskList(clickedCategory);
            }

            // Step 3: Refresh colors for all panels
            foreach (Control control in CategoryPnlHldr.Controls)
            {
                if (control is Panel panel && panel.Tag is Category category)
                {
                    SetPanelColor(panel, category.Status, category.isSelected);
                }
            }
        }
        private void CreateTaskList(Category category)
        {
            // Clear and dispose of all existing panels
            ClearAndDisposePanels(tasksPnl);
            tasksPnl.Controls.Clear();
            int totalWidth = tasksPnl.Width;
            int panelWidth = totalWidth / 3;  // Fixed width for 3-column layout
            int panelHeight = 100;  // Fixed height for simplicity, adjust as needed

            // Set FlowLayoutPanel properties for task panel
            tasksPnl.FlowDirection = FlowDirection.LeftToRight;
            tasksPnl.WrapContents = true;

            foreach (Task task in category.Tasks)
            {
                // Create Panel
                Panel panel = new Panel
                {
                    Width = panelWidth,
                    Height = panelHeight,
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle

                };

                // Create Label
                Label label = new Label
                {
                    Text = task.Name,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    AutoSize = false
                };
                label.Click += new EventHandler(TaskPanel_Click);
                // Set Panel color and tag
                panel.Tag = task; // Save task object in panel's Tag for later retrieval
                SetPanelColor(panel, task.Status, task.isSelected);
                panel.Click += new EventHandler(TaskPanel_Click); // Attach click event

                // Add Label to Panel
                panel.Controls.Add(label);

                // Add Panel to FlowLayoutPanel
                tasksPnl.Controls.Add(panel);
            }
        }
        private void SetPanelColor(Panel panel, TaskStatus status, bool isSelected)
        {
            if (isSelected)
            {
                panel.BackColor = colorButtonSelected;
                return;
            }

            switch (status)
            {
                case TaskStatus.NotStarted:
                    panel.BackColor = colorButtonNotCompleted;
                    break;
                case TaskStatus.Completed:
                    panel.BackColor = colorButtonCompleted;
                    break;
                case TaskStatus.InProgress:
                    // Add color here if you want
                    break;
            }
        }
        private void ClearAndDisposePanels(FlowLayoutPanel panelHolder)
        {
            foreach (Control control in panelHolder.Controls)
            {
                if (control is Panel panel)
                {
                    // Unsubscribe from events if any
                    panel.Click -= CategoryPanel_Click;  // Example
                    panel.Dispose();
                }
            }
            panelHolder.Controls.Clear();
        }
        private void TaskPanel_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Task Clicked");

            Task clickedTask = null;

            // Step 1: Reset isSelected for all tasks
            foreach (Control control in tasksPnl.Controls)
            {
                if (control is Panel panel && panel.Tag is Task task)
                {
                    task.isSelected = false;
                }
            }

            // Find the clicked task and set isSelected = true
            if (sender is Panel clickedPanel)
            {
                clickedTask = clickedPanel.Tag as Task;
            }
            else if (sender is Label clickedLabel && clickedLabel.Parent is Panel parentPanel)
            {
                clickedTask = parentPanel.Tag as Task;
            }

            // Step 2: Update isSelected for the clicked task
            if (clickedTask != null)
            {
                clickedTask.isSelected = true;
                currentSelectedTask = clickedTask;
                UpdateTaskWindow(currentSelectedTask);
            }

            // Step 3: Refresh colors for all panels
            foreach (Control control in tasksPnl.Controls)
            {
                if (control is Panel panel && panel.Tag is Task task)
                {
                    SetPanelColor(panel, task.Status, task.isSelected);
                }
            }
        }
        private void UpdateTaskWindow(Task currentTask)
        {

            taskNameLbl.Text = currentTask.Name;

            timeSpntLbl.Text = $"{currentTask.ActualTimeSpent}.{tickCounter}";
        }

        private void startTimerBtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Timer Btn Clicked");
            timer1.Start();
            //update actual timespent with each tick?
        }

        private void stopTimerBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void resetTimerBtn_Click(object sender, EventArgs e)
        {
            if (currentSelectedTask != null)
            {
                currentSelectedTask.ActualTimeSpent = 0;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("TICK");
            tickCounter++;

            if (tickCounter >= 60) // 60 seconds in a minute
            {
                if (currentSelectedTask != null)
                {
                    currentSelectedTask.ActualTimeSpent += 1; // Increment by 1 minute
                }

                tickCounter = 0; // Reset the counter
            }

            if (currentSelectedTask != null)
            {
                UpdateTaskWindow(currentSelectedTask);
            }
        }
    }

    public enum TaskStatus { NotStarted, InProgress, Completed }

    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Task> Tasks { get; set; }
        public TaskStatus Status { get; set; }
        public bool isSelected;

    }

    public class Task
    {
        public string Name { get; set; }
        public int EstimatedTime { get; set; } // in minutes
        public int ActualTimeSpent { get; set; } // in minutes
        public TaskStatus Status { get; set; }
        public bool isSelected;
    }
}

