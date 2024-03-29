﻿using System.Diagnostics;

var sw = new Stopwatch();
Random random = new Random();

void SetConsoleBackgroundColor(ConsoleColor color) {
    Console.BackgroundColor = color;
    for (int i = 0; i < Console.WindowHeight; i++)
    {
        Console.WriteLine(new string(' ', Console.WindowWidth));
    }
}

void WriteCenteredText(string text) {
    Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
    Console.WriteLine(text);
}

void Main() {
    while (true) {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        WriteCenteredText("Thank you for running the Reaction Time Test.");
        WriteCenteredText("Press any key to start the test.");
        Console.ReadKey();

        Console.Clear();
        SetConsoleBackgroundColor(ConsoleColor.Red);
        Thread.Sleep(random.Next(3000, 6000));
        sw.Start();
        SetConsoleBackgroundColor(ConsoleColor.Green);
        var startTime = sw.ElapsedTicks;
        Console.ReadKey();
        var endTime = sw.ElapsedTicks;
        sw.Stop();

        var reactionTime = (double)(endTime - startTime) / Stopwatch.Frequency * 1000;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        if (sw.ElapsedMilliseconds < 10) {
            WriteCenteredText("You cannot press the button before it turns green.");
            WriteCenteredText("Press any key to play again.");
        } else {
            WriteCenteredText($"Your reaction time was {reactionTime}ms.");
            WriteCenteredText($"Press any key to play again.");
        }
        Console.ReadKey();
        sw.Reset();
    }
}

Main();