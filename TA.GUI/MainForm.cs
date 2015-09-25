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
                var loader = new TA.Core.Loader();
                loader.Load(dialog.FileName).RemoveUselessChars().ToUpperCase();
                _words = loader.Words;

                statisticAnalisysToolStripMenuItem.Enabled = true;
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
    }
}
