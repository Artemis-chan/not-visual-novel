using System;
using System.Threading;

namespace NotVisualNovel
{
    public static class DelayedWriter
    {
        public static int sleepTime = 70;
        public static void WriteLineDelay(string text)
        {
            foreach (var ch in text)
            {
                WriteCharDelay(ch);
            }
        }
        public static void WriteCharDelay(char character)
        {
            Thread.Sleep(sleepTime);
            Console.Write(character);
        }
    }
}