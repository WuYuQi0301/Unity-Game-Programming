using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessScen : MonoBehaviour {
    //define some varibles
    private int curPlayer = 1;
    private int[,] chessboard = new int[3, 3];
    private int gameOn = 1;

    private int marginX = 300;
    private int marginY = 100;
    private float hight = 70;
    private float width = 70;

	// Use this for initialization
	void Start () {
        Reset();
	}

    private void OnGUI()
    {
        //if reset button is pressed
        if(GUI.Button(new Rect(marginX, marginY + 3 * hight + 50, width, hight), "RESET"))
            Reset();

        //check status of game eveytime OnGUI() called
        int status = Judge();
        ShowStatus(status);

        //create chessboard eveytime OnGUI() called
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0;j < 3; j++)
            {
                if (chessboard[i, j] == -1)
                    GUI.Button(new Rect(marginX + i * width, marginY + j * hight, width, hight), "O");
                else if (chessboard[i, j] == 1)
                    GUI.Button(new Rect(marginX + i * width, marginY + j * hight, width, hight), "X");
                if(GUI.Button(new Rect(marginX + i * width, marginY + j * hight, width, hight), ""))
                {
                    Debug.Log("Click on Button");
                    if (gameOn == 1)
                    {
                        Debug.Log(curPlayer);
                        chessboard[i, j] = curPlayer;
                        curPlayer = -curPlayer;

                    }
                }
            }
        }
    }

    private void Reset()
    {
        Debug.Log("Reset");
        curPlayer = 1;
        gameOn = 1;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                chessboard[i, j] = 0;
    }
    private int Judge()
    {
        for(int i = 0; i < 3; i++)
        {
            if (chessboard[i, 0] != 0
                && chessboard[i, 0] == chessboard[i, 1]
                && chessboard[i, 1] == chessboard[i, 2])
            {
                gameOn = 0;
                return chessboard[i, 0];
            }
        }
        for(int i = 0; i < 3; i++)
        {
            if (chessboard[0, i] != 0
                && chessboard[0, i] == chessboard[1, i]
                && chessboard[1, i] == chessboard[2, i])
            {
                gameOn = 0;
                return chessboard[0, i];
            }
        }
        if ((chessboard[0, 0] != 0 && chessboard[0, 0] == chessboard[2, 2] && chessboard[2, 2] == chessboard[1, 1])
            || (chessboard[0, 2] != 0 && chessboard[1, 1] == chessboard[0, 2] && chessboard[0, 2] == chessboard[2, 0]))
        {
            gameOn = 0;
            return chessboard[1, 1];
        }
            return 0;
    }
    private void ShowStatus(int status)
    {
        if (status == -1)
        {
            GUI.Label(new Rect(marginX + 75, marginY - 50, 100, 50), "O wins!");
        }
        else if (status == 1)
        {
            GUI.Label(new Rect(marginX + 75, marginY - 50, 100, 50), "X wins!");
        }
        if (gameOn == 1 && status == 0)
        {
            GUI.Label(new Rect(marginX + 75, marginY - 50, 100, 50), "Hello Game");
        }
    }
}
