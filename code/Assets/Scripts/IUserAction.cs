using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionMode { KINEMATIC, PHYSIC, NOTSET }

public interface IUserAction
{
    int GetScore();
    //void GameOver();
    GameState GetGameState();
    void SetGameState(GameState gs);
    void hit(Vector3 pos);
    void setMode(ActionMode m);
    ActionMode getMode();
}
