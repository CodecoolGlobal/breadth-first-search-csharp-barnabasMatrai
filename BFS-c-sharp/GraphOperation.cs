using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp
{
    public class GraphOperation
    {
        public int MinimumDistance(UserNode startNode, UserNode endNode)
        {
            //Dictionary<UserNode, int> nodeDistances = GetNodeDistancesFromStartNode(startNode);

            //if (nodeDistances.ContainsKey(endNode))
            //{
            //    return nodeDistances[endNode];
            //}

            //return nodeDistances[startNode];
            return 0;
        }

        public HashSet<UserNode> FriendsOfFriendsAtDistance(UserNode startNode, int distance)
        {
            //Dictionary<UserNode, int> nodeDistances = GetNodeDistancesFromStartNode(startNode);
            //HashSet<UserNode> usersAtDistance = new HashSet<UserNode>();

            //foreach (KeyValuePair<UserNode, int> user in nodeDistances)
            //{
            //    if (user.Value == distance)
            //    {
            //        usersAtDistance.Add(user.Key);
            //    }
            //}

            //return usersAtDistance;
            return new HashSet<UserNode>();
        }

        public Dictionary<HashSet<UserNode>, int> GetNodeDistancesFromStartNode(UserNode startUser)
        {
            Queue<UserNode> queue = new Queue<UserNode>();
            HashSet<UserNode> visited = new HashSet<UserNode>();
            HashSet<UserNode> dictionaryKey = new HashSet<UserNode>();
            Dictionary<HashSet<UserNode>, int> friendDistances = new Dictionary<HashSet<UserNode>, int>();

            HashSet<UserNode> previousFriendLayer = new HashSet<UserNode>();
            HashSet<UserNode> currentFriendLayer = new HashSet<UserNode>();

            int distance = -1;

            queue.Enqueue(startUser);
            visited.Add(startUser);
            currentFriendLayer.Add(startUser);

            while (queue.Count > 0)
            {
                UserNode currentUser = queue.Dequeue();

                if (!previousFriendLayer.Any(user => currentUser.Friends.Contains(user)))
                {
                    if (previousFriendLayer.Count > 0)
                    {
                        dictionaryKey = new HashSet<UserNode>(previousFriendLayer);
                        friendDistances[dictionaryKey] = distance;
                    }
                    previousFriendLayer = new HashSet<UserNode>(currentFriendLayer);
                    currentFriendLayer.Clear();

                    distance++;
                }

                if (!currentUser.Equals(startUser))
                {
                    currentFriendLayer.Add(currentUser);
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

            dictionaryKey = new HashSet<UserNode>(previousFriendLayer);
            friendDistances[dictionaryKey] = distance;

            distance++;

            dictionaryKey = new HashSet<UserNode>(currentFriendLayer);
            friendDistances[dictionaryKey] = distance;

            return friendDistances;
        }
    }
}
