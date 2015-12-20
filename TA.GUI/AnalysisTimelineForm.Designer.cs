namespace TA.GUI
{
    partial class AnalysisTimelineForm
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
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.lengthDaysLabel = new System.Windows.Forms.Label();
            this.lengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.datesLabel = new System.Windows.Forms.Label();
            this.dateStartPicker = new System.Windows.Forms.DateTimePicker();
            this.dateEndPicker = new System.Windows.Forms.DateTimePicker();
            this.processButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // statusComboBox
            // 
            this.statusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Location = new System.Drawing.Point(151, 31);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(538, 21);
            this.statusComboBox.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(701, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskSyncToolStripMenuItem,
            this.journalSyncToolStripMenuItem});
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.supportToolStripMenuItem.Text = "Обслуживание";
            // 
            // taskSyncToolStripMenuItem
            // 
            this.taskSyncToolStripMenuItem.Name = "taskSyncToolStripMenuItem";
            this.taskSyncToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.taskSyncToolStripMenuItem.Text = "Синхронизировать задачи Redmine";
            this.taskSyncToolStripMenuItem.Click += new System.EventHandler(this.taskSyncToolStripMenuItem_Click);
            // 
            // journalSyncToolStripMenuItem
            // 
            this.journalSyncToolStripMenuItem.Name = "journalSyncToolStripMenuItem";
            this.journalSyncToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.journalSyncToolStripMenuItem.Text = "Синхронизировать журналы Redmine";
            this.journalSyncToolStripMenuItem.Click += new System.EventHandler(this.journalSyncToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(16, 34);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(79, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Статус задачи";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(16, 61);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(73, 13);
            this.typeLabel.TabIndex = 3;
            this.typeLabel.Text = "Тип выборки";
            // 
            // typeComboBox
            // 
            this.typeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Location = new System.Drawing.Point(151, 58);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(538, 21);
            this.typeComboBox.TabIndex = 4;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(16, 88);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(131, 13);
            this.lengthLabel.TabIndex = 5;
            this.lengthLabel.Text = "Частота/длина выборки";
            // 
            // lengthDaysLabel
            // 
            this.lengthDaysLabel.AutoSize = true;
            this.lengthDaysLabel.Location = new System.Drawing.Point(279, 88);
            this.lengthDaysLabel.Name = "lengthDaysLabel";
            this.lengthDaysLabel.Size = new System.Drawing.Size(31, 13);
            this.lengthDaysLabel.TabIndex = 6;
            this.lengthDaysLabel.Text = "дней";
            // 
            // lengthNumericUpDown
            // 
            this.lengthNumericUpDown.Location = new System.Drawing.Point(151, 86);
            this.lengthNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.lengthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lengthNumericUpDown.Name = "lengthNumericUpDown";
            this.lengthNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.lengthNumericUpDown.TabIndex = 7;
            this.lengthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // datesLabel
            // 
            this.datesLabel.AutoSize = true;
            this.datesLabel.Location = new System.Drawing.Point(16, 118);
            this.datesLabel.Name = "datesLabel";
            this.datesLabel.Size = new System.Drawing.Size(82, 13);
            this.datesLabel.TabIndex = 8;
            this.datesLabel.Text = "Даты выборки";
            // 
            // dateStartPicker
            // 
            this.dateStartPicker.Location = new System.Drawing.Point(151, 112);
            this.dateStartPicker.Name = "dateStartPicker";
            this.dateStartPicker.Size = new System.Drawing.Size(200, 20);
            this.dateStartPicker.TabIndex = 9;
            // 
            // dateEndPicker
            // 
            this.dateEndPicker.Location = new System.Drawing.Point(357, 112);
            this.dateEndPicker.Name = "dateEndPicker";
            this.dateEndPicker.Size = new System.Drawing.Size(200, 20);
            this.dateEndPicker.TabIndex = 10;
            // 
            // processButton
            // 
            this.processButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processButton.Location = new System.Drawing.Point(19, 151);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(670, 23);
            this.processButton.TabIndex = 11;
            this.processButton.Text = "Построить временной ряд";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // AnalysisTimelineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 190);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.dateEndPicker);
            this.Controls.Add(this.dateStartPicker);
            this.Controls.Add(this.datesLabel);
            this.Controls.Add(this.lengthNumericUpDown);
            this.Controls.Add(this.lengthDaysLabel);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "AnalysisTimelineForm";
            this.Text = "AnalysisTimelineForm";
            this.Load += new System.EventHandler(this.AnalysisTimelineForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem journalSyncToolStripMenuItem;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label lengthDaysLabel;
        private System.Windows.Forms.NumericUpDown lengthNumericUpDown;
        private System.Windows.Forms.Label datesLabel;
        private System.Windows.Forms.DateTimePicker dateStartPicker;
        private System.Windows.Forms.DateTimePicker dateEndPicker;
        private System.Windows.Forms.Button processButton;
    }
}