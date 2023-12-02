namespace Day2;

class Program
{
    static string puzzleInput = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

    static void Main(string[] args)
    {
        Part2();
    }

    static void Part1()
    {
        var games = Input.realInput.Split("\n");
        int redBagCount = 12;
        int greenBagCount = 13;
        int blueBagCount = 14;
        int total = 0;
        int gameCount = 1;

        foreach (var game in games)
        {
            var instructions = game.Split(":")[1];
            var sets = instructions.Split(";");
            bool correctGame = true;
            foreach (var set in sets)
            {
                var subSets = set.Split(",");
                foreach (var subSet in subSets)
                {
                    int redCount = 0;
                    int greenCount = 0;
                    int blueCount = 0;
                    int cubeCount = int.Parse(subSet.Split(" ")[1]);
                    string color = subSet.Split(" ")[2].Trim();

                    switch (color)
                    {
                        case "red":
                            redCount += cubeCount;

                            if (redCount > redBagCount)
                            {
                                correctGame = false;
                            }
                            break;
                        case "green":
                            greenCount += cubeCount;
                            if (greenCount > greenBagCount)
                            {
                                correctGame = false;
                            }
                            break;
                        case "blue":
                            blueCount += cubeCount;
                            if (blueCount > blueBagCount)
                            {
                                correctGame = false;
                            }
                            break;
                        default:
                            Console.WriteLine("EROR EROREROREROREROREROREROREROREROREROREROREROR" + gameCount);
                            break;
                    }
                }
            }
            if (correctGame)
            {
                total += gameCount;
            }
            gameCount++;
        }

        Console.WriteLine("total" + total);
    }


    static void Part2()
    {
        var games = Input.realInput.Split("\n");
        int redBagCount = 12;
        int greenBagCount = 13;
        int blueBagCount = 14;
        int total = 0;
        int gameCount = 1;

        foreach (var game in games)
        {
            var instructions = game.Split(":")[1];
            var sets = instructions.Split(";");
            bool correctGame = true;
            int maxRed = 0;
            int maxGreen = 0;
            int maxBlue = 0;
            foreach (var set in sets)
            {
                var subSets = set.Split(",");
                foreach (var subSet in subSets)
                {
                    int cubeCount = int.Parse(subSet.Split(" ")[1]);
                    string color = subSet.Split(" ")[2].Trim();

                    switch (color)
                    {
                        case "red":
                            if (cubeCount > maxRed)
                            {
                                maxRed = cubeCount;
                            }
                            break;
                        case "green":
                            if (cubeCount > maxGreen)
                            {
                                maxGreen = cubeCount;
                            }
                            break;
                        case "blue":
                            if (cubeCount > maxBlue)
                            {
                                maxBlue = cubeCount;
                            }
                            break;
                        default:
                            Console.WriteLine("EROR EROREROREROREROREROREROREROREROREROREROREROR" + gameCount);
                            Console.WriteLine("color " + color);
                            break;
                    }
                }

            }
            total += maxBlue * maxGreen * maxRed;
            gameCount++;
        }

        Console.WriteLine("total" + total);
    }
}
