using System;

namespace NotVisualNovel.Modules
{
    public class Choice
    {
        public string text;
        public int targetLine;
        public Choice(string parseText)
        {
            var temp = parseText.Split(':');
            text = temp[0];
            targetLine = int.Parse(temp[1]);
        }
    }
}