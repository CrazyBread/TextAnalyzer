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
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            string who = "Моисеевым Владиславом, Прохоровым Евгением, Храмковым Евгением";
            string group = "ПИмд-11 (2015)";
            string body = "Программа разработана {0}.\nГруппа — {1}.";
            MessageBox.Show(string.Format(body, who, group), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonAStatistic_Click(object sender, EventArgs e)
        {
            new AnalysisStatisticForm().ShowDialog();
        }

        private void buttonAMorph_Click(object sender, EventArgs e)
        {
            new AnalysisMorphForm().ShowDialog();
        }

        private void buttonAClaster_Click(object sender, EventArgs e)
        {
            new AnalysisClasterForm().ShowDialog();
        }

        private void buttonAOnth_Click(object sender, EventArgs e)
        {
            new AnalysisOnthForm().ShowDialog();
        }

        private void buttonATimeline_Click(object sender, EventArgs e)
        {
            new AnalysisTimelineForm().ShowDialog();
        }
    }
}
