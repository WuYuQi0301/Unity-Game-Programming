using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoundAction : SSAction {
    private enum Direction { EAST, NORTH, WEST, SOUTH  };
    private Vector3 original_loc;
    private float speed = 1.2f;
    private float length;
    private bool trigger_sign = true;
    private PatrolData thisData;
    private Direction thisDirection = Direction.NORTH;
	
    public static PatrolRoundAction GetSSAction(Vector3 loc)
    {
        PatrolRoundAction action = CreateInstance<PatrolRoundAction>();
        action.original_loc = loc;
        action.length = Random.Range(3, 6);
        return action;
    }

    public override void Start()
    {
        this.gameobject.GetComponent<Animator>().SetBool("run", true);
        thisData = this.gameobject.GetComponent<PatrolData>();
    }
    // Update is called once per frame
    public override void Update () {
		if(thisData.follow_player == true)
        {
            this.destroy = true;
            this.callback.SSActionEvent(this, 0, this.gameobject);
        }
        else
        {
            if (trigger_sign == true)
            {
                switch (thisDirection)
                {
                    case Direction.EAST:
                        original_loc.x -= length;
                        break;
                    case Direction.NORTH:
                        original_loc.z += length;
                        break;
                    case Direction.WEST:
                        original_loc.x += length;
                        break;
                    case Direction.SOUTH:
                        original_loc.z -= length;
                        break;
                }
                trigger_sign = false;
            }
            this.transform.LookAt(original_loc);
            float distance = Vector3.Distance(transform.position, original_loc);
            if (distance > 0.9)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, 
                    original_loc, speed * Time.deltaTime);
            }
            else
            {
                thisDirection++;
                if (thisDirection > Direction.SOUTH)
                {
                    thisDirection = Direction.EAST;
                }
                trigger_sign = true;
            }
        }
	}
}
