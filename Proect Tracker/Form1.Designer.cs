namespace Proect_Tracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tasksPnl = new FlowLayoutPanel();
            panel3 = new Panel();
            label5 = new Label();
            panel4 = new Panel();
            label6 = new Label();
            totalHrsLbl = new Label();
            titleText = new Label();
            resetTimerBtn = new Button();
            stopTimerBtn = new Button();
            startTimerBtn = new Button();
            remainingHrsLbl = new Label();
            CategoryPnlHldr = new FlowLayoutPanel();
            taskNameLbl = new Label();
            label8 = new Label();
            timeSpntLbl = new Label();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            panel2 = new Panel();
            completedHrsLbl = new Label();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tasksPnl
            // 
            tasksPnl.Location = new Point(34, 336);
            tasksPnl.Name = "tasksPnl";
            tasksPnl.Size = new Size(949, 314);
            tasksPnl.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label5);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(37, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(963, 253);
            panel3.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 72F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(532, 53);
            label5.Name = "label5";
            label5.Size = new Size(288, 149);
            label5.TabIndex = 1;
            label5.Text = "34%";
            // 
            // panel4
            // 
            panel4.Controls.Add(label6);
            panel4.Controls.Add(totalHrsLbl);
            panel4.Controls.Add(titleText);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(372, 277);
            panel4.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(14, 91);
            label6.Name = "label6";
            label6.Size = new Size(111, 23);
            label6.TabIndex = 5;
            label6.Text = "Started Sep 9";
            // 
            // totalHrsLbl
            // 
            totalHrsLbl.AutoSize = true;
            totalHrsLbl.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            totalHrsLbl.Location = new Point(3, 50);
            totalHrsLbl.Name = "totalHrsLbl";
            totalHrsLbl.Size = new Size(201, 38);
            totalHrsLbl.TabIndex = 1;
            totalHrsLbl.Text = "Total Hours: 69";
            // 
            // titleText
            // 
            titleText.AutoSize = true;
            titleText.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            titleText.Location = new Point(0, 0);
            titleText.Name = "titleText";
            titleText.Size = new Size(365, 50);
            titleText.TabIndex = 0;
            titleText.Text = "E-Commerce Site";
            // 
            // resetTimerBtn
            // 
            resetTimerBtn.Location = new Point(157, 142);
            resetTimerBtn.Name = "resetTimerBtn";
            resetTimerBtn.Size = new Size(94, 29);
            resetTimerBtn.TabIndex = 7;
            resetTimerBtn.Text = "Reset";
            resetTimerBtn.UseVisualStyleBackColor = true;
            resetTimerBtn.Click += resetTimerBtn_Click;
            // 
            // stopTimerBtn
            // 
            stopTimerBtn.Location = new Point(59, 174);
            stopTimerBtn.Name = "stopTimerBtn";
            stopTimerBtn.Size = new Size(94, 29);
            stopTimerBtn.TabIndex = 6;
            stopTimerBtn.Text = "Stop Timer";
            stopTimerBtn.UseVisualStyleBackColor = true;
            stopTimerBtn.Click += stopTimerBtn_Click;
            // 
            // startTimerBtn
            // 
            startTimerBtn.Location = new Point(59, 142);
            startTimerBtn.Name = "startTimerBtn";
            startTimerBtn.Size = new Size(94, 29);
            startTimerBtn.TabIndex = 2;
            startTimerBtn.Text = "Start Timer";
            startTimerBtn.UseVisualStyleBackColor = true;
            startTimerBtn.Click += startTimerBtn_Click;
            // 
            // remainingHrsLbl
            // 
            remainingHrsLbl.AutoSize = true;
            remainingHrsLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            remainingHrsLbl.Location = new Point(265, 885);
            remainingHrsLbl.Name = "remainingHrsLbl";
            remainingHrsLbl.Size = new Size(158, 31);
            remainingHrsLbl.TabIndex = 2;
            remainingHrsLbl.Text = "Remaining: 69";
            // 
            // CategoryPnlHldr
            // 
            CategoryPnlHldr.Location = new Point(34, 271);
            CategoryPnlHldr.Margin = new Padding(0);
            CategoryPnlHldr.Name = "CategoryPnlHldr";
            CategoryPnlHldr.Size = new Size(966, 59);
            CategoryPnlHldr.TabIndex = 5;
            CategoryPnlHldr.WrapContents = false;
            // 
            // taskNameLbl
            // 
            taskNameLbl.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            taskNameLbl.Location = new Point(0, 0);
            taskNameLbl.Name = "taskNameLbl";
            taskNameLbl.Size = new Size(340, 226);
            taskNameLbl.TabIndex = 8;
            taskNameLbl.Text = "Plan the App";
            taskNameLbl.UseMnemonic = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(59, 8);
            label8.Name = "label8";
            label8.Size = new Size(188, 37);
            label8.TabIndex = 9;
            label8.Text = "Time Spent";
            // 
            // timeSpntLbl
            // 
            timeSpntLbl.AutoSize = true;
            timeSpntLbl.Font = new Font("Showcard Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point);
            timeSpntLbl.Location = new Point(59, 45);
            timeSpntLbl.Name = "timeSpntLbl";
            timeSpntLbl.Size = new Size(192, 98);
            timeSpntLbl.TabIndex = 2;
            timeSpntLbl.Text = "1:30";
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(timeSpntLbl);
            panel1.Controls.Add(startTimerBtn);
            panel1.Controls.Add(resetTimerBtn);
            panel1.Controls.Add(stopTimerBtn);
            panel1.Location = new Point(346, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(633, 206);
            panel1.TabIndex = 10;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(445, 161);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(174, 42);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Completed";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(taskNameLbl);
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(34, 656);
            panel2.Name = "panel2";
            panel2.Size = new Size(980, 226);
            panel2.TabIndex = 11;
            // 
            // completedHrsLbl
            // 
            completedHrsLbl.AutoSize = true;
            completedHrsLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            completedHrsLbl.Location = new Point(51, 885);
            completedHrsLbl.Name = "completedHrsLbl";
            completedHrsLbl.Size = new Size(162, 31);
            completedHrsLbl.TabIndex = 12;
            completedHrsLbl.Text = "Completed: 20";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 925);
            Controls.Add(completedHrsLbl);
            Controls.Add(panel2);
            Controls.Add(CategoryPnlHldr);
            Controls.Add(panel3);
            Controls.Add(tasksPnl);
            Controls.Add(remainingHrsLbl);
            Name = "Form1";
            Text = "Form1";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel tasksPnl;
        private Panel panel3;
        private Panel panel4;
        private Label titleText;
        private Label remainingHrsLbl;
        private Label totalHrsLbl;
        private Label label5;
        private Label label6;
        private Button startTimerBtn;
        private Button stopTimerBtn;
        private FlowLayoutPanel CategoryPnlHldr;
        private Button resetTimerBtn;
        private Label taskNameLbl;
        private Label label8;
        private Label timeSpntLbl;
        private Panel panel1;
        private Panel panel2;
        private Label completedHrsLbl;
        private CheckBox checkBox1;
    }
}