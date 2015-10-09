using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Morph
{
    internal class MystemWrapper
    {
        private List<string> _Run(string path)
        {
            var asseblyFile = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var mystemPath = Path.GetDirectoryName(asseblyFile) + @"\Ext\";
            var mystemFile = mystemPath + @"mystem.exe";
            var arguments = string.Format("-n -i \"{0}\"", path);

            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = mystemFile;
            p.StartInfo.Arguments = arguments;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            List<string> resultList = new List<string>();
            string output = p.StandardOutput.ReadLine();
            while (!string.IsNullOrEmpty(output))
            {
                resultList.Add(output);
                output = p.StandardOutput.ReadLine();
            }
            p.WaitForExit();
            return resultList;
        }

        public List<Word> GetFullInfo(string path)
        {
            var result = _Run(path);
            List<Word> resultList = new List<Word>();

            foreach (var wordString in result)
            {
                var word = _ProcessWord(wordString);
                if (word.HasValue)
                    resultList.Add(word.Value);
            }
            return resultList;
        }

        public Word? _ProcessWord(string wordString)
        {
            Word w = new Word();

            var descr = wordString.Split('{');
            if (descr.Length < 2)
                return null;

            var descrInt = descr[1].Substring(0, descr[1].Length - 1);

            if (descrInt.Contains("|"))
            {
                descrInt = descrInt.Split('|')[0];
            }

            if (descrInt.Contains("??"))
            {
                w.Text = descrInt.Substring(0, descrInt.Length - 2);
                return w;
            }

            var descrParts = descrInt.Split('=');
            if (string.IsNullOrEmpty(descrParts[0]))
                w.Text = descr[0];
            else
                w.Text = descrParts[0].ToUpper();

            var partOfSpeech = descrParts[1];
            if (partOfSpeech.Contains(","))
            {
                var commaPosition = partOfSpeech.IndexOf(',');
                w.PartOfSpeech = partOfSpeech.Substring(0, commaPosition);
                w.PartOfSpeechAddition = partOfSpeech.Substring(commaPosition + 1);
            }
            else
            {
                w.PartOfSpeech = partOfSpeech;
            }

            w.Text = w.Text.Replace("?", "");
            return w;
        }
    }
}
