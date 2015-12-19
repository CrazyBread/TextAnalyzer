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
    public partial class AnalysisClasterForm : Form
    {
        private List<string> _words;
        private Connector.Redmine.Model.Issue _task;

        public AnalysisClasterForm(List<string> words, Connector.Redmine.Model.Issue task)
        {
            InitializeComponent();
            _words = words;
            _task = task;
        }

        private void buttonClasterize_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var text = System.IO.File.ReadAllText(dialog.FileName);
                var morphLib = new TA.Morph.MorphLib(text);
                var firstFormWords = morphLib.ToMainForm("S", "A");
                var firstFormString = string.Join(" ", firstFormWords);

                var method1 = new TA.Statistic.MutualInformation(firstFormWords);
                var method2 = new TA.Statistic.TScore(firstFormWords);
                var method3 = new TA.Statistic.LogLikelihood(firstFormWords);

                var clasterItems = new List<Claster.ClasterItem>();
                for (int i = 0; i < firstFormWords.Count - 1; i++)
                {
                    var clasterItemText = firstFormWords[i] + " " + firstFormWords[i + 1];
                    if (clasterItems.Any(j => j.Item.ToString() == clasterItemText))
                        continue;
                    var m1 = method1.Calculate(clasterItemText);
                    var m2 = method2.Calculate(clasterItemText);
                    var m3 = method3.Calculate(clasterItemText);
                    var clasterItem = new Claster.ClasterItem(3) { Item = clasterItemText };
                    clasterItem.SetValue(0, m1);
                    clasterItem.SetValue(1, m2);
                    clasterItem.SetValue(2, m3);
                    clasterItems.Add(clasterItem);
                }

                var clasterizeBigrams = new TA.Claster.ClasterizeBigram(text, clasterItems);
                clasterizeBigrams.Run();
                clasterizeBigrams.PrintResult(@"d:\result.txt");
            }
        }
    }
}
