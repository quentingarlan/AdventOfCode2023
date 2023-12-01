using System.Text.RegularExpressions;

namespace Day1;

class Program
{
    static string puzzleInput = @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen";

    static void Main(string[] args)
    {
        Part2();

    }

    static void Part1()
    {
        var instructions = Input.realInput.Split("\n");
        List<int> numbers = [];
        int total = 0;
        foreach (var instr in instructions)
        {
            List<Char> numbersInInstr = instr.Where(char.IsDigit).ToList();
            var number = numbersInInstr.First() + "" + numbersInInstr.Last();
            total += int.Parse(number);
        }
        Console.WriteLine("total" + total);
    }

    static void Part2()
    {
        var instructions = Input.realInput.Split("\n");
        List<int> numbers = [];
        int total = 0;
        foreach (var instr in instructions)
        {
            string match = @"\d|one|two|three|four|five|six|seven|eight|nine";
            var first = Regex.Match(instr, match);
            var last = Regex.Match(instr, match, RegexOptions.RightToLeft);

            total += ParseMatch(first.Value) * 10 + ParseMatch(last.Value);
        }
        Console.WriteLine("total" + total);
    }

    static int ParseMatch(string st) => st switch
    {
        "" => 0, // no match
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        var d => int.Parse(d)
    };
}
