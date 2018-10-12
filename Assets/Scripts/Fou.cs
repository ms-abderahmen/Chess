using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fou : Piece
{

    public override void calcuateRange(Piece[,] board)
    {
        range.Clear();
        Pair p ;
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
