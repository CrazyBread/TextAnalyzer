using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Ontology
{
    public class FindOntoResult
    {
        public List<OntoClass> findedList = new List<OntoClass>();
        public List<OntoClass> findedFazyList = new List<OntoClass>();
        public bool isTerm {
            get {
                return findedList != null && findedList.Any();
            }
        }
        public Dictionary<OntoClass, decimal> probabilityIsTermDicrionary
        {
            get {
                return findedFazyList.ToDictionary(n=> n, m => (decimal)((decimal)1 / (decimal)m.Lemm.Split(' ').Count()));
            }
        }
    }
}
