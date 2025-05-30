using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

class RainfallProgram
{
    static void Main()
    {
        Console.Clear();
        Console.Write("Enter your name (English alphabets only): ");
        string name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name) || !IsEnglishAlphabets(name))
        {
            Console.Write("Invalid input. Please enter your name (English alphabets only): ");
            name = Console.ReadLine();
        }

        int nameLength = name.Length;
        Console.Clear();
        Console.SetCursorPosition((Console.WindowWidth - nameLength) / 2, 0);
        Console.WriteLine(name);
        Thread.Sleep(1000);

        for (int i = 0; i < name.Length; i++)
        {
            RainDrop(name[i], i);
        }

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }

    static bool IsEnglishAlphabets(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c) || c > 127)
                return false;
        }
        return true;
    }

    static void RainDrop(char c, int position)
    {
        int col = (Console.WindowWidth - (position + 1)) / 2 + position;
        for (int row = 1; row < Console.WindowHeight - 2; row++)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(c);
            PlayRainSound();
            Thread.Sleep(80);
            Console.SetCursorPosition(col, row);
            Console.Write(' ');
        }
        Console.SetCursorPosition(col, Console.WindowHeight - 2);
        Console.Write(c);
    }

    static void PlayRainSound()
    {
        Console.Beep(800, 40); // Simulate rain sound
    }
}
