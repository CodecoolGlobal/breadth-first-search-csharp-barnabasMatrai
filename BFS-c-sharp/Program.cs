﻿using BFS_c_sharp.Model;
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
            UserNode endNode = users[1];

            GraphOperation graphOperation = new GraphOperation();
            foreach (KeyValuePair<HashSet<UserNode>, int> friendDistance in graphOperation.GetNodeDistancesFromStartNode(startNode))
            {
                foreach (UserNode user in friendDistance.Key)
                {
                    Console.WriteLine($"{user.FirstName} {user.LastName}");
                }
                Console.WriteLine(friendDistance.Value);
            }

            //Console.WriteLine(graphOperation.MinimumDistance(startNode, endNode));

            //var distance = 1;

            //foreach (UserNode user in graphOperation.FriendsOfFriendsAtDistance(startNode, distance))
            //{
            //    Console.WriteLine($"{user.FirstName} {user.LastName}");
            //}

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
