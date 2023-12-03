string[] line = File.ReadAllLines("input.txt");

char[][] engine = line.Select(s => s.ToCharArray()).ToArray();

char[] parts = ['&', '+', '-', '#', '@', '$', '/', '%', '*', '='];

List<char> digits = [];
List<int> associatedGears = [];

List<(int num, int index)> gears = [];

bool foundPartNumber = false;
int sum = 0;
for (int i = 0; i < engine.Length; i++)
{
    for (int j = 0; j < engine[i].Length; j++)
    {
        if (char.IsDigit(engine[i][j]))
        {
            digits.Add(engine[i][j]);
            List<int> foundParts = LookaroundForParts(i, j);
            if (foundParts.Count > 0)
            {
                associatedGears.AddRange(foundParts);
                foundPartNumber = true;
            }
        }
        else
        {
            if (foundPartNumber)
            {
                int num = int.Parse(string.Join("", digits));
                gears.AddRange(associatedGears.Select((g) => (num, g)));
            }

            foundPartNumber = false;
            associatedGears.Clear();
            digits.Clear();
        }
    }

    if (foundPartNumber)
    {
        int num = int.Parse(string.Join("", digits));
        gears.AddRange(associatedGears.Select((g) => (num, g)));
    }

    foundPartNumber = false;
    associatedGears.Clear();
    digits.Clear();
}

sum = gears.Distinct().GroupBy(g => g.index).Sum(s =>
{
    if (s.Count() != 2)
    {
        return 0;
    }

    int product = 1;
    foreach ((int num, int index) in s)
    {
        product *= num;
    }

    return product;
});

Console.WriteLine($"Sum: {sum}");

List<int> LookaroundForParts(int i, int j)
{
    (int xmin, int xmax) = (Math.Max(0, i - 1), Math.Min(engine.Length - 1, i + 1));
    (int ymin, int ymax) = (Math.Max(0, j - 1), Math.Min(engine[i].Length - 1, j + 1));

    List<int> locations = [];

    for (int x = xmin; x <= xmax; x++)
    {
        for (int y = ymin; y <= ymax; y++)
        {

            char[] line = engine[x];
            char char1 = line[y];
            if (char1 == '*')
            {
                locations.Add((x * engine.Length) + y);
            }
        }
    }

    return locations;
}