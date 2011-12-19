using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathingLibrary.Mapping.NodeMapGeneration
{
    public interface INodeMapGenerator
    {
        ///<summary>Interface to create a rectangular node map</summary> 
        ///<param name="xNodes">Number of nodes in the x direction of the map</param> 
        ///<param name="yNodes">Number of nodes in the y direction of the map</param> 
        Node[,] GenerateNodeMap(int xNodes,int yNodes);
    }
}
