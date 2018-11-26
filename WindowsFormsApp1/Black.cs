using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    class Black:Piece
    {
        public Black(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.black;
        }
        public override PieceType GetPieceType()
        {
            return PieceType.BLACK;
        }
    }
}
