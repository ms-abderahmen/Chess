using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheval : Piece
{

    public override void calcuateRange(Piece[,] board)
    {
        range.Clear();
        Pair p;
        if ((posZ + 2 < 8) && (posX + 1 < 8) && ((board[posZ + 2, posX + 1] == null) || ((board[posZ + 2, posX + 1] != null) && (board[posZ + 2, posX + 1].getColor() != getColor()))))
        {//gameScript.setSelected(posX+1,posZ+2);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ + 2;
            range.Add(p);
        }

        if ((posZ + 2 < 8) && (posX - 1 >= 0) && ((board[posZ + 2, posX - 1] == null) || ((board[posZ + 2, posX - 1] != null) && (board[posZ + 2, posX - 1].getColor() != getColor()))))
        {//gameScript.setSelected(posX-1,posZ+2);
            p = new Pair();
            p.x = posX - 1;
            p.z = posZ + 2;
            range.Add(p);
        }

        if ((posZ - 2 >= 0) && (posX + 1 < 8) && ((board[posZ - 2, posX + 1] == null) || ((board[posZ - 2, posX + 1] != null) && (board[posZ - 2, posX + 1].getColor() != getColor()))))
        {//gameScript.setSelected(posX+1,posZ-2);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ - 2;
            range.Add(p);
        }

        if ((posZ - 2 >= 0) && (posX - 1 >= 0) && ((board[posZ - 2, posX - 1] == null) || ((board[posZ - 2, posX - 1] != null) && (board[posZ - 2, posX - 1].getColor() != getColor()))))
        {//gameScript.setSelected(posX-1,posZ-2);
            p = new Pair();
            p.x = posX - 1;
            p.z = posZ - 2;
            range.Add(p);
        }

        if ((posZ + 1 < 8) && (posX + 2 < 8) && ((board[posZ + 1, posX + 2] == null) || ((board[posZ + 1, posX + 2] != null) && (board[posZ + 1, posX + 2].getColor() != getColor()))))
        {//gameScript.setSelected(posX+1,posZ+2);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ + 2;
            range.Add(p);
        }

        if ((posZ + 1 < 8) && (posX - 2 >= 0) && ((board[posZ + 1, posX - 2] == null) || ((board[posZ + 1, posX - 2] != null) && (board[posZ + 1, posX - 2].getColor() != getColor()))))
        {//gameScript.setSelected(posX-2,posZ+1);
            p = new Pair();
            p.x = posX - 2;
            p.z = posZ + 1;
            range.Add(p);
        }

        if ((posZ - 1 >= 0) && (posX + 2 < 8) && ((board[posZ - 1, posX + 2] == null) || ((board[posZ - 1, posX + 2] != null) && (board[posZ - 1, posX + 2].getColor() != getColor()))))
        {//gameScript.setSelected(posX+1,posZ-2);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ - 2;
            range.Add(p);
        }

        if ((posZ - 1 >= 0) && (posX - 2 >= 0) && ((board[posZ - 1, posX - 2] == null) || ((board[posZ - 1, posX - 2] != null) && (board[posZ - 1, posX - 2].getColor() != getColor()))))
        {//gameScript.setSelected(posX-2,posZ-1);
            p = new Pair();
            p.x = posX - 2;
            p.z = posZ - 1;
            range.Add(p);
        }
    }
    
}
