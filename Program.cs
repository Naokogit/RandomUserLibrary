using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUserLibrary
{
    public class Program
    {
        static void Main(string[] args)
        {
            // https://github.com/Naokogit/RandomUserLibrary

            RandomUser randomUser = new RandomUser();
            List<RandomUser.Result> users = randomUser.GetUsersAsync(10).Result.results;

            foreach (RandomUser.Result item in users)
                Console.WriteLine(item.name.first + " " + item.name.last);

            Console.ReadKey();
        }
    }
}
