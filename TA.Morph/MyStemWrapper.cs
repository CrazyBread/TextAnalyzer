using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Morph
{
#warning Make this class internal
    /*internal*/public class MystemWrapper
    {
        private void _Run(string path)
        {
            var asseblyFile = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var mystemPath = Path.GetDirectoryName(asseblyFile) + @"\Libraries\";
            var mystemFile = mystemPath + @"mystem.exe";
            var arguments = string.Format("\"{0}\"", path);

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = mystemFile;
            p.StartInfo.Arguments = arguments;
            p.Start();
            string output = p.StandardOutput.ReadLine();
            p.WaitForExit();
        }
    }
}
