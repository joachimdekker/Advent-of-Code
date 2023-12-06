namespace Day5;

internal class Part2
{
    private static void Main(string[] args)
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

        Mapping[][] MappingChain =
        [
            seedToSoil,
            soilToFertilizer,
            fertilizerToWater,
            waterToLight,
            lightToTemperature,
            temperatureToHumidity,
            humidityToLocation
        ];

        List<(long, long)> seedsNRanges = [];

        for(int i = 0; i < seeds.Length; i+= 2)
        {
            seedsNRanges.Add((seeds[i], seeds[i+1]));
        }


        long minLocation = long.MaxValue;
        // Translate the seeds to soil
        foreach ((long seed, long range) in seedsNRanges)
        {
            Console.WriteLine($"Seed: {seed}, Range: {range}");
            for(long i = seed; i < seed + range; i++)
            {
                long answer = i;
                foreach (Mapping[] mapping in MappingChain)
                {
                    foreach (Mapping m in mapping)
                    {
                        if (m.TryMap(answer, out long mapped))
                        {
                            answer = mapped;
                            break;
                        }
                    }
                }

                if (answer < minLocation)
                {
                    minLocation = answer;
                    Console.WriteLine($"New Min: {minLocation}");
                }
            }
        }

        Console.WriteLine($"Final Answer: {minLocation}");
    }
}