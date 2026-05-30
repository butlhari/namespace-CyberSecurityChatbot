
using System;
using System.Media;

namespace CyberSecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Chatbot bot = new Chatbot();
            bot.Start();
        }
    }

    class Chatbot
    {
        private string userName;
        private string rememberedTopic = "";

        public void Start()
        {
            Console.Title = "Cybersecurity Awareness AI Chatbot";

            PlayGreeting();
            DisplayBanner();
            AskName();
            ChatLoop();
        }

        
        private void PlayGreeting()
        {
            try
            {
                string soundPath = AppDomain.CurrentDomain.BaseDirectory + "welcome.wav";

                SoundPlayer player = new SoundPlayer(soundPath);
                player.PlaySync();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: welcome.wav file not found.");
            }
        }

        
        private void DisplayBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("=================================================");
            Console.WriteLine("      CYBERSECURITY AWARENESS AI CHATBOT");
            Console.WriteLine("=================================================");
            Console.WriteLine("      Stay Safe Online From Cyber Threats");
            Console.WriteLine("=================================================\n");
        }

        
        private void AskName()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Enter your name: ");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name cannot be empty.\n");
                }

            } while (string.IsNullOrWhiteSpace(userName));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcome {userName}!");
            Console.WriteLine("Ask me about cybersecurity.\n");
        }

        
        private void ChatLoop()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("You: ");
                string input = Console.ReadLine().ToLower().Trim();

                
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bot: Please enter a valid message.\n");
                    continue;
                }

                
                if (input == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Bot: Goodbye! Stay safe online.");
                    break;
                }

                
                DetectSentiment(input);
                RememberTopic(input);

                
                Respond(input);
            }
        }

        
        private void DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bot: Do not worry. I will help you stay safe online.");
            }

            if (input.Contains("curious") || input.Contains("interested"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bot: Great! Learning cybersecurity is important.");
            }

            if (input.Contains("frustrated") || input.Contains("angry"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bot: I understand your frustration.");
            }
        }

        
        private void RememberTopic(string input)
        {
            if (input.Contains("password"))
            {
                rememberedTopic = "password safety";
            }
            else if (input.Contains("phishing"))
            {
                rememberedTopic = "phishing scams";
            }
            else if (input.Contains("privacy"))
            {
                rememberedTopic = "online privacy";
            }
        }

       
        private void Respond(string input)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (input.Contains("password"))
            {
                Console.WriteLine("Bot: Use strong passwords with uppercase letters, numbers, and symbols.\n");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Bot: Never click suspicious email links or attachments.\n");
            }
            else if (input.Contains("safe browsing"))
            {
                Console.WriteLine("Bot: Use secure HTTPS websites and avoid unknown downloads.\n");
            }
            else if (input.Contains("privacy"))
            {
                Console.WriteLine("Bot: Protect your personal information online and use privacy settings.\n");
            }
            else if (input.Contains("malware"))
            {
                Console.WriteLine("Bot: Malware is harmful software that can damage your computer.\n");
            }
            else if (input.Contains("2fa"))
            {
                Console.WriteLine("Bot: Two-factor authentication adds extra account security.\n");
            }
            else if (input.Contains("remember"))
            {
                if (rememberedTopic != "")
                {
                    Console.WriteLine($"Bot: Earlier you were interested in {rememberedTopic}.\n");
                }
                else
                {
                    Console.WriteLine("Bot: I do not remember a  topic yet.\n");
                }
            }
            else
            {
                Console.WriteLine("Bot: I can help with passwords , phishing, malware, privacy, safe browsing, and 2FA.\n");
            }
        }
    }
}

