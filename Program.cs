using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.IO;

namespace chatbot_st10203232
{
    class Program
    {
        static void Main(string[] args)
        {
            //background colour change
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            //voice greeting
            string audio = "welcome.wav";

            using (var audioFile = new AudioFileReader(audio))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                // Wait until the sound finishes playing
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100);
                }
            }

            //image display as heading in ASCI
            //ASCII art
            string filePath = "ascii.txt";

            if (File.Exists(filePath))
            {
                string heading = File.ReadAllText(filePath);
                Console.WriteLine(heading);
            }

            Console.WriteLine("Welcome");
            Console.WriteLine("I'm Cyber, a chatbot that will educate you about cybersecurity");

            //ask user for name and personalise
            string name = "", howru = "", topic = "";


            Console.WriteLine("What is your name?......");
            name = Console.ReadLine();
            Console.WriteLine("Hi " + name + ", how are you?");
            howru = Console.ReadLine();
            Console.WriteLine("I'm well even though I'm just a bot, " + name);
            Console.WriteLine("I am a bot that will talk to you about cybersecurity and how to keep yourself safe online");

            // Console.WriteLine(".....");
            //topic = Console.ReadLine();

            bool onTopic = false;

            while (!onTopic)
            {
                Console.WriteLine("Please choose a topic between password safety, phishing and safe browsing");
                Console.WriteLine(name + ", if you really want to leave early, please type exit");
                topic = Console.ReadLine().ToLower();

                switch (topic)
                {
                    case "password safety":
                        Console.WriteLine("keep password safe and dont share it with anyone, you never know what they doing with it");
                        break;
                    case "phishing":
                        Console.WriteLine("beware of emails and sms that dont look legitimate, rather communicate with the company directly or know their contact details to make sure its actually them");
                        break;
                    case "safe browsing":
                        Console.WriteLine("dont go into a weird website that have a lot of ads, they can infect your computer with viruses or hack you");
                        break;
                    case "exit":
                        Console.WriteLine("It's sad to see you go " + name + " but I hope you have learned a lot about internet safety . See you next time.");
                        Console.WriteLine("Bye!");
                        return;
                    default:
                        Console.WriteLine("Please enter one of the topics in which I mentioned previously...");
                        break;
                }


            }

            //responsive and handles unexpected or invalid input+
        }
    }
}
