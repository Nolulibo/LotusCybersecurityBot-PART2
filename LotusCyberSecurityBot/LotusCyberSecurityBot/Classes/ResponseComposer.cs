namespace LotusCyberSecurityBot.Classes
{
    // I created this class to combine all chatbot systems into natural responses
    public class ResponseComposer
    {
        // I combine sentiment, memory, and keyword response into one natural output
        public string Compose(string emotionPrefix, string memoryPrefix, string mainResponse)
        {
            return $"{memoryPrefix}{emotionPrefix}{mainResponse}";
        }

        // I generate fallback responses when no keyword is found
        public string GetFallback()
        {
            return "I am not fully sure, but I can help you with topics like passwords, phishing, and malware.";
        }
    }
}

