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
        public AnalysisOntologyForm()
        {
            InitializeComponent();
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
                    OntologyLib ontologyLib = new OntologyLib(od.FileName);
                    ontologyLib.ParseXmlData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
