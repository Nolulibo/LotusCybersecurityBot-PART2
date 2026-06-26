using System;

namespace LotusCyberSecurityBot.Classes
{
    // I created this class as the central controller for all chatbot logic
    public class Chatbot
    {
        private KeywordResponder _keywords;
        private SentimentDetector _sentiment;
        private MemoryStore _memory;
        private ConversationManager _conversation;
        private ResponseComposer _composer;

        public Chatbot()
        {
            _keywords = new KeywordResponder();
            _sentiment = new SentimentDetector();
            _memory = new MemoryStore();
            _conversation = new ConversationManager();
            _composer = new ResponseComposer();
        }

        // I created this method to process all user input through the chatbot pipeline
        public string GetResponse(string input)
        {
            input = input.ToLower();

            // STEP 1: Capture user name
            if (string.IsNullOrEmpty(_memory.UserName))
            {
                string cleanedName = input
                    .Replace("my name is", "")
                    .Trim();

                _memory.Store("name", cleanedName);

                return $"Nice to meet you {cleanedName}. What cybersecurity topic are you interested in?";
            }

            // STEP 2: Follow-up handling
            if (_conversation.IsFollowUp(input)
                && !string.IsNullOrEmpty(_conversation.LastTopic))
            {
                return _conversation.GetFollowUpResponse();
            }

            // STEP 3: Detect favourite topic
            string[] possibleTopics =
            {
                "password",
                "phishing",
                "malware",
                "privacy",
                "scam",
                "ransomware",
                "firewall"
    };

            foreach (string topic in possibleTopics)
            {
                if (input.Contains(topic))
                {
                    _memory.Store("topic", topic);
                }
            }

            // STEP 4: Sentiment detection
            Sentiment sentiment = _sentiment.Detect(input);

            string emotionPrefix =
                _sentiment.GetEmotionPrefix(sentiment);

            // STEP 5: Keyword response
            string keywordResponse =
                _keywords.GetResponse(input, out string matchedKeyword);

            if (matchedKeyword != null)
            {
                _conversation.LastTopic = matchedKeyword;

                string memoryPrefix =
                    _memory.GetPersonalisedOpener();

                return emotionPrefix
                    + memoryPrefix
                    + keywordResponse;
            }

            // STEP 6: Special questions
            if (input.Contains("what can you do"))
            {
                return "I can help explain cybersecurity concepts like phishing, malware, passwords, privacy, scams, ransomware, and firewalls.";
            }

            if (input.Contains("purpose"))
            {
                return "My purpose is to improve cybersecurity awareness and help users stay safe online.";
            }

            if (input.Contains("how are you"))
            {
                return "I am functioning perfectly and ready to help you learn cybersecurity awareness.";
            }

            // STEP 7: Fallback response
            return _keywords.GetFallbackResponse();
        }
    }
}

