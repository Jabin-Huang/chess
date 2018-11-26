using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    class White : Piece
    {
        public White(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
        }
        public override PieceType GetPieceType()
        {
            return PieceType.WHITE;
        }
    }
}
