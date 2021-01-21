using System;
using System.Linq;

namespace TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string[], int, string> delegateMain = MainFunc(GetCorrectNumber());

            Console.WriteLine(delegateMain(names, num));
            
        }

        static Func<string[], int, string> MainFunc(Func<string, int, bool> filter) 
        {
            return (x, y) => x.Where(w => filter(w, y)).FirstOrDefault();
        }

        static Func<string, int, bool> GetCorrectNumber() 
        {
            return (x, y) => x.Sum(ch => ch + 0) >= y;
        }
    }
}
