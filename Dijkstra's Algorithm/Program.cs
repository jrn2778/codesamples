using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE19_DijkstrasAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            Console.WriteLine("Starting Location: Bedroom");
            graph.ShortestPath("Bedroom");
            Console.WriteLine("(Shortest path algorithm has finished)\n");
            Console.Write("Which room are you trying to get to?\n  > ");
            string room = Console.ReadLine();
            Console.WriteLine("\nShortest Path:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            graph.PrintShortestPath(room);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
