
namespace Day2;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] strings = File.ReadAllLines("input.txt");

        Game[] games = strings.Select(s =>
        {
            string[] split = s.Split(":");
            int id = int.Parse(split[0].Split(" ")[^1]);

            Subset[] subsets = split[1].Split(";").Select((subsetString) =>
            {
                string[] colourStrings = subsetString.Split(",");
                Colour[] colours = colourStrings.Select((colourString) =>
                {
                    string[] colourSplit = colourString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    return new Colour
                    {
                        Name = colourSplit[^1],
                        Number = int.Parse(colourSplit[0])
                    };
                }).ToArray();

                return new Subset
                {
                    Colours = colours
                };
            }).ToArray();

            return new Game
            {
                Id = id,
                Subsets = subsets
            };
        }).ToArray();

        int sum = 0;

        Dictionary<string, int> lowest;

        foreach (Game game in games)
        {
            lowest = new Dictionary<string, int>
            {
                { "red", 0 },
                { "blue", 0 },
                { "green", 0 }
            };

            foreach (Subset subset in game.Subsets)
            {
                foreach (Colour colour in subset.Colours)
                {
                    lowest[colour.Name] = Math.Max(lowest[colour.Name], colour.Number);

                    // Part 1
                    /*if ((colour.Name == "red" && colour.Number > 12)
                     || (colour.Name == "blue" && colour.Number > 14)
                     || (colour.Name == "green" && colour.Number > 13))
                    {
                        broken = true;
                        break;
                    }*/
                }

                /*if (broken)
                {
                    break;
                }*/
            }

            sum += lowest["red"] * lowest["blue"] * lowest["green"];

            /*if (!broken)
            {
                sum += game.Id;
            }*/
        }

        Console.WriteLine(sum);
    }
}

public class Subset
{
    public required Colour[] Colours { get; set; }
}

public class Colour
{
    public required string Name { get; set; }
    public int Number { get; set; }
}

public class Game
{
    public int Id { get; set; }
    public required Subset[] Subsets { get; set; }
}
