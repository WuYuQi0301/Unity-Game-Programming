using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    public FirstController sceneController;
    public int score = 0;                            //分数

    // Use this for initialization
    void Start()
    {
        sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
        sceneController.scoreManager = this;
    }
    public int GetScore()
    {
        return score;
    }
    public void AddScore()
    {
        score++;
    }
}

