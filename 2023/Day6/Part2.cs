using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6;
internal class Part2
{
    internal static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");

        long time = long.Parse(string.Join("",lines[0].Replace("Time: ", "").Split(' ', StringSplitOptions.RemoveEmptyEntries)));
        long distance = long.Parse(string.Join("", lines[1].Replace("Distance: ", "").Split(' ', StringSplitOptions.RemoveEmptyEntries)));

        Console.WriteLine($"Time: {time}, Distance: {distance}");

        long low = Helpers.BinarySearch(0, time, (long duration) => {
            long speed = duration;    
            long timeToRun = time - duration;

            return (duration * timeToRun) > distance;
        });

        Console.WriteLine($"Low: {low}");

        long high = time - low;
            
        long waysToBeat = high - low + 1;

        Console.WriteLine(waysToBeat);
    }

}

static partial class Helpers
{
    public static long BinarySearch(long low, long high, Func<long, bool> predicate)
    {
        while (low < high)
        {
            long mid = (low + high) / 2;
            if (predicate(mid))
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }
}
