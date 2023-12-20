using adventOfCode;

class Program
{
    public static void Main(string[] args)
    {
        var challenge1 = new Challenge_1();
        //challenge1.Challenge_1_Output();

        var challenge2 = new Challenge_2();
        //challenge2.WriteResult();

        var challenge3 = new Challenge_3();

        string input = File.ReadAllText("C:\\Users\\tsvetan.petrov\\source\\repos\\adventOfCode\\adventOfCode\\Inputs\\input3.txt");
        Console.WriteLine(challenge3.PartOne(input));
        challenge3.PartTwo(input);
    }
}