using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback, IActionManager {
    // 实战的动作管理器，需要与场景控制器配合
    public RoundController sceneController;
    //一系列飞行的动作实例
    public int diskNum;

    protected void Start()
    {
        Debug.Log("Action Manager Start");
        //获得唯一导演实例中的场景控制器
        sceneController = (RoundController)Director.getInstance().currentSceneController;
        //一实例化就 赋值给 currentSceneController 中的动作管理器
        sceneController.actionManager = this;
        diskNum = sceneController.diskCount;
    }

    public void setDiskNumber(int _num)
    {
        diskNum = _num;
    }

    public int getDiskNumber()
    {
        return diskNum;
    }
    /* StartThrow (): 将就绪的飞碟和动作 
     * 和实战动作管理器作为“完成动作后的被通知者”扔进RunAction（继承自SSActionManager）
     */
    public void StartThrow(GameObject diskToThrow)
    {
        Debug.Log("Throw disk : " + diskToThrow.GetInstanceID());
        CCFlyAction temp = CCFlyAction.GetSSAction();
        RunAction(diskToThrow, temp, this);
    }

    //Update是方法覆盖，提醒编程人员该方法不会多态且要用base调用原方法
    protected new void Update()
    {
        base.Update();
    }

    /*
     * 实现ISSActionCallback接口中的 SSActionEvent：隐藏回调函数的细节
     * 如果动作是fly，说明一个飞碟已经飞出
     * 动作管理器中排队的飞碟数减少,飞碟工厂回收飞碟，动作管理器回收动作
     */
    // 通过接口函数接收已经完成动作
    // 原设计调用飞碟工厂的唯一实例回收游戏对象
    // 改进：调用roundController的回收函数，roundController再通知飞碟工厂回收
    void ISSActionCallback.SSActionEvent(SSAction source,SSActionEventType events, 
        int intParam, string strParam, Object objectParam)
    {
        if(source is CCFlyAction)
        {
            diskNum--;
            sceneController.RecycleDisk(source.gameObject);
            source.destory = true;
        }
    }

    public void Reset()
    {
        diskNum = sceneController.diskCount;
    }
}
