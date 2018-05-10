using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolData : MonoBehaviour {

    public int sign;              //巡逻兵区域
    public bool follow_player;    //是否跟随玩家
    public int wall_sign = -1;    //当前玩家所在区域
    public GameObject player;     //玩家游戏对象
    public Vector3 start_position;//当前巡逻兵初始位置
}
