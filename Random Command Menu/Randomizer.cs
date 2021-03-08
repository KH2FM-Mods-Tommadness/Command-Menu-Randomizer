using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using YamlDotNet;

namespace Random_Command_Menu
{
    class Randomizer
    {
        List<string> commandMenuNames;
        public Randomizer()
        {
            commandMenuNames = new List<string>();
            var input = File.ReadAllText("mod.yml");
            foreach (var commandMenu in Directory.GetFiles("CommandMenus"))
            {
                commandMenuNames.Add(commandMenu);
            }

            MatchEvaluator evaluator = new MatchEvaluator(Randomize);
            var textout = Regex.Replace(input, @"- name: ((?!field2d).*)\r", evaluator,RegexOptions.ExplicitCapture);

            File.WriteAllText("mod.yml", textout);
        }

        private string Randomize(Match match)
        {
            Random rnd = new Random();
            string newMenu;

            if (commandMenuNames.Count > 0)
            {
                newMenu = commandMenuNames[rnd.Next(0, commandMenuNames.Count)];
                commandMenuNames.Remove(newMenu);
                return "- name: " + newMenu.Replace(@"\",@"/") + "\r";
            }
            return null;

        }
    }
}
