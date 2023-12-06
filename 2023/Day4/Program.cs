string[] lines = File.ReadAllLines("input.txt");

int sum = 0;

int[] totalCards = new int[lines.Length];
for (int i = 0; i < lines.Length; i++)
{
    totalCards[i] = 1;
}

foreach (string line in lines)
{
    string[] split = line.Split('|');
    string[] card = split[0].Split(":");

    int cardNum = int.Parse(card[0].Split(" ")[^1]);
    int[] winningNumbers = card[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    int[] ownNumbers = split[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    int prices = ownNumbers.Where(winningNumbers.Contains).Count();

    for (int i = cardNum; i < cardNum + prices && i < lines.Length; i++)
    {
        totalCards[i] += totalCards[cardNum - 1];
    }
}

sum = totalCards.Sum();

Console.WriteLine(sum);