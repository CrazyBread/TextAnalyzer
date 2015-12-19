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

                    ontologyResult_richTextBox.Text += "\n\nФайл с онтологией успено разобран.\n\n";
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
            ontologyResult_richTextBox.Text += string.Format("\n\nИсходный тест задачи:\n{0}\n\n", _task.Description);
            foreach (var item in _words.Distinct())
            {
                words_listBox.Items.Add(item);
            }
        }

        private void checkWord_button_Click(object sender, EventArgs e)
        {
            string selectedWord = words_listBox.SelectedItem.ToString();
            
            FindOntoResult findResult = _ontologiLib.FindWord(selectedWord);
            string resultText = string.Empty;

            resultText += string.Format("\nСлово \"{0}\"{1} является термином.\n", selectedWord, findResult.isTerm ? string.Empty : " не");
            if (findResult.findedList.Any())
            {
                resultText += string.Format("\nВ онтологии были\b точно\b найдены объекты:\n");
                foreach(var item in findResult.findedList)
                {
                    resultText += string.Format("\n\t Название: {0}\n\t Лемма: {1}\n", item.Name, item.Lemm);
                }
                resultText += "\n";
            }
            if (findResult.findedFazyList.Any())
            {
                resultText += string.Format("\nВозможно слово \"{0}\" относится к объектам:\n", selectedWord);
                foreach (var item in findResult.findedFazyList)
                {
                    resultText += string.Format("\n\t Название: {0}\n\t Лемма: {1}\n\t Вероятность совпадения: {2:0.000}\n", item.Name, item.Lemm, findResult.probabilityIsTermDicrionary[item]);
                }
                resultText += "\n";
            }
            ontologyResult_richTextBox.Text += resultText;

            ontologyResult_richTextBox.SelectionStart = ontologyResult_richTextBox.Text.Length;
            ontologyResult_richTextBox.ScrollToCaret();
        }
    }
}
