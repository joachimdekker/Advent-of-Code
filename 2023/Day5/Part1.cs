namespace Day5;

internal class Part1
{
    private static void Part1Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");

        long[] seeds = lines[0].Replace("seeds: ", "").Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
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

        Mapping[][] MappingChain = new Mapping[][]
        {
            seedToSoil,
            soilToFertilizer,
            fertilizerToWater,
            waterToLight,
            lightToTemperature,
            temperatureToHumidity,
            humidityToLocation
        };


        List<long> locations = [];

        // Translate the seeds to soil
        foreach (long seed in seeds)
        {
            long answer = seed;
            Console.WriteLine("Seed: " + seed);
            foreach (Mapping[] mapping in MappingChain)
            {
                foreach (Mapping m in mapping)
                {
                    if (m.TryMap(answer, out long mapped))
                    {
                        Console.WriteLine($"Mapped {answer} to {mapped}");
                        answer = mapped;
                        break;
                    }
                }
            }

            Console.WriteLine(answer);
            locations.Add(answer);
        }

        Console.WriteLine($"Final Answer: {locations.Min()}");
    }
}

internal class Mapping
{
    public long Destination;
    public long Source;
    public long Range;

    public static Mapping FromString(string line)
    {
        string[] strings = line.Split(' ');
        return new()
        {
            Destination = long.Parse(strings[0]),
            Source = long.Parse(strings[1]),
            Range = long.Parse(strings[2])
        };
    }

    public bool TryMap(long value, out long mapping)
    {
        long offset = value - Source;
        if (offset >= 0 && offset < Range)
        {
            mapping = Destination + offset;
            return true;
        }

        mapping = value;
        return false;
    }
}