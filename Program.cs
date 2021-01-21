using System;
using System.Collections.Generic;
using System.IO;
using TextReader.Extensions;

namespace TextReader
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var cwd = Directory.GetCurrentDirectory();
            var output = cwd + "\\TextFolder\\Output\\";
            var stopWordsPath = cwd + "\\TextFolder\\StopWords\\stopwords.txt"; 
            var file1 = cwd + "\\TextFolder\\";
            var getWords = FetchStopWords(stopWordsPath);
            foreach (var file in Directory.GetFiles(file1, "*.txt", SearchOption.TopDirectoryOnly))
            {
                DoWorkOnText(file,output,getWords);
            }
            Console.WriteLine("\npress any key to exit the process...");
            Console.ReadKey();
        }

        static void DoWorkOnText(string path, string savelocation, List<string> stopWords)
        {
            var temp = new StopWords(path, stopWords);
            temp.SaveFile(savelocation);
        }

        static List<string> FetchStopWords(string filePath)
        {
            List<string> returnable = new List<string>();
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        returnable.Add(line);
                    }
                }

                Console.WriteLine("Stop list was read in");
                Console.WriteLine($"Stop words list contains {returnable.Count} words");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured trying to read from {filePath}, it is shown below:\n{ex.Message}");
            }

            return returnable;
        }
    }
}
