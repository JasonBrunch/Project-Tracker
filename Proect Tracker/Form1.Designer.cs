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
            components = new System.ComponentModel.Container();
            tasksPnl = new FlowLayoutPanel();
            panel3 = new Panel();
            label5 = new Label();
            panel4 = new Panel();
            button2 = new Button();
            label6 = new Label();
            button1 = new Button();
            label1 = new Label();
            titleText = new Label();
            CategoryPnlHldr = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // tasksPnl
            // 
            tasksPnl.Location = new Point(34, 325);
            tasksPnl.Name = "tasksPnl";
            tasksPnl.Size = new Size(946, 328);
            tasksPnl.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label5);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(37, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(943, 253);
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
            panel4.Controls.Add(button2);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(titleText);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(372, 277);
            panel4.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(3, 223);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Start Timer";
            button2.UseVisualStyleBackColor = true;
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
            // button1
            // 
            button1.Location = new Point(3, 188);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Start Timer";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 50);
            label1.Name = "label1";
            label1.Size = new Size(215, 41);
            label1.TabIndex = 1;
            label1.Text = "Total Hours: 69";
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
            // CategoryPnlHldr
            // 
            CategoryPnlHldr.Location = new Point(37, 271);
            CategoryPnlHldr.Name = "CategoryPnlHldr";
            CategoryPnlHldr.Size = new Size(943, 51);
            CategoryPnlHldr.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(51, 663);
            label2.Name = "label2";
            label2.Size = new Size(158, 31);
            label2.TabIndex = 2;
            label2.Text = "Remaining: 69";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(377, 663);
            label3.Name = "label3";
            label3.Size = new Size(236, 31);
            label3.TabIndex = 3;
            label3.Text = "Productivity: 3hrs/day";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(725, 663);
            label4.Name = "label4";
            label4.Size = new Size(255, 31);
            label4.TabIndex = 4;
            label4.Text = "Projected Finish: Sep 21";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 703);
            Controls.Add(CategoryPnlHldr);
            Controls.Add(label4);
            Controls.Add(panel3);
            Controls.Add(tasksPnl);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Form1";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel tasksPnl;
        private Panel panel3;
        private Panel panel4;
        private Label titleText;
        private Panel CategoryPnlHldr;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button button2;
        private System.Windows.Forms.Timer timer1;
    }
}