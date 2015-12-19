using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.GUI
{
    public static class Logger
    {
        private static string _text = string.Empty;
        private static string _html = string.Empty;

        public static void LogText(string text)
        {
            _text += text + "\r\n";
            if(TextChanged != null)
                TextChanged(null, _text);
        }

        public static void LogHtml(string text)
        {
            _html += text;
            if(HtmlChanged != null)
                HtmlChanged(null, _html);
        }

        public static void SaveText(string fileName)
        {
            System.IO.File.WriteAllText(fileName, _text);
        }

        public static void SaveHtml(string fileName)
        {
            System.IO.File.WriteAllText(fileName, "<!DOCTYPE html><html><head><meta charset=\"utf-8\" /><title>log</title></head><body>" + _html + "</body></html>");
        }

        public static event EventHandler<string> TextChanged;
        public static event EventHandler<string> HtmlChanged;
    }
}
