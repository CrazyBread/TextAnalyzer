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
            this.comboBoxStatuses = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxStatuses
            // 
            this.comboBoxStatuses.FormattingEnabled = true;
            this.comboBoxStatuses.Location = new System.Drawing.Point(12, 39);
            this.comboBoxStatuses.Name = "comboBoxStatuses";
            this.comboBoxStatuses.Size = new System.Drawing.Size(332, 21);
            this.comboBoxStatuses.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(701, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip";
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
            // AnalysisTimelineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 261);
            this.Controls.Add(this.comboBoxStatuses);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnalysisTimelineForm";
            this.Text = "AnalysisTimelineForm";
            this.Load += new System.EventHandler(this.AnalysisTimelineForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStatuses;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem journalSyncToolStripMenuItem;
    }
}