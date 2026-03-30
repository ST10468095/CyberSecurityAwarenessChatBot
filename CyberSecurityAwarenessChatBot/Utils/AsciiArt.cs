using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityAwarenessChatBot.Utils
{
    public static class AsciiArt
    {
        public static void ShowLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
----------------------------------------
      CYBER SECURITY AWARENESS CHATBOT
----------------------------------------
            Stay Safe Online 
----------------------------------------
");

            Console.ResetColor();
        }
    }
}