namespace TA.GUI
{
    partial class AnalysisClasterForm
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
            this.buttonClasterize = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.actionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClasterize
            // 
            this.buttonClasterize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClasterize.Location = new System.Drawing.Point(6, 19);
            this.buttonClasterize.Name = "buttonClasterize";
            this.buttonClasterize.Size = new System.Drawing.Size(187, 46);
            this.buttonClasterize.TabIndex = 6;
            this.buttonClasterize.Text = "Кластеризация";
            this.buttonClasterize.UseVisualStyleBackColor = true;
            this.buttonClasterize.Click += new System.EventHandler(this.buttonClasterize_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.BackColor = System.Drawing.Color.White;
            this.resultTextBox.Location = new System.Drawing.Point(218, 12);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(391, 354);
            this.resultTextBox.TabIndex = 7;
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.actionsGroupBox.Controls.Add(this.buttonClasterize);
            this.actionsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Size = new System.Drawing.Size(200, 354);
            this.actionsGroupBox.TabIndex = 8;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Действия";
            // 
            // AnalysisClasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 378);
            this.Controls.Add(this.actionsGroupBox);
            this.Controls.Add(this.resultTextBox);
            this.Name = "AnalysisClasterForm";
            this.Text = "AnalysisClasterForm";
            this.actionsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClasterize;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.GroupBox actionsGroupBox;
    }
}