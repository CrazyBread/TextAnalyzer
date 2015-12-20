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
        private string _html;
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
            statusComboBox.Items.AddRange(statuses.Select(i => new ComboboxItem() { Id = i.Id, Name = i.Name }).ToArray());

            typeComboBox.Items.Add(new ComboboxItem() { Id = 1, Name = "На полночь дня" });
            typeComboBox.Items.Add(new ComboboxItem() { Id = 2, Name = "На интервал" });
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

        private void processButton_Click(object sender, EventArgs e)
        {
            var dateStart = dateStartPicker.Value;
            var dateEnd = dateEndPicker.Value;
            int statusId = (statusComboBox.SelectedItem is ComboboxItem) ? (statusComboBox.SelectedItem as ComboboxItem).Id : -1;
            var typeId = (typeComboBox.SelectedItem is ComboboxItem) ? (typeComboBox.SelectedItem as ComboboxItem).Id : -1;
            var interval = Convert.ToInt32(lengthNumericUpDown.Value);

            if (statusId < 1)
            {
                MessageBox.Show("Выберите статус задач из выпадающего списка.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (typeId < 1)
            {
                MessageBox.Show("Выберите необходимый алгоритм расчёта временного ряда.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateStart >= dateEnd)
            {
                MessageBox.Show("Дата начала должна быть раньше даты завершения расчётов.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateEnd - dateStart > new TimeSpan(366, 0, 0, 0, 0))
            {
                MessageBox.Show("Максимальная дата построения временного ряда - 1 год.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // form begining of report
            _html = "<html><head><meta charset='utf-8' /><title>report</title></head><body>";
            _html += "<h1>Отчёт о расчёте временного ряда</h1>";
            _html += string.Format("<em>Дата составления: {0:G}.</em>", DateTime.Now);
            _html += "<h2>Исходные данные</h2>";
            _html += string.Format("<p><strong>Тип расчёта:</strong> {0}.</p>", typeComboBox.SelectedItem.ToString());
            _html += string.Format("<p><strong>Статус задач:</strong> {0}.</p>", statusComboBox.SelectedItem.ToString());
            _html += string.Format("<p><strong>Дата начала:</strong> {0:g}.</p>", dateStart);
            _html += string.Format("<p><strong>Дата окончания:</strong> {0:g}.</p>", DateTime.Now); // yes, I know...
            _html += string.Format("<p><strong>{0} (дней):</strong> {1}.</p>", (typeId == 1 ? "Промежуток между измерениями" : "Интервал"), interval);

            // process and fill report
            _html += "<h2>Результаты</h2>";
            if (typeId == 1)
                processMoment(statusId, dateStart, dateEnd, interval);
            if (typeId == 2)
                processInterval(statusId, dateStart, dateEnd, interval);
            _html += "</body></html>";

            // save into file report
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "HTML|*.html";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dialog.FileName, _html);
                MessageBox.Show("Документ успешно сохранён", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Документ не был сохранён", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void processMoment(int statusId, DateTime start, DateTime end, int interval)
        {
            using (var db = new Connector.Redmine.Model.dbEntities())
            {
                db.Database.CommandTimeout = 600;
                var result = db.TimelineGetMoment(start, interval).ToList().Where(i => i.StatusId == statusId);
            }
        }
        private void processInterval(int statusId, DateTime start, DateTime end, int interval)
        {
            using (var db = new Connector.Redmine.Model.dbEntities())
            {
                db.Database.CommandTimeout = 600;
                var result = db.TimelineGetIntervalChange(start, interval, statusId).ToList();
            }
        }
    }
}
