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
    public partial class MainForm : Form
    {
        private List<string> _words;

        public MainForm()
        {
            InitializeComponent();
        }

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
            var freq = new TA.Basic.Frequency(_words);
            var resultString = string.Join("\r\n", freq.Process().Take(20).Select(i => i.word + " — " + i.count));
            MessageBox.Show(resultString);
        }

        private void mutualInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mutInf = new TA.Basic.MutualInformation(_words);
            var result = mutInf.Calculate(textBoxBigramm.Text.ToUpper());
            MessageBox.Show(result.ToString());
        }

        private void buttonBigrammFind_Click(object sender, EventArgs e)
        {
            double resultCoef = 0.0;
            string resultBigramm = string.Empty;
            var mutInf = new TA.Basic.MutualInformation(_words);

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

            textBoxBigramm.Text = resultBigramm;
            MessageBox.Show(resultCoef.ToString());
        }

        private void morphologicalAnalisysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void fillWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var issues = TA.Connector.Redmine.Connector.GetAllIssues();

            foreach (var issue in issues)
            {
                System.Diagnostics.Trace.WriteLine(issue.RedmineId);

                var morphLib = new TA.Morph.MorphLib(issue.Description);
                var wrds = morphLib.Filter("V", "S", "A", "ANUM", "APRO", "NUM", "SPRO", "ADV");
                var wrdsFreq = new Basic.Frequency(wrds);
                var wrdsFreqResult = wrdsFreq.Process();
                foreach (var word in wrdsFreqResult)
                {
                    TA.Connector.Redmine.WordCollector.Collect(issue.Id, word.word, word.count);
                }
                TA.Connector.Redmine.WordCollector.Submit();
            }
        }

        private void buttonClasterize_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var text = System.IO.File.ReadAllText(dialog.FileName);
                var morphLib = new TA.Morph.MorphLib(text);
                var firstFormWords = morphLib.Filter("S", "A");
                var firstFormString = string.Join(" ", firstFormWords);

                var method1 = new TA.Basic.MutualInformation(firstFormWords);
                var method2 = new TA.Basic.TScore(firstFormWords);
                var method3 = new TA.Basic.LogLikelihood(firstFormWords);

                var clasterItems = new List<Core.ClasterItem>();
                for (int i = 0; i < firstFormWords.Count - 1; i++)
                {
                    var clasterItemText = firstFormWords[i] + " " + firstFormWords[i + 1];
                    if (clasterItems.Any(j => j.Item.ToString() == clasterItemText))
                        continue;
                    var m1 = method1.Calculate(clasterItemText);
                    var m2 = method2.Calculate(clasterItemText);
                    var m3 = method3.Calculate(clasterItemText);
                    var clasterItem = new Core.ClasterItem(3) { Item = clasterItemText };
                    clasterItem.SetValue(0, m1);
                    clasterItem.SetValue(1, m2);
                    clasterItem.SetValue(2, m3);
                    clasterItems.Add(clasterItem);
                }

                var clasterizeBigrams = new TA.Core.ClasterizeBigram(text, clasterItems);
                clasterizeBigrams.Run();
                clasterizeBigrams.PrintResult(@"d:\result.txt");
            }
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Connector.Redmine.IssueLoader ir = new Connector.Redmine.IssueLoader(new Connector.Redmine.RedmineConfigurator()
            {
                Link = "http://redmine.aisgorod.ru",
                Key = "3a2901bd622185835374cb45e9c98a58644df40f"
            });
            ir.Run();
        }
    }
}
