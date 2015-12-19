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
    public partial class RedmineTaskSelector : Form
    {
        public int? TaskId { protected set; get; }

        public RedmineTaskSelector()
        {
            InitializeComponent();
            TaskId = null;
        }

        private void RedmineTaskSelector_Load(object sender, EventArgs e)
        {
            // add columns
            tasksDataGridView.Columns.Add("redmineId", "ИД");
            tasksDataGridView.Columns.Add("title", "Заголовок");
            tasksDataGridView.Columns.Add("assignee", "Назначена");
            tasksDataGridView.Columns.Add("status", "Статус");

            // tweak out view
            tasksDataGridView.Columns[1].Width *= 4;
            tasksDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tasksDataGridView.MultiSelect = false;

            // add rows
            var issues = Connector.Redmine.Connector.GetAllIssues();
            foreach (var issue in issues)
                tasksDataGridView.Rows.Add(issue.RedmineId, issue.Subject, issue.AssigneeId.HasValue ? issue.Assignee.Name : "-", issue.Status.Name);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            var selectedRows = tasksDataGridView.SelectedRows;
            if(selectedRows.Count == 1)
            {
                var selectedRow = selectedRows[0];
                TaskId = int.Parse(selectedRow.Cells[0].Value.ToString());
                this.Close();
                return;
            }
            MessageBox.Show("Ничего не выбрано.");
        }
    }
}
