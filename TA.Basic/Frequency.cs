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
    }
}
