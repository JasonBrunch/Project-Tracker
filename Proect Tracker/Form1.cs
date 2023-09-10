using System.Diagnostics;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace Proect_Tracker
{
    public enum TaskStatus { NotStarted, Completed }
    public partial class Form1 : Form
    {
        private readonly Color colorBackground = Color.FromArgb(240, 240, 240);
        private readonly Color colorButtonNotCompleted = Color.FromArgb(255, 102, 102);
        private readonly Color colorButtonCompleted = Color.FromArgb(102, 255, 102);
        private readonly Color colorButtonSelected = Color.FromArgb(255, 255, 102);

        Task currentSelectedTask = null;
        private int tickCounter = 0;
        System.Windows.Forms.Timer timer1;

        ProjectData projectData;
        float completedHours = 0;
        float totalHours = 0;

        public Form1()
        {
            InitializeComponent();
            projectData = new ProjectData();
            projectData.InitializeProjectData();

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(this.timer1_Tick);  // Attach the tick event
            timer1.Interval = 1000; // Fires every 1 second (1000 ms)


            SetUpProject(projectData);
            CreateCategories(projectData.categories);


        }
        private void SetUpProject(ProjectData projectData)
        {
            totalHours = GetTotalHours(projectData.categories);
            totalHrsLbl.Text = "Estimated Hours: " + totalHours.ToString();
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
                SetPanelColor(panel, category.Status, category.isSelected);

                panel.Click += new EventHandler(CategoryPanel_Click);
                // Create Label
                Label label = new Label
                {
                    Text = category.Name,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    AutoSize = false
                };

                label.Click += new EventHandler(CategoryPanel_Click);
                // Add Label to Panel
                panel.Controls.Add(label);
                // Add Panel to FlowLayoutPanel
                CategoryPnlHldr.Controls.Add(panel);
            }
            // Initial creation of categories - set current task to most current category
            Category initialCategory = MostRecentCategory();
            if (initialCategory != null)
            {
                initialCategory.isSelected = true;
                CreateTaskList(initialCategory); // Simulate a click by manually calling the method
            }
        }
        private Category MostRecentCategory()
        {
            foreach (Category category in projectData.categories)
            {
                if (category.Status == TaskStatus.NotStarted)
                {
                    return category;
                }
            }
            return null; // Return null if no category is found with the status NotStarted
        }
        //CHECK IF CATEGORY IS COMPLETE AND MARK IT SO SOMEWHERE
        private void CategoryPanel_Click(object sender, EventArgs e)
        {


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
            int panelWidth = (totalWidth / 3) - 10;  // Fixed width for 3-column layout
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
                panel.Click += new EventHandler(TaskPanel_Click);
                // Add Label to Panel
                panel.Controls.Add(label);
                // Add Panel to FlowLayoutPanel
                tasksPnl.Controls.Add(panel);
            }
            Task mostRecentTask = MostRecentTask(category.Tasks);
            if (mostRecentTask != null)
            {
                mostRecentTask.isSelected = true;
                currentSelectedTask = mostRecentTask;
            }
            UpdateTaskUI();

        }
        private Task MostRecentTask(List<Task> tasks)
        {
            foreach (Task task in tasks)
            {
                if (task.Status == TaskStatus.NotStarted)
                {
                    return task;
                }
            }
            return null; // Return null if no task is found with the status NotStarted
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


                //update the tick timer for the new clicked task
                //stop the previous timer
                timer1.Stop();
                tickCounter = 0;
                //then call the update



                UpdateTaskUI();
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
        //UPDATE ALL THE TASKS AND THE CURRENT ONE
        private void UpdateTaskUI()
        {
            // Update the background color of all task panels
            foreach (Control control in tasksPnl.Controls)
            {
                if (control is Panel panel && panel.Tag is Task task)
                {
                    SetPanelColor(panel, task.Status, task.isSelected);
                }
            }
            if (currentSelectedTask != null)
            {
                // Update the labels and checkbox for the currently selected task
                taskNameLbl.Text = currentSelectedTask.Name;
                timeSpntLbl.Text = $"{currentSelectedTask.ActualTimeSpent}.{tickCounter}";
                checkBox1.Checked = currentSelectedTask.Status == TaskStatus.Completed;


            }
            else
            {
                // Handle the case where no task is currently selected
                taskNameLbl.Text = "No task selected";
                timeSpntLbl.Text = "0.0";
                checkBox1.Checked = false;
            }
            //Update the bottom trackers
            int completedHours = GetCompletedHours();
            completedHrsLbl.Text = "Completed: " + completedHours;
            int totalHoursAsInt = Convert.ToInt32(totalHours);
            int remainingHours = totalHoursAsInt - completedHours;
            remainingHrsLbl.Text = "Remaining: " + remainingHours.ToString();


            if (totalHoursAsInt == 0)
            {
                percentageLbl.Text = "N/A";  // handle divide by zero
            }
            else
            {
                int percentage = (int)Math.Round((double)(completedHours * 100) / totalHoursAsInt);
                percentageLbl.Text = percentage + "%";
            }



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
                UpdateTaskUI();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (currentSelectedTask != null)
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox.Checked)
                {
                    currentSelectedTask.Status = TaskStatus.Completed;
                }
                else
                {
                    currentSelectedTask.Status = TaskStatus.NotStarted;
                }
                UpdateTaskUI();
            }
        }
        private int GetCompletedHours()
        {
            int minutes = 0;
            foreach (Category category in projectData.categories)
            {
                for (int i = 0; i < category.Tasks.Count; i++)
                {
                    if (category.Tasks[i].Status == TaskStatus.Completed)
                    {
                        minutes += category.Tasks[i].EstimatedTime;
                    }
                }

            }
            return minutes / 60;
        }
    }






}

