﻿using System;
using System.Collections.Generic;

namespace DiscordBotCore.Storage.Implementations
{
    class InMemoryStorage : IDataStorage
    {

        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public InMemoryStorage()
        {
            Console.WriteLine("InMemoryStorage Constructor");
        }

        public T RestoreObject<T>(string key)
        {
            if (!_dictionary.ContainsKey(key))
                throw new ArgumentException($"The provide key '{key}' wasn't found.");

            return (T)_dictionary[key];
        }

        public void StoreObject(object obj, string key)
        {
            if (_dictionary.ContainsKey(key)) return;
            _dictionary.Add(key, obj);
        }

        public void Hello()
        {
            Console.WriteLine("Hi!");
        }
    }
}
