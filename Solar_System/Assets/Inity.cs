using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inity : MonoBehaviour {
    public Transform sun;
    public Transform moon;
    public Transform earth;
    public Transform shadow;

    public Transform MuXing;
    public Transform ShuiXing;
    public Transform JingXing;
    public Transform HuoXing;
    public Transform TuXing;
    public Transform TianWangXing;
    public Transform HaiWangXing;

    public Vector3 MuXingAxis;
    public Vector3 ShuiXingAxis;
    public Vector3 HuoXingAxis;
    public Vector3 TianWangAxis;
    public Vector3 JinAxis;
    public Vector3 TuAxis;
    public Vector3 HaiWangXingAxis;

    // Use this for initialization
    void Start () {
        this.transform.position = new Vector3(0, 0, -25);

        sun.localScale += new Vector3(2f, 2f, 2f);
        earth.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        moon.localScale += new Vector3(0.2f, 0.2f, 0.2f);

        sun.position = Vector3.zero;
        earth.position = new Vector3(6, 0, 0);
        moon.position = new Vector3(8, 0, 0);
        MuXing.position = new Vector3(Random.Range(3, 15), 0, Random.Range(1, 20));
        ShuiXing.position = new Vector3(Random.Range(-3, -15), 0, 0);
        HuoXing.position = new Vector3(Random.Range(-3, -15), 0, Random.Range(-1, -20));
        TuXing.position = new Vector3(Random.Range(3, 15), 0, 0);
        TianWangXing.position = new Vector3(Random.Range(3, 15), 0, Random.Range(1, 20));
        JingXing.position = new Vector3(Random.Range(-3, -15), 0, 0);
        HaiWangXing.position = new Vector3(Random.Range(3, 15), 0, 0);

        shadow.position = earth.position;


        MuXingAxis = Vector3.up + new Vector3((float)0.125, 0, 0);
        ShuiXingAxis = Vector3.up + new Vector3((float)0.2, 0, (float)0.05);
        HuoXingAxis = Vector3.up + new Vector3((float)-0.03, 0, (float)0.273);
        TianWangAxis = Vector3.up + new Vector3((float)-0.05, 0, (float)-0.2);
        JinAxis = Vector3.up + new Vector3((float)-0.13, 0, 0);
        TuAxis = Vector3.up + new Vector3((float)0.15, 0, (float)-0.1);
        HaiWangXingAxis = Vector3.up + new Vector3((float)0.2, 0, (float)0.2);
    }
    
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Vector3.up);
        earth.RotateAround(sun.position, Vector3.up, 10 * Time.deltaTime);
        earth.Rotate(Vector3.up * 30 * Time.deltaTime);

        shadow.RotateAround(sun.position, Vector3.up, 10 * Time.deltaTime);
        moon.RotateAround(shadow.position, Vector3.up, 359 * Time.deltaTime);

        MuXing.RotateAround(sun.position, MuXingAxis, 44 * Time.deltaTime);
        MuXing.Rotate(MuXingAxis * 102 * Time.deltaTime);

        JingXing.RotateAround(sun.position, JinAxis, 20 * Time.deltaTime);
        JingXing.Rotate(JinAxis * 250 * Time.deltaTime);

        HuoXing.RotateAround(sun.position, HuoXingAxis, 34 * Time.deltaTime);
        HuoXing.Rotate(HuoXingAxis * 34 * Time.deltaTime);

        ShuiXing.RotateAround(sun.position, ShuiXingAxis, 100 * Time.deltaTime);
        ShuiXing.Rotate(ShuiXingAxis * 30 * Time.deltaTime);
        
        TuXing.RotateAround(sun.position, TuAxis,35 * Time.deltaTime);
        TuXing.Rotate(TuAxis * 14 * Time.deltaTime);

        TianWangXing.RotateAround(sun.position, TianWangAxis, 70 * Time.deltaTime);
        TianWangXing.Rotate(TianWangAxis * 3 * Time.deltaTime);

        HaiWangXing.RotateAround(sun.position, HaiWangXingAxis, 5 * Time.deltaTime);
        HaiWangXing.Rotate(HaiWangXingAxis * 200 * Time.deltaTime);
    }

}


