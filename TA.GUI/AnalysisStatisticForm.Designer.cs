namespace TA.GUI
{
    partial class AnalysisStatisticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.redmineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskGroupBox = new System.Windows.Forms.GroupBox();
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.taskButton = new System.Windows.Forms.Button();
            this.contentLabel = new System.Windows.Forms.Label();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.buttonTfIdf = new System.Windows.Forms.Button();
            this.buttonLogLikehood = new System.Windows.Forms.Button();
            this.buttonTScore = new System.Windows.Forms.Button();
            this.buttonMI = new System.Windows.Forms.Button();
            this.buttonFreq = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.taskGroupBox.SuspendLayout();
            this.actionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redmineToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(624, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // redmineToolStripMenuItem
            // 
            this.redmineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillWordsToolStripMenuItem});
            this.redmineToolStripMenuItem.Name = "redmineToolStripMenuItem";
            this.redmineToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.redmineToolStripMenuItem.Text = "Redmine";
            // 
            // fillWordsToolStripMenuItem
            // 
            this.fillWordsToolStripMenuItem.Name = "fillWordsToolStripMenuItem";
            this.fillWordsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.fillWordsToolStripMenuItem.Text = "Fill words";
            this.fillWordsToolStripMenuItem.Click += new System.EventHandler(this.fillWordsToolStripMenuItem_Click);
            // 
            // taskGroupBox
            // 
            this.taskGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskGroupBox.Controls.Add(this.taskTextBox);
            this.taskGroupBox.Controls.Add(this.taskButton);
            this.taskGroupBox.Location = new System.Drawing.Point(12, 27);
            this.taskGroupBox.Name = "taskGroupBox";
            this.taskGroupBox.Size = new System.Drawing.Size(600, 50);
            this.taskGroupBox.TabIndex = 0;
            this.taskGroupBox.TabStop = false;
            this.taskGroupBox.Text = "Задача из Redmine";
            // 
            // taskTextBox
            // 
            this.taskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskTextBox.Location = new System.Drawing.Point(7, 18);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.ReadOnly = true;
            this.taskTextBox.Size = new System.Drawing.Size(465, 20);
            this.taskTextBox.TabIndex = 2;
            this.taskTextBox.Text = "Задача не выбрана";
            // 
            // taskButton
            // 
            this.taskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.taskButton.Location = new System.Drawing.Point(478, 16);
            this.taskButton.Name = "taskButton";
            this.taskButton.Size = new System.Drawing.Size(116, 23);
            this.taskButton.TabIndex = 1;
            this.taskButton.Text = "Выбрать";
            this.taskButton.UseVisualStyleBackColor = true;
            this.taskButton.Click += new System.EventHandler(this.taskButton_Click);
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(12, 80);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(268, 13);
            this.contentLabel.TabIndex = 2;
            this.contentLabel.Text = "Введите в строку ниже слово (С) или двусловие (Д)";
            // 
            // contentTextBox
            // 
            this.contentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTextBox.Location = new System.Drawing.Point(12, 97);
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.Size = new System.Drawing.Size(594, 20);
            this.contentTextBox.TabIndex = 3;
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.actionsGroupBox.Controls.Add(this.buttonTfIdf);
            this.actionsGroupBox.Controls.Add(this.buttonLogLikehood);
            this.actionsGroupBox.Controls.Add(this.buttonTScore);
            this.actionsGroupBox.Controls.Add(this.buttonMI);
            this.actionsGroupBox.Controls.Add(this.buttonFreq);
            this.actionsGroupBox.Location = new System.Drawing.Point(12, 124);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Size = new System.Drawing.Size(200, 285);
            this.actionsGroupBox.TabIndex = 4;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Действия";
            // 
            // buttonTfIdf
            // 
            this.buttonTfIdf.Location = new System.Drawing.Point(7, 228);
            this.buttonTfIdf.Name = "buttonTfIdf";
            this.buttonTfIdf.Size = new System.Drawing.Size(187, 46);
            this.buttonTfIdf.TabIndex = 4;
            this.buttonTfIdf.Text = "Метод TF*IDF (С)";
            this.buttonTfIdf.UseVisualStyleBackColor = true;
            this.buttonTfIdf.Click += new System.EventHandler(this.buttonTfIdf_Click);
            // 
            // buttonLogLikehood
            // 
            this.buttonLogLikehood.Location = new System.Drawing.Point(7, 176);
            this.buttonLogLikehood.Name = "buttonLogLikehood";
            this.buttonLogLikehood.Size = new System.Drawing.Size(187, 46);
            this.buttonLogLikehood.TabIndex = 3;
            this.buttonLogLikehood.Text = "Метод Log-Likelihood (Д)";
            this.buttonLogLikehood.UseVisualStyleBackColor = true;
            this.buttonLogLikehood.Click += new System.EventHandler(this.buttonLogLikehood_Click);
            // 
            // buttonTScore
            // 
            this.buttonTScore.Location = new System.Drawing.Point(7, 124);
            this.buttonTScore.Name = "buttonTScore";
            this.buttonTScore.Size = new System.Drawing.Size(187, 46);
            this.buttonTScore.TabIndex = 2;
            this.buttonTScore.Text = "Метод T-Score (Д)";
            this.buttonTScore.UseVisualStyleBackColor = true;
            this.buttonTScore.Click += new System.EventHandler(this.buttonTScore_Click);
            // 
            // buttonMI
            // 
            this.buttonMI.Location = new System.Drawing.Point(7, 72);
            this.buttonMI.Name = "buttonMI";
            this.buttonMI.Size = new System.Drawing.Size(187, 46);
            this.buttonMI.TabIndex = 1;
            this.buttonMI.Text = "Метод Mutual Information (Д)";
            this.buttonMI.UseVisualStyleBackColor = true;
            this.buttonMI.Click += new System.EventHandler(this.buttonMI_Click);
            // 
            // buttonFreq
            // 
            this.buttonFreq.Location = new System.Drawing.Point(7, 20);
            this.buttonFreq.Name = "buttonFreq";
            this.buttonFreq.Size = new System.Drawing.Size(187, 46);
            this.buttonFreq.TabIndex = 0;
            this.buttonFreq.Text = "Метод подсчёта частот (С, Д)";
            this.buttonFreq.UseVisualStyleBackColor = true;
            this.buttonFreq.Click += new System.EventHandler(this.buttonFreq_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.BackColor = System.Drawing.Color.White;
            this.resultTextBox.Location = new System.Drawing.Point(219, 124);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(393, 274);
            this.resultTextBox.TabIndex = 5;
            // 
            // AnalysisStatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 421);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.actionsGroupBox);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.contentLabel);
            this.Controls.Add(this.taskGroupBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 460);
            this.Name = "AnalysisStatisticForm";
            this.Text = "Статистический анализ";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.taskGroupBox.ResumeLayout(false);
            this.taskGroupBox.PerformLayout();
            this.actionsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem redmineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillWordsToolStripMenuItem;
        private System.Windows.Forms.GroupBox taskGroupBox;
        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.Button taskButton;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.GroupBox actionsGroupBox;
        private System.Windows.Forms.Button buttonMI;
        private System.Windows.Forms.Button buttonFreq;
        private System.Windows.Forms.Button buttonTfIdf;
        private System.Windows.Forms.Button buttonLogLikehood;
        private System.Windows.Forms.Button buttonTScore;
        private System.Windows.Forms.TextBox resultTextBox;
    }
}

