using System;
using System.Threading;
using NotVisualNovel.Config;

namespace NotVisualNovel
{
    public static class DelayedWriter
    {
        public static void WriteLineDelay(string text)
        {
            Console.Write("> ");
            foreach (var ch in text)
            {
                WriteCharDelay(ch);
            }
        }
        public static void WriteCharDelay(char character)
        {
            Thread.Sleep(NVNConfig.wordDelay);
            Console.Write(character);
        }
    }
}