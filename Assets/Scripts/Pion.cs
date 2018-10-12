using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pion : Piece
{
    
    public override void calcuateRange(Piece[,] board)
    {
        range.Clear();
        Pair p;
        if ((board[posZ + direction, posX] == null) && (posZ + direction>=0) && (posZ + direction <8))
        {//gameScript.setSelected(posX, posZ + direction);
            p = new Pair();
            p.x = posX;
            p.z = posZ + direction;
            range.Add(p);
        }
        if ((moved == false) && (board[posZ + (2 * direction), posX] == null))
        {//gameScript.setSelected(posX, posZ + (2 * direction));
            p = new Pair();
            p.x = posX;
            p.z = posZ + (2 * direction);
            range.Add(p);

        }
        if ((posX+1<8) && (posZ + direction>=0) && (posZ + direction <8) && (board[posZ + direction, posX + 1] != null) && (board[posZ + direction, posX + 1].getColor() != getColor()))
        { //gameScript.setSelected(posX + 1, posZ + direction);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ + direction;
            range.Add(p);

        }
        if ((posX-1>=0) && (posZ + direction>=0) && (posZ + direction <8) && (board[posZ + direction, posX - 1] != null) && (board[posZ + direction, posX - 1].getColor() != getColor()))
        {//gameScript.setSelected(posX - 1, posZ + direction);
            p = new Pair();
            p.x = posX - 1;
            p.z = posZ + direction;
            range.Add(p);

        }
    }

}
