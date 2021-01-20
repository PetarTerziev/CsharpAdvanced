using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EvenLines
{
    class EvenLines
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("../../../text.txt"))
            {
                string line = streamReader.ReadLine();
                int counter = 0;

                using (var streamWriter = new StreamWriter("../../../Output.txt"))
                {
                    while (line != null)
                    {

                        Regex rgx = new Regex(@"[-,\.!\?]");

                        if (counter % 2 == 0)
                        {
                            streamWriter.WriteLine(string.Join(" ", rgx.Replace(line, "@")
                                                         .Split().ToArray().Reverse()));
                        }

                        counter++;
                        line = streamReader.ReadLine();

                    }
                }
            }
        }
    }
}
