namespace TA.GUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelWelcome = new System.Windows.Forms.Label();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.buttonATimeline = new System.Windows.Forms.Button();
            this.buttonAOnth = new System.Windows.Forms.Button();
            this.buttonAClaster = new System.Windows.Forms.Button();
            this.buttonAMorph = new System.Windows.Forms.Button();
            this.buttonAStatistic = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.taskGroupBox = new System.Windows.Forms.GroupBox();
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.taskButton = new System.Windows.Forms.Button();
            this.saveLogHtmlButton = new System.Windows.Forms.Button();
            this.groupBoxActions.SuspendLayout();
            this.taskGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.Location = new System.Drawing.Point(12, 9);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(539, 106);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = resources.GetString("labelWelcome.Text");
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxActions.Controls.Add(this.buttonATimeline);
            this.groupBoxActions.Controls.Add(this.buttonAOnth);
            this.groupBoxActions.Controls.Add(this.buttonAClaster);
            this.groupBoxActions.Controls.Add(this.buttonAMorph);
            this.groupBoxActions.Controls.Add(this.buttonAStatistic);
            this.groupBoxActions.Location = new System.Drawing.Point(15, 183);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(536, 271);
            this.groupBoxActions.TabIndex = 1;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Для продолжения выберите необходимую категорию:";
            // 
            // buttonATimeline
            // 
            this.buttonATimeline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonATimeline.Location = new System.Drawing.Point(6, 216);
            this.buttonATimeline.Name = "buttonATimeline";
            this.buttonATimeline.Size = new System.Drawing.Size(524, 40);
            this.buttonATimeline.TabIndex = 4;
            this.buttonATimeline.Text = "Работа с временными рядами";
            this.buttonATimeline.UseVisualStyleBackColor = true;
            this.buttonATimeline.Click += new System.EventHandler(this.buttonATimeline_Click);
            // 
            // buttonAOnth
            // 
            this.buttonAOnth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAOnth.Enabled = false;
            this.buttonAOnth.Location = new System.Drawing.Point(6, 170);
            this.buttonAOnth.Name = "buttonAOnth";
            this.buttonAOnth.Size = new System.Drawing.Size(524, 40);
            this.buttonAOnth.TabIndex = 3;
            this.buttonAOnth.Text = "Онтологический анализ";
            this.buttonAOnth.UseVisualStyleBackColor = true;
            this.buttonAOnth.Click += new System.EventHandler(this.buttonAOnth_Click);
            // 
            // buttonAClaster
            // 
            this.buttonAClaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAClaster.Enabled = false;
            this.buttonAClaster.Location = new System.Drawing.Point(6, 124);
            this.buttonAClaster.Name = "buttonAClaster";
            this.buttonAClaster.Size = new System.Drawing.Size(524, 40);
            this.buttonAClaster.TabIndex = 2;
            this.buttonAClaster.Text = "Кластерный анализ";
            this.buttonAClaster.UseVisualStyleBackColor = true;
            this.buttonAClaster.Click += new System.EventHandler(this.buttonAClaster_Click);
            // 
            // buttonAMorph
            // 
            this.buttonAMorph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAMorph.Enabled = false;
            this.buttonAMorph.Location = new System.Drawing.Point(6, 78);
            this.buttonAMorph.Name = "buttonAMorph";
            this.buttonAMorph.Size = new System.Drawing.Size(524, 40);
            this.buttonAMorph.TabIndex = 1;
            this.buttonAMorph.Text = "Морфологический анализ";
            this.buttonAMorph.UseVisualStyleBackColor = true;
            this.buttonAMorph.Click += new System.EventHandler(this.buttonAMorph_Click);
            // 
            // buttonAStatistic
            // 
            this.buttonAStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAStatistic.Enabled = false;
            this.buttonAStatistic.Location = new System.Drawing.Point(6, 32);
            this.buttonAStatistic.Name = "buttonAStatistic";
            this.buttonAStatistic.Size = new System.Drawing.Size(524, 40);
            this.buttonAStatistic.TabIndex = 0;
            this.buttonAStatistic.Text = "Статистический анализ";
            this.buttonAStatistic.UseVisualStyleBackColor = true;
            this.buttonAStatistic.Click += new System.EventHandler(this.buttonAStatistic_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.Location = new System.Drawing.Point(343, 460);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(127, 23);
            this.buttonAbout.TabIndex = 0;
            this.buttonAbout.Text = "О разработчиках";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(476, 460);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // taskGroupBox
            // 
            this.taskGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskGroupBox.Controls.Add(this.taskTextBox);
            this.taskGroupBox.Controls.Add(this.taskButton);
            this.taskGroupBox.Location = new System.Drawing.Point(15, 118);
            this.taskGroupBox.Name = "taskGroupBox";
            this.taskGroupBox.Size = new System.Drawing.Size(536, 50);
            this.taskGroupBox.TabIndex = 3;
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
            this.taskTextBox.Size = new System.Drawing.Size(401, 20);
            this.taskTextBox.TabIndex = 2;
            this.taskTextBox.Text = "Задача не выбрана";
            // 
            // taskButton
            // 
            this.taskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.taskButton.Location = new System.Drawing.Point(414, 16);
            this.taskButton.Name = "taskButton";
            this.taskButton.Size = new System.Drawing.Size(116, 23);
            this.taskButton.TabIndex = 1;
            this.taskButton.Text = "Выбрать";
            this.taskButton.UseVisualStyleBackColor = true;
            this.taskButton.Click += new System.EventHandler(this.taskButton_Click);
            // 
            // saveLogHtmlButton
            // 
            this.saveLogHtmlButton.Location = new System.Drawing.Point(15, 460);
            this.saveLogHtmlButton.Name = "saveLogHtmlButton";
            this.saveLogHtmlButton.Size = new System.Drawing.Size(103, 23);
            this.saveLogHtmlButton.TabIndex = 4;
            this.saveLogHtmlButton.Text = "Сохранить лог";
            this.saveLogHtmlButton.UseVisualStyleBackColor = true;
            this.saveLogHtmlButton.Click += new System.EventHandler(this.saveLogHtmlButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 495);
            this.Controls.Add(this.saveLogHtmlButton);
            this.Controls.Add(this.taskGroupBox);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.labelWelcome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Анализ слабоструктурированных информационных ресурсов";
            this.groupBoxActions.ResumeLayout(false);
            this.taskGroupBox.ResumeLayout(false);
            this.taskGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonATimeline;
        private System.Windows.Forms.Button buttonAOnth;
        private System.Windows.Forms.Button buttonAClaster;
        private System.Windows.Forms.Button buttonAMorph;
        private System.Windows.Forms.Button buttonAStatistic;
        private System.Windows.Forms.GroupBox taskGroupBox;
        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.Button taskButton;
        private System.Windows.Forms.Button saveLogHtmlButton;
    }
}