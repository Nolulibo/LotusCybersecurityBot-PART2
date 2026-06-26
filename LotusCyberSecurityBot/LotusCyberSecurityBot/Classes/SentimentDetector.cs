using System;
using System.Collections.Generic;

namespace LotusCyberSecurityBot.Classes
{
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated,
        Happy
    }

    // I created this class to detect emotional tone in user messages
    public class SentimentDetector
    {
        private Dictionary<Sentiment, string[]> _triggers;

        public SentimentDetector()
        {
            _triggers = new Dictionary<Sentiment, string[]>
    {
        {
            Sentiment.Worried,
            new[]
            {
                "worried",
                "scared",
                "afraid",
                "anxious",
                "nervous",
                "unsafe"
            }
        },

        {
            Sentiment.Curious,
            new[]
            {
                "curious",
                "wondering",
                "interested",
                "want to know",
                "how",
                "why",
                "explain"
            }
        },

        {
            Sentiment.Frustrated,
            new[]
            {
                "frustrated",
                "annoyed",
                "confused",
                "don't understand"
            }
        },

        {
            Sentiment.Happy,
            new[]
            {
                "great",
                "thanks",
                "helpful",
                "awesome",
                "love"
            }
        }
    };
        }

        // I detect sentiment by scanning for emotional keywords
        public Sentiment Detect(string input)
        {
            input = input.ToLower();

            foreach (var pair in _triggers)
            {
                foreach (var word in pair.Value)
                {
                    if (input.Contains(word))
                        return pair.Key;
                }
            }

            return Sentiment.Neutral;
        }

        // I created this to generate emotional response prefixes
        public string GetEmotionPrefix(Sentiment sentiment)
        {
            return sentiment switch
            {
                Sentiment.Worried => "I understand your concern — cybersecurity can feel overwhelming. ",
                Sentiment.Frustrated => "I understand your frustration — let me simplify this for you. ",
                Sentiment.Curious => "That is a great question — learning this is very important. ",
                Sentiment.Happy => "I am glad you are engaged with this topic! ",
                _ => ""
            };
        }
    }
}
