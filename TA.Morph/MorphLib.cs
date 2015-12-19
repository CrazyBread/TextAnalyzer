using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Morph
{
    /// <summary>
    /// Библиотека, реализующая основной функционал для морфологического анализа
    /// </summary>
    public class MorphLib
    {
        List<string> _words;
        string _sourceString;

        public MorphLib(List<string> words)
        {
            _words = words;
        }

        public MorphLib(string sourceString)
        {
            _sourceString = sourceString;
        }

        private List<Word> _GetWordsInfo()
        {
            // null check
            if (string.IsNullOrEmpty(_sourceString) && (_words == null || _words.Count == 0))
                return new List<Word>();

            var tempFileName = Path.GetTempFileName();
            if (string.IsNullOrEmpty(_sourceString))
            {
                var inputString = string.Join(" ", _words);
                File.WriteAllText(tempFileName, inputString);
            }
            else
            {
                File.WriteAllText(tempFileName, _sourceString);
            }

            var mystemWrapper = new MystemWrapper();
            var result = mystemWrapper.GetFullInfo(tempFileName);

            File.Delete(tempFileName);
            return result;
        }

        /// <summary>
        /// Приведение слов к начальной форме
        /// </summary>
        /// <returns></returns>
        public List<string> ToMainForm()
        {
            return _GetWordsInfo().Select(i => i.Text).ToList();
        }

        /// <summary>
        /// Возвращает слова только определённых частей речи
        /// </summary>
        /// <param name="partOfSpeech">Разрешённые части речи из mystem</param>
        /// <returns></returns>
        public List<string> Filter(params string[] partOfSpeech)
        {
            return _GetWordsInfo().Where(i => partOfSpeech.Contains(i.PartOfSpeech)).Select(i => i.Text).ToList();
        }
    }
}
