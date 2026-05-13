using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecurityAwarenessChatBot_GUI.Services
{
    public class ChatbotService
    {
        // Memory properties
        public string UserName { get; set; }
        public string UserInterest { get; set; }
        public string LastTopic { get; set; }

        // Random 
        private Random random = new Random();

        // Dictionary for keyword responses 
        private Dictionary<string, List<string>> keywordResponses;

        // Delegate for sentiment detection 
        public delegate string SentimentHandler(string sentiment, string originalResponse);
        public SentimentHandler SentimentCallback { get; set; }

        public ChatbotService()
        {
            InitializeDictionaryResponses();
        }

        private void InitializeDictionaryResponses()
        {
            keywordResponses = new Dictionary<string, List<string>>
            {
                ["password"] = new List<string>
                {
                    " Use a strong password with uppercase letters, numbers, and symbols!",
                    " Never reuse passwords across different accounts!",
                    " Enable Two-Factor Authentication (2FA) for extra security!"
                },

                ["phishing"] = new List<string>
                {
                    " Never click suspicious email links! Always verify the sender first.",
                    " Phishing emails often create urgency. Take a breath and check carefully.",
                    " Hover over links to see where they really go before clicking."
                },

                ["browsing"] = new List<string>
                {
                    " Always check for HTTPS before entering personal details.",
                    " Use a secure browser with privacy features enabled.",
                    " Avoid saving passwords in your browser - use a password manager instead."
                },

                ["scam"] = new List<string>
                {
                    " Online scams often involve urgency. Always verify before responding!",
                    " If it sounds too good to be true, it probably is a scam.",
                    " Never share personal info with unsolicited callers or messages."
                },

                ["virus"] = new List<string>
                {
                    " Malware is harmful software. Always use antivirus protection!",
                    " Avoid unknown downloads and keep Windows Defender updated.",
                    " Don't open email attachments from unknown senders."
                },

                ["antivirus"] = new List<string>
                {
                    " Antivirus software detects and removes dangerous programs.",
                    " Run regular scans and keep your antivirus updated daily.",
                    " Windows Defender is great, but consider additional protection."
                },

                ["vpn"] = new List<string>
                {
                    " A VPN encrypts your internet connection and protects privacy.",
                    " Use a VPN on public WiFi to prevent hackers from seeing your data.",
                    " Choose a reputable VPN - free ones often sell your data!"
                },

                ["wifi"] = new List<string>
                {
                    " Avoid accessing banking or sensitive accounts on public WiFi.",
                    " Always use a VPN when connecting to public hotspots.",
                    " Disable auto-connect to open WiFi networks."
                },

                ["update"] = new List<string>
                {
                    " Keep your software updated to fix security vulnerabilities!",
                    " Enable automatic updates for your operating system and apps.",
                    " Don't ignore update notifications - they often patch critical flaws."
                },

                ["two factor"] = new List<string>
                {
                    " Enable 2FA everywhere possible! Use an authenticator app.",
                    " SMS 2FA is better than nothing, but apps are more secure.",
                    " Save backup codes somewhere safe in case you lose your phone."
                },

                ["ransomware"] = new List<string>
                {
                    " Ransomware locks your files. Regular backups are your best defense!",
                    " Never pay the ransom - paying encourages more attacks.",
                    " Be careful with email attachments - common ransomware vector."
                },

                ["backup"] = new List<string>
                {
                    " Follow the 3-2-1 backup rule: 3 copies, 2 media types, 1 offsite.",
                    " Use both cloud storage and an external hard drive for backups.",
                    " Test your backups regularly to ensure they work!"
                },

                ["firewall"] = new List<string>
                {
                    " A firewall monitors traffic and blocks unauthorized access.",
                    " Windows Firewall is enabled by default - don't disable it!",
                    " For home networks, ensure your router's firewall is active."
                },

                ["identity theft"] = new List<string>
                {
                    " Monitor your credit report regularly for suspicious activity.",
                    " Freeze your credit if you suspect identity theft.",
                    " Be careful what personal info you share on social media."
                }
            };
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please type something! I'm here to help with cybersecurity. 🔒";

            string lowerInput = input.ToLower();

            // Check for name input 
            if (lowerInput.Contains("my name is") || lowerInput.Contains("call me"))
            {
                UserName = ExtractName(input);
                return $"Nice to meet you, {UserName}! I'll help you stay safe online today! 🛡️";
            }

            // Check for interest input
            if (lowerInput.Contains("interested in"))
            {
                UserInterest = ExtractInterest(input);
                return $"Great! I'll remember that you're interested in {UserInterest}. Let me share some tips about this! 💡";
            }

            // Conversation flow
            if (lowerInput.Contains("tell me more") || lowerInput.Contains("another tip") || lowerInput.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(LastTopic))
                {
                    return GetRandomResponseForTopic(LastTopic);
                }
                return "Ask me about passwords, phishing, scams, or other cybersecurity topics first, then I can tell you more! 📚";
            }

            // Sentiment detection
            string sentiment = DetectSentiment(lowerInput);

            
            string topic = FindMatchingTopic(lowerInput);
            string response;

            if (topic != null)
            {
                LastTopic = topic;
                response = GetRandomResponseForTopic(topic);
            }
            else
            {
                // Fallback responses 
                response = GetGeneralResponse(lowerInput);
            }

            // Apply sentiment adjustment
            if (SentimentCallback != null && sentiment != "neutral")
            {
                response = SentimentCallback(sentiment, response);
            }

            // Memory recall check
            if (!string.IsNullOrEmpty(UserName) && lowerInput.Contains("remember me"))
            {
                response = $"Of course I remember you, {UserName}! You're doing great staying security-aware! {response}";
            }

            return response;
        }

        private string GetRandomResponseForTopic(string topic)
        {
            if (keywordResponses.ContainsKey(topic))
            {
                var responses = keywordResponses[topic];
                int index = random.Next(responses.Count);
                return responses[index];
            }
            return "Let me help you with cybersecurity. What would you like to know about? 🔒";
        }

        private string FindMatchingTopic(string input)
        {
            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                    return keyword;
            }
            return null;
        }

        private string GetGeneralResponse(string input)
        {
            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
                return "Hello! Ask me anything about staying safe online! 👋";

            if (input.Contains("how are you"))
                return "I'm fully operational and ready to protect you online! 🤖";

            if (input.Contains("purpose") || input.Contains("what can you do") || input.Contains("help"))
                return "I'm your Cybersecurity Assistant! I can teach you about: passwords, phishing, scams, viruses, VPNs, 2FA, ransomware, backups, and more! Just ask! 🛡️";

            if (input.Contains("thank"))
                return "You're welcome! Staying safe online is a team effort! 🙏";

            if (input.Contains("exit") || input.Contains("bye") || input.Contains("goodbye"))
                return "Stay safe online! Remember to use strong passwords and think before you click! 👋";

            if (!string.IsNullOrEmpty(UserName) && input.Contains("my name"))
                return $"Your name is {UserName}! Did I remember correctly? 😊";

            return "I don't quite understand. Try asking about: passwords, phishing, scams, viruses, VPNs, 2FA, ransomware, or backups! 🔒";
        }

        private string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("nervous") || input.Contains("afraid"))
                return "worried";
            if (input.Contains("curious") || input.Contains("interesting") || input.Contains("cool") || input.Contains("awesome"))
                return "curious";
            if (input.Contains("frustrated") || input.Contains("annoying") || input.Contains("confusing") || input.Contains("difficult"))
                return "frustrated";
            if (input.Contains("happy") || input.Contains("great") || input.Contains("good"))
                return "happy";
            return "neutral";
        }

        private string ExtractName(string input)
        {
            string lower = input.ToLower();
            if (lower.Contains("my name is"))
            {
                int index = lower.IndexOf("my name is") + 10;
                if (index < input.Length)
                    return input.Substring(index).Trim();
            }
            if (lower.Contains("call me"))
            {
                int index = lower.IndexOf("call me") + 7;
                if (index < input.Length)
                    return input.Substring(index).Trim();
            }
            return "Friend";
        }

        private string ExtractInterest(string input)
        {
            if (input.ToLower().Contains("interested in"))
            {
                int index = input.ToLower().IndexOf("interested in") + 13;
                if (index < input.Length)
                {
                    string interest = input.Substring(index).Trim();
                    return interest.Length > 30 ? interest.Substring(0, 30) : interest;
                }
            }
            return "cybersecurity";
        }
    }
}