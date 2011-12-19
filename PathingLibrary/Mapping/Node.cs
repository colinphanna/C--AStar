using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathingLibrary.Mapping
{
    public class Node : IComparable
    {
        private double _movementCost;
        private bool _vistable;
        private Position _postition;
        private Node _parent;
        private double _fCost;
        private double _gCost;
        private double _hCost;

        #region constructors
        ///<summary>Creates a node at the input position and movement cost of 1</summary>
        public Node(Position position)
        {
            _postition = position;
            _parent = null;
            _movementCost = 1;
            _vistable = true;
        }

        ///<summary>Creates a node at the input position and the inputed movement cost</summary>
        public Node(Position position, double movementCost)
        {
            _postition = position;
            _parent = null;
            _movementCost = movementCost;
            _vistable = true;
        }
        #endregion

        #region properties
        public double MovementCost
        {
            get { return _movementCost; }
            set { _movementCost = value; }
        }

        public bool Vistable
        {
            get { return _vistable; }
            set { _vistable = value; }
        }

        public Position Postition
        {
            get { return _postition; }
            set { _postition = value; }
        }

        public Node Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public double FCost
        {
            get { return _fCost; }
            set { _fCost = value; }
        }

        public double GCost
        {
            get { return _gCost; }
            set { _gCost = value; }
        }

        public double HCost
        {
            get { return _hCost; }
            set { _hCost = value; }
        }
        #endregion

        #region equality functions
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Node otherNode = obj as Node;
            if ((System.Object)otherNode == null)
            {
                return false;
            }
            
            return this.Postition == otherNode.Postition;
        }

        public override int GetHashCode()
        {
            return _postition.GetHashCode();
        }

        public static bool operator ==(Node nodeA, Node nodeB)
        {
            if (System.Object.ReferenceEquals(nodeA, nodeB))
            {
                return true;
            }

            if (((object)nodeA == null) || ((object)nodeB == null))
            {
                return false;
            }

            return nodeA.Postition == nodeB.Postition;
        }

        public static bool operator !=(Node nodeA, Node nodeB)
        {
            return !(nodeA == nodeB);
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            };

            Node otherNode = obj as Node;
            if (otherNode != null)
            {
                return this._fCost.CompareTo(otherNode._fCost);
            }
            else
            {
                throw new ArgumentException("Object is not a Node");
            }
        }
        #endregion
    }
}
