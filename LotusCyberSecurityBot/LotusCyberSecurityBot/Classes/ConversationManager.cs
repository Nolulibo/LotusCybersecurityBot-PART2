namespace LotusCyberSecurityBot.Classes
{
    // I created this class to manage follow-up conversations
    public class ConversationManager
    {
        public string LastTopic { get; set; }

        // I detect follow-up phrases naturally
        public bool IsFollowUp(string input)
        {
            input = input.ToLower();

            return input == "more"
                || input.Contains("tell me more")
                || input.Contains("explain more")
                || input.Contains("explain further")
                || input.Contains("continue")
                || input.Contains("go on");
        }

        // I provide deeper explanations for previous topics
        public string GetFollowUpResponse()
        {
            switch (LastTopic)
            {
                case "password":
                    return "Strong passwords should also be changed regularly and never shared with others.";

                case "phishing":
                    return "Phishing attacks may appear as fake emails, SMS messages, or websites designed to steal your information.";

                case "malware":
                    return "Some malware can secretly monitor your activity and steal sensitive information.";

                case "privacy":
                    return "Using privacy settings and limiting personal information online can improve your digital safety.";

                case "scam":
                    return "Scammers often use emotional manipulation and urgency to pressure victims.";

                case "ransomware":
                    return "Businesses often use secure backups to recover from ransomware attacks.";

                case "firewall":
                    return "Firewalls act as a barrier between trusted networks and potentially dangerous traffic.";

                default:
                    return "Cybersecurity awareness is important for protecting your information online.";
            }
        }
    }
}

