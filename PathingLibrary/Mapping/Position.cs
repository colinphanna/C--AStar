using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathingLibrary.Mapping
{
    public class Position
    {
        private int _x;
        private int _y;

        #region constructors
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }
        #endregion

        #region properites
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        #endregion

        #region equality functions
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Position otherPosition = obj as Position;
            if ((System.Object)otherPosition == null)
            {
                return false;
            }

            return this == otherPosition;
        }

        public bool Equals(Position position)
        {
            if ((object)position == null)
            {
                return false;
            }

            return this == position;
        }

        public override int GetHashCode()
        {
            return _x ^ _y;
        }

        public static bool operator ==(Position positionA, Position positionB)
        {
            if (System.Object.ReferenceEquals(positionA, positionB))
            {
                return true;
            }

            if (((object)positionA == null) || ((object)positionB == null))
            {
                return false;
            }

            return (positionA.X == positionB.X && positionA.Y == positionB.Y);
        }

        public static bool operator !=(Position positionA, Position positionB)
        {
            return !(positionA == positionB);
        }
        #endregion

        #region public functions
        public override string ToString()
        {
            return "(" + _x + "," + _y + ")";
        }
        #endregion
    }
}
