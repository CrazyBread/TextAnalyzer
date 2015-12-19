using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Ontology
{
    public class OntoClass
    {
        public string Name { get; set; }
        public string Lemm { get; set; }
        public List<OntoClass> Childrens { get; set; } = new List<OntoClass>();
        public bool HasChildrens
        {
            get
            {
                return Childrens.Any();
            }
        }
    }
}
