namespace Day5;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");

        int[] seeds = lines[0].Replace("seeds: ", "").Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        lines = lines[3..];
        Mapping[] seedToSoil = lines.TakeWhile(s => s != "").Select(Mapping.FromString).ToArray();
        lines = lines[(seedToSoil.Length + 2)..];

        Mapping[] soilToFertilizer = lines.TakeWhile(s => s != "").Where(s => s != "").Select(Mapping.FromString).ToArray();
        lines = lines[(soilToFertilizer.Length + 2)..];

        Mapping[] fertilizerToWater = lines.TakeWhile(s => s != "").Select(Mapping.FromString).ToArray();
        lines = lines[(fertilizerToWater.Length + 2)..];

        Mapping[] waterToLight = lines.TakeWhile(s => s != "").Select(Mapping.FromString).ToArray();
        lines = lines[(waterToLight.Length + 2)..];

        Mapping[] lightToTemperature = lines.TakeWhile(s => s != "").Select(Mapping.FromString).ToArray();
        lines = lines[(lightToTemperature.Length + 2)..];

        Mapping[] temperatureToHumidity = lines.TakeWhile(s => s != "").Select(Mapping.FromString).ToArray();
        lines = lines[(temperatureToHumidity.Length + 2)..];

        Mapping[] humidityToLocation = lines.Select(Mapping.FromString).ToArray();

    }
}

internal class Mapping
{
    public int Destination;
    public int Source;
    public int Range;

    public static Mapping FromString(string line)
    {
        string[] strings = line.Split(' ');
        return new()
        {
            Destination = int.Parse(strings[0]),
            Source = int.Parse(strings[1]),
            Range = int.Parse(strings[2])
        };
    }
}