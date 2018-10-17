using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE19_DijkstrasAlgorithm
{
    class Graph
    {
        private int[,] adjMatrix;
        private Dictionary<String, Vertex> dictionary;
        private List<Vertex> list;

        public Graph()
        {
            Vertex a = new Vertex("Bedroom");
            Vertex b = new Vertex("Bathroom");
            Vertex c = new Vertex("Living Room");
            Vertex d = new Vertex("Kitchen");
            Vertex e = new Vertex("Exit");

            dictionary = new Dictionary<string, Vertex>();
            dictionary.Add(a.Name, a);
            dictionary.Add(b.Name, b);
            dictionary.Add(c.Name, c);
            dictionary.Add(d.Name, d);
            dictionary.Add(e.Name, e);

            list = new List<Vertex> { a, b, c, d, e };
            adjMatrix = new int[5, 5]
            {
                {0, 1, 3, 0, 0},
                {1, 0, 0, 1, 0},
                {3, 0, 0, 2, 1},
                {0, 1, 2, 0, 0},
                {0, 0, 1, 0, 0},
            };
        }

        public void ShortestPath(string startingVertex)
        {
            Vertex start;
            Vertex current;
            bool remainingNonPermanentVertices = true;

            // Makes sure the starting vertex exists
            if (!dictionary.ContainsKey(startingVertex))
                throw new Exception("Given vertex does not exist");
            else
                start = dictionary[startingVertex];

            Reset();
            start.Permanent = true;
            start.Distance = 0;
            current = start;

            while(remainingNonPermanentVertices)
            {
                UpdateNeighbors(current);
                current = FindSmallestVertex();
                if (current != null)
                    current.Permanent = true;
                else
                    remainingNonPermanentVertices = false;
            }
        }

        /// <summary>
        /// Resets all values of each vertex to default values
        /// </summary>
        public void Reset()
        {
            foreach(Vertex v in list)
            {
                v.Distance = int.MaxValue;
                v.NearestNeighbor = null;
                v.Permanent = false;
            }
        }

        /// <summary>
        /// Updates path of all neighbors if path is shorter
        /// </summary>
        /// <param name="current">The current vertex</param>
        public void UpdateNeighbors(Vertex current)
        {
            Vertex neighbor;
            List<Vertex> updated = new List<Vertex>();

            while((neighbor = GetAdjacentNonPermanent(current)) != null && !updated.Contains(neighbor))
            {
                if (current.Distance + adjMatrix[list.IndexOf(current), list.IndexOf(neighbor)] < neighbor.Distance)
                {
                    neighbor.Distance = current.Distance + adjMatrix[list.IndexOf(current), list.IndexOf(neighbor)];
                    neighbor.NearestNeighbor = current;
                }
                updated.Add(neighbor);
                neighbor.Permanent = true;
            }

            foreach(Vertex v in updated)
            {
                v.Permanent = false;
            }
        }

        /// <summary>
        /// Returns the vertex with the smallest distance
        /// </summary>
        public Vertex FindSmallestVertex()
        {
            Vertex smallest = null;

            foreach(Vertex v in list)
            {
                if ((smallest == null && !v.Permanent) || (!v.Permanent && v.Distance < smallest.Distance))
                    smallest = v;
            }

            return smallest;
        }

        /// <summary>
        /// Returns a non-permanent adjacent vertex to given vertex
        /// </summary>
        /// <param name="name">Vertex to check for adjacent verticies</param>
        public Vertex GetAdjacentNonPermanent(Vertex current)
        {
            int index = list.IndexOf(current);
            for (int i = 0; i < adjMatrix.GetLength(1); i++)
            {
                if (adjMatrix[index, i] > 0 && !list[i].Permanent)
                    return list[i];
            }

            return null;
        }

        /// <summary>
        /// Prints the shortest path to the given destination
        /// </summary>
        public void PrintShortestPath(string destination)
        {
            Vertex current;
            List<string> order = new List<string>();

            if (!dictionary.ContainsKey(destination))
                throw new Exception("Given vertex does not exist");
            else
                current = dictionary[destination];

            order.Add(current.Name);
            while(current != null && current.NearestNeighbor != null)
            {
                order.Add(current.NearestNeighbor.Name);
                current = current.NearestNeighbor;
            }

            for(int i = order.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(order[i]);
            }
        }
    }
}
