using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6;
internal class Part1
{
    internal static void Part1Main()
    {
        string[] lines = File.ReadAllLines("input.txt");

        int[] times = lines[0].Replace("Time: ", "").Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] distances = lines[1].Replace("Distance: ", "").Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int[] waysToBeat = new int[times.Length];

        for(int i=0; i<times.Length; i++)
        {
            int time = times[i];
            int distance = distances[i];

            Console.WriteLine($"Time: {time}, Distance: {distance}");

            int low = Helpers.BinarySearch(0, time, (int duration) => {
                int speed = duration;    
                int timeToRun = time - duration;

                return (duration * timeToRun) > distance;
            });

            Console.WriteLine($"Low: {low}");

            int high = time - low;
            
            waysToBeat[i] = high - low + 1;

        }

        Console.WriteLine(waysToBeat.Aggregate((a, b) => a * b));
    }

}
static partial class Helpers
{
    public static int BinarySearch(int low, int high, Func<int, bool> predicate)
    {
        while (low < high)
        {
            int mid = (low + high) / 2;
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
