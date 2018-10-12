using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelect : MonoBehaviour
{
    int roiX = 0;
    int roiZ = 0;
    bool checkMate;
    bool check;
    public GameScript gameScript;
    bool selectable = false;
    Material[] maaa = new Material[2];
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if ((Piece.Piece_Selected != null) && (selectable == true))
            {
                int x = (int)Piece.Piece_Selected.position.x;
                int z = (int)Piece.Piece_Selected.position.z;
                if (gameScript.GameBoard[(int)transform.position.z, (int)transform.position.x] != null)
                {
                    Destroy(gameScript.GameBoard[(int)transform.position.z, (int)transform.position.x].gameObject);
                }
                gameScript.GameBoard[z, x].setMoved(true);
                gameScript.GameBoard[(int)transform.position.z, (int)transform.position.x] = gameScript.GameBoard[z, x];
                gameScript.GameBoard[z, x] = null;
                Piece.Piece_Selected.position = new Vector3(transform.position.x, Piece.Piece_Selected.position.y, transform.position.z);
                Piece.Piece_Selected.gameObject.GetComponent<Piece>().setPosX((int)transform.position.x);
                Piece.Piece_Selected.gameObject.GetComponent<Piece>().setPosZ((int)transform.position.z);
                selectable = false;

                //checkmate script
                
                checkMate = true;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (gameScript.GameBoard[i, j] != null)
                        {
                            gameScript.GameBoard[i, j].calcuateRange(gameScript.GameBoard);
                            gameScript.GameBoard[i, j].possibleMovement();
                            if ((gameScript.GameBoard[i, j].range.Count != 0) && (gameScript.GameBoard[i, j].getColor() != GameScript.turn))
                            {
                                checkMate = false;
                            }
                        }
                    }
                }
                if (checkMate == true)
                {
                    print(GameScript.turn + " wins");
                }
                //changement couleur check
                if (((roiX % 2 == 0) && (roiZ % 2 == 0)) || ((roiX % 2 == 1) && (roiZ % 2 == 1)))
                {
                    maaa[0] = gameScript.white;
                    maaa[1] = gameScript.white;
                }
                else
                {
                    maaa[0] = gameScript.black;
                    maaa[1] = gameScript.black;
                }
                gameScript.Tiles[roiZ, roiX].GetComponent<Renderer>().materials = maaa;

                check = false;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((gameScript.GameBoard[i, j] != null) && (gameScript.GameBoard[i, j].getColor() != GameScript.turn))
                        {
                            roiX = gameScript.GameBoard[i, j].roiSameColor.getPosX();
                            roiZ = gameScript.GameBoard[i, j].roiSameColor.getPosZ();
                            if (gameScript.GameBoard[i, j].roiSameColor.Check(gameScript.GameBoard))
                            {
                                maaa[0] = gameScript.Tiles[roiZ, roiX].GetComponent<Renderer>().materials[0];
                                maaa[1] = gameScript.checkMat;
                                gameScript.Tiles[roiZ, roiX].GetComponent<Renderer>().materials = maaa;
                                check = true;
                                break;
                            }
                        }
                    }
                    if (check == true)
                        break;
                }
                //changement de tour
                if (GameScript.turn == "white")
                {
                    GameScript.turn = "black";
                    enableDisableCollider("black");
                }
                else
                {
                    GameScript.turn = "white";
                    enableDisableCollider("white");
                }
                gameScript.turnText.text = GameScript.turn;
                //
            }
            if (Piece.Piece_Selected != null)
            {
                if (Piece.Piece_Selected.gameObject.GetComponent<Piece>().getColor() == "black")
                    Piece.Piece_Selected.gameObject.GetComponent<Piece>().GetComponent<Renderer>().material = Piece.Piece_Selected.gameObject.GetComponent<Piece>().black;
                if (Piece.Piece_Selected.gameObject.GetComponent<Piece>().getColor() == "white")
                    Piece.Piece_Selected.gameObject.GetComponent<Piece>().GetComponent<Renderer>().material = Piece.Piece_Selected.gameObject.GetComponent<Piece>().white;
            }
            Piece.selectedObjects.Clear();
            Piece.Piece_Selected = null;
            gameScript.removeSelected();
        }
    }

    void enableDisableCollider(string enable)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (gameScript.GameBoard[i, j] != null)
                {
                    if (gameScript.GameBoard[i, j].getColor() == enable)
                        gameScript.GameBoard[i, j].GetComponent<BoxCollider>().enabled = true;
                    else gameScript.GameBoard[i, j].GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }

    public void setSelectable(bool i)
    {
        selectable = i;
    }
}
