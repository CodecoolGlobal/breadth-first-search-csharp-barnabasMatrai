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
            Dictionary<UserNode, int> nodeDistances = GetNodeDistancesFromStartNode(startNode);

            if (nodeDistances.ContainsKey(endNode))
            {
                return nodeDistances[endNode];
            }

            return nodeDistances[startNode];
        }

        public HashSet<UserNode> FriendsOfFriendsAtDistance(UserNode startNode, int distance)
        {
            Dictionary<UserNode, int> nodeDistances = GetNodeDistancesFromStartNode(startNode);
            HashSet<UserNode> usersAtDistance = new HashSet<UserNode>();

            foreach (KeyValuePair<UserNode, int> user in nodeDistances)
            {
                if (user.Value == distance)
                {
                    usersAtDistance.Add(user.Key);
                }
            }

            return usersAtDistance;
        }

        private Dictionary<UserNode, int> GetNodeDistancesFromStartNode(UserNode startNode)
        {
            Queue<UserNode> queue = new Queue<UserNode>();
            Dictionary<UserNode, int> nodeDistances = new Dictionary<UserNode, int>();

            queue.Enqueue(startNode);
            var distance = 0;
            nodeDistances[startNode] = 0;

            while (queue.Count > 0)
            {
                var currentUser = queue.Dequeue();

                distance++;

                foreach (UserNode user in currentUser.Friends)
                {
                    if (!nodeDistances.ContainsKey(user))
                    {
                        nodeDistances[user] = distance;
                        queue.Enqueue(user);
                    }
                }
            }

            return nodeDistances;
        }
    }
}
