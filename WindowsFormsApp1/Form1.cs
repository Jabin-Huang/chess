using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Game game = new Game(); 

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;

            }
            else this.Cursor = Cursors.Default;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            if (piece != null)
                this.Controls.Add(piece);

            if (game.Winner == PieceType.BLACK)
                MessageBox.Show("黑色获胜！");
            else if (game.Winner == PieceType.WHITE)
                MessageBox.Show("白色获胜！");   
           
        }
    }
}
