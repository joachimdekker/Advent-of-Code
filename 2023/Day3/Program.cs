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
        if (engine[i][j] == '*')
        {
            int[] nums = LookAroundForNums(i, j);

            if(nums.Length == 2)
            {
                sum += nums[0] * nums[1];
            }
        }
    }
/*
    if (foundPartNumber)
    {
        Console.WriteLine($"Found part number: {string.Join("", digits)} (EOL)");
        sum += int.Parse(string.Join("", digits));
    }
    else
    {
        if (digits.Count > 0)
        {
            Console.WriteLine($"Found no part number for digits: {string.Join("", digits)} (EOL)");
        }
    }

    foundPartNumber = false;
    digits.Clear();*/

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


int[] LookAroundForNums(int i, int j)
{
    (int xmin, int xmax) = (Math.Max(0, i - 1), Math.Min(engine.Length - 1, i + 1));
    (int ymin, int ymax) = (Math.Max(0, j - 1), Math.Min(engine[i].Length - 1, j + 1));

    List<int> nums = [];

    for (int x = xmin; x <= xmax; x++)
    {
        for (int y = ymin; y <= ymax; y++)
        {

            char[] line = engine[x];
            char char1 = line[y];
            if (char.IsDigit(engine[x][y]))
            {
                int num = GetNum(x, y);
                if(!nums.Contains(num))
                {
                    nums.Add(GetNum(x, y));
                }
            }
        }
    }

    return nums.ToArray();
}

int GetNum(int i, int j)
{
    int num = 0;
    int multiplier = 1;

    int jTemp = j;

    List<char> digits = [engine[i][j]];

    jTemp--;

    while (char.IsDigit(engine[i][j]) && jTemp > 0)
    {
        digits.Insert(0, engine[i][jTemp]);
        jTemp--;
    }

    jTemp = j;

    while (char.IsDigit(engine[i][j]) && jTemp < engine[i].Length - 1)
    {
        digits.Add(engine[i][jTemp]);
        jTemp++;
    }

    return num;
}