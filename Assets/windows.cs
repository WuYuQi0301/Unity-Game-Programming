using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windows : MonoBehaviour {
    Vector2 range = new Vector2(5f, 3f);

    Transform m_trasform;
    Quaternion m_quaternion;
    Vector2 rot = Vector2.zero;
	// Use this for initialization
	void Start () {
        m_trasform = this.gameObject.transform;
        m_quaternion = m_trasform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Input.mousePosition;
        float screenWidth = Screen.width * 0.5f;
        float screenHeight = Screen.height * 0.5f;
        float x = Mathf.Clamp((pos.x - screenWidth) / screenWidth, -1f, 1f);
        float y = Mathf.Clamp((pos.y - screenHeight)/screenHeight, -1f, 1f);
        rot = Vector2.Lerp(rot, new Vector2(x, y), Time.deltaTime * 5f);
        m_trasform.localRotation = m_quaternion * Quaternion.Euler(-rot.y * range.y, rot.x * range.x, 0);
	}
}
