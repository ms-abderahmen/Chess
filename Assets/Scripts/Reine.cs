using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reine : Piece
{

    public override void calcuateRange(Piece[,] board)
    {
        range.Clear();
        Pair p;
        for (int x = posX + 1; x < 8; x++)
        {
            if (board[posZ, x] == null)
            {//gameScript.setSelected(x, posZ);
                p = new Pair();
                p.x = x;
                p.z = posZ;
                range.Add(p);
            }
            else
            {
                if (board[posZ, x].getColor() != getColor())
                {//gameScript.setSelected(x, posZ);
                    p = new Pair();
                    p.x = x;
                    p.z = posZ;
                    range.Add(p);
                }
                break;
            }
        }
        for (int x = posX - 1; x >= 0; x--)
        {
            if (board[posZ, x] == null)
            {//gameScript.setSelected(x, posZ);
                p = new Pair();
                p.x = x;
                p.z = posZ;
                range.Add(p);
            }
            else
            {
                if (board[posZ, x].getColor() != getColor())
                {//gameScript.setSelected(x, posZ);
                    p = new Pair();
                    p.x = x;
                    p.z = posZ;
                    range.Add(p);
                }
                break;
            }
        }
        for (int z = posZ + 1; z < 8; z++)
        {
            if (board[z, posX] == null)
            {//gameScript.setSelected(posX, z);
                p = new Pair();
                p.x = posX;
                p.z = z;
                range.Add(p);
            }
            else
            {
                if (board[z, posX].getColor() != getColor())
                {//gameScript.setSelected(posX, z);
                    p = new Pair();
                    p.x = posX;
                    p.z = z;
                    range.Add(p);
                }
                break;
            }
        }
        for (int z = posZ - 1; z >= 0; z--)
        {
            if (board[z, posX] == null)
            {//gameScript.setSelected(posX, z);
                p = new Pair();
                p.x = posX;
                p.z = z;
                range.Add(p);
            }
            else
            {
                if (board[z, posX].getColor() != getColor())
                {//gameScript.setSelected(posX, z);
                    p = new Pair();
                    p.x = posX;
                    p.z = z;
                    range.Add(p);
                }
                break;
            }
        }
        //#########################################################################
        //-------------------------------------------------------------------------
        for (int x = 1; (posX + x < 8) && (posZ + x < 8); x++)
        {
            if (board[posZ + x, posX + x] == null)
            {//gameScript.setSelected(posX + x, posZ + x);
                p = new Pair();
                p.x = posX + x;
                p.z = posZ + x;
                range.Add(p);
            }
            else
            {
                if (board[posZ + x, posX + x].getColor() != getColor())
                {//gameScript.setSelected(posX + x, posZ + x);
                    p = new Pair();
                    p.x = posX + x;
                    p.z = posZ + x;
                    range.Add(p);
                }
                break;
            }
        }
        for (int x = -1; (posX + x >= 0) && (posZ + x >= 0); x--)
        {
            if (board[posZ + x, posX + x] == null)
            {//gameScript.setSelected(posX + x, posZ + x);
                p = new Pair();
                p.x = posX + x;
                p.z = posZ + x;
                range.Add(p);
            }
            else
            {
                if (board[posZ + x, posX + x].getColor() != getColor())
                {//gameScript.setSelected(posX + x, posZ + x);
                    p = new Pair();
                    p.x = posX + x;
                    p.z = posZ + x;
                    range.Add(p);
                }
                break;
            }
        }
        for (int x = 1; (posX - x >= 0) && (posZ + x < 8); x++)
        {
            if (board[posZ + x, posX - x] == null)
            {//gameScript.setSelected(posX - x, posZ + x);
                p = new Pair();
                p.x = posX - x;
                p.z = posZ + x;
                range.Add(p);
            }
            else
            {
                if (board[posZ + x, posX - x].getColor() != getColor())
                {//gameScript.setSelected(posX - x, posZ + x);
                    p = new Pair();
                    p.x = posX - x;
                    p.z = posZ + x;
                    range.Add(p);
                }
                break;
            }
        }
        for (int x = -1; (posX - x < 8) && (posZ + x >= 0); x--)
        {
            if (board[posZ + x, posX - x] == null)
            {//gameScript.setSelected(posX - x, posZ + x);
                p = new Pair();
                p.x = posX - x;
                p.z = posZ + x;
                range.Add(p);
            }
            else
            {
                if (board[posZ + x, posX - x].getColor() != getColor())
                {//gameScript.setSelected(posX - x, posZ + x);
                    p = new Pair();
                    p.x = posX - x;
                    p.z = posZ + x;
                    range.Add(p);
                }
                break;
            }
        }
    }
}
