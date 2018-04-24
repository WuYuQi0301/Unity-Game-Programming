using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour {
    int score;
	// Use this for initialization
	void Start () {
        Debug.Log("ScoreRecorder start");
        Reset();
	}
	
    public void Reset()
    {
        score = 0;        
    }

    public void Record(DiskData onHit)
    {
        Debug.Log("onHit! " + onHit.getScore());
        score += onHit.getScore();
    }

    public int getScore() { return score; }
}
