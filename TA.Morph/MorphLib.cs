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

        public MorphLib(List<string> words)
        {
            _words = words;
        }

        /// <summary>
        /// Приведение слов к начальной форме
        /// </summary>
        /// <returns></returns>
        public List<string> ToMainForm()
        {
            var inputString = string.Join(" ", _words);
            var tempFileName = @"D:\taText.tmp"; //Path.GetTempFileName();
            File.WriteAllText(tempFileName, inputString);

            var mystemWrapper = new MystemWrapper();
            var result = mystemWrapper.GetFullInfo(tempFileName);

            File.Delete(tempFileName);
            return result;
        }
    }
}
