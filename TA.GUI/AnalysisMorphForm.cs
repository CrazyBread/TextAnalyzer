using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA.GUI
{
    public partial class AnalysisMorphForm : Form
    {
        private List<string> _words;
        private Connector.Redmine.Model.Issue _task;

        public AnalysisMorphForm(List<string> words, Connector.Redmine.Model.Issue task)
        {
            InitializeComponent();
            _words = words;
            _task = task;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();

            var morphLib = new Morph.MorphLib(wordTextBox.Text);
            var words = morphLib.GetWordsInfo();
            foreach(var word in words)
            {
                resultTextBox.Text += "!!! " + word.Text + " !!!\r\n";
                resultTextBox.Text += "Часть речи: " + word.PartOfSpeech + "\r\n";
                resultTextBox.Text += "Дополнительная информация: " + word.PartOfSpeechAddition + "\r\n";
                resultTextBox.Text += "\r\n";
            }
        }
    }
}
