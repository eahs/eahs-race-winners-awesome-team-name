using System;
using System.Threading.Tasks;
using System.Linq;

namespace RaceWinners;

public class Program
{
    static async Task Main(string[] args)
    {
        DataService ds = new DataService();

        // Asynchronously retrieve the group (class) data
        var data = await ds.GetGroupRanksAsync();
        var min = data.OrderBy(i => i.Ranks.Average()).First();
        for (int i = 0; i < data.Count; i++)
        {
            // Combine the ranks to print as a list
            var ranks = String.Join(", ", data[i].Ranks);

            Console.WriteLine($"{data[i].Name} - [{ranks}]");

        }
        Console.WriteLine($"The winner is: {min.Name}");
    }
}