using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSActionManager : MonoBehaviour {
    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    //就绪： 即将被加入目录的动作实例
    private Queue<SSAction> waitingAdd = new Queue<SSAction>();
    //就绪：即将从目录中删除的动作
    private Queue<int> waitingDelete = new Queue<int>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {

        //把等待添加队列中的动作都添加到action目录中
        foreach (SSAction ac in waitingAdd)
            actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        //检查动作管理器中所有动作的状态，若标记为删除，则删除，若标记为active，则调用其Update（）
        foreach(KeyValuePair<int, SSAction> kv in actions)
        {
            SSAction ac = kv.Value;
            if (ac.destory)
                waitingDelete.Enqueue(ac.GetInstanceID());
            else if (ac.enable)
                ac.Update();
        }

        //把删除队列里所有的动作删除  (在打飞碟中应该是用不到的)
        foreach (int key in waitingDelete)
        {
            SSAction ac = actions[key];
            actions.Remove(key);
            DestroyObject(ac);
        }
        waitingDelete.Clear();
    }

    // 给action注册Gameobject和callback，并把它们加入waitingAdd，等待执行
    // manager表示完成动作后通知谁,一般是实战动作管理器
    public void RunAction(GameObject gameObject, SSAction action, ISSActionCallback manager)
    {
        action.gameObject = gameObject;
        action.transform = gameObject.transform;
        action.callback = manager;
        waitingAdd.Enqueue(action);
        action.Start();
    }
}
