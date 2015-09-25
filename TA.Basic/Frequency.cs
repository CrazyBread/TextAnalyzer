using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Basic
{
    public struct FrequencyItem
    {
        public FrequencyItem(string w, int c)
        {
            word = w;
            count = c;
        }

        public string word;
        public int count;
    }

    /// <summary>
    /// Реализация статистического метода Frequency.
    /// </summary>
    public class Frequency
    {
        private List<string> _words { set; get; }

        public Frequency(List<string> words)
        {
            _words = words;
        }

        public List<FrequencyItem> Process()
        {
            var stats = _words
                .GroupBy(i => i, i => i, (i, j) => new FrequencyItem(i, j.Count()))
                .OrderByDescending(i => i.count)
                .ToList();
            return stats;
        }

        /// <summary>
        /// Получить частоту одного слова
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int GetByOneWord(string word)
        {
            var freqList = Process();
            if (!freqList.Any(i => i.word == word))
                return 0;
            return freqList.First(i => i.word == word).count;
        }

        /// <summary>
        /// Получить частоту биграммы (двух слов)
        /// </summary>
        /// <param name="bigramm"></param>
        /// <returns></returns>
        public int GetByBigramm(string bigramm)
        {
            var bigrammWords = bigramm.Split(' ');
            if (bigrammWords.Count() != 2)
                throw new ArgumentException("Для оценки частоты биграммы необходимо два слова.");

            int cntr = 0;
            for (int i = 0; i < _words.Count - 1; i++)
            {
                if (_words[i] == bigrammWords[0] && _words[i + 1] == bigrammWords[1])
                    ++cntr;
            }
            return cntr;
        }
    }
}
