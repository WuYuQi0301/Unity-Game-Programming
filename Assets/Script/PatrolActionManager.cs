using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolActionManager : SSActionManager
{
    private PatrolRoundAction round;

    public void PatrolRoundStart(GameObject patrol)
    {
        round = PatrolRoundAction.GetSSAction(patrol.transform.position);
        this.RunAction(patrol, round, this);
    }
    //停止所有动作
    public void DestroyAllAction()
    {
        DestroyAll();
    }
}
