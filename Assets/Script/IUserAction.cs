using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus { Ready, Running, Over };

public interface IUserAction {
    void StartGame();
    void GameOver();
    int GetScore();
    void IncreaseScore();
    GameStatus GetStatus();
    void SetStatus(GameStatus _sta);
    void MovePlayer(float translationX, float translationZ);
}
