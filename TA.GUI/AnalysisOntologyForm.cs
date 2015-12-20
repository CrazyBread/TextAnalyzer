using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TA.Ontology;

namespace TA.GUI
{
    public partial class AnalysisOntologyForm : Form
    {
        private List<string> _words;
        private Connector.Redmine.Model.Issue _task;
        private OntologyLib _ontologiLib;

        public AnalysisOntologyForm(List<string> words, Connector.Redmine.Model.Issue task)
        {
            InitializeComponent();

            Logger.TextChanged += (sender, e) =>
            {
                ontologyResult_richTextBox.Text = e;
            };
            ontologyResult_richTextBox.TextChanged += (sender, e) =>
            {
                ontologyResult_richTextBox.SelectionStart = ontologyResult_richTextBox.TextLength;
                ontologyResult_richTextBox.ScrollToCaret();
            };

            Logger.LogHtml("<h1>Онтологический анализ</h1>");
            Logger.LogText("Онтологический анализ");
            _words = words;
            _task = task;
        }

        private void selectOntologyFile_Button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog();
                od.Filter = "Файлы-онтологии|*.owl";
                od.Title = "Выберите файл с онтологией";
                if (od.ShowDialog() == DialogResult.OK)
                {
                    string xmlString = File.ReadAllText(od.FileName);
                    _ontologiLib = new OntologyLib(od.FileName);
                    selectOntologyFile_Button.Enabled = false;
                    _ontologiLib.ParseXmlData();
                    
                    Logger.LogText("\nФайл с онтологией успено разобран.\n\n");
                    ontologyResult_richTextBox.SelectionStart = ontologyResult_richTextBox.Text.Length;
                    ontologyResult_richTextBox.ScrollToCaret();

                    words_listBox.Enabled = checkWord_button.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AnalysisOntologyForm_Load(object sender, EventArgs e)
        {
            Logger.LogText(string.Format("\n\nИсходный тест задачи:\n{0}\n\n", _task.Description));

            foreach (var item in _words.Distinct())
            {
                words_listBox.Items.Add(item);
            }
        }

        private void checkWord_button_Click(object sender, EventArgs e)
        {
            string selectedWord = words_listBox.SelectedItem.ToString();
            
            FindOntoResult findResult = _ontologiLib.FindWord(selectedWord);

            Logger.LogHtml(string.Format("<h3>Слово \"{0}\"{1} является термином.</h3>", selectedWord, findResult.isTerm ? string.Empty : " не"));
            Logger.LogText(string.Format("\nСлово \"{0}\"{1} является термином.\n", selectedWord, findResult.isTerm ? string.Empty : " не"));
            
            if (findResult.findedList.Any())
            {
                Logger.LogHtml(string.Format("<p>В онтологии были точно найдены объекты:</p>"));
                Logger.LogText(string.Format("\nВ онтологии были\b точно\b найдены объекты:\n"));

                Logger.LogHtml("<ul>");
                foreach (var item in findResult.findedList)
                {
                    Logger.LogHtml(string.Format("<li>Название: {0} Лемма: {1}</li>", item.Name, item.Lemm));
                    Logger.LogText(string.Format("\n\t Название: {0}\n\t Лемма: {1}\n", item.Name, item.Lemm));
                }
                Logger.LogHtml("</ul>");
                ontologyResult_richTextBox.Text += "\n";
            }
            if (findResult.findedFazyList.Any())
            {
                Logger.LogHtml(string.Format("<p>Возможно слово \"{0}\" относится к объектам:</p>", selectedWord));
                Logger.LogText(string.Format("\nВозможно слово \"{0}\" относится к объектам:\n", selectedWord));

                Logger.LogHtml("<ul>");
                foreach (var item in findResult.findedFazyList)
                {
                    Logger.LogHtml(string.Format("<li>Название: {0}\n\t Лемма: {1}\n\t Вероятность совпадения: {2:0.000}</li>", item.Name, item.Lemm, findResult.probabilityIsTermDicrionary[item]));
                    Logger.LogText(string.Format("\n\t Название: {0}\n\t Лемма: {1}\n\t Вероятность совпадения: {2:0.000}\n", item.Name, item.Lemm, findResult.probabilityIsTermDicrionary[item]));
                }
                Logger.LogHtml("</ul>");
                ontologyResult_richTextBox.Text  += "\n";
            }
        }
    }
}
