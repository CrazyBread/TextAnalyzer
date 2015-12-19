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
            this.words_listBox = new System.Windows.Forms.ListBox();
            this.checkWord_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ontologyResult_richTextBox
            // 
            this.ontologyResult_richTextBox.Location = new System.Drawing.Point(238, 13);
            this.ontologyResult_richTextBox.Name = "ontologyResult_richTextBox";
            this.ontologyResult_richTextBox.ReadOnly = true;
            this.ontologyResult_richTextBox.Size = new System.Drawing.Size(370, 363);
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
            this.groupBox1.Controls.Add(this.checkWord_button);
            this.groupBox1.Controls.Add(this.words_listBox);
            this.groupBox1.Controls.Add(this.selectOntologyFile_Button);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 364);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Онтологический анализ";
            // 
            // words_listBox
            // 
            this.words_listBox.Enabled = false;
            this.words_listBox.FormattingEnabled = true;
            this.words_listBox.Location = new System.Drawing.Point(11, 68);
            this.words_listBox.Name = "words_listBox";
            this.words_listBox.Size = new System.Drawing.Size(191, 238);
            this.words_listBox.TabIndex = 1;
            // 
            // checkWord_button
            // 
            this.checkWord_button.Enabled = false;
            this.checkWord_button.Location = new System.Drawing.Point(11, 313);
            this.checkWord_button.Name = "checkWord_button";
            this.checkWord_button.Size = new System.Drawing.Size(191, 38);
            this.checkWord_button.TabIndex = 2;
            this.checkWord_button.Text = "Проверить слово";
            this.checkWord_button.UseVisualStyleBackColor = true;
            this.checkWord_button.Click += new System.EventHandler(this.checkWord_button_Click);
            // 
            // AnalysisOntologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 388);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ontologyResult_richTextBox);
            this.Name = "AnalysisOntologyForm";
            this.Text = "Онтологический анализ";
            this.Load += new System.EventHandler(this.AnalysisOntologyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox ontologyResult_richTextBox;
        private System.Windows.Forms.Button selectOntologyFile_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox words_listBox;
        private System.Windows.Forms.Button checkWord_button;
    }
}