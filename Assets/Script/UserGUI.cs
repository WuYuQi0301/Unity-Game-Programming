using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

    private IUserAction action;
    private float bottonWidth = 100;
    private float bottonHeight = 50;
    private float bottonPosX = Screen.width / 2 - 50;
    private float bottonPosY = Screen.width / 2 - 50;

    // Use this for initialization
    void Start () {
        /*
         * 通过导演类获取将当前的场景控制器
         * 并将场景控制器设置为接口的对面一方
         * 表示调用接口函数时将选择这一对象的函数作为实现
         */
        action = SSDirector.getInstance().currentSceneController as IUserAction;
        action.SetStatus(GameStatus.Ready);
    }

    // Update is called once per frame
    //实际是调用了当前场景控制器的gameover
    //但不需要知道当前场景控制器是谁
    void OnGUI () {
        if (action.GetStatus() == GameStatus.Ready)
        {
            if(GUI.Button(new Rect(bottonPosX, bottonPosY, bottonWidth, bottonHeight), "Start Game"))
            {
                action.StartGame();
            }
        }
        else if(action.GetStatus() == GameStatus.Over)
        {
            if(GUI.Button(new Rect(bottonPosX, bottonPosY, bottonWidth, bottonHeight), "Restart Start"))
            {
                action.SetStatus(GameStatus.Ready);
            }
        }
	}
    void Update()
    {
        //获取方向键的偏移量
        float translationX = Input.GetAxis("Horizontal");
        float translationZ = Input.GetAxis("Vertical");
        //移动玩家
        action.MovePlayer(translationX, translationZ);
    }
}
