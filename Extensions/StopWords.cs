using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextReader.Extensions
{
    class StopWords
    {
        private List<string> _stopList = new List<string>();
        private List<string> _remainingWords = new List<string>();
        private string _filePath = "";
        private string _name;
        private PorterStemmer _wordStemmer = new PorterStemmer();
        private string _resultingString = "";
        public StopWords(string path, List<string> list)
        {
            _filePath = path;
            _stopList = list;
            var temp = path.Split("\\");
            _name = temp.Last();
            //Steps
            ReadInFile();
            RemoveNonAlphaCharaters();
            RemoveStopWords();
            StemRemainingWords();
            CountOccur();
        }

        private void ReadInFile()
        {
            _resultingString = File.ReadAllText(_filePath);
        }

        public void RemoveStopWords()
        {
            string strFile = _resultingString;
            foreach (var word in _stopList)
            {
                var pattern = @"\b" + word + @"\b";
                strFile = Regex.Replace(strFile, pattern, "", RegexOptions.IgnoreCase);
            }

            _resultingString = strFile;

            Console.WriteLine($"Removed Stop Words completed for {_name}!");
        }

        public void RemoveNonAlphaCharaters()
        {
            var resulting = Regex.Replace(_resultingString, @"[^a-zA-Z]", " ");
            _resultingString = resulting;

            Console.WriteLine($"Removed Non Alphabetical text completed for {_name}!");
        }
        public void StemRemainingWords()
        {
            var temp = new List<string>();
            var useThis = _resultingString.Split(" ");
            foreach (var word in useThis)
            {
                temp.Add(_wordStemmer.StemWord(word));
            }

            _remainingWords = new List<string>(temp.Where(x => !string.IsNullOrEmpty(x)));
            Console.WriteLine($"Stemmed words completed {temp.Count} base forms in file {_name}.");
            _resultingString = string.Join("\n", temp.Where(x => !string.IsNullOrEmpty(x)));
        }

        public void CountOccur()
        {
            List<AppearingWords> appears = new List<AppearingWords>();
            foreach (var word in _remainingWords)
            {
                foreach (var temp in appears.Where(x => x.Word == word))
                {
                    temp.Count = temp.Count + 1;
                }

                if (!appears.Any(x => x.Word == word))
                    appears.Add(new AppearingWords() { Word = word, Count = 1 });

            }
            var finalList = appears.OrderByDescending(x => x.Count).ToList();
            Console.WriteLine($"Top 20 most used words in file {_name}.");
            for (int index = 0; index < 20; index++)
            {
                Console.WriteLine(finalList[index].ToString());
            }
        }

        public void SaveFile(string filePath)
        {
            var outFile = filePath + $"\\{_name}-RemovedStopWords.txt";
            File.WriteAllText(outFile, _resultingString);
        }
    }

    public class AppearingWords
    {
        public string Word;
        public int Count;

        public override string ToString()
        {
            return $"Word: {Word}, Count: {Count}";
        }
    }
}
