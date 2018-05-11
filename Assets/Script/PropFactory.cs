
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * charactor factory t create 9 patrol
 * when create : set position and tag
 * when restart game : reset animation of patrols
 */
public class PropFactory : MonoBehaviour {
    public GameObject PatrolPrefab;
    public GameObject CrystallPrefab;

    private Vector3[] vec = new Vector3[4];
    public List<GameObject> used;
    public List<GameObject> free;
    private void Awake()
    {
        PatrolPrefab = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/patrol")
                                                              , Vector3.zero, Quaternion.identity);
        PatrolPrefab.SetActive(false);
        int[] pos_x = { -3, 2};
        int[] pos_z = { -2, -1};
        int index = 0;
        //create different original position of patrol
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                vec[index] = new Vector3(pos_x[i], 0, pos_z[j]);
                index++;
            }
        }
    }
    public List<GameObject> GetPatrols()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject temp = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/patrol"), new Vector3(0, 9, 0),
                                                       Quaternion.identity) as GameObject;
            temp.AddComponent<PatrolData>();
            temp.GetComponent<PatrolData>().sign = i + 1;
            temp.GetComponent<PatrolData>().start_position = vec[i];
            temp.transform.position = vec[i];
            used.Add(temp);
        }
        return used;
    }
    public void StopPatrol()
    {
        for(int i = 0; i < used.Count; i++)
        {
            used[i].gameObject.GetComponent<Animator>().SetBool("run", false);
        }
    }
}
