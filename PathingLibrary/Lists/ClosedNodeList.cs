using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathingLibrary.Mapping;

namespace PathingLibrary.Lists
{
    public class ClosedNodeList
    {
        private List<Node> _closedNodeList;

        #region Constructors
        public ClosedNodeList()
        {
            _closedNodeList = new List<Node>();
        }
        #endregion

        #region public functions
        ///<summary>Adds the input node into the closed list</summary>
        ///<param name="node">Node to add to the closed list</param>
        public void Add(Node node)
        {
            _closedNodeList.Add(node);
            #if Debug
                Console.WriteLine("Added node at " + node.Postition.ToString() + " to closed list");
            #endif
        }

        ///<summary>Tests to see if the input node is in the closed list</summary>
        ///<param name="node">Node to test if the node exists in the closed list</param> 
        ///<returns>Returns true if the node is in the closed list.  Returns false if the node is not in the closed list.</returns>
        public bool Contains(Node node)
        {
            for (int i = 0; i < _closedNodeList.Count; i++)
            {
                if (node == _closedNodeList[i])
                {
                    return true;
                }
            }

            return false;
        }

        ///<summary>Creates a string with all of the positions of the nodes in the closed list seperated by a return</summary>
        ///<returns>Returns an unordered listing of all the positions of the nodes in the closed list</returns>
        public override string ToString()
        {
            string nodes = "Closed Node List\n";
            for (int i = 0; i < _closedNodeList.Count; i++)
            {
                nodes += _closedNodeList[i].Postition.ToString() + "\n";
            }
            return nodes;
        }
        #endregion
    }
}
