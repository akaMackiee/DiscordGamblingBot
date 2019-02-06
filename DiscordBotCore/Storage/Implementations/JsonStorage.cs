using System.IO;
using Newtonsoft.Json;

namespace DiscordBotCore.Storage.Implementations
{
    class JsonStorage : IDataStorage
    {
        public T RestoreObject<T>(string key)
        {
            var file = ($"{key}.json");
            var json = File.ReadAllText(file);
            var botcnf = JsonConvert.DeserializeObject<T>(json);
            return botcnf;
        }

        public void StoreObject(object obj, string key)
        {
            var file = $"{key}.json";
            if (!Directory.Exists(Path.GetDirectoryName(file)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(file));
            }
            if (!File.Exists(Path.GetDirectoryName(file)))
            {
                string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                File.WriteAllText(file, json);
            }
        }
    }

    public struct BotConfig
    {
        public string BotToken;
        public string cmdPrefix;
    }
}
