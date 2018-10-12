using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
	public Text turnText;
	static public string turn = "white";
    public class Pair
    {
        public int x;
        public int z;
    }
    public GameObject[,] Tiles = new GameObject[8, 8];
    public Piece[,] GameBoard = new Piece[8, 8];
    public Material mat;
    public Material black;
    public Material white;
	public Material checkMat;
	Material[] maaa = new Material[2];
    List<Pair> selectedObjects = new List<Pair>();

    void Start()
    {
		turnText.text = turn;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                string s = "Tile " + i.ToString() + j.ToString();
                Tiles[i, j] = GameObject.Find(s);
            }
        }

		for(int i=0;i<2;i++)
		{
			for (int j=0;j<8;j++)
			{
				string s = "White "+(i*8 + j).ToString();
				GameBoard[i,j] = GameObject.Find(s).GetComponent<Piece>();
				GameBoard[i,j].setColor("white");
				GameBoard[i,j].direction = 1;
			}
		}
		for(int i=6;i<8;i++)
		{
			for (int j=0;j<8;j++)
			{
				string s = "Black "+((i-6)*8 + j).ToString();
				GameBoard[i,j] = GameObject.Find(s).GetComponent<Piece>();
				GameBoard[i,j].setColor("black");
				GameBoard[i,j].direction = -1;
			}
		}
		for(int i=2;i<6;i++)
		{
			for (int j=0;j<8;j++)
			{
				GameBoard[i,j] = null;
			}
		}

		for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
				if (GameBoard[i,j] != null)
				{
					if(GameBoard[i,j].getColor() == "white")
						GameBoard[i,j].roiSameColor = GameObject.Find("White 4").GetComponent<Piece>();
					if(GameBoard[i,j].getColor() == "black")
						GameBoard[i,j].roiSameColor = GameObject.Find("Black 12").GetComponent<Piece>();
                	GameBoard[i,j].calcuateRange(GameBoard);
				}
            }
        }
    }

    public void setSelected(List<Piece.Pair> l)
    {
		Pair p = new Pair();
		foreach (Piece.Pair pai in l){
			maaa[0] = Tiles[pai.z, pai.x].GetComponent<Renderer>().materials[0];
			maaa[1] = mat;
        	Tiles[pai.z, pai.x].GetComponent<CubeSelect>().setSelectable(true);
        	Tiles[pai.z, pai.x].GetComponent<Renderer>().materials = maaa;
			p = new Pair();
			p.x = pai.x;
			p.z = pai.z;
			selectedObjects.Add(p);
		}
    }

	public void removeSelected()
	{
		foreach (Pair p in selectedObjects)
		{
			if(((p.x%2 == 0)&&(p.z%2 == 0)) || ((p.x%2 == 1)&&(p.z%2==1))){
				maaa[0] = white;
				maaa[1] = white;
				Tiles[p.z,p.x].GetComponent<Renderer>().materials = maaa;
			} else {
				maaa[0] = black;
				maaa[1] = black;
				Tiles[p.z,p.x].GetComponent<Renderer>().materials = maaa;
			}
			Tiles[p.z,p.x].GetComponent<CubeSelect>().setSelectable(false);
		}
		selectedObjects.Clear();
	}

}
