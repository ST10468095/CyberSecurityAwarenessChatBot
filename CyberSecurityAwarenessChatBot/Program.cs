using CyberSecurityAwarenessChatBot.Models;
using CyberSecurityAwarenessChatBot.Services;
using CyberSecurityAwarenessChatBot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;


namespace CyberSecurityAwarenessChatBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //welcome.wav sound plays for user
            PlayWelcomeSound();
            //display the heading
            Console.Title = "Cyber Security Awareness Chatbot";
            Console.Clear();

            AsciiArt.ShowLogo();
            User user = new User();

            //prompt user to enter their name 

            Console.Write("\nEnter your name: ");
            user.Name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome {user.Name}! I will be helping you stay safe today! How may I assist  you?");
            Console.ResetColor();

            string input;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                input = Console.ReadLine();
                //if user types nothing and presses enter
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
        static void PlayWelcomeSound()
        {
            try
            {
                //welcome.wav plays
                SoundPlayer player = new SoundPlayer("welcome.wav");
                player.PlaySync(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing sound: " + ex.Message);
            }
        }

    }

}
