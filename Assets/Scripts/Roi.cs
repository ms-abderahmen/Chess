using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roi : Piece
{
    Material[] mat = new Material[2];
    Pair checkPos = new Pair();
    public override void calcuateRange(Piece[,] board)
    {
        type = "roi";
        range.Clear();
        Pair p;
        if ((posZ + 1 < 8) && (board[posZ + 1, posX] == null))
        {   //gameScript.setSelected(posX, posZ + 1);
            p = new Pair();
            p.x = posX;
            p.z = posZ + 1;
            range.Add(p);
        }
        if ((posZ + 1 < 8) && ((board[posZ + 1, posX] != null) && (board[posZ + 1, posX].getColor() != getColor())))
        {   //gameScript.setSelected(posX, posZ + 1);
            p = new Pair();
            p.x = posX;
            p.z = posZ + 1;
            range.Add(p);
        }
        //
        if ((posX + 1 < 8) && (board[posZ, posX + 1] == null))
        {   //gameScript.setSelected(posX + 1, posZ);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ;
            range.Add(p);
        }
        if ((posX + 1 < 8) && ((board[posZ, posX + 1] != null) && (board[posZ, posX + 1].getColor() != getColor())))
        {   //gameScript.setSelected(posX + 1, posZ);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ;
            range.Add(p);
        }
        //
        if ((posZ - 1 >= 0) && (board[posZ - 1, posX] == null))
        {   //gameScript.setSelected(posX, posZ - 1);
            p = new Pair();
            p.x = posX;
            p.z = posZ - 1;
            range.Add(p);
        }
        if ((posZ - 1 >= 0) && ((board[posZ - 1, posX] != null) && (board[posZ - 1, posX].getColor() != getColor())))
        {   //gameScript.setSelected(posX, posZ - 1);
            p = new Pair();
            p.x = posX;
            p.z = posZ - 1;
            range.Add(p);
        }
        //
        if ((posX - 1 >= 0) && (board[posZ, posX - 1] == null))
        {   //gameScript.setSelected(posX - 1, posZ);
            p = new Pair();
            p.x = posX - 1;
            p.z = posZ;
            range.Add(p);
        }
        if ((posX - 1 >= 0) && ((board[posZ, posX - 1] != null) && (board[posZ, posX - 1].getColor() != getColor())))
        {   //gameScript.setSelected(posX - 1, posZ);
            p = new Pair();
            p.x = posX - 1;
            p.z = posZ;
            range.Add(p);
        }
        //
        //
        if ((posZ + 1 < 8) && (posX + 1 < 8) && (board[posZ + 1, posX + 1] == null))
        {   //gameScript.setSelected(posX + 1, posZ + 1);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ + 1;
            range.Add(p);
        }
        if ((posZ + 1 < 8) && (posX + 1 < 8) && ((board[posZ + 1, posX + 1] != null) && (board[posZ + 1, posX + 1].getColor() != getColor())))
        {   //gameScript.setSelected(posX + 1, posZ + 1);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ + 1;
            range.Add(p);
        }
        //
        if ((posX + 1 < 8) && (posZ - 1 >= 0) && (board[posZ - 1, posX + 1] == null))
        {   //gameScript.setSelected(posX + 1, posZ - 1);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ - 1;
            range.Add(p);
        }
        if ((posX + 1 < 8) && (posZ - 1 >= 0) && ((board[posZ - 1, posX + 1] != null) && (board[posZ - 1, posX + 1].getColor() != getColor())))
        {   //gameScript.setSelected(posX + 1, posZ - 1);
            p = new Pair();
            p.x = posX + 1;
            p.z = posZ - 1;
            range.Add(p);
        }
        //
        if ((posZ - 1 >= 0) && (posX - 1 >= 0) && (board[posZ - 1, posX - 1] == null))
        {   //gameScript.setSelected(posX - 1, posZ - 1);
            p = new Pair();
            p.x = posX - 1;
            p.z = posZ - 1;
            range.Add(p);
        }
        if ((posZ - 1 >= 0) && (posX - 1 >= 0) && ((board[posZ - 1, posX - 1] != null) && (board[posZ - 1, posX - 1].getColor() != getColor())))
        {   //gameScript.setSelected(posX - 1, posZ - 1);
            p = new Pair();
            p.x = posX - 1;
            p.z = posZ - 1;
            range.Add(p);
        }
        //
        if ((posX - 1 >= 0) && (posZ + 1 < 8) && (board[posZ + 1, posX - 1] == null))
        {   //gameScript.setSelected(posX - 1, posZ + 1);
            p = new Pair();
            p.x = posX - 1;
            p.z = posZ + 1;
            range.Add(p);
        }
        if ((posX - 1 >= 0) && (posZ + 1 < 8) && ((board[posZ + 1, posX - 1] != null) && (board[posZ + 1, posX - 1].getColor() != getColor())))
        {   //gameScript.setSelected(posX - 1, posZ + 1);
            p = new Pair();
            p.x = posX - 1;
            p.z = posZ + 1;
            range.Add(p);
        }
    }

    public override bool Check(Piece[,] GameBoard)
    {
        Pair p = new Pair();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if((GameBoard[i, j] != null) && (GameBoard[i, j].getColor() == getColor()) && (GameBoard[i, j].type == "roi"))
                {
                    p.x = j;
                    p.z = i;
                    break;
                }
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((GameBoard[i, j] != null) && (GameBoard[i, j].getColor() != getColor()) && (GameBoard[i, j].range.Contains(p)))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
