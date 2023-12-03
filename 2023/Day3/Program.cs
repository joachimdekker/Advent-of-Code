string[] line = File.ReadAllLines("input.txt");

char[][] engine = line.Select(s => s.ToCharArray()).ToArray();

char[] parts = ['&', '+', '-', '#', '@', '$', '/', '%', '*', '='];

List<char> digits = [];
bool foundPartNumber = false;
int sum = 0;
for (int i = 0; i < engine.Length; i++)
{
    for (int j = 0; j < engine[i].Length; j++)
    {
        if (char.IsDigit(engine[i][j]))
        {
            digits.Add(engine[i][j]);

            if (LookaroundForParts(i, j))
            {
                foundPartNumber = true;
            }
        }
        else
        {
            if (foundPartNumber)
            {
                Console.WriteLine($"Found part number: {string.Join("", digits)} ({i},{j})");
                sum += int.Parse(string.Join("", digits));
            }
            else
            {
                if (digits.Count > 0)
                {
                    Console.WriteLine($"Found no part number for digits: {string.Join("", digits)} ({i},{j})");
                }
            }

            foundPartNumber = false;
            digits.Clear();
        }
    }
}

Console.WriteLine($"Sum: {sum}");

bool LookaroundForParts(int i, int j)
{
    (int xmin, int xmax) = (Math.Max(0, i - 1), Math.Min(engine.Length - 1, i + 1));
    (int ymin, int ymax) = (Math.Max(0, j - 1), Math.Min(engine[i].Length - 1, j + 1));

    for (int x = xmin; x <= xmax; x++)
    {
        for (int y = ymin; y <= ymax; y++)
        {
            char[] line = engine[x];
            char char1 = line[y];
            if (parts.Contains(char1))
            {
                return true;
            }
        }
    }

    return false;
}