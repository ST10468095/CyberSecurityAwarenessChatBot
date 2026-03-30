using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityAwarenessChatBot.Utils;
using CyberSecurityAwarenessChatBot.Models;


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
        }
    }
}
