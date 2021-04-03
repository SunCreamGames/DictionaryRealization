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
                var values = dictionary[line.ToUpper()];
                for (int i = 0; i < values.Length; i++)
                {
                    Console.Write(values[i]+"\t");
                }
                Console.WriteLine();
            }
        }
    }
}