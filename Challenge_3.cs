using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventOfCode
{
    internal class Challenge_3
    {
        const string FILE_PATH = "C:\\Users\\tsvetan.petrov\\source\\repos\\adventOfCode\\adventOfCode\\Inputs\\input3.txt";

        private void challenge_3()
        {
            var input = File.ReadAllLines(FILE_PATH);
            var matrix = new char[input.Length][];
            for (int i = 0; i < input.Length; i++)
            {
                matrix[i] = input[i].ToCharArray();
            }
            GetSymbol(matrix);
        }

        private void GetSymbol(char[][] matrix)
        {
            var sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(0); y++)
                {
                    char symbol = matrix[i][y];
                    if (!char.IsDigit(symbol) && symbol != '.')
                    {
                        string pattern = @$"\d\{symbol}\d|\{symbol}\d|\d\{symbol}";
                        var symbolsToCheckForDigit = new List<char>()
                        {
                            matrix[i-1][y-1], matrix[i-1][y], matrix[i-1][y+1],
                            matrix[i][y-1],matrix[i][y+1],
                            matrix[i+1][y-1],matrix[i+1][y], matrix[i+1][y+1]
                        };
                        foreach (var ch in symbolsToCheckForDigit)
                        {
                            if (char.IsDigit(ch))
                            {
                                Console.WriteLine(ch);
                            }
                        }
                        
                    }
                }
            }
            Console.WriteLine(sum);
        }
        public void WriteResult()
        {
            challenge_3();
        }
    }
}
