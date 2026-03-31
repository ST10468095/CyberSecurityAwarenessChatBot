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

            if (input.Contains("virus")) 
                return "Malware is harmful software. Always install antivirus software/ Microsoft Defender and avoid unknown downloads.";

            if (input.Contains("antivirus"))
                return "Antivirus software helps detect and remove dangerous programs from your computer.";

            if (input.Contains("vpn"))
                return "A vpn encrypts your internet connection and protects your privacy online.";

            if (input.Contains("wifi")) 
                return "Avoid accessing sensitive accounts on public WiFi unless using a VPN.";

            if (input.Contains("scam"))
                return "Online scams often involve a sense of urgency. Always verify messages before responding.";

            if (input.Contains("email safety"))
                return "Check the sender address carefully and avoid downloading attachments from unknown sources.";

            if (input.Contains("update")) 
                return "Keep your software updated to fix security vulnerabilities.";

            if (input.Contains("two factor"))
                return "Enable two-factor authentication for an extra layer of security.";

            if (input.Contains("identity theft"))
                return "Protect personal information and monitor accounts regularly to prevent identity theft.";

            if (input.Contains("safe download"))
                return "Only download files from trusted websites or official app stores.";

            if (input.Contains("backup"))
                return "Regularly back up important files to protect against data loss or ransomware.";

            if (input.Contains("ransomware"))
                return "Ransomware locks your files. Backups and updated security software help protect you.";

            if (input.Contains("firewall"))
                return "A firewall monitors incoming and outgoing traffic to block unauthorized access.";

            if (input.Contains("hello"))
                return "Hello! Ask me anything about staying safe online.";

            if (input.Contains("thank"))
                return "You're welcome! Staying safe online is important.";

            return "I don't understand. Try asking about something else related to cybersecurity.";
        }
    }
}
