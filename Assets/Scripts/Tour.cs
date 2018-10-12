using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour : Piece
{

    public override void calcuateRange(Piece[,] board)
    {
        range.Clear();
        Pair p;
        for (int x = posX + 1; x < 8; x++)
        {
            if ((board[posZ, x] == null))
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
                if ((board[posZ, x] != null) && (board[posZ, x].getColor() != getColor()))
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
                if ((board[z, posX] != null) && (board[z, posX].getColor() != getColor()))
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
            //print(roiSameColor.Check(changeTestBoard(posX,z)));
            if (board[z, posX] == null)
            {//gameScript.setSelected(posX, z);
                p = new Pair();
                p.x = posX;
                p.z = z;
                range.Add(p);
            }
            else
            {
                if ((board[z, posX] != null) && (board[z, posX].getColor() != getColor()))
                {//gameScript.setSelected(posX, z);
                    p = new Pair();
                    p.x = posX;
                    p.z = z;
                    range.Add(p);
                }
                break;
            }

        }
    }
}
