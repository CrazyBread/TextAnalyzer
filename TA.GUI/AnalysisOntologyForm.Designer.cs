namespace TA.GUI
{
    partial class AnalysisOntologyForm
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
            this.ontologyResult_richTextBox = new System.Windows.Forms.RichTextBox();
            this.selectOntologyFile_Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ontologyResult_richTextBox
            // 
            this.ontologyResult_richTextBox.Location = new System.Drawing.Point(238, 13);
            this.ontologyResult_richTextBox.Name = "ontologyResult_richTextBox";
            this.ontologyResult_richTextBox.Size = new System.Drawing.Size(370, 357);
            this.ontologyResult_richTextBox.TabIndex = 1;
            this.ontologyResult_richTextBox.Text = "Для работы с онтологией необходимо выбрать файл онтологии в формате \".owl\".";
            // 
            // selectOntologyFile_Button
            // 
            this.selectOntologyFile_Button.Location = new System.Drawing.Point(11, 22);
            this.selectOntologyFile_Button.Name = "selectOntologyFile_Button";
            this.selectOntologyFile_Button.Size = new System.Drawing.Size(191, 39);
            this.selectOntologyFile_Button.TabIndex = 0;
            this.selectOntologyFile_Button.Text = "Выбрать файл с онтологией";
            this.selectOntologyFile_Button.UseVisualStyleBackColor = true;
            this.selectOntologyFile_Button.Click += new System.EventHandler(this.selectOntologyFile_Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectOntologyFile_Button);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 357);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Онтологический анализ";
            // 
            // AnalysisOntologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ontologyResult_richTextBox);
            this.Name = "AnalysisOntologyForm";
            this.Text = "Онтологический анализ";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox ontologyResult_richTextBox;
        private System.Windows.Forms.Button selectOntologyFile_Button;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}