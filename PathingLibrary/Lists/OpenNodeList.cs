using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathingLibrary.Mapping;
using Wintellect.PowerCollections;

namespace PathingLibrary.Lists
{
    public class OpenNodeList
    {
        OrderedBag<Node> _openNodes;

        #region constructors
        public OpenNodeList()
        {
            _openNodes = new OrderedBag<Node>();
        }
        #endregion

        #region public functions
        ///<summary>Adds the input node to the heap</summary>
        ///<param name="node">Node to add to the open list</param> 
        public void Add(Node node)
        {
            _openNodes.Add(node);
            #if Debug
                Console.WriteLine("Added node at " + node.Postition.ToString() + " to open list");
            #endif
        }

        ///<summary>Removes the input node from the open list if it exists</summary>
        ///<param name="node">Node to remove from the open list</param>         
        public void Remove(Node node)
        {
            for (int i = 0; i < _openNodes.Count; i++)
            {
                if (node == _openNodes[i])
                {
                    _openNodes.RemoveAllCopies(_openNodes[i]);
                }
            }
            #if Debug
                Console.WriteLine("Removed node at " + node.Postition.ToString() + " from the open list");
            #endif
        }

        ///<summary>Tests to see if the input node is in the open list</summary>
        ///<param name="node">Node to test if the node exists in the open list</param> 
        ///<returns>Returns true if the node is in the open list.  Returns false if the node is not in the open list.</returns>
        public bool Contains(Node node)
        {
            for (int i = 0; i < _openNodes.Count; i++)
            {
                if (node == _openNodes[i])
                {
                    return true;
                }
            }

            return false;
        }

        ///<summary>Returns the node at the top of the heap</summary>         
        ///<returns>Returns the node with the best f score</returns>
        public Node GetBestFScore()
        {
            return _openNodes.GetFirst();
        }

        ///<summary>Clears the open node list</summary>                 
        public void ClearAll()
        {
            _openNodes.Clear();
        }

        ///<summary>Creates a string with all of the positions of the nodes in the open list seperated by a return</summary>
        ///<returns>Returns an f score sorted listing of all the positions of the nodes in the open list</returns>
        public override string ToString()
        {
            string nodes = "Open Node List\n";
            for (int i = 0; i < _openNodes.Count; i++)
            {
                nodes += _openNodes[i].Postition.ToString() + "\n";
            }
            return nodes;
        }
        #endregion

        #region properties
        public int Count
        {
            get { return _openNodes.Count; }
        }
        #endregion
    }
}
