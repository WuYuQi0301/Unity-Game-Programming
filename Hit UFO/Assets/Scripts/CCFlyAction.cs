using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction : SSAction {

    public Vector3 direction;   //初始飞行方向
    float acceleration;
    float horizantalSpeed;      //水平方向速度
    float time;                 //总飞行时间


    public static CCFlyAction GetSSAction()
    {
        CCFlyAction action = ScriptableObject.CreateInstance<CCFlyAction>();
        return action;
    }
    public static CCFlyAction GetSSAction(Vector3 _target, float _speed)
    {
        CCFlyAction action = ScriptableObject.CreateInstance<CCFlyAction>();
        action.direction = _target;
        action.horizantalSpeed = _speed;
        return action;
    }

	public override void Start () {
        enable = true;
        acceleration = 9.8f;
        time = 0;
        horizantalSpeed = gameObject.GetComponent<DiskData>().getSpeed();
        direction = gameObject.GetComponent<DiskData>().getDirection();
            Debug.Log("Action Start");
    }

    public override void Update () {
        if (gameObject.activeSelf)//若游戏对象是active的
        {
            time += Time.deltaTime;//得到飞行时间
            transform.Translate(Vector3.down * acceleration * time * Time.deltaTime);//垂直速度 = v * a * t * detltaT
            transform.Translate(direction * horizantalSpeed * Time.deltaTime);//水平速度 = 起始方向 * 水平速度 *delteT
            Debug.Log(transform.position);
            if(this.transform.position.y < -7)
            {
                this.gameObject.SetActive(false);
                this.destory = true;
                this.enable = false;
                this.callback.SSActionEvent(this); 
                //继承自基类的callback，表示动作完成，通过接口把完成了的动作送回动作管理器
            }
        }
	}
}
