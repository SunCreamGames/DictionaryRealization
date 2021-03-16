namespace DataStructuresLab
{
    using System;
    using System.Collections.Generic;

    public class MyDictionary<T>
    {
        public LinkedList<Pair<T>>[] HashTable { get; private set; }
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        private const int K = 253;

        public MyDictionary(int capacity)
        {
            Capacity = capacity;
            HashTable = new LinkedList<Pair<T>>[Capacity];
            Count = 0;
            InitHashTable();
        }

        private void InitHashTable()
        {
            for (var i = 0; i < Capacity; i++)
            {
                HashTable[i] = new LinkedList<Pair<T>>();
            }
        }

        public void Set(string key, T value)
        {
            var preHash = HashFunc(key);
            var pairToAdd = new Pair<T>(key, value);


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

        public T Get(string key)
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
            if (Capacity * 0.75f <= Count)
            {
                Resize();
            }
        }

        private void Resize()
        {
            MyDictionary<T> newDict = new MyDictionary<T>(Capacity * 2);
            for (var i = 0; i < Capacity; i++)
            {
                foreach (var pair in HashTable[i])
                {
                    newDict.Set(pair.Key, pair.Value);
                }
            }

            HashTable = newDict.HashTable;
        }

        private int HashFunc(string key)
        {
            var stringKey = key.ToString();
            var hash = 0;
            for (var i = 0; i < stringKey.Length; i++)
            {
                var c = stringKey[i];
                var increment = ((int) c) * (int) Math.Pow(K, i);
                hash += increment;
            }

            hash %= Capacity;
            Console.WriteLine($"for key : {key.ToString()} hash is {hash}");
            return hash;
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