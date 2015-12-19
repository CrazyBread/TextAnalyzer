namespace TA.GUI
{
    partial class RedmineTaskSelector
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
            this.tasksDataGridView = new System.Windows.Forms.DataGridView();
            this.submitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksDataGridView
            // 
            this.tasksDataGridView.AllowUserToAddRows = false;
            this.tasksDataGridView.AllowUserToDeleteRows = false;
            this.tasksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksDataGridView.Location = new System.Drawing.Point(13, 13);
            this.tasksDataGridView.Name = "tasksDataGridView";
            this.tasksDataGridView.ReadOnly = true;
            this.tasksDataGridView.Size = new System.Drawing.Size(888, 380);
            this.tasksDataGridView.TabIndex = 0;
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(807, 399);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(94, 23);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Выбрать";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // RedmineTaskSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 432);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.tasksDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RedmineTaskSelector";
            this.Text = "Выберите задачу и нажмите на кнокпу \"Выбрать\"";
            this.Load += new System.EventHandler(this.RedmineTaskSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tasksDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tasksDataGridView;
        private System.Windows.Forms.Button submitButton;
    }
}