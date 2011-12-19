using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathingLibrary.Mapping;
using PathingLibrary.Lists;

namespace PathingLibrary.Algorithms
{
    public class AStar
    {
        private Node _startingNode;
        private Node _endingNode;
        private Map _map;

        #region constructors
        ///<summary>Instantiates the AStar class with a starting node, ending node, and a map.  Ensures the starting and ending nodes are on the map and visitable</summary>
        ///<param name="startingNode">Beginning of the path</param>
        ///<param name="next">Node to find a path to from the starting node</param>         
        public AStar(Node startingNode, Node endingNode, Map map)
        {
            if (!startingNode.Vistable)
            {
                throw new Exception("Can't start on an unvistable node");
            }
            if (!endingNode.Vistable)
            {
                throw new Exception("Can't end on an unvistable node");
            }
            if (!map.Contains(startingNode))
            {
                throw new Exception("Starting node not on the map");
            }
            if (!map.Contains(endingNode))
            {
                throw new Exception("Ending node not on the map");
            }
            _startingNode = startingNode;
            _endingNode = endingNode;
            _map = map;
        }
        #endregion

        #region private functions
        ///<summary>Calculates the movement cost from input node and all of its parents</summary>
        ///<param name="node">Node used to backtrack from to find the known movement cost</param>        
        ///<returns>Returns the movement cost as a double of the input node and all its parents</returns>
        private double g(Node node)
        {
            double cost = node.MovementCost;
            while (node.Parent != null)
            {
                node = node.Parent;
                cost += node.MovementCost;
            }
            return cost;
        }

        ///<summary>Appends the next node to the end of the current node's parent list and calculates the movement cost from the next node and all of its parents</summary>
        ///<param name="current">Node used to backtrack from to find the known movement cost</param>
        ///<param name="next">Node to append to the end of the current node's parent list</param>    
        ///<returns>Returns the movement cost as a double of next node appended to current and all current's parents</returns>
        private double g(Node current, Node next)
        {
            next.Parent = current;
            return g(current);
        }

        ///<summary>Estimates the movement cost from input node to the ending node.  Uses the Manhatten method and a cross product tie breaker to estimate movement cost.</summary>
        ///<param name="node">Node used to estimate the cost from the node to the ending position</param>        
        ///<returns>Returns the estimated movement cost from the input node to the endingnode as a double</returns>
        private double h(Node node)
        {
            double dx1 = node.Postition.X - _endingNode.Postition.X;
            double dy1 = node.Postition.Y - _endingNode.Postition.Y;
            double dx2 = _startingNode.Postition.X - _endingNode.Postition.X;
            double dy2 = _startingNode.Postition.Y - _endingNode.Postition.Y;
            double h = node.MovementCost * (Math.Abs(dx1) + Math.Abs(dy1));
            //Crossproduct tiebreak for path smoothness
            double cross = Math.Abs(dx1 * dy2 - dx2 * dy1);
            return h + cross * 0.01;
        }

        ///<summary>Approximates the movement cost from the starting to ending node passing through the input node</summary>
        /// <param name="node">Node used to estimate the cost from the starting position to the ending position passing through the node</param>        
        /// <returns>Returns the estimated movement cost from the starting node to the ending node as a double</returns>
        private double f(Node node)
        {
            return g(node) + h(node);
        }
        #endregion

        #region public functions
        ///<summary>Find a path from the starting node to the ending node or a blank path if no path exists</summary>                
        /// <returns>Returns a path from the starting node to the ending node or a blank path if no path exists</returns>
        public Path GetPath()
        {
            OpenNodeList openNodes = new OpenNodeList();
            ClosedNodeList closedNodes = new ClosedNodeList();
            _startingNode.FCost = f(_startingNode);
            openNodes.Add(_startingNode);

            while (openNodes.Count != 0)
            {
                Node current = openNodes.GetBestFScore();

                #if Debug
                    Console.WriteLine("Node at " + current.Postition.ToString() + " is the current node.");
                    Console.WriteLine(openNodes.ToString());
                    Console.WriteLine(closedNodes.ToString());
                #endif

                closedNodes.Add(current);
                openNodes.Remove(current);

                if (current == _endingNode)
                {
                    openNodes.ClearAll();
                    return retracePath(current);
                }

                foreach (Node neighbor in _map.GetAdjacentNodes(current))
                {
                    bool nodeInClosed = closedNodes.Contains(neighbor);
                    if (!neighbor.Vistable || nodeInClosed)
                    {
                        #if Debug
                            Console.WriteLine("Node at " + neighbor.Postition.ToString() + " is closed or unvistable");
                        #endif

                        continue;
                    }

                    bool nodeInOpen = openNodes.Contains(neighbor);

                    if (!nodeInOpen)
                    {
                        neighbor.Parent = current;
                        neighbor.FCost = f(neighbor);
                        neighbor.GCost = g(neighbor);
                        neighbor.HCost = h(neighbor);
                        openNodes.Add(neighbor);

                        #if Debug
                            Console.WriteLine("Added node at " + neighbor.Postition.ToString() + " to the path after " + current.Postition.ToString());
                        #endif
                    }
                    else if (nodeInOpen && neighbor.GCost > g(current, neighbor))
                    {
                        openNodes.Remove(neighbor);
                        neighbor.Parent = current;
                        neighbor.FCost = f(neighbor);
                        neighbor.GCost = g(neighbor);
                        neighbor.HCost = h(neighbor);
                        openNodes.Add(neighbor);

                        #if Debug
                            Console.WriteLine("Changed node at " + neighbor.Postition.ToString() + " parent to be " + current.Postition.ToString());
                        #endif
                    }
                }
            }

            #if Debug
                Console.WriteLine(openNodes.ToString());
                Console.WriteLine(closedNodes.ToString());
            #endif
            return new Path();
        }

        ///<summary>Creates a path from the ending node to its first parent</summary>
        /// <param name="endingNode">Ending node to trace a path using its parents</param>
        ///<returns>Returns a path from the starting node to the ending node</returns>
        private Path retracePath(Node endingNode)
        {
            Path path = new Path();
            path.AppendNode(endingNode);
            while (endingNode.Parent != null)
            {
                endingNode = endingNode.Parent;
                path.AppendNode(endingNode);
            }
            path.ReversePath();
            return path;
        }
        #endregion

        #region properties
        public Node StartingNode
        {
            get { return _startingNode; }
            set { _startingNode = value; }
        }

        public Node EndingNode
        {
            get { return _endingNode; }
            set { _endingNode = value; }
        }
        #endregion

    }
}
