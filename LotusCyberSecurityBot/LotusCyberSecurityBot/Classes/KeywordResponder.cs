using System;
using System.Collections.Generic;

namespace LotusCyberSecurityBot.Classes
{
    // I created this class to manage cybersecurity keyword responses
    public class KeywordResponder
    {
        private Dictionary<string, List<string>> _responses;

        private List<string> _fallbackResponses;

        private Random _random;

        public KeywordResponder()
        {
            _random = new Random();

            _responses = new Dictionary<string, List<string>>()
            {
                {
                    "password", new List<string>
                    {
                        "Strong passwords should include symbols, numbers, and uppercase letters.",
                        "Using unique passwords for every account improves your security.",
                        "Avoid using personal information inside your passwords."
                    }
                },

                {
                    "phishing", new List<string>
                    {
                        "Phishing attacks trick users into revealing sensitive information.",
                        "Always verify email links before clicking them.",
                        "Cybercriminals often use urgency to make phishing messages believable."
                    }
                },

                {
                    "malware", new List<string>
                    {
                        "Malware is harmful software designed to damage devices or steal information.",
                        "Keeping your antivirus updated helps protect against malware.",
                        "Avoid downloading files from unknown websites."
                    }
                },

                {
                    "privacy", new List<string>
                    {
                        "Protecting your privacy online helps prevent identity theft.",
                        "Avoid sharing sensitive information publicly on social media.",
                        "Review app permissions regularly to protect your personal data."
                    }
                },

                {
                    "scam", new List<string>
                    {
                        "Online scams often pretend to be trustworthy organisations.",
                        "Never share banking details with unverified sources.",
                        "Be cautious of offers that sound too good to be true."
                    }
                },

                {
                    "ransomware", new List<string>
                    {
                        "Ransomware locks your files until payment is made.",
                        "Regular backups help protect your data from ransomware attacks.",
                        "Avoid opening suspicious email attachments."
                    }
                },

                {
                    "firewall", new List<string>
                    {
                        "A firewall helps block unauthorised access to your system.",
                        "Firewalls monitor incoming and outgoing network traffic.",
                        "Keeping your firewall enabled improves cybersecurity protection."
                    }
                }
            };

            _fallbackResponses = new List<string>()
            {
                "I am not sure I understand. Could you rephrase your cybersecurity question?",
                "Try asking me about passwords, phishing, malware, privacy, or scams.",
                "I can help explain cybersecurity topics and online safety tips.",
                "Could you provide more detail about the cybersecurity topic you need help with?"
            };
        }

        // I detect keywords and return a random matching response
        public string GetResponse(string input, out string matchedKeyword)
        {
            input = input.ToLower();

            matchedKeyword = null;

            foreach (var keyword in _responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    matchedKeyword = keyword;

                    List<string> responses = _responses[keyword];

                    return responses[_random.Next(responses.Count)];
                }
            }

            return null;
        }

        // I return random fallback responses
        public string GetFallbackResponse()
        {
            return _fallbackResponses[
                _random.Next(_fallbackResponses.Count)];
        }

        // I return all supported keywords
        public List<string> GetAllKeywords()
        {
            return new List<string>(_responses.Keys);
        }
    }
}
