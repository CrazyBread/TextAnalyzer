﻿namespace TA.GUI
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
            // AnalysisTimelineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 261);
            this.Controls.Add(this.comboBoxStatuses);
            this.Name = "AnalysisTimelineForm";
            this.Text = "AnalysisTimelineForm";
            this.Load += new System.EventHandler(this.AnalysisTimelineForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStatuses;
    }
}