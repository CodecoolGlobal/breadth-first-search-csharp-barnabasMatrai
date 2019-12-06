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

            UserNode startUser = users[0];
            UserNode endUser = users[1];

            GraphOperation graphOperation = new GraphOperation();

            foreach (KeyValuePair<HashSet<UserNode>, int> friendDistance in graphOperation.GetUserDistancesFromStartUser(startUser))
            {
                foreach (UserNode user in friendDistance.Key)
                {
                    Console.WriteLine($"{user.FirstName} {user.LastName}");
                }
                Console.WriteLine(friendDistance.Value);
            }

            Console.WriteLine(graphOperation.MinimumDistanceOfUsers(users[0], users[1]));

            foreach (UserNode userNode in graphOperation.FriendsOfFriendsAtDistance(users[0], 1))
            {
                Console.WriteLine($"{userNode.FirstName} {userNode.LastName}");
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
