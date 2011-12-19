using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathingLibrary.Mapping.NodeMapGeneration;

namespace PathingLibrary.Mapping
{
    public class Map
    {
        private int _xNodes;
        private int _yNodes;
        private Node[,] _nodeMap;
        private INodeMapGenerator _nodeMapGenerator;

        #region contstructor
        ///<summary>Intiates the map with the default blank map</summary>
        ///<param name="xNodes">Number of nodes in the x direction of the map</param> 
        ///<param name="yNodes">Number of nodes in the y direction of the map</param>         
        public Map(int xNodes, int yNodes)
        {
            _xNodes = xNodes;
            _yNodes = yNodes;
            _nodeMapGenerator = new BlankNodeMap();
            _nodeMap = _nodeMapGenerator.GenerateNodeMap(_xNodes, _yNodes);
        }

        ///<summary>Creates a rectangular node map with all nodes vistable and movement cost of 1</summary>
        ///<param name="xNodes">Number of nodes in the x direction of the map</param> 
        ///<param name="yNodes">Number of nodes in the y direction of the map</param>  
        ///<param name="nodeMapGenerator">A custom node map generator</param>  
        public Map(int xNodes, int yNodes, INodeMapGenerator nodeMapGenerator)
        {
            _xNodes = xNodes;
            _yNodes = yNodes;
            _nodeMapGenerator = nodeMapGenerator;
            _nodeMap = _nodeMapGenerator.GenerateNodeMap(_xNodes, _yNodes);
        }
        #endregion

        #region public functions
        ///<summary>Finds all of nodes on the map up, down, left, or right of the input node</summary>
        ///<param name="node">Node to adjacent to</param>         
        ///<returns>Returns a list of adjacent nodes</returns>
        public List<Node> GetAdjacentNodes(Node node)
        {
            List<Node> adjacentNodes = new List<Node>();
            int x = node.Postition.X;
            int y = node.Postition.Y;
            if (x != 0)
            {
                adjacentNodes.Add(_nodeMap[x - 1, y]);
            }
            if (y != 0)
            {
                adjacentNodes.Add(_nodeMap[x, y - 1]);
            }
            if (x != _xNodes - 1)
            {
                adjacentNodes.Add(_nodeMap[x + 1, y]);
            }
            if (y != _yNodes - 1)
            {
                adjacentNodes.Add(_nodeMap[x, y + 1]);
            }
            return adjacentNodes;
        }

        ///<summary>Generates an ASCII map with the path designated as stars and nodes not on the path as 0's</summary>
        ///<param name="path">Path to display in stars</param>         
        ///<returns>Returns a sting containing an ASCII map with the path as stars</returns>
        public string GetASCIIMap(Path path)
        {
            string[,] ASCIIMap = new string[_xNodes,_yNodes];
            for (int i = 0; i < _xNodes; i++)
            {
                for (int j = 0; j < _xNodes; j++)
                {
                    ASCIIMap[i, j] = "0";
                }
            }
            foreach (Node node in path.GetPath())
            {
                ASCIIMap[node.Postition.X, node.Postition.Y] = "*";
            }
            string ASCIIMapString = "";
            for (int i = 0; i < _xNodes; i++)
            {
                for (int j = 0; j < _xNodes; j++)
                {
                    ASCIIMapString += ASCIIMap[i, j];
                    if (j == _yNodes - 1)
                    {
                        ASCIIMapString += "\n";
                    }
                }
            }

            return ASCIIMapString;
        }

        ///<summary>Tests to see if the input node is on the map</summary>
        ///<param name="node">Node to check if it is on the map</param>
        ///<returns>Returns true if the node is on the map. Returns false if it is not on the map</returns>
        public bool Contains(Node node)
        {
            if (node.Postition.X >= _xNodes || node.Postition.Y >= _yNodes ||
                node.Postition.X < 0 || node.Postition.Y < 0)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region properties
        public Node[,] NodeMap
        {
            get { return _nodeMap; }
            set { _nodeMap = value; }
        }
        #endregion
    }
}
