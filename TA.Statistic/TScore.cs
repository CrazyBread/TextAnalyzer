using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Statistic
{
    public class TScore
    {
        private List<string> _words { set; get; }

        public TScore(List<string> words)
        {
            _words = words;
        }

        public double Calculate(string bigramm)
        {
            var bigrammWords = bigramm.Split(' ');
            if (bigrammWords.Count() != 2)
                throw new ArgumentException("Для оценки частоты биграммы необходимо два слова.");

            Frequency freq = new Frequency(_words);
            double f1 = freq.GetByOneWord(bigrammWords[0]);
            double f2 = freq.GetByOneWord(bigrammWords[1]);
            double f12 = freq.GetByBigramm(bigramm);

            return (f12 - f1 * f2 / (_words.Count - 1)) / Math.Pow(f12, 2);
        }
    }
}
