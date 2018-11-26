using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Board
    {   //OFFSET：最外网格线与窗体边框的距离
        //NODE_DISTANCE:网格线间的距离
        //NODE_RADIUS:以交叉点为中心，该半径内可以下子（鼠标由箭头变成手）
        //NO_MATCH_NODE（-1，-1）：假设的不存在的节点，不能放棋时返回的坐标
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;

        private Piece[,] pieces = new Piece[9, 9];

        private Point lastplacedNode = NO_MATCH_NODE;
        //使最后下子的位置能被外部调用查看，但不能修改
        public Point LastPlacedNode { get { return lastplacedNode; } }

        public PieceType GetPieceType(int nodeX,int nodeY)
        {
            if (pieces[nodeX, nodeY] == null)
                return PieceType.NULL;
            return pieces[nodeX, nodeY].GetPieceType();
        }

        //鼠标移动到节点附近，鼠标由箭头变成手
        public bool CanBePlaced(int x,int y)
        {//1.找最近能放的节点,如果没有，return false；
            Point node = FindTheClosetNode(x, y);
            if (node == NO_MATCH_NODE) return false;
            //2.检查是否已经有棋子存在,如有则return false；
            if (pieces[node.X, node.Y] != null)
                return false;
            return true;
        }

        //鼠标在可放棋的节点附近点击时，在节点精准生成相应棋子
        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            //1.找最近能放的节点,如果没有，return null；
            Point node = FindTheClosetNode(x, y);
            if (node == NO_MATCH_NODE) return null;
            //2.检查是否已经有棋子存在
            if (pieces[node.X, node.Y] != null)
                return null;
            //3.根据type产生对应棋子
            Point FormPos = convertToFormPosition(node);
            if (type == PieceType.BLACK)
                pieces[node.X, node.Y] = new Black(FormPos.X,FormPos.Y);
            else if (type == PieceType.WHITE)
                pieces[node.X, node.Y] = new White(FormPos.X,FormPos.Y);
            //记录最后下子的位置
            lastplacedNode = node;

            return pieces[node.X, node.Y];
        }

        //找最近能放的节点，没有则返回NO_MATCH_NODE
        private Point FindTheClosetNode(int x,int y)
        {
            int NODE_X = FindTheClosetNode(x);
            int NODE_Y = FindTheClosetNode(y);
            if (NODE_X==-1||NODE_X>8) return NO_MATCH_NODE;
            if (NODE_Y==-1||NODE_Y>8) return NO_MATCH_NODE;

            return new Point(NODE_X, NODE_Y);
        }

        //网格交叉点坐标和像素点坐标的转换
        private Point convertToFormPosition(Point node)
        {
            Point FormPosition = new Point();
            FormPosition.X = node.X * NODE_DISTANCE + OFFSET;
            FormPosition.Y = node.Y * NODE_DISTANCE + OFFSET;
            return FormPosition;
        }

        private int FindTheClosetNode(int l)
        {
            if (l < OFFSET - NODE_RADIUS) return -1;
            l -= OFFSET;
            int quotient = l / NODE_DISTANCE;
            int remainder = l % NODE_DISTANCE;
            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;
        }
    }
}
