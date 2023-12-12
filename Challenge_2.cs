using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventOfCode
{

    record GameSet(int Green, int Red, int Blue)
    {
        public static List<GameSet> ParseSets(string setInfo) => setInfo
            .Split(';', StringSplitOptions.TrimEntries)
            .Select(ParseSet)
            .ToList();

        public static GameSet ParseSet(string line)
        {
            var parts = line.Split(',', StringSplitOptions.TrimEntries);
            var regEx = new Regex(@"(?<id>\d+) (?<color>red|green|blue)", RegexOptions.IgnoreCase);
            Dictionary<string, int> colors = new Dictionary<string, int>
        {
            {"red",0},
            {"blue",0},
            {"green",0}
        };

            foreach (var part in parts)
            {
                Match game = regEx.Match(part);
                Group id = game.Groups["id"];
                Group color = game.Groups["color"];

                colors[color.Value] = int.Parse(id.Value);
            }
            return new GameSet(colors["green"], colors["red"], colors["blue"]);
        }
    }

    record Game(int GameId, List<GameSet> Sets)
    {
        public static Game Parse(string line)
        {
            var parts = line.Split(':', StringSplitOptions.TrimEntries);
            string pattern = @"\d+";
            var id = Regex.Match(parts[0], pattern).Value;

            return new Game(int.Parse(id), GameSet.ParseSets(parts[1]));
        }
    }
    internal class Challenge_2
    {
        const string FILE_PATH = "C:\\Users\\tsvetan.petrov\\source\\repos\\adventOfCode\\adventOfCode\\Inputs\\input2.txt";

        private Dictionary<string, int> maxValues = new Dictionary<string, int>
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };

        private bool IsValidGame(Game game) => game.Sets.All(IsValidSet);

        private bool IsValidSet(GameSet set) => set.Red <= maxValues["red"] && set.Green <= maxValues["green"] && set.Blue <= maxValues["blue"];

        private GameSet FindMaxSets(List<GameSet> sets) =>
            new GameSet(
                Red: sets.Max(s => s.Red),
                Green: sets.Max(s => s.Green),
                Blue: sets.Max(s => s.Blue)
            );

        private int ChallengePart1(Game[] games)
        {
            return games.Where(IsValidGame).Select(x => x.GameId).Sum();
        }

        private int ChallengePart2(Game[] games) =>
            games.Select(game => FindMaxSets(game.Sets))
                 .Select(x => x.Red * x.Green * x.Blue)
                 .Sum();

        public void WriteResult()
        {
            string[] lines = File.ReadAllLines(FILE_PATH);
            Game[] games = lines.Select(Game.Parse).ToArray();

            Console.WriteLine(ChallengePart1(games));
            Console.WriteLine(ChallengePart2(games));
        }
    }
}
