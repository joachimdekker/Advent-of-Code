// See https://aka.ms/new-console-template for more information

string[] input = File.ReadAllLines("input.txt");

int sum = 0;
(string digit, int num)[] mapping = [("sevenineight", 798), ("oneight", 18), ("threeight", 38), ("fiveight", 58), ("nineight", 98), ("sevenine", 79), ("twone", 21), ("eightwo", 82), ("one", 1), ("two", 2), ("three", 3), ("four", 4), ("five", 5), ("six", 6), ("seven", 7), ("eight", 8), ("nine", 9)];
foreach (string line in input)
{
    int[] numbers = GetAllNumbers(line, mapping);
    sum += (numbers[0] * 10) + numbers[^1];
}

static int[] GetAllNumbers(string line, (string digit, int num)[] mapping)
{
    List<int> ints = [];

    // Get location of all digits
    foreach ((string digit, int num) in mapping)
    {
        line = line.Replace(digit, num.ToString());

    }

    // Get all numbers
    foreach (char c in line)
    {
        if (char.IsDigit(c))
        {
            ints.Add(c - 48);
        }
    }

    return ints.ToArray();
}

Console.WriteLine(sum);
