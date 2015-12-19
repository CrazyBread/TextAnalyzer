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

        public AnalysisStatisticForm(List<string> words, Connector.Redmine.Model.Issue task)
        {
            InitializeComponent();
            Logger.TextChanged += (sender, e) => 
            {
                resultTextBox.Text = e;
            };
            resultTextBox.TextChanged += (sender, e) =>
            {
                resultTextBox.SelectionStart = resultTextBox.TextLength;
                resultTextBox.ScrollToCaret();
            };
            _words = words;
            _task = task;
            Logger.LogHtml("<h1>Статистический анализ</h1>");
            Logger.LogText("Статистический анализ");

            // get frequency of words
            var freqLib = new TA.Statistic.Frequency(_words);
            var orderedWords = freqLib.Process().OrderByDescending(i => i.count);

            // log it
            Logger.LogHtml("<h2>Частота употребления слов</h2><ul>");
            Logger.LogText("ЧАСТОТА УПОТРЕБЛЕНИЯ СЛОВ:");
            foreach (var item in orderedWords)
            {
                Logger.LogHtml(string.Format("<li><strong>{0}</strong> — {1}</li>", item.word, item.count));
                Logger.LogText(string.Format("  {0} — {1}", item.word, item.count));
            }
            resultTextBox.Text += "\r\n";
            Logger.LogHtml("</ul>");
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
                    var wrds = morphLib.ToMainForm("S", "A");//, "V", "ANUM", "APRO", "NUM", "SPRO", "ADV");
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
            Logger.LogText(string.Format("Поиск частоты [{0}]: {1} из {2}.", sourceString, result, _words.Count));
            Logger.LogHtml(string.Format("<p><strong>Поиск частоты [{0}]:</strong> {1} из числа слов: {2}.</p>", sourceString, result, _words.Count));
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
            Logger.LogText(string.Format("Метод Mutural-Information [{0}]: {1}.", sourceString, result));
            Logger.LogHtml(string.Format("<p><strong>Метод Mutural-Information [{0}]:</strong> {1}.</p>", sourceString, result));
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
            Logger.LogText(string.Format("Метод T-Score [{0}]: {1}.", sourceString, result));
            Logger.LogHtml(string.Format("<p><strong>Метод T-Score [{0}]:</strong> {1}.</p>", sourceString, result));
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
            Logger.LogText(string.Format("Метод Log-Likelihood [{0}]: {1}.", sourceString, result));
            Logger.LogHtml(string.Format("<p><strong>Метод Log-Likelihood [{0}]:</strong> {1}.</p>", sourceString, result));
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
            Logger.LogText(string.Format("Метод TF*IDF [{0}]: {1}.", sourceString, result));
            Logger.LogHtml(string.Format("<p><strong>Метод TF*IDF [{0}]:</strong> {1}.</p>", sourceString, result));
        }

        #region other stuff
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
