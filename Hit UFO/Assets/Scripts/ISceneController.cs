using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { START, END, ROUND_END, ROUND_START, RUNNING }

public interface ISceneController
{
    void LoadResource();
}
