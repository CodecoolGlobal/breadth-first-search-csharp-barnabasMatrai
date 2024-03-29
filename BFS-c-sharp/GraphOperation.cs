﻿using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp
{
    public class GraphOperation
    {
        public void ShowFriendsAndDistancesFromUser(UserNode startUser)
        {
            foreach (KeyValuePair<HashSet<UserNode>, int> friendDistance in GetUserDistancesFromUser(startUser))
            {
                foreach (UserNode user in friendDistance.Key)
                {
                    Console.WriteLine($"{user.FirstName} {user.LastName}");
                }
                Console.WriteLine(friendDistance.Value);
            }
        }

        public int? MinimumDistanceOfUsers(UserNode startUser, UserNode endUser)
        {
            Dictionary<HashSet<UserNode>, int> userDistances = GetUserDistancesFromUser(startUser);

            int? distance = null;

            foreach (KeyValuePair<HashSet<UserNode>, int> userDistance in userDistances)
            {
                if (userDistance.Key.Contains(endUser))
                {
                    distance = userDistance.Value;
                }
            }

            return distance;
        }

        public HashSet<UserNode> FriendsOfFriendsAtDistance(UserNode startUser, int distance)
        {
            Dictionary<HashSet<UserNode>, int> userDistances = GetUserDistancesFromUser(startUser);

            HashSet<UserNode> usersAtDistance = null;

            foreach (KeyValuePair<HashSet<UserNode>, int> userDistance in userDistances)
            {
                if (userDistance.Value == distance)
                {
                    usersAtDistance = userDistance.Key;
                }
            }

            return usersAtDistance;
        }

        private Dictionary<HashSet<UserNode>, int> GetUserDistancesFromUser(UserNode startUser)
        {
            Queue<UserNode> queue = new Queue<UserNode>();
            HashSet<UserNode> visited = new HashSet<UserNode>();
            HashSet<UserNode> dictionaryKey = new HashSet<UserNode>();
            Dictionary<HashSet<UserNode>, int> userDistances = new Dictionary<HashSet<UserNode>, int>();

            HashSet<UserNode> previousUserLayer = new HashSet<UserNode>();
            HashSet<UserNode> currentUserLayer = new HashSet<UserNode>();

            int distance = -1;

            queue.Enqueue(startUser);
            visited.Add(startUser);
            currentUserLayer.Add(startUser);

            while (queue.Count > 0)
            {
                UserNode currentUser = queue.Dequeue();

                if (!previousUserLayer.Any(user => currentUser.Friends.Contains(user)))
                {
                    if (previousUserLayer.Count > 0)
                    {
                        userDistances = AddKeyToDictionaryWithValue(userDistances, previousUserLayer, distance);
                    }
                    previousUserLayer = new HashSet<UserNode>(currentUserLayer);
                    currentUserLayer.Clear();

                    distance++;
                }

                if (!currentUser.Equals(startUser))
                {
                    currentUserLayer.Add(currentUser);
                }

                foreach (UserNode friend in currentUser.Friends)
                {
                    if (!visited.Contains(friend))
                    {
                        queue.Enqueue(friend);

                        visited.Add(friend);
                    }
                }
            }

            userDistances = AddKeyToDictionaryWithValue(userDistances, previousUserLayer, distance);

            distance++;

            userDistances = AddKeyToDictionaryWithValue(userDistances, currentUserLayer, distance);

            return userDistances;
        }

        private Dictionary<HashSet<UserNode>, int> AddKeyToDictionaryWithValue(Dictionary<HashSet<UserNode>, int> dictionary, HashSet<UserNode> key, int distance)
        {
            HashSet<UserNode> dictionaryKey = new HashSet<UserNode>(key);
            dictionary[dictionaryKey] = distance;

            return dictionary;
        }
    }
}
