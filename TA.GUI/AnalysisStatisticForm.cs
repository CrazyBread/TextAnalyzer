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

        private void buttonTScore_Click(object sender, EventArgs e)
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
            var tScore = new TA.Statistic.TScore(_words);
            var result = tScore.Calculate(sourceString);

            // print result
            resultTextBox.Text += string.Format("Метод T-Score [{0}]: {1}.\r\n", sourceString, result);
        }

        private void buttonLogLikehood_Click(object sender, EventArgs e)
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
            var logLikeihood = new TA.Statistic.LogLikelihood(_words);
            var result = logLikeihood.Calculate(sourceString);

            // print result
            resultTextBox.Text += string.Format("Метод Log-Likelihood [{0}]: {1}.\r\n", sourceString, result);
        }

        private void buttonTfIdf_Click(object sender, EventArgs e)
        {
            // check format
            if (!isOneWord())
            {
                MessageBox.Show("Неверный формат входной строки.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get first form of source string
            string sourceString = sourceFirstForm();

            // get other data
            int collectionLength = 0;
            int usedCount = 0;
            using (var db = new Connector.Redmine.Model.dbEntities())
            {
                collectionLength = db.Words.Where(i => i.WordsInText == 1).Sum(i => i.Count);
                usedCount = db.Words.Where(i => i.Text == sourceString).Sum(i => i.Count);
            }

            // get result
            var tfIdf = new TA.Statistic.TfIdf(_words);
            var result = tfIdf.Calculate(sourceString, collectionLength, usedCount);

            // print result
            resultTextBox.Text += string.Format("Метод TF*IDF [{0}]: {1}.\r\n", sourceString, result);
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
    }
}
