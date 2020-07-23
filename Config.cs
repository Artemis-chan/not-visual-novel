using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NotVisualNovel.Config
{
    public static class NVNConfig
    {
        public static string storyFile = "storyFile.txt";
        public static int wordDelay = 100;

        public static void Load()
        {
            var matches = Regex.Matches(File.ReadAllText("config.ini"), @"^((?!\/\/).)+", RegexOptions.Multiline);
            var fields = typeof(NVNConfig).GetFields();
            foreach (Match line in matches)
            {
                var config = line.Value.Split('=');
                foreach (var field in fields)
                {
                    if(field.Name.Equals(config[0].Trim()))
                    {
                        field.SetValue(null, TypeDescriptor.GetConverter(field.FieldType).ConvertFromString(config[1].Trim()));
                    }
                }
            }
        }
    }
}