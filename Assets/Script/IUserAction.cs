using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus { Ready, Running, Over };

public interface IUserAction {
    void StartGame();
    void GameOver();
    int GetScore();
    GameStatus GetStatus();
    void SetStatus(GameStatus _sta);
    void MovePlayer(float translationX, float translationZ);
}
