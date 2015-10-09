using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TA.Connector.File
{
    /// <summary>
    /// Позполяет получить текст из файла.
    /// </summary>
    public class FileLoader
    {
        public List<string> Words { set; get; }

        /// <summary>
        /// Загружает список слов из файла.
        /// </summary>
        /// <param name="path">Путь до файла.</param>
        public FileLoader Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Путь до файла должен быть заполнен.");
            Words = System.IO.File.ReadAllText(path).Split(' ', '\r', '\n').Where(i => i.Length > 0).ToList();
            if (Words.Count == 0)
                throw new ArgumentException("В файле нет слов.");
            return this;
        }

        /// <summary>
        /// Удаляет ненужные символы (знаки препинания и другие ненужные символы).
        /// </summary>
        public FileLoader RemoveUselessChars()
        {
            Words = Words.Select(i => Regex.Replace(i, "[^A-Za-zА-Яа-я]", string.Empty)).Where(i => i.Length > 0).ToList();
            return this;
        }

        /// <summary>
        /// Преобразует все слова к нижнему регистру.
        /// </summary>
        public FileLoader ToUpperCase()
        {
            Words = Words.Select(i => i.ToUpper()).ToList();
            return this;
        }
    }
}
