using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathingLibrary.Algorithms;
using PathingLibrary.Mapping;

namespace Main
{
    /// <summary>Example of pathfinding for a 25 by 25 node map. Starts at 0,0 looking for a path to 17,19.  Displays a list of visted nodes and an ascii map with path.</summary>
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(25, 25);
            AStar aStar = new AStar(new Node(new Position(0, 0)), new Node(new Position(17, 19)), map);
            Path path = aStar.GetPath();
            Console.Write(path.ToString());
            Console.Write(map.GetASCIIMap(path));
            Console.ReadLine();
        }
    }
}
