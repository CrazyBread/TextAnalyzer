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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticAnalisysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mutualInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelBigramm = new System.Windows.Forms.Label();
            this.textBoxBigramm = new System.Windows.Forms.TextBox();
            this.buttonBigrammFind = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.statisticAnalisysToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
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
            this.textBoxBigramm.Size = new System.Drawing.Size(195, 20);
            this.textBoxBigramm.TabIndex = 3;
            // 
            // buttonBigrammFind
            // 
            this.buttonBigrammFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBigrammFind.Location = new System.Drawing.Point(15, 67);
            this.buttonBigrammFind.Name = "buttonBigrammFind";
            this.buttonBigrammFind.Size = new System.Drawing.Size(256, 27);
            this.buttonBigrammFind.TabIndex = 4;
            this.buttonBigrammFind.Text = "Поиск биграммы";
            this.buttonBigrammFind.UseVisualStyleBackColor = true;
            this.buttonBigrammFind.Click += new System.EventHandler(this.buttonBigrammFind_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
    }
}

