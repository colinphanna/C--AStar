using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathingLibrary.Mapping.NodeMapGeneration
{
    public class BlankNodeMap : INodeMapGenerator
    {
        ///<summary>Creates a rectangular node map with all nodes vistable and movement cost of 1</summary>
        ///<param name="xNodes">Number of nodes in the x direction of the map</param> 
        ///<param name="yNodes">Number of nodes in the y direction of the map</param> 
        ///<returns>Returns a 2D array of nodes that are visitable with a movement cost of 1</returns>
        public Node[,] GenerateNodeMap(int xNodes, int yNodes)
        {
            if (xNodes < 2 || yNodes < 2)
            {
                throw new Exception("Node map must be at least 2x2");
            }
            Node[,] nodeMap = new Node[xNodes, yNodes];
            for (int x = 0; x < xNodes; x++)
            {
                for (int y = 0; y < yNodes; y++)
                {
                    nodeMap[x, y] = new Node(new Position(x, y), 1);
                }
            }
            return nodeMap;
        }
    }
}
