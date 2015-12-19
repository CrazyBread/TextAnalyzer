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
            this.SuspendLayout();
            // 
            // buttonClasterize
            // 
            this.buttonClasterize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClasterize.Location = new System.Drawing.Point(12, 12);
            this.buttonClasterize.Name = "buttonClasterize";
            this.buttonClasterize.Size = new System.Drawing.Size(653, 27);
            this.buttonClasterize.TabIndex = 6;
            this.buttonClasterize.Text = "Кластеризация";
            this.buttonClasterize.UseVisualStyleBackColor = true;
            this.buttonClasterize.Click += new System.EventHandler(this.buttonClasterize_Click);
            // 
            // AnalysisClasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 51);
            this.Controls.Add(this.buttonClasterize);
            this.Name = "AnalysisClasterForm";
            this.Text = "AnalysisClasterForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClasterize;
    }
}