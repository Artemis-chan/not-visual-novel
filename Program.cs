using System;
using System.Threading;
using NotVisualNovel.Config;

namespace NotVisualNovel
{
    class Program
    {
        static void Main(string[] args)
        {
            NVNConfig.Load();
            var story = new Story(NVNConfig.storyFile);
            story.Start();
        }

    }
}
