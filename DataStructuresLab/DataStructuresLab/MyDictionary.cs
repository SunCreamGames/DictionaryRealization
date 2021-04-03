namespace DataStructuresLab
{
    using System;
    using System.Collections.Generic;

    public class MyDictionary<T>
    {
        private MyLinkedList<Pair<T>>[] HashTable { get; set; }
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        private const int K = 253;

        public MyDictionary(int capacity)
        {
            Capacity = capacity;
            HashTable = new MyLinkedList<Pair<T>>[Capacity];
            Count = 0;
            InitHashTable();
        }

        private void InitHashTable()
        {
            for (var i = 0; i < Capacity; i++)
            {
                HashTable[i] = new MyLinkedList<Pair<T>>();
            }
        }


        public void Set(string key, T value)
        {
            var preHash = HashFunc(key);
            var pairToAdd = new Pair<T>(key, value);
            HashTable[preHash].Add(pairToAdd);
            Count++;
            CheckForResize();
        }

        private T[] Get(string key)
        {
            var preHash = HashFunc(key);
            if (HashTable[preHash].Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine($"The dictionary has no pair with this key : {key}");
                Console.WriteLine();
                return default;
            }
            List<T> Pairs = new List<T>();
            var pair = HashTable[preHash].GetFirst();
            for (int i = 0; i < HashTable[preHash].Count; i++)
            {
                if (pair.Value.Key == key)
                {
                    Pairs.Add(pair.Value.Value);
                }
                pair = pair.Next;
            }
            if (Pairs.Count != 0)
                return Pairs.ToArray();
            else
                Console.WriteLine($"The dictionary has no pair with this key : {key}");
            return default;
        }

        private long HashFunc(string key)
        {
            uint hash = 0;
            for (var i = 0; i < key.Length; i++)
            {
                var c = key[i];
                uint increment = ((uint) c) * (uint) Math.Pow(K, i);
                hash += increment;
            }

            var result = (long) hash % (uint) Capacity;
            return result;
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
                while (HashTable[i].Count > 0)
                {
                    var pair = HashTable[i].GetFirst().Value;
                    newDict.Set(pair.Key, pair.Value);
                    HashTable[i].RemoveFirst();
                }
            }

            Capacity = newDict.Capacity;
            HashTable = newDict.HashTable;
        }

        public T[] this[string key]
        {
            get => Get(key);
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