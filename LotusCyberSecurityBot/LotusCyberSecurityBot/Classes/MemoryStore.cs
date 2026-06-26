using System.Collections.Generic;

namespace LotusCyberSecurityBot.Classes
{
    // I created this class to store and recall user information
    public class MemoryStore
    {
        public string UserName { get; set; }

        public string FavouriteTopic { get; set; }

        private Dictionary<string, string> _memory;

        public MemoryStore()
        {
            _memory = new Dictionary<string, string>();
        }

        // I store user information dynamically
        public void Store(string key, string value)
        {
            _memory[key] = value;

            if (key == "name")
            {
                UserName = value;
            }

            if (key == "topic")
            {
                FavouriteTopic = value;
            }
        }

        // I safely retrieve stored information
        public string Recall(string key)
        {
            return _memory.ContainsKey(key)
                ? _memory[key]
                : null;
        }

        // I personalise chatbot responses using memory
        public string GetPersonalisedOpener()
        {
            string opener = "";

            if (!string.IsNullOrEmpty(UserName))
            {
                opener += $"Hello {UserName}. ";
            }

            if (!string.IsNullOrEmpty(FavouriteTopic))
            {
                opener += $"As someone interested in {FavouriteTopic}, ";
            }

            return opener;
        }
    }
}
