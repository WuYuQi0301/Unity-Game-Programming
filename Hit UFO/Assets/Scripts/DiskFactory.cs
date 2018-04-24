using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour {
    public GameObject diskPrafab;
    //原本想用Queue，后来发现在查询某个disk data是否存在且移除的时候十分不方便
    List<GameObject> used = new List<GameObject>();
    List<GameObject> free = new List<GameObject>();
    //DiskData diskData_round1 = new DiskData();
    //DiskData diskData_round2 = new DiskData();
    //DiskData diskData_round3 = new DiskData();

    //事先将所有生成的预置实例设为非活跃
    private void Awake()
    {
        diskPrafab = (GameObject)Instantiate(Resources.Load("Prefab/disk"), new Vector3(0, 0, 0), Quaternion.identity);
        diskPrafab.SetActive(false);
    }
    //获得disk：如果free为空则新生成，否则使用free中的disk
    public GameObject getDisk(int ruler)
    {
        GameObject a_disk;
        if (free.Count != 0)
        {
            a_disk = free[0];
            free.Remove(free[0]);
        }
        else
        {
            a_disk = (GameObject)Instantiate(Resources.Load("Prefab/disk"), new Vector3(0, 0, 0), Quaternion.identity);
            a_disk.AddComponent<DiskData>();
            used.Add(a_disk);
        }

        //根据现在的回合数来设置不同的disk属性：目的地，颜色，速度，大小
        switch (ruler)
        {
            case 1:
                a_disk.GetComponent<DiskData>().setData(new Vector3(0, 3,-10), new Vector3(3, (float)0.5, 3), Color.blue, (float)1, 1);
                break;
            case 2:
                a_disk.GetComponent<DiskData>().setData(new Vector3(0, 3, -10), new Vector3((float)2, (float)0.3, (float)2), Color.red, (float)1.5, 2);
                break;
            case 3:
                a_disk.GetComponent<DiskData>().setData(new Vector3(0, 3, -10), new Vector3(1, (float)0.3, 1), Color.yellow, (float)1.5, 3);
                break;
            default:
                break;
        }
        float ranX = UnityEngine.Random.Range(-8, 8);
        a_disk.GetComponent<DiskData>().setDirection(new Vector3(ranX, 1, 15));
        a_disk.SetActive(false);
        used.Add(a_disk);
        Debug.Log("in DiskFactoy + diraciton x" + ranX);
        return a_disk;
    }


    //回收使用过的disk
    public void freeDisk(GameObject disk)
    {
        try
        {
            //先去确认disk的data在used中有相同的
            bool flag = false;
            for(int i = 0; i < used.Count; i++)
            {
                if(used[i].GetComponent<DiskData>().isEqual(disk.GetComponent<DiskData>()))
                {
                    used[i].SetActive(false);
                    //如果有，则从used中移除，加入free
                    free.Add(used[i]);
                    used.Remove(used[i]);
                    flag = true;
                    break;
                }
            }
            //如果没有，则抛出异常
            if (!flag)
            {
                throw new Exception("disk has not been used");
            }
        }
        catch(Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
    // Use this for initialization

    void Start()
    {
    }	
	// Update is called once per frame
	void Update () {
		
	}
}
