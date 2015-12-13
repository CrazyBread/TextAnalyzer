using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Statistic
{
    /// <summary>
    /// Реализация статистического метода TF*IDF.
    /// </summary>
    public class TfIdf
    {
        private List<string> _words { set; get; }

        public TfIdf(List<string> words)
        {
            _words = words;
        }

        public double Calculate(string word)
        {
            throw new NotImplementedException();
            //Frequency freq = new Frequency(_words);
            //double f = freq.GetByOneWord(word);
            //double TF = f / _words.Count;
            //double IDF = 0;
            //return TF * IDF;
        }
    }
}
