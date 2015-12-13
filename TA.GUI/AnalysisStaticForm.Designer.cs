namespace TA.GUI
{
    partial class AnalysisStaticForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticAnalisysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mutualInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morphologicalAnalisysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redmineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelBigramm = new System.Windows.Forms.Label();
            this.textBoxBigramm = new System.Windows.Forms.TextBox();
            this.buttonBigrammFind = new System.Windows.Forms.Button();
            this.buttonClasterize = new System.Windows.Forms.Button();
            this.issuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStatusesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.statisticAnalisysToolStripMenuItem,
            this.morphologicalAnalisysToolStripMenuItem,
            this.redmineToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(599, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // statisticAnalisysToolStripMenuItem
            // 
            this.statisticAnalisysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frequencyToolStripMenuItem,
            this.mutualInformationToolStripMenuItem});
            this.statisticAnalisysToolStripMenuItem.Enabled = false;
            this.statisticAnalisysToolStripMenuItem.Name = "statisticAnalisysToolStripMenuItem";
            this.statisticAnalisysToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.statisticAnalisysToolStripMenuItem.Text = "Statistic analisys";
            // 
            // frequencyToolStripMenuItem
            // 
            this.frequencyToolStripMenuItem.Name = "frequencyToolStripMenuItem";
            this.frequencyToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.frequencyToolStripMenuItem.Text = "Frequency";
            this.frequencyToolStripMenuItem.Click += new System.EventHandler(this.frequencyToolStripMenuItem_Click);
            // 
            // mutualInformationToolStripMenuItem
            // 
            this.mutualInformationToolStripMenuItem.Name = "mutualInformationToolStripMenuItem";
            this.mutualInformationToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.mutualInformationToolStripMenuItem.Text = "Mutual Information";
            this.mutualInformationToolStripMenuItem.Click += new System.EventHandler(this.mutualInformationToolStripMenuItem_Click);
            // 
            // morphologicalAnalisysToolStripMenuItem
            // 
            this.morphologicalAnalisysToolStripMenuItem.Enabled = false;
            this.morphologicalAnalisysToolStripMenuItem.Name = "morphologicalAnalisysToolStripMenuItem";
            this.morphologicalAnalisysToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.morphologicalAnalisysToolStripMenuItem.Text = "Morphological analisys";
            this.morphologicalAnalisysToolStripMenuItem.Click += new System.EventHandler(this.morphologicalAnalisysToolStripMenuItem_Click);
            // 
            // redmineToolStripMenuItem
            // 
            this.redmineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillWordsToolStripMenuItem,
            this.issuesToolStripMenuItem});
            this.redmineToolStripMenuItem.Name = "redmineToolStripMenuItem";
            this.redmineToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.redmineToolStripMenuItem.Text = "Redmine";
            // 
            // fillWordsToolStripMenuItem
            // 
            this.fillWordsToolStripMenuItem.Name = "fillWordsToolStripMenuItem";
            this.fillWordsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fillWordsToolStripMenuItem.Text = "Fill words";
            this.fillWordsToolStripMenuItem.Click += new System.EventHandler(this.fillWordsToolStripMenuItem_Click);
            // 
            // labelBigramm
            // 
            this.labelBigramm.AutoSize = true;
            this.labelBigramm.Location = new System.Drawing.Point(12, 40);
            this.labelBigramm.Name = "labelBigramm";
            this.labelBigramm.Size = new System.Drawing.Size(59, 13);
            this.labelBigramm.TabIndex = 2;
            this.labelBigramm.Text = "Биграмма";
            // 
            // textBoxBigramm
            // 
            this.textBoxBigramm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBigramm.Location = new System.Drawing.Point(77, 38);
            this.textBoxBigramm.Name = "textBoxBigramm";
            this.textBoxBigramm.Size = new System.Drawing.Size(510, 20);
            this.textBoxBigramm.TabIndex = 3;
            // 
            // buttonBigrammFind
            // 
            this.buttonBigrammFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBigrammFind.Location = new System.Drawing.Point(15, 67);
            this.buttonBigrammFind.Name = "buttonBigrammFind";
            this.buttonBigrammFind.Size = new System.Drawing.Size(571, 27);
            this.buttonBigrammFind.TabIndex = 4;
            this.buttonBigrammFind.Text = "Поиск биграммы";
            this.buttonBigrammFind.UseVisualStyleBackColor = true;
            this.buttonBigrammFind.Click += new System.EventHandler(this.buttonBigrammFind_Click);
            // 
            // buttonClasterize
            // 
            this.buttonClasterize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClasterize.Location = new System.Drawing.Point(15, 100);
            this.buttonClasterize.Name = "buttonClasterize";
            this.buttonClasterize.Size = new System.Drawing.Size(571, 27);
            this.buttonClasterize.TabIndex = 5;
            this.buttonClasterize.Text = "Кластеризация";
            this.buttonClasterize.UseVisualStyleBackColor = true;
            this.buttonClasterize.Click += new System.EventHandler(this.buttonClasterize_Click);
            // 
            // issuesToolStripMenuItem
            // 
            this.issuesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.loadStatusesToolStripMenuItem});
            this.issuesToolStripMenuItem.Name = "issuesToolStripMenuItem";
            this.issuesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.issuesToolStripMenuItem.Text = "Issues";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // loadStatusesToolStripMenuItem
            // 
            this.loadStatusesToolStripMenuItem.Name = "loadStatusesToolStripMenuItem";
            this.loadStatusesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadStatusesToolStripMenuItem.Text = "Load statuses";
            this.loadStatusesToolStripMenuItem.Click += new System.EventHandler(this.loadStatusesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 261);
            this.Controls.Add(this.buttonClasterize);
            this.Controls.Add(this.buttonBigrammFind);
            this.Controls.Add(this.textBoxBigramm);
            this.Controls.Add(this.labelBigramm);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticAnalisysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mutualInformationToolStripMenuItem;
        private System.Windows.Forms.Label labelBigramm;
        private System.Windows.Forms.TextBox textBoxBigramm;
        private System.Windows.Forms.Button buttonBigrammFind;
        private System.Windows.Forms.ToolStripMenuItem morphologicalAnalisysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redmineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillWordsToolStripMenuItem;
        private System.Windows.Forms.Button buttonClasterize;
        private System.Windows.Forms.ToolStripMenuItem issuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadStatusesToolStripMenuItem;
    }
}

