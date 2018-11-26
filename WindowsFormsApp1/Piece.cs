using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
   abstract class Piece:PictureBox
   {
        public Piece(int x,int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x-25, y-25);
            this.Size = new Size(50, 50);
        }
        public abstract PieceType GetPieceType();
        

        
    }
}
