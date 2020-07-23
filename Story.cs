using System;
using System.IO;
using System.Text.RegularExpressions;
using NotVisualNovel.Modules;

namespace NotVisualNovel
{
    public class Story
    {
        private string[] _storyLines;
        private int _len;
        private int _linePointer = 0;

        public Story(string storyFile)
        {
            _storyLines = System.IO.File.ReadAllLines(storyFile);
            _len = _storyLines.Length;
        }

        public void Start()
        {
            while (_linePointer < _len)
            {
                ProcessLine(_storyLines[_linePointer]);
            }
        }

        private void ProcessLine(string line)
        {
            if(line.StartsWith('$'))
            {
                var match = Regex.Match(line, @"(?<=\$jmp\s)\d+", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    //Console.Write($"Jump to {match.Value}");
                    _linePointer = int.Parse(match.Value) - 1;
                    return;
                }

                if(line.StartsWith("$choice"))
                {
                    var matches = Regex.Matches(line, @"(?<=\$choice|\|)[^\|]+:\s*[1-9]+", RegexOptions.IgnoreCase);
                    if (matches.Count > 0)
                    {
                        ParseChoice(matches);
                        return;
                    }
                }
            }
            DelayedWriter.WriteLineDelay(line);
            Console.ReadKey(true);
            Console.Write("\n");
            _linePointer++;
        }

        private void ParseChoice(MatchCollection matches)
        {
            var count = matches.Count;
            var choices = new Choice[count];
            for (int i = 0; i < count; i++)
            {
                choices[i] = new Choice(matches[i].Value);
                DelayedWriter.WriteLineDelay($"{i} - {choices[i].text}\n");
            }
            _linePointer = choices[GetChoice(count)].targetLine - 1;
        }

        private int GetChoice(int count)
        {
            //DelayedWriter.WriteLineDelay("Enter choice.\n");
            int choice;
            while(true)
            {
                if(int.TryParse(Console.ReadLine(), out choice))
                {
                    if(choice < count)
                    {
                        break;
                    }
                }
                DelayedWriter.WriteLineDelay("Enter a valid choice\n");
            }
            return choice;
        }
    }
}