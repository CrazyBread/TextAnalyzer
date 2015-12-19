using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TA.Morph;

namespace TA.Ontology
{
    public class OntologyLib
    {
        public List<OntoClass> OntoClassList = new List<OntoClass>();
        private string _PathToOntologyFile = string.Empty;

        public OntologyLib(string pathToOntologyFile)
        {
            _PathToOntologyFile = pathToOntologyFile;
        }

        public void ParseXmlData()
        {
            if (!File.Exists(_PathToOntologyFile))
                throw new Exception("Путь до файла с онтологией указан не верно.");
            string xmlString = File.ReadAllText(_PathToOntologyFile);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            _ParseOntoClassList(xmlDoc);
            _ParseOntoIndividualLemm(xmlDoc);
            _ParsSubClassOf(xmlDoc);
            _ModifyLemmState();
        }

        public string GetLemmByClass(string Name)
        {
            return Name.Replace("#", string.Empty).Replace("_", " ");
        }

        private void _ParseOntoClassList(XmlDocument xmlDoc)
        {
            XmlNodeList declarationList = xmlDoc.GetElementsByTagName("Declaration");

            foreach (XmlElement declaration in declarationList)
            {
                foreach (XmlElement childNode in declaration.ChildNodes)
                {
                    string className = childNode.Attributes["IRI"].Value;
                    OntoClassList.Add(new OntoClass
                    {
                        Name = className,
                        Lemm = GetLemmByClass(className)
                    });
                }
            }
        }

        private void _ParseOntoIndividualLemm(XmlDocument xmlDoc)
        {
            XmlNodeList dataPropList = xmlDoc.GetElementsByTagName("DataPropertyAssertion");

            foreach (XmlElement prop in dataPropList)
            {
                if (prop.InnerXml.Contains("#имеетЛемму"))
                {
                    string individualName = prop.ChildNodes[1].Attributes["IRI"].Value;
                    string lemm = prop.ChildNodes[2].InnerXml;
                    var ontoClassItem = OntoClassList.First(m => m.Name == individualName);
                    ontoClassItem.Lemm = lemm;
                }

            }
        }

        private void _ParsSubClassOf(XmlDocument xmlDoc)
        {

            XmlNodeList subClassOfList = xmlDoc.GetElementsByTagName("SubClassOf");

            foreach (XmlElement relation in subClassOfList)
            {
                string childClassName = relation.ChildNodes[0].Attributes["IRI"].Value;
                string parentClassName = relation.ChildNodes[0].Attributes["IRI"].Value;

                var childClassItem = OntoClassList.First(m => m.Name == childClassName);
                var parentClassItem = OntoClassList.First(m => m.Name == parentClassName);
                parentClassItem.Childrens.Add(childClassItem);
            }
        }

        private void _ModifyLemmState()
        {
            List<string> lemmList = OntoClassList.Select(m => m.Lemm).ToList();
            MorphLib morphLib = new MorphLib(lemmList);
            var morphList = morphLib.ToMainForm();
            for (int i = 0; i < OntoClassList.Count; i++)
            {
                OntoClassList[i].Lemm = morphList[i];
            }
        }
    }
}
