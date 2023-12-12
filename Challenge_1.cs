using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventOfCode
{
    internal class Challenge_1
    {
        const string FILE_PATH = "C:\\Users\\tsvetan.petrov\\source\\repos\\adventOfCode\\adventOfCode\\Inputs\\input1.txt";

        static Dictionary<string, string> translations = new Dictionary<string, string>
    {
        {"one", "one1one"},
        {"two", "two2two"},
        {"three", "three3three"},
        {"four", "four4four"},
        {"five", "five5five"},
        {"six", "six6six"},
        {"seven", "seven7seven"},
        {"eight", "eight8eight"},
        {"nine", "nine9nine"}
    };

        static string OnlyNumerics(string strInput)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char ch in strInput)
            {
                if (char.IsDigit(ch)) builder.Append(ch);
            }
            return builder.ToString();
        }

        static string ReplaceNumbers(string original)
        {
            foreach (var key in translations.Keys)
            {
                original = original.Replace(key, translations[key]);
            }
            return original;
        }

        static int GetFirstAndLast(string str)
        {
            int first = int.Parse(str[0].ToString());
            int last = int.Parse(str[^1].ToString());

            return first * 10 + last; // this converts first digit to a 10th digit e.g 1 = 10, 2 = 20
        }

        static int mainTask()
        {
            string[] lines = File.ReadAllLines(FILE_PATH);
            return lines.Select(OnlyNumerics).Select(GetFirstAndLast).Sum();
        }

        static int extraTask()
        {
            string[] lines = File.ReadAllLines(FILE_PATH);
            string[] replaced = lines.Select(ReplaceNumbers).ToArray();
            return replaced.Select(OnlyNumerics).Select(GetFirstAndLast).Sum();
        }

        public void Challenge_1_Output()
        {
            Console.WriteLine("Part 1:" + mainTask().ToString());
            Console.WriteLine("Part 2:" + extraTask().ToString());
        }
    }
}
