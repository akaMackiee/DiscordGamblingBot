using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using System;

namespace DiscordBotCore
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello sugar");

            var ims = new InMemoryStorage();
            var mp = new MyProfile(ims);
            mp.NewUser("marcus");
        }
    }

    public class MyProfile
    {
        private readonly IDataStorage _storage;

        public MyProfile(IDataStorage storage)
        {
            _storage = storage;
        }

        public void NewUser(string name)
        {
            var registrationTime = DateTime.UtcNow;

            _storage.StoreObject(registrationTime, name)
        }
    }
}
