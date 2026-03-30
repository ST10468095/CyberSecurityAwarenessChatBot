using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityAwarenessChatBot.Services
{
    public class ChatbotService
    {
        public static string GetResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("password"))
                return "Use a strong password with uppercase letters, numbers, and symbols.";

            if (input.Contains("phishing"))
                return "Never click suspicious email links.Ever!";

            if (input.Contains("browsing"))
                return "Always check HTTPS websites before entering personal details.";

            if (input.Contains("purpose"))
                return "I help users stay safe and provide cybersecurity awareness.";

            if (input.Contains("how are you"))
                return "I'm ready to help!";

            return "I don't understand. Try asking about something else related to cybersecurity.";
        }
    }
}
