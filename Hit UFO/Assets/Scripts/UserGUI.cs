using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {
    private IUserAction action;

    GUIStyle fontStyle = new GUIStyle();
    
    /* used keyword "as" to  convert type ISceneController to IUserAction
    * which are both absract classes
    * aim at convey "this" to UserGUI
    */
    void Start () {
        Debug.Log("UserGUI Start");
        action = Director.getInstance().currentSceneController as IUserAction;

        fontStyle.normal.background = null;    //设置背景填充  
        fontStyle.normal.textColor = new Color(1, 0, 0);   //设置字体颜色  
        fontStyle.fontSize = 40;       //字体大小  
    }

    // Update is called once per frame
    private void OnGUI()
    {
        if (action.getMode() == ActionMode.NOTSET)
        {
            if (GUI.Button(new Rect(500, 100, 90, 90), "KINEMATIC"))
            {
                action.setMode(ActionMode.KINEMATIC);
            }
            if (GUI.Button(new Rect(400, 100, 90, 90), "PHYSIC"))
            {
                action.setMode(ActionMode.PHYSIC);
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1")) //检测鼠标左键点击
                action.hit(Input.mousePosition); //回传鼠标位置给controller进行后续判断

            int score = action.GetScore();       //通过接口获得当前得分
            GUI.Label(new Rect(100, 0, 400, 400), score.ToString(), fontStyle); //显示得分

            if (action.GetGameState() == GameState.START && GUI.Button(new Rect(300, 200, 200, 100), "Start"))
            {
                Debug.Log("Game Start");
                action.SetGameState(GameState.ROUND_START);//按下Start按钮，游戏开始
            }
            if (action.GetGameState() == GameState.ROUND_END && GUI.Button(new Rect(300, 200, 200, 100), "NextRound"))
                action.SetGameState(GameState.ROUND_START);//按下next round 按钮，下一回合开始

            if (action.GetGameState() == GameState.END && GUI.Button(new Rect(300, 200, 200, 100), "Restart"))
                action.SetGameState(GameState.START); // 所有回合结束，重新开始游戏
        }
    }

}
