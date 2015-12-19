using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA.GUI
{
    public partial class AnalysisStatisticForm : Form
    {
        private List<string> _words;
        private Connector.Redmine.Model.Issue _task;

        public AnalysisStatisticForm()
        {
            InitializeComponent();
            buttonsDisable();
            resultTextBox.TextChanged += (sender, e) =>
            {
                resultTextBox.SelectionStart = resultTextBox.TextLength;
                resultTextBox.ScrollToCaret();
            };
        }

        #region TODO: replace or delete
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var loader = new TA.Connector.File.FileLoader();
                loader.Load(dialog.FileName).RemoveUselessChars().ToUpperCase();
                _words = loader.Words;

                statisticAnalisysToolStripMenuItem.Enabled = true;
                morphologicalAnalisysToolStripMenuItem.Enabled = true;
                loadToolStripMenuItem.Enabled = false;
            }
        }

        private void frequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // на первый раз выведем в messagebox топ20 слов
            var freq = new TA.Statistic.Frequency(_words);
            var resultString = string.Join("\r\n", freq.Process().Take(20).Select(i => i.word + " — " + i.count));
            MessageBox.Show(resultString);
        }

        private void mutualInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mutInf = new TA.Statistic.MutualInformation(_words);
            var result = mutInf.Calculate("ГИС ЖКХ");
            MessageBox.Show(result.ToString());
        }

        private void buttonBigrammFind_Click(object sender, EventArgs e)
        {
            double resultCoef = 0.0;
            string resultBigramm = string.Empty;
            var mutInf = new TA.Statistic.MutualInformation(_words);

            for (int i = 0; i < _words.Count - 1; i++)
            {
                var currentBigramm = _words[i] + " " + _words[i + 1];
                var currentCoef = mutInf.Calculate(currentBigramm);

                if (currentCoef > resultCoef)
                {
                    resultCoef = currentCoef;
                    resultBigramm = currentBigramm;
                }
            }

            MessageBox.Show(resultBigramm + ": " + resultCoef.ToString());
        }

        private void morphologicalAnalisysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void fillWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var issues = TA.Connector.Redmine.Connector.GetAllIssues();
            var statementSplitters = new string[] { ".", ",", "?", "!", ";", "\r", "\n" };

            foreach (var issue in issues)
            {
                System.Diagnostics.Trace.WriteLine(issue.RedmineId);

                var issueStatements = issue.Description.Split(statementSplitters, StringSplitOptions.RemoveEmptyEntries);
                foreach (var statement in issueStatements)
                {
                    var morphLib = new TA.Morph.MorphLib(statement);
                    var wrds = morphLib.Filter("S", "A");//, "V", "ANUM", "APRO", "NUM", "SPRO", "ADV");
                    var wrdsFreq = new Statistic.Frequency(wrds);
                    var wrdsFreqResult = wrdsFreq.Process();
                    foreach (var word in wrdsFreqResult)
                    {
                        TA.Connector.Redmine.WordCollector.Collect(issue.Id, word.word, word.count, 1);
                    }

                    for (int i = 1; i < wrds.Count; i++)
                    {
                        string bigramm = wrds[i - 1] + " " + wrds[i];
                        TA.Connector.Redmine.WordCollector.Collect(issue.Id, bigramm, wrdsFreq.GetByBigramm(bigramm), 2);
                    }
                }
                TA.Connector.Redmine.WordCollector.Submit();
            }
        }
        #endregion

        private void taskButton_Click(object sender, EventArgs e)
        {
            int? taskId;
            using (RedmineTaskSelector form = new RedmineTaskSelector())
            {
                form.ShowDialog();
                taskId = form.TaskId;
            }
            if (taskId == null || !taskId.HasValue)
            {
                MessageBox.Show("Задача не выбрана.");
                return;
            }
            _task = Connector.Redmine.Connector.GetIssues(taskId.Value);
            taskTextBox.Text = string.Format("[#{0}] {1}", _task.RedmineId, _task.Subject);
            buttonsEnable();
            resultTextBox.Text = string.Empty;

            // get words array
            var morphLib = new TA.Morph.MorphLib(_task.Description.ToUpper());
            _words = morphLib.ToMainForm();
            resultTextBox.Text = string.Format("[{0}]\r\n\r\n", string.Join(" ", _words));

            // get frequency of words
            var freqLib = new TA.Statistic.Frequency(_words);
            var orderedWords = freqLib.Process().OrderByDescending(i => i.count);
            resultTextBox.Text += "ЧАСТОТА УПОТРЕБЛЕНИЯ СЛОВ:\r\n";
            foreach (var item in orderedWords)
                resultTextBox.Text += string.Format("  {0} — {1}\r\n", item.word, item.count);
            resultTextBox.Text += "\r\n";
        }

        #region other stuff
        private void buttonsDisable()
        {
            foreach (Control control in actionsGroupBox.Controls)
                control.Enabled = false;
        }

        private void buttonsEnable()
        {
            foreach (Control control in actionsGroupBox.Controls)
                control.Enabled = true;
        }

        private bool isOneWord()
        {
            Regex r = new Regex("[A-Za-zА-Яа-я]+");
            return r.IsMatch(contentTextBox.Text);
        }

        private bool isTwoWords()
        {
            Regex r = new Regex("[A-Za-zА-Яа-я]+ [A-Za-zА-Яа-я]+");
            return r.IsMatch(contentTextBox.Text);
        }

        private string sourceFirstForm()
        {
            // get first form of source string
            var morphLib = new TA.Morph.MorphLib(contentTextBox.Text);
            return string.Join(" ", morphLib.ToMainForm());
        }
        #endregion

        private void buttonFreq_Click(object sender, EventArgs e)
        {
            // check format
            if (!isOneWord() && !isTwoWords())
            {
                MessageBox.Show("Неверный формат входной строки.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get first form of source string
            string sourceString = sourceFirstForm();

            // get frequency of words
            var freqLib = new TA.Statistic.Frequency(_words);
            int result = 0;
            if (isOneWord()) result = freqLib.GetByOneWord(sourceString);
            if (isTwoWords()) result = freqLib.GetByBigramm(sourceString);

            // print result
            resultTextBox.Text += string.Format("Поиск частоты [{0}]: {1} из {2}.\r\n", sourceString, result, _words.Count);
        }

        private void buttonMI_Click(object sender, EventArgs e)
        {
            // check format
            if (!isTwoWords())
            {
                MessageBox.Show("Неверный формат входной строки.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get first form of source string
            string sourceString = sourceFirstForm();

            // get result
            var muturalInf = new TA.Statistic.MutualInformation(_words);
            var result = muturalInf.Calculate(sourceString);

            // print result
            resultTextBox.Text += string.Format("Метод Mutural-Information [{0}]: {1}.\r\n", sourceString, result);
        }
    }
}
