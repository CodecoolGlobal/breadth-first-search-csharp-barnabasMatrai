using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            UserNode startNode = users[0];
            UserNode endNode = users[5];

            GraphOperation graphOperation = new GraphOperation();
            Console.WriteLine(graphOperation.MinimumDistance(startNode, endNode));

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
