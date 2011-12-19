using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathingLibrary.Mapping
{
    public class Path
    {
        private List<Node> _path;

        #region constructors
        public Path()
        {
            _path = new List<Node>();
        }
        #endregion

        #region public functions
        ///<summary>Adds the input node to the end of the path</summary>
        ///<param name="node">Number of nodes in the x direction of the map</param> 
        public void AppendNode(Node node)
        {
            _path.Add(node);
        }

        ///<summary>Verbose get from the private list of nodes</summary>
        ///<returns>Returns a list of nodes with node 0 as the starting node and the last node as the ending node</returns>
        public List<Node> GetPath()
        {
            return _path;
        }

        ///<summary>Reverses the path</summary>
        public void ReversePath()
        {
            _path.Reverse();
        }

        ///<summary>Clears the path</summary>
        public void ClearPath()
        {
            _path.Clear();
        }

        ///<summary>Gets the path in string form starting at node 0 ending at the last node</summary>
        ///<returns>Returns postions on the path with a return seperating them or 'Blank Path' if the path is empty</returns>
        public override string ToString()
        {
            if (_path.Count == 0)
            {
                return "Blank Path";
            }
            else
            {
                string path = "Path:\n";
                for (int i = 0; i < _path.Count; i++)
                {
                    path += _path[i].Postition.ToString() + "\n";
                }
                return path;
            }
        }
        #endregion
    }
}
