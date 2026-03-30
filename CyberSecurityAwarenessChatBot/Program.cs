using CyberSecurityAwarenessChatBot.Models;
using CyberSecurityAwarenessChatBot.Services;
using CyberSecurityAwarenessChatBot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CyberSecurityAwarenessChatBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AsciiArt.ShowLogo();
            User user = new User();

            Console.Write("\nEnter your name: ");
            user.Name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome {user.Name}! I will be helping you stay safe today!");
            Console.ResetColor();

            string input;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please type something.");
                    continue;
                }

                if (input.ToLower() == "exit")
                    break;

                string response = ChatbotService.GetResponse(input);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Bot: " + response);
                Console.ResetColor();
            }
        }

    }
}
