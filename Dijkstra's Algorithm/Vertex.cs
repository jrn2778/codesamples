using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE19_DijkstrasAlgorithm
{
    class Vertex
    {
        private string name;
        private int distance;
        private Vertex nearestNeighbor;
        private bool permanent;

        public string Name { get { return name; } }
        public int Distance { get { return distance; } set { distance = value; } }
        public Vertex NearestNeighbor { get { return nearestNeighbor; } set { nearestNeighbor = value; } }
        public bool Permanent { get { return permanent; } set { permanent = value; } }

        public Vertex(string name)
        {
            this.name = name;
            distance = int.MaxValue;
            nearestNeighbor = null;
            permanent = false;
        }
    }
}
