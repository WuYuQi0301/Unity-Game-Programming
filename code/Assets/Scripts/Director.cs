using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Director : System.Object{
    //singleton instance
    private static Director _instance;
    //process a scene controller as a member
    public ISceneController currentSceneController { get; set; }

    public static Director getInstance()
    {
        if(_instance == null)
        {
            _instance = new Director();
        }
        return _instance;
    }
}
