using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public GameScript gameScript;
    static public Transform Piece_Selected = null;
    protected int posX;
    protected int posZ;
    protected string color;
    protected bool moved = false;
    public string type = "piece";
    [HideInInspector]
    public int direction;
    public class Pair : IEquatable<Pair>
    {
        public Pair(int _x, int _z)
        {
            this.x = _x;
            this.z = _z;
        }
        public Pair()
        {
            this.x = 0;
            this.z = 0;
        }
        public int x { get; set; }
        public int z { get; set; }

        public bool Equals(Pair p)
        {
            return this.x == p.x &&
                   this.z == p.z;
        }

    }
    static public List<Pair> selectedObjects = new List<Pair>();
    public Material selectedMat;
    public Material black;
    public Material white;
    public List<Pair> range = new List<Pair>();
    [HideInInspector]
    public Piece roiSameColor;

    public int getPosZ()
    {
        return posZ;
    }
    public int getPosX()
    {
        return posX;
    }
    public void setPosX(int x)
    {
        posX = x;
    }
    public void setPosZ(int z)
    {
        posZ = z;
    }
    public void setColor(string col)
    {
        color = col;
    }
    public string getColor()
    {
        return color;
    }
    public void setMoved(bool b)
    {
        moved = b;
    }
    public string getType()
    {
        return type;
    }
    public void setType(string s)
    {
        type = s;
    }

    void Start()
    {
        posX = (int)transform.position.x;
        posZ = (int)transform.position.z;
    }

    public void setSelected(int x, int z)
    {
        Pair p = new Pair();
        gameObject.GetComponent<Renderer>().material = selectedMat;
        p.x = x;
        p.z = z;
        selectedObjects.Add(p);
    }
    public void removeSelected()
    {
        foreach (Pair p in selectedObjects)
        {
            if (gameScript.GameBoard[p.z, p.x].getColor() == "black")
                gameScript.GameBoard[p.z, p.x].GetComponent<Renderer>().material = black;
                if (gameScript.GameBoard[p.z, p.x].getColor() == "white")
                gameScript.GameBoard[p.z, p.x].GetComponent<Renderer>().material = white;
        }
        selectedObjects.Clear();
    }

    public virtual void movement() { }
    public virtual void calcuateRange(Piece[,] board) { }
    public virtual bool Check(Piece[,] GameBoard) { return false; }
    protected Piece[,] changeTestBoard(int x, int z)
    {
        Piece[,] testBoard = new Piece[8, 8];
        testBoard = gameScript.GameBoard.Clone() as Piece[,];
        testBoard[z, x] = testBoard[posZ, posX];
        testBoard[posZ, posX] = null;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((gameScript.GameBoard[i, j] != null) && (gameScript.GameBoard[i,j].getColor() != getColor()))
                {
                    gameScript.GameBoard[i, j].calcuateRange(testBoard);
                }
            }
        }
        return testBoard;
    }
    public void possibleMovement()
    {
        for(int i=range.Count-1;i>=0;i--)
        {
            if(roiSameColor.Check(changeTestBoard(range[i].x, range[i].z)))
            {
                range.RemoveAt(i);
            }
        }
    }
    public void OnMouseDown()
    {
        if ((Input.GetMouseButtonDown(0)) && (GameScript.turn == getColor()))
        {
            //print(gameScript.GameBoard[5,5]);
            removeSelected();
            setSelected((int)transform.position.x, (int)transform.position.z);
            Piece_Selected = gameObject.transform;
            gameScript.removeSelected();
            gameScript.setSelected(range);
        }
    }
}
