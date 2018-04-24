﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicActionManager : MonoBehaviour, IActionManager, ISSActionCallback
{

    /** 
 * 这个文件是管理动作的具体动作管理器，是用来管理飞碟的飞行动作 
 */

    public RoundController sceneController;
    public int DiskNumber = 0;


    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();        //保存所有已经注册的动作  
    private List<SSAction> waitingAdd = new List<SSAction>();                           //动作的等待队列，在这个对象保存的动作会稍后注册到动作管理器里  
    private List<int> waitingDelete = new List<int>();                                  //动作的删除队列，在这个对象保存的动作会稍后删除  

    protected void Start()
    {
        sceneController = (RoundController)Director.getInstance().currentSceneController;
        sceneController.actionManager = this;

    }

    // Update is called once per frame  
    protected void Update()
    {
        //把等待队列里所有的动作注册到动作管理器里  
        foreach (SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        //管理所有的动作，如果动作被标志为删除，则把它加入删除队列，被标志为激活，则调用其对应的Update函数  
        foreach (KeyValuePair<int, SSAction> kv in actions)
        {
            SSAction ac = kv.Value;
            if (ac.destory)
            {
                waitingDelete.Add(ac.GetInstanceID());
            }
            else if (ac.enable)
            {
                ac.Start();
            }
        }

        //把删除队列里所有的动作删除  
        foreach (int key in waitingDelete)
        {
            SSAction ac = actions[key];
            actions.Remove(key);
            DestroyObject(ac);
        }
        waitingDelete.Clear();
    }

    //初始化一个动作  
    public void RunAction(GameObject gameobject, CCFlyAction action, ISSActionCallback manager)
    {
        action.gameObject = gameobject;
        action.transform = gameobject.transform;
        action.callback = manager;
        waitingAdd.Add(action);
        action.Start();
    }


    public void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Competeted,
        int intParam = 0,
        string strParam = null,
        UnityEngine.Object objectParam = null)
    {
        if (source is CCFlyAction)
        {
            DiskNumber--;
            source.gameObject.SetActive(false);
        }
    }

    public void StartThrow(GameObject diskToThrow)
    {
        CCFlyAction temp = CCFlyAction.GetSSAction();
        RunAction(diskToThrow, temp, this);
    }
    public int getDiskNumber()
    {
        return DiskNumber;
    }

    public void setDiskNumber(int num)
    {
        DiskNumber = num;
    }
}
