using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    class Game
    {
        private Board board = new Board();

        private PieceType currentPlayer = PieceType.BLACK;

        private PieceType winner = PieceType.NULL;
        public PieceType Winner { get { return winner; } }

        //检查能否放置，被form调用
        public bool CanBePlaced(int x,int y)
        {
            return board.CanBePlaced(x, y);
        }

        //正确放置棋子，被form调用
        public Piece PlaceAPiece(int x,int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                CheckWinner();
               
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                    currentPlayer = PieceType.BLACK;
                return piece;
            }
            return null;
        }

        //检查胜负
        private void CheckWinner()
        {
            int centerX = board.LastPlacedNode.X;
            int centerY = board.LastPlacedNode.Y;

            for (int x = 0; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int count1 = 1;
                    int count2 = 1;
                    while (count1 + count2-1 <5 )
                    {
                        int targetX1 = centerX + count1 * x;
                        int targetY1 = centerY + count1 * y;

                        if (targetX1 < 0 || targetX1 > 8 ||
                            targetY1 < 0 || targetY1 > 8 ||
                            board.GetPieceType(targetX1, targetY1) != currentPlayer)
                            break;
                        count1++;
                    }
                    while (count1 + count2-1 < 5)
                    {
                        int targetX2 = centerX - count2 * x;
                        int targetY2 = centerY - count2 * y;

                        if (targetX2 < 0 || targetX2 > 8 ||
                            targetY2 < 0 || targetY2 > 8 ||
                            board.GetPieceType(targetX2, targetY2) != currentPlayer)
                            break;
                        count2++;
                    }
                    if (count1+count2-1 == 5)
                        winner = currentPlayer;
                }
            }
        }
    }
}
