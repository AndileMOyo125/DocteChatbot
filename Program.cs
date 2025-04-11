using System;
using System.Media;
using System.Threading;
using System.IO;


class DocteChatbot
{
    static void Main()
    {
        Console.Title = "🛡️ Docte Cybersecurity Chatbot 🛡️";
        Console.Clear();
        DrawBorder();
        DisplayAsciiArt();

        WriteSectionHeader("👋 Voice Greeting");
        if (OperatingSystem.IsWindows())
        {
            PlayGreeting();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️ Voice greeting is only supported on Windows. Skipping audio playback.");
            Console.ResetColor();
        }

        WriteSectionHeader("💬 Let's Get Started");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("🧑 Enter your name: ");
        Console.ForegroundColor = ConsoleColor.White;
        string? nameInput = Console.ReadLine();
        string userName = nameInput ?? "User";
        TypeWriteLine($"\n🤖 Hello, {userName}! I am here to help you stay safe online.\n");

        BasicResponseSystem();
    }
     
     [System.Runtime.Versioning.SupportedOSPlatform("windows")]
     
    static void PlayGreeting()
{
    try
    {
        string projectLocation = AppDomain.CurrentDomain.BaseDirectory;
        string updatedPath = projectLocation.Replace("bin\\Debug\\", "");
        string fullPath = Path.Combine(updatedPath,
         @"C:\Users\ME\Desktop\IvoriChatbot\ConsoleApp1\bin\Recording (3).wav");

        if (!File.Exists(fullPath))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️ Greeting audio file not found. Skipping audio playback.");
            Console.ResetColor();
            return;
        }

        using (SoundPlayer player = new SoundPlayer(fullPath))
        {
            player.PlaySync();
        }
    }
    catch (Exception error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("⚠️ Error playing audio: " + error.Message);
        Console.ResetColor();

    }
}

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
    ╔════════════════════════════════════════════════════════════════╗
    ║   ____ _   _    _    _______ ____   ___   ____ _____ _____     ║
    ║  / ___| | | |  / \  |__   __|  _ \ / _ \ / ___|_   _| ____|    ║
    ║ | |   | |_| | / _ \    | |  | | | | | | | |     | | |  _|      ║
    ║ | |__ |  _  |/ ___ \   | |  | |_| | |_| | |___  | | | |___     ║
    ║  \____|_| |_/_/   \_\  |_|  |____/ \___/ \____| |_| |_____|    ║
    ╚════════════════════════════════════════════════════════════════╝
        ");
        Console.ResetColor();
    }

    static void WriteSectionHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n─────────────────────────────────────────────────────");
        Console.WriteLine($"🔷 {title}");
        Console.WriteLine("─────────────────────────────────────────────────────");
        Console.ResetColor();
    }

    static void TypeWriteLine(string text, int delay = 30)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    static void DrawBorder()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                      WELCOME TO DOCTE CHATBOT                  ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════╝\n");
        Console.ResetColor();
    }

    static void BasicResponseSystem()
    {
    WriteSectionHeader("🧠 Cyber Help Center (Type 'exit' to quit)");

    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\nYou: ");
        Console.ResetColor();
        string? input = Console.ReadLine();
        string userInput = input?.ToLower() ?? "";

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Docte: ");
        Console.ResetColor();

        if (string.IsNullOrWhiteSpace(userInput))
        {
            TypeWriteLine("Please enter a valid question.");
            continue;
        }

        if (userInput == "exit")
        {
            TypeWriteLine("Goodbye! Stay safe online. 👋");
            break;
        }
        else if (userInput.Contains("how are you"))
        {
            TypeWriteLine("I'm great, thank you! Ready to help you stay safe online. 💪");
        }
        else if (userInput.Contains("purpose") || userInput.Contains("what do you do"))
        {
            TypeWriteLine("My purpose is to teach you how to protect yourself from online threats and stay cyber smart. 🛡️");
        }
        else if (userInput.Contains("what can i ask") || userInput.Contains("help") || userInput.Contains("topics"))
        {
            TypeWriteLine("You can ask me about phishing, passwords, malware, safe browsing, antivirus, 2FA, firewalls, software updates, and more!");
        }
        else if (userInput.Contains("phishing"))
        {
            TypeWriteLine("Phishing is a scam where attackers impersonate trusted sources to steal personal data. Be cautious of suspicious emails or messages asking for your info.");
        }
        else if (userInput.Contains("password"))
        {
            TypeWriteLine("Create long, complex passwords using letters, numbers, and symbols. Never reuse passwords and consider using a password manager.");
        }
        else if (userInput.Contains("safe browsing"))
        {
            TypeWriteLine("Use secure browsers, avoid clicking on unknown links, and make sure websites use HTTPS. Don’t download files from untrusted sources.");
        }
        else if (userInput.Contains("malware"))
        {
            TypeWriteLine("Malware is malicious software that can harm your computer or steal your data. Use antivirus tools and avoid suspicious downloads.");
        }
        else if (userInput.Contains("antivirus"))
        {
            TypeWriteLine("Antivirus software helps detect and remove malicious programs. Keep it up to date to stay protected.");
        }
        else if (userInput.Contains("firewall"))
        {
            TypeWriteLine("A firewall blocks unauthorized access to your device or network. It's a strong first line of defense.");
        }
        else if (userInput.Contains("update") || userInput.Contains("updates"))
        {
            TypeWriteLine("Regularly updating your software and operating system fixes vulnerabilities and enhances security.");
        }
        else if (userInput.Contains("2fa") || userInput.Contains("two-factor"))
        {
            TypeWriteLine("Two-Factor Authentication adds an extra layer of security by requiring a code sent to your device in addition to your password.");
        }
        else
        {
            TypeWriteLine("Sorry, I do not understand. Try asking about a cybersecurity topic like passwords or phishing.");
        }
    }
}
}
