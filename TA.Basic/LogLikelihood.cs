using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Basic
{
    /// <summary>
    /// Реализация статистического метода Log-Likelihood.
    /// </summary>
    public class LogLikelihood
    {
        private List<string> _words { set; get; }

        public LogLikelihood(List<string> words)
        {
            _words = words;
        }

        public double Calculate(string bigramm)
        {
            var bigrammWords = bigramm.Split(' ');
            if (bigrammWords.Count() != 2)
                throw new ArgumentException("Для оценки частоты биграммы необходимо два слова.");

            var otherBigrammsLeftLemm = _words.Where(t => t != bigrammWords[1]).Select(t => bigrammWords[0] + ' ' + t).ToList();
            var otherBigrammsRightLemm = _words.Where(t => t != bigrammWords[0]).Select(t => t + ' ' + bigrammWords[1]).ToList();
            var _wordsWithoutBigrammWords = _words.Where(t => !bigrammWords.Contains(t)).ToList();
            var otherBigramms = new List<string>(); //_wordsWithoutBigrammWords.SelectMany(t => _wordsWithoutBigrammWords, (t, w) => t + ' ' + w).ToList();
            for(int i = 0; i < _words.Count - 1; i++)
            {
                var otherBigrammText = _words[i] + " " + _words[i + 1];
                if (otherBigrammText != bigramm)
                    otherBigramms.Add(otherBigrammText);
            }

            Frequency freq = new Frequency(_words);
            var a = freq.GetByBigramm(bigramm);
            var b = otherBigrammsLeftLemm.Sum(t => freq.GetByBigramm(t));
            var c = otherBigrammsRightLemm.Sum(t => freq.GetByBigramm(t));
            var d = otherBigramms.Sum(t => freq.GetByBigramm(t));

            return a * Math.Log(a + 1)
                 + b * Math.Log(b + 1)
                 + c * Math.Log(c + 1)
                 + d * Math.Log(d + 1)
                 - (a + b) * Math.Log(a + b + 1)
                 - (a + c) * Math.Log(a + c + 1)
                 - (b + d) * Math.Log(b + d + 1)
                 - (c + d) * Math.Log(c + d + 1)
                 + (a + b + c + d) * Math.Log(a + b + c + d + 1);
        }
    }
}
