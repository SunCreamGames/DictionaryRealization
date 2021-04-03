using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLab
{
    public class DictionaryParser
    {
        public void SetDictionary(ref MyDictionary<string> dictionary)
        {
            StreamReader sr = new StreamReader("test.txt");
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string key = "";
                int counter = 0;
                while(line[counter] != ';')
                {
                    key += line[counter];
                    counter++;
                }
                key.ToLower();
                dictionary.Set(key, line);
            }
            sr.Close();
        }
    }
}
