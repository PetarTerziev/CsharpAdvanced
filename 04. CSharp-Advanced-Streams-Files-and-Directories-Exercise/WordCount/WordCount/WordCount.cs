using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("../../../text.txt");
            string[] words = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> countWords = words.ToDictionary(w => w, w => 0);
            text = RemovePuntctation(text);

            foreach (var word in words)
            {
                foreach (var txt in text)
                {
                    countWords[word] += txt.ToLower().Split().Count(x => x == word);
                }
            }

            using (var streamWriter = new StreamWriter("../../../actualResults.txt"))
            {
                foreach (var pair in countWords.OrderByDescending(x => x.Value))
                {
                    streamWriter.WriteLine($"{pair.Key}-{pair.Value}");
                }
            }
        }

        static string[] RemovePuntctation(string[] text) 
        {
            string[] temp = text.ToArray();
            Regex rgx = new Regex(@"[-,\.!\?]");

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = rgx.Replace(temp[i], "");
            }

            return temp;
        }

    }
}
