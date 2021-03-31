using System;
using System.IO;

namespace DataStructuresLab
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<string> dictionary = new MyDictionary<string>(98215);
            DictionaryParser parser = new DictionaryParser();
            parser.SetDictionary(ref dictionary);
            Console.Write("Type a sentence to get definition: ");
            var lines = Console.ReadLine().Split(" ");
            foreach (var line in lines)
            {
                Console.WriteLine();
                Console.WriteLine(dictionary.Get(line.ToUpper()));
            }
        }
    }
}