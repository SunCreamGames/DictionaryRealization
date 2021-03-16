namespace DataStructuresLab
{
    using System;
    using System.Collections.Generic;

    public class MyDictionary<ValueType>
    {
        public LinkedList<Pair<ValueType>>[] HashTable { get; private set; }
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        public MyDictionary(int capacity)
        {
            Capacity = capacity;
            HashTable = new LinkedList<Pair<ValueType>>[Capacity];
            Count = 0;
        }

        public void Set(string key, ValueType value)
        {
            var preHash = HashFunc(key);
            var pairToAdd = new Pair<ValueType>(key, value);

            if (HashTable[preHash] == null)
            {
                HashTable[preHash] = new LinkedList<Pair<ValueType>>();
            }

            if (HashTable[preHash].Count == 0)
            {
                HashTable[preHash].AddLast(pairToAdd);
                Count++;
                CheckForResize();
            }
            else
            {
                var curPair = HashTable[preHash].First;
                while (curPair.Value.Key != pairToAdd.Key)
                {
                    if (curPair.Next == null)
                    {
                        HashTable[preHash].AddLast(pairToAdd);
                        Count++;
                        CheckForResize();
                        return;
                    }
                }

                curPair.Value = pairToAdd;
            }
        }

        public ValueType Get(string key)
        {
            var preHash = HashFunc(key);
            if (HashTable[preHash].Count == 0)
            {
                Console.WriteLine($"The dictionary has no pair with this key : <color=red>{key}</color>");
                return default;
            }

            var curPair = HashTable[preHash].First;
            while (curPair.Value.Key != key)
            {
                if (curPair.Next == null)
                {
                    Console.WriteLine($"The dictionary has no pair with this key : <color=red>{key}</color>");
                    return default;
                }

                curPair = curPair.Next;
            }

            return curPair.Value.Value;
        }

        private void CheckForResize()
        {
        }

        private int HashFunc(string key)
        {
            return 0;
        }
    }

    public class Pair<T>

    {
        public string Key { get; private set; }

        public T Value { get; private set; }

        public Pair(string key, T value)
        {
            Key = key;
            Value = value;
        }
    }
}