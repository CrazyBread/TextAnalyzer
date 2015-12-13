using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Statistic
{
    /// <summary>
    /// Реализация статистического метода Mutual Information.
    /// </summary>
    public class MutualInformation
    {
        private List<string> _words;

        public MutualInformation(List<string> words)
        {
            _words = words;
        }

        /// <summary>
        /// Вычисляет коэффициент взаимной информации
        /// </summary>
        /// <param name="bigramm"></param>
        /// <returns></returns>
        public double Calculate(string bigramm)
        {
            var freq = new Frequency(_words);
            var bigramWords = bigramm.Split(' ');

            var f1 = freq.GetByOneWord(bigramWords[0]);
            var f2 = freq.GetByOneWord(bigramWords[1]);
            var f12 = freq.GetByBigramm(bigramm);

            return Math.Log(((double)f12 * N) / (f1 * f2), 2);
        }

        private int N { get { return _words.Count; } }
    }
}
