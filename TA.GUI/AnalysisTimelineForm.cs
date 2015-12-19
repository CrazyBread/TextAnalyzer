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
    public partial class AnalysisTimelineForm : Form
    {
        private class ComboboxItem
        {
            public int Id { set; get; }
            public string Name { set; get; }
            public override string ToString() { return Name; }
        }

        public AnalysisTimelineForm()
        {
            InitializeComponent();
        }

        private void AnalysisTimelineForm_Load(object sender, EventArgs e)
        {
            var statuses = Connector.Redmine.Connector.GetAllStatuses();
            comboBoxStatuses.Items.AddRange(statuses.Select(i => new ComboboxItem() { Id = i.Id, Name = i.Name }).ToArray());
        }

        private void taskSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connector.Redmine.IssueLoader issueLoader = new Connector.Redmine.IssueLoader(new Connector.Redmine.RedmineConfigurator()
            {
                Link = "http://redmine.aisgorod.ru",
                Key = "3a2901bd622185835374cb45e9c98a58644df40f"
            });
            issueLoader.Run();
        }

        private void journalSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connector.Redmine.IssueLoader issueLoader = new Connector.Redmine.IssueLoader(new Connector.Redmine.RedmineConfigurator()
            {
                Link = "http://redmine.aisgorod.ru",
                Key = "3a2901bd622185835374cb45e9c98a58644df40f"
            });
            issueLoader.RunJournals();
        }
    }
}
