using System;
using System.Collections.ObjectModel;
using System.Media;
using System.Windows;
using System.Windows.Input;
using CyberSecurityAwarenessChatBot_GUI.Services;
using CyberSecurityAwarenessChatBot_GUI.Utils;

namespace CyberSecurityAwarenessChatBot_GUI
{
    public partial class MainWindow : Window
    {
        private ChatbotService _chatbot;
        private ObservableCollection<ChatMessage> _messages;

        public MainWindow()
        {
            InitializeComponent();
            InitializeChatbot();
            Loaded += MainWindow_Loaded;
        }

        private void InitializeChatbot()
        {
            _chatbot = new ChatbotService();
            _messages = new ObservableCollection<ChatMessage>();
            ChatListBox.ItemsSource = _messages;

            // Setup sentiment callback dlegate
            _chatbot.SentimentCallback = (sentiment, originalResponse) =>
            {
                switch (sentiment)
                {
                    case "worried":
                        return $" It's okay to feel worried! {originalResponse} You've got this!";
                    case "curious":
                        return $" Great question! {originalResponse} Keep being curious about security!";
                    case "frustrated":
                        return $" I know cybersecurity can be frustrating. {originalResponse} Take it one step at a time!";
                    default:
                        return originalResponse;
                }
            };
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Display ASCII art
            AsciiArtBlock.Text = AsciiArt.GetLogoForGUI();

            // Play voice greeting
            PlayWelcomeSound();

            // Welcome message
            AddBotMessage("Hello! Welcome to the Cybersecurity Awareness Bot! 🔒");
            AddBotMessage("What's your name?");
        }

        private void PlayWelcomeSound()
        {
            try
            {
                string audioPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "welcome.wav");
                if (System.IO.File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine($"Sound error: {ex.Message}");
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendUserInput();
        }

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendUserInput();
            }
        }

        private void SendUserInput()
        {
            string input = UserInputTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
                return;

            AddUserMessage(input);
            UserInputTextBox.Clear();

            string response = _chatbot.GetResponse(input);
            AddBotMessage(response);
        }

        private void AddUserMessage(string message)
        {
            _messages.Add(new ChatMessage { Message = message, IsUser = true });
            ChatListBox.ScrollIntoView(_messages[_messages.Count - 1]);
        }

        private void AddBotMessage(string message)
        {
            _messages.Add(new ChatMessage { Message = message, IsUser = false });
            ChatListBox.ScrollIntoView(_messages[_messages.Count - 1]);
        }
    }
}