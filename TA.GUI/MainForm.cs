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
        private Connector.Redmine.Model.Issue _task;

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
            new AnalysisStatisticForm(_words, _task).ShowDialog();
        }

        private void buttonAMorph_Click(object sender, EventArgs e)
        {
            new AnalysisMorphForm(_words, _task).ShowDialog();
        }

        private void buttonAClaster_Click(object sender, EventArgs e)
        {
            new AnalysisClasterForm(_words, _task).ShowDialog();
        }

        private void buttonAOnth_Click(object sender, EventArgs e)
        {
            new AnalysisOntologyForm(_words, _task).ShowDialog();
        }

        private void buttonATimeline_Click(object sender, EventArgs e)
        {
            new AnalysisTimelineForm().ShowDialog();
        }

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
                MessageBox.Show("Задача не выбрана.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            taskButton.Enabled = false;

            _task = Connector.Redmine.Connector.GetIssue(taskId.Value);
            taskTextBox.Text = string.Format("[#{0}] {1}", _task.RedmineId, _task.Subject);
            Logger.LogHtml(string.Format("<h1>Выбор задачи</h1><p>Была выбрана задача <strong>#{0} {1}</strong>.</p>", _task.RedmineId, _task.Subject));
            Logger.LogText(string.Format("Была выбрана задача #{0} {1}.", _task.RedmineId, _task.Subject));

            // write task details into html log
            Logger.LogHtml("<h2>Информация о задаче</h2><ul>");
            Logger.LogHtml(string.Format("<li><strong>Идентификатор</strong> — {0}.</li>", _task.RedmineId));
            Logger.LogHtml(string.Format("<li><strong>Название</strong> — {0}.</li>", _task.Subject));
            Logger.LogHtml(string.Format("<li><strong>Дата создания</strong> — {0}.</li>", _task.Created.ToString("G")));
            Logger.LogHtml(string.Format("<li><strong>Проект</strong> — {0}.</li>", _task.Project.Name));
            Logger.LogHtml(string.Format("<li><strong>Статус</strong> — {0}.</li>", _task.Status.Name));
            Logger.LogHtml(string.Format("<li><strong>Назначена</strong> — {0}.</li>", _task.AssigneeId.HasValue ? _task.Assignee.Name : "-"));
            Logger.LogHtml("<p>" + _task.Description + "</p>");
            Logger.LogHtml("</ul>");

            // get words array
            var morphLib = new TA.Morph.MorphLib(_task.Description.ToUpper());
            _words = morphLib.ToMainForm("S", "A");
            var taskFirstForm = string.Join(" ", _words);
            Logger.LogHtml(string.Format("<h1>Начальная форма слов</h1><p>{0}</p>", taskFirstForm));
            Logger.LogText(string.Format("Начальная форма слов — {0}.", taskFirstForm));

            foreach (Control item in groupBoxActions.Controls)
            {
                if (!item.Enabled)
                    item.Enabled = true;
            }
        }

        private void saveLogHtmlButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "HTML|*.html";
            if(dialog.ShowDialog() == DialogResult.OK) {
                Logger.SaveHtml(dialog.FileName);
            }
        }
    }
}
