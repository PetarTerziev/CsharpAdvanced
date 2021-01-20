using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");


            for (int i = 0; i < lines.Length; i++)
            {
                string temp = lines[i].Replace(" ", "");
                int countAllLetters = temp.Count(x => Char.IsLetter(x));
                int countAllPunctuation = temp.Count(x => Char.IsPunctuation(x));

                lines[i] = $"Line:{i + 1}{lines[i]} ({countAllLetters})({countAllPunctuation})";
            }

            File.WriteAllLines("../../../Output.txt", lines);

        }
    }
}
