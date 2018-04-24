using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动作基类
public class SSAction : ScriptableObject {

    public bool enable = true;
    public bool destory = false;

    public GameObject gameObject { get; set; }
    public Transform transform { get; set; }
    public ISSActionCallback callback{get; set;}

    //protected instructor
    protected SSAction() { }
    
    // 虚Start函数：子类必须实现Start()
	public virtual void Start () {
        throw new System.NotImplementedException();
	}
    
	public virtual void Update () {
        throw new System.NotImplementedException();
	}

    public void Reset()
    {
        gameObject = null;
        transform = null;
        callback = null;
        enable = false;
        destory = false;
    }
}
