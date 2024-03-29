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

            UserNode startUser = users[0];
            UserNode endUser = users[1];

            GraphOperation graphOperation = new GraphOperation();

            graphOperation.ShowFriendsAndDistancesFromUser(startUser);

            Console.WriteLine(graphOperation.MinimumDistanceOfUsers(startUser, endUser));

            foreach (UserNode userNode in graphOperation.FriendsOfFriendsAtDistance(startUser, 1))
            {
                Console.WriteLine($"{userNode.FirstName} {userNode.LastName}");
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
