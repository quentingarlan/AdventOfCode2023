namespace Day4;

class Program
{
    static string puzzleInput = @"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";

    static void Main(string[] args)
    {
        Part2();
    }

    static void Part1()
    {
        var lines = Input.puzzleInput.Split("\n"); //split the string in lines
        var cards = lines.Select(i => i.Split(":")[1]);
        int total = 0;
        foreach (var card in cards)
        {
            var game = card.Split('|');
            var winningNumbers = StringListToInt(game[0].Split(" ").ToList());
            var myGame = StringListToInt(game[1].Split(" ").ToList());

            var myWinningNumbers = winningNumbers.Select(i => i).Intersect(myGame);

            if (myWinningNumbers.Count() == 1)
            {
                total += myWinningNumbers.Count();
            }
            else if (myWinningNumbers.Count() > 1)
            {
                total += (int)Math.Pow(2, myWinningNumbers.Count() - 1);
            }

        }

    }
    static void Part2()
    {
        var lines = Input.puzzleInput.Split("\n"); //split the string in lines
        var cards = lines.Select(i => i.Split(":")[1]);

        List<int> cardsCount = new List<int>();
        int copyIndex = 1;
        foreach (var card in cards)
        {
            var game = card.Split('|');
            var winningNumbers = StringListToInt(game[0].Split(" ").ToList());
            var myGame = StringListToInt(game[1].Split(" ").ToList());

            var myWinningNumbers = winningNumbers.Select(i => i).Intersect(myGame);

            if (cardsCount.Count < copyIndex) cardsCount.Add(1);
            else cardsCount[copyIndex - 1]++;

            int intersectCount = myWinningNumbers.Count();
            int currentCardCopies = cardsCount[copyIndex - 1];

            for (int cardNumber = copyIndex + 1; cardNumber <= copyIndex + intersectCount; cardNumber++)
            {
                if (cardNumber > cardsCount.Count)
                {
                    cardsCount.Add(currentCardCopies);
                }
                else
                {
                    cardsCount[cardNumber - 1] += currentCardCopies;
                }
            }

            copyIndex++;

        }
        var result = cardsCount.Sum();
        Console.WriteLine("result" + result);
    }

    static List<int> StringListToInt(List<string> stringList)
    {
        var myString = "010";
        int myInt;
        List<int> B = stringList.Where(x => int.TryParse(x.ToString(), out myInt)).Select(x => int.Parse(x.ToString())).ToList();

        return B;
    }

}
