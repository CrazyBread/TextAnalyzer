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
        private string _Run(string path)
        {
            var asseblyFile = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var mystemPath = Path.GetDirectoryName(asseblyFile) + @"\Ext\";
            var mystemFile = mystemPath + @"mystem.exe";
            var arguments = string.Format("\"{0}\"", path);

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = mystemFile;
            p.StartInfo.Arguments = arguments;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();
            string output = p.StandardOutput.ReadLine();
            p.WaitForExit();

            return output;
        }

        public List<string> GetFullInfo(string path)
        {
            var result = _Run(path);
            var stringResult = result.Split(new char[] { '}' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i
                    .Substring(i.IndexOf('{') + 1)
                    .Split(new char[] { '|', '?' })[0]
                    .ToUpper())
                .ToList();
            return stringResult;
        }
    }
}
