using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Connector.Redmine
{
    public static class WordCollector
    {
        private static List<Model.Word> _cache;

        public static void Submit()
        {
            using (var _context = new Model.dbEntities())
            {
                foreach (var word in _cache)
                {
                    if (!_context.Words.Any(i => i.Text == word.Text && i.IssueId == word.IssueId))
                    {
                        _context.Words.Add(word);
                    }
                    else
                    {
                        var entity = _context.Words.First(i => i.Text == word.Text && i.IssueId == word.IssueId);
                        entity.Count += word.Count;
                    }
                }

                _cache.Clear();
                _context.SaveChanges();
            }
        }

        public static void Collect(int issueId, string text, int count, int wordsInText)
        {
            if (_cache == null)
                _cache = new List<Model.Word>();

            var wordItem = new Model.Word() { IssueId = issueId, Text = text, Count = count, WordsInText = wordsInText, Created = DateTime.Now };

            var _cacheItem = _cache.FirstOrDefault(i => i.IssueId == wordItem.IssueId && i.Text == wordItem.Text);
            if (_cacheItem != null)
                _cacheItem.Count += count;
            else
                _cache.Add(wordItem);
        }
    }
}
