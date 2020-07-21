using System;
using System.Threading;

namespace NotVisualNovel
{
    class Program
    {
        static void Main(string[] args)
        {
            var story = new Story("teststory.txt");
            story.Start();
        }

    }
}
